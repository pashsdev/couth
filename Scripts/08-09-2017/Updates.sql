Alter Table Units Add OracleUnitID BIGINT
GO
Alter Table Units Add Constraint UQ_Units_Unit Unique (Unit)
GO
Alter Table Units Add Active BIT NOT NULL Constraint DF_Units_Active Default 1
GO
Alter Proc PG_Unit_Save
(
@UnitID BigInt,
@UnitName Varchar(200),
@Mode Varchar(1),
@OracleUnitID BIGINT,
@Active BIT
)
as
If (@Mode = 'I')
Begin
	Insert Into Units(Unit,OracleUnitID,Active) Values
	(@UnitName,@OracleUnitID,@Active)
End
if (@Mode = 'U')
Begin
	Update Units Set Unit = @UnitName, OracleUnitID = @OracleUnitID, [Active] = @Active Where UnitID = @UnitID
End

GO

Alter Proc PG_Unit_Listing
(
	@UnitID BigInt = NULL
)
as
Select * From Units u WITH (NOLOCK) 
Where u.UnitID = COAlESCE(@UnitID,u.UnitID)

Select * From Designation dg WITH (NOLOCK)
Left Join 
	(
		Select ur.Available,ur.DesignationID,ur.UnitId,ur.UnitRightsID,ur.UserId,u.UserName
		From UnitRights ur WITH (NOLOCK)
		Inner Join Users u WITH (NOLOCK) on ur.UserId = u.UserID
		Where ur.UnitId = @UnitID
	) urgt on urgt.DesignationID = dg.DesignationID
Order by dg.DesignationID

--Select * from UnitRights ur WITH (NOLOCK) 
--Inner Join Designation dg WITH (NOLOCK) on ur.designationID = dg.DesignationID 
--Inner Join Users u WITH (NOLOCK) on ur.UserId = u.UserID 
--Where UnitId = COALESCE(@UnitID,UnitID)

Select * from Designation WITH (NOLOCK)

Select * From Users WITH (NOLOCK) 
Where COALESCE(FromDate,GETDATE()) >= GETDATE() And COALESCE(ToDate,GETDATE()) <= GETDATE()

Go

Alter Proc PG_UnitRights_Save
(
@UnitRightsID BigInt,
@UnitID BigInt,
@UserID BigInt = null,
@DesignationID BigInt,
@IsAvailable Bit
)
as
if (@UnitID =0)
Begin
	set @UnitID = Ident_Current('Units')
End

If (@UnitRightsID > 0)
Begin
	Update UnitRights Set UserId = @UserID, DesignationID = @DesignationID, Available = @IsAvailable Where UnitRightsID = @UnitRightsID
End	
Else
Begin
	Insert Into UnitRights (UnitId,UserId,DesignationID,Available) Values (@UnitID, @UserID,@DesignationID,@IsAvailable)
End

go

Create Table Reprint
(
	ReprintID BIGINT IDENTITY(1,1) CONSTRAINT PK_Reprint Primary Key,
	ReprintNo Varchar(50) NOT NULL,
	ReprintDate Datetime NOT NULL,
	RequestUserID BIGINT NOT NULL,
	UnitID BIGINT NOT NULL,
	Approved BIT NOT NULL Constraint DF_Reprint_Approved Default 0,
	ApprovedBy BIGINT,
	ApprovedDate Datetime
)

go

Create Table ReprintDetails
(
	ReprintDetailsID BIGINT IDENTITY(1,1) CONSTRAINT PK_ReprintDetails PRIMARY KEY,
	ReprintID BIGINT NOT NULL Constraint FK_ReprintDetails_ReprintID References Reprint,
	Serial_Number Varchar(30),
	JobNumber Varchar(30),
	Item_Code Varchar(40),
	[Description] Varchar(240)
)

go

Create PROC PG_GET_ReprintNumber
as
DECLARE @ReprintNo Varchar(50)
Select @ReprintNo  = CONVERT(BIGINT, SUBSTRING(ReprintNo,6,5)) + 1 From Reprint
IF (@ReprintNo IS NULL)
BEGIN
	Select 'REPRQ00001-17/18' as ReprintNo
END
ELSE
BEGIN
	Select 'REPRQ' + REPLICATE('0',5- LEN(@ReprintNo) ) +@ReprintNo+ '-17/18' as ReprintNo
END

GO

Alter Table cri_catalog_values Add org_id BIGINT

GO
Alter Table cri_serial_numbers Add organization_id BIGINT

GO


Alter Proc PG_List_ReprintRequest
(
  @JOBNO VARCHAR(max),
  @p_from_serial VARCHAR(max),
  @p_to_serial VARCHAR(MAX),
  @p_org_id BIGINT
  @Approved BIT,
) AS
BEGIN
 
select *
from cri_catalog_values ccv, cri_serial_numbers csn
where csn.serial_number=ccv.serial_number
  and ccv.org_id=csn.organization_id
  and ccv.org_id=@p_org_id
  and
  And ccv.jobnumber = coalesce(@JOBNO,ccv.jobnumber)
  and ccv.serial_number between COalesce( @p_from_serial,ccv.serial_number) and COALESCE( @p_to_serial,ccv.serial_number)
 
END

GO

Alter Proc PG_Save_ReprintRequest
(
@RequestNo Varchar(100),
@RequestUserID BigInt,
@UnitID BIGINT
)
as

Insert Into Reprint (ReprintNo,ReprintDate,RequestUserID,UnitID) values (@RequestNo,GETDATE(),@RequestUserID,@UnitID)

GO

Create Proc PG_Save_ReprintRequestDetails
(
@RequestNo Varchar(100),
@Serial_Number Varchar(30),
@Jobnumber varchar(30),
@Item_Code Varchar(40),
@Description Varchar(240)
)
as
Declare @ReprintID BIGINT
Select @ReprintID = ReprintID From Reprint WITH (NOLOCK) Where ReprintNo = @RequestNo
Insert Into ReprintDetails( ReprintID,Serial_Number,JobNumber,Item_Code,[Description]) values (@ReprintID ,@Serial_Number,@Jobnumber,@Item_Code,@Description)

Go

Create Proc PG_Get_ReprintMasters
(
	@UnitId Bigint = NULL,
	@Jobno Varchar(30) = NULL,
	@SerialNoFrom Varchar(30) = NULL,
	@SerialNoTo Varchar(30) = NULL,
	@reprintID BIGINT = NULL,
	@FromDt DateTime = NULL,
	@ToDt DateTime = NULL
)
as
  
  Select r.ReprintID,r.ReprintNo,r.ReprintDate,r.RequestUserID,r.Approved,r.ApprovedBy,r.ApprovedDate,r.UnitID,u.UserName,app.UserName as ApprovedByUser 
  From Reprint r WITH (NOLOCK)
  Inner Join ReprintDetails rd WITH (NOLOCK) on r.ReprintID = rd.ReprintID
  Inner Join Users u on r.RequestUserID = u.UserID 
  Left Join Users app on r.ApprovedBy = u.UserID 
  Where 1=1
  and r.UnitID = COALESCE(@UnitId ,r.UnitID)
  and rd.JobNumber = COALESCE(@Jobno , rd.JobNumber)
  and rd.Serial_Number between COalesce(@SerialNoFrom,rd.Serial_Number) and COALESCE( @SerialNoTo,rd.Serial_Number)
  and r.ReprintID = COALESCE(@reprintID,r.ReprintID)
  and r.ReprintDate between COalesce(@FromDt,r.ReprintDate) and COALESCE( @ToDt,r.ReprintDate)
  
