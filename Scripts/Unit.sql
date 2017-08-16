IF Exists(Select * From sys.objects Where name = 'PG_User_Listing' And type='p')
Drop Proc PG_User_Listing
go
Create Proc PG_User_Listing
(
	@UserID BigInt = NULL
)
as
--Select UserID, UserName, [Password], Email, IsApprover, IsAdmin,CONVERT(varchar(20),FromDate,103) AS FromDate,
--Convert(varchar(20),ToDate,103) as Todate From Users WITH (NOLOCK) Where UserID = COAlESCE(@UserID,UserID)

Select UserID, UserName, [Password], Email, IsApprover, IsAdmin, FromDate,Todate 
From Users WITH (NOLOCK) Where UserID = COAlESCE(@UserID,UserID)

Select * From Units un WITH (NOLOCK)
Left Join (Select uu.UserUnitID,uu.UserID,uu.UnitID,uu.FullRights,uu.ViewRights From UserUnits uu WITH (NOLOCK) 
Inner Join Users u on uu.userID = u.UserID
Where uu.UserID = @UserID) unr ON un.UnitID = unr.UnitID

Go
IF Exists(Select * From sys.objects Where name = 'PG_User_Save' And type='p')
Drop Proc PG_User_Save
go
Create Proc PG_User_Save
(
@UserID BigInt,
@UserName Varchar(200),
@Password varchar(200),
@Email varchar(100),
@IsApprover Bit,
@IsAdmin Bit,
@FromDate Datetime = null,
@ToDate Datetime = null,
@Mode Varchar(1)
)
as
If (@Mode = 'I')
Begin
	Insert Into Users (UserName ,[Password],Email,IsApprover,IsAdmin,FromDate,ToDate) Values
	(@UserName,@Password,@Email,@IsApprover,@IsAdmin,@FromDate,@ToDate)
End
if (@Mode = 'U')
Begin
	Update Users Set UserName = @UserName, [Password] = @Password, Email = @Email, IsApprover=@IsApprover,IsAdmin = @IsAdmin,
	FromDate = @FromDate , ToDate = @ToDate Where UserID = @UserID 
End

Go
IF Exists(Select * From sys.objects Where name = 'PG_UserUnit_Save' And type='p')
Drop Proc PG_UserUnit_Save
go
Create Proc PG_UserUnit_Save
(
@UserUnitID BIGINT,
@UserID BIGINT,
@UnitID BIGINT,
@FullRights BIT ,
@ViewRights BIT 
)
as
If (@UserUnitID > 0)
Begin
	Update UserUnits Set FullRights = @FullRights, ViewRights = @ViewRights Where UserUnitID = @UserUnitID
End 
Else
Begin
	Insert Into UserUnits (UserID,UnitID,FullRights,ViewRights) Values (@UserID, @UnitID, @FullRights, @ViewRights)
End						   
						   
go		

IF Exists(Select * From sys.objects Where name = 'PG_Unit_Listing' And type='p')
Drop Proc PG_Unit_Listing
go			   
Create Proc PG_Unit_Listing
(
	@UnitID BigInt = NULL
)
as
Select * From Units u WITH (NOLOCK) 
Where u.UnitID = COAlESCE(@UnitID,u.UnitID)


Select * from UnitRights ur WITH (NOLOCK) 
Inner Join Designation dg WITH (NOLOCK) on ur.designationID = dg.DesignationID 
Inner Join Users u WITH (NOLOCK) on ur.UserId = u.UserID 
Where UnitId = COALESCE(@UnitID,UnitID)

Select * from Designation WITH (NOLOCK)

Select * From Users WITH (NOLOCK) 
Where COALESCE(FromDate,GETDATE()) >= GETDATE() And COALESCE(ToDate,GETDATE()) <= GETDATE()

Go

IF Exists(Select * From sys.objects Where name = 'PG_Unit_Save' And type='p')
Drop Proc PG_Unit_Save
go
Create Proc PG_Unit_Save
(
@UnitID BigInt,
@UnitName Varchar(200),
@Mode Varchar(1)
)
as
If (@Mode = 'I')
Begin
	Insert Into Units(Unit) Values
	(@UnitName)
End
if (@Mode = 'U')
Begin
	Update Units Set Unit = @UnitName Where UnitID = @UnitID
End

Go

IF Exists(Select * From sys.objects Where name = 'PG_UnitRights_Save' And type='p')
Drop Proc PG_UnitRights_Save
go
Create Proc PG_UnitRights_Save
(
@UnitRightsID BigInt,
@UnitID BigInt,
@UserID BigInt,
@DesignationID BigInt,
@IsAvailable Bit
)
as
If (@UnitRightsID > 0)
Begin
	Update UnitRights Set UserId = @UserID, DesignationID = @DesignationID, Available = @IsAvailable Where UnitRightsID = @UnitRightsID
End	
Else
Begin
	Insert Into UnitRights (UnitId,UserId,DesignationID,Available) Values (@UnitID, @UserID,@DesignationID,@IsAvailable)
End

go
IF Exists(Select * From sys.objects Where name = 'PG_List_Designation' And type='p')
Drop Proc PG_List_Designation
go
Create Proc PG_List_Designation
as
Select * From Designation
