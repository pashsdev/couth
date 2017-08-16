Create Table cri_serial_numbers 
(
Inventory_Item_Id BIGINT IDENTITY(1,1) PRIMARY KEY,
Item_Name Varchar(40),
Item_Desc Varchar(240)
)

Go

Create Table cri_catalog_values (
Serial_Number Varchar(30),
Jobnumber varchar(30),
Item_Code Varchar(40),
[Description] Varchar(240),
Printed Bit
)

Go


Create Table Reprint (
RequestID BIGINT IDENTITY(1,1) PRIMARY KEY,
RequestNo Varchar(100),
RequestDate Datetime,
RequestUserID BigInt,
Serial_Number Varchar(30),
Jobnumber varchar(30),
Item_Code Varchar(40),
[Description] Varchar(240),
Approved Bit,
ApprovedBy BIGINT,
ApprovedDate DateTime
)

Go

Create Proc PG_List_ReprintRequest
(
@Approved Bit
)
AS
Select * From cri_serial_numbers sn WITH (NOLOCK) 
Inner Join cri_catalog_values c on sn.Item_Name = c.Item_Code
Where Printed = 1

go

Create Proc PG_Save_ReprintRequest
(
@RequestNo Varchar(100),
@RequestUserID BigInt,
@Serial_Number Varchar(30),
@Jobnumber varchar(30),
@Item_Code Varchar(40),
@Description Varchar(240)
)
as

Insert Into Reprint (RequestNo, RequestDate,RequestUserID,Serial_Number,Jobnumber,Item_Code,[Description]) values (@RequestNo,GETDATE(),@RequestUserID,@Serial_Number,@Jobnumber,@Item_Code,@Description)

go

Create Proc PG_Save_ReprintApprove
(
@RequestID BIGINT,
@Approved Bit,
@ApprovedBy BIGINT
)
AS
Update Reprint Set Approved = @Approved, ApprovedBy = @ApprovedBy, ApprovedDate = GETDATE() Where RequestID = @RequestID

Go

Create Proc PG_Save_SerialJobNumber
(
@Inventory_Item_Id BIGINT,
@Item_Name Varchar(40),
@Item_Desc Varchar(240),
@Serial_Number Varchar(30),
@JobNumber Varchar(30),
@Item_Code Varchar(40),
@Description Varchar(240),
@Printed Bit
)
as

If Not Exists(Select * From cri_serial_numbers WITH (NOLOCK) Where Inventory_Item_Id =@Inventory_Item_Id)
Begin
	Insert Into cri_serial_numbers (Item_Name,Item_Desc) Values (@Item_Name,@Item_Desc)
End

If Not Exists (Select * From cri_catalog_values WITH (NOLOCK) Where Serial_Number = @Serial_Number)
Begin
	Insert Into cri_catalog_values (Serial_Number,Jobnumber,Item_Code,[Description],Printed) Values (@Serial_Number,@JobNumber,@Item_Code,@Description,@Printed)
End
Else
Begin
	Update cri_catalog_values Set Printed = @Printed Where Serial_Number = @Serial_Number
End

go
-- 4.2.2017
Alter Table cri_serial_numbers Add Serial_Number varchar(30)
go
Alter Table cri_catalog_values Add CatalogValueID BIGINT Identity(1,1) Primary key Not null
go

CREATE Proc PG_List_Printed
AS
Select * From cri_serial_numbers sn WITH (NOLOCK) 
Inner Join cri_catalog_values c on sn.Serial_Number = c.Serial_Number
Where Printed = 1

go

Alter Proc PG_List_PendingReprintRequest
(
@Approved Bit = 0
)
as
Select Rp.*,u.UserName as RequestUser From Reprint Rp WITH (NOLOCK)
Inner Join Users u WITH (NOLOCK) on Rp.RequestUserID = u.UserID 
Where COALESCE(Approved,0) = @Approved