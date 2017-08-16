Create Table Users
(
UserID BigInt Identity (1,1) Constraint PK_Users_UserID Primary Key ,
UserName varchar(200) Not null Constraint UQ_Users_UserName Unique,
[Password] varchar(200) Not null,
Email varchar(100) Not null,
IsApprover Bit Not null Constraint DF_Users_IsApprover Default (0),
IsAdmin Bit Not null Constraint DF_Users_IsAdmin Default (0),
FromDate Datetime,
ToDate Datetime
)

go

Insert Into Users (UserName,[Password],Email,IsApprover,IsAdmin) Values ('Admin','Admin','test@test.com',1,1)

Go

Create Table Designation
(DesignationID BigInt Identity(1,1) Primary Key,
Designation Varchar(100)
)

Go

Create Table Units
(UnitID BigInt Identity(1,1) Primary Key,
Unit Varchar(100)
)

Go

Create Table UnitRights
(UnitRightsID BigInt Identity(1,1) Primary Key,
UnitId BigInt Constraint FK_UnitRights_UnitID References Units(UnitID),
UserId BigInt Constraint FK_UnitRights_UserId References Users(UserID),
DesignationID BigInt Constraint FK_UnitRights_DesignationID References Designation(DesignationID),
Available Bit Constraint DF_UnitRights_Available Default (0)
)

Go

Create Table UserUnits
(
UserUnitID BIGINT Identity(1,1) Primary Key,
UserID BIGINT Constraint FK_UserUnits_UserID References Users(UserID),
UnitID BIGINT Constraint FK_UnitsUnitID References Units(UnitID),
FullRights BIT Constraint DF_UserUnits_FullRights Default(0),
ViewRights BIT Constraint DF_UserUnits_ViewRights Default(0),
)

go

If Exists(Select * From Sysobjects Where name ='GetValidUser' and type ='P')
Begin
	Drop Proc GetValidUser
End

Go

Create Proc GetValidUser
(@UserName Varchar(200),
 @Password Varchar(200))
as
Select * From Users WITH (NOLOCK) Where UserName = @UserName and [Password] = @Password
And COALESCE(FromDate,GETDATE()) >= GETDATE() And COALESCE(ToDate,GETDATE()) <= GETDATE()

Go


--Insert Into Users (UserName,[Password],Email,IsApprover,IsAdmin) Values ('Admin','admin','admin@pg.com',1,1)
--Insert Into Users (UserName,[Password],Email,IsApprover,IsAdmin) Values ('pghr','pghr','hr@pg.com',0,0)
