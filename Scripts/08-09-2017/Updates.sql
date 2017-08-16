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