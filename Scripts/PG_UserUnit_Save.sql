
Alter Proc PG_UserUnit_Save
(
@UserUnitID BIGINT,
@UserName varchar(200),
@UnitID BIGINT,
@FullRights BIT ,
@ViewRights BIT 
)
as
Declare @UserID BIGINT
Select @UserID = UserID From Users WITH (NOLOCK) Where UserName = @UserName
If (@UserUnitID > 0)
Begin
	Update UserUnits Set FullRights = @FullRights, ViewRights = @ViewRights Where UserUnitID = @UserUnitID
End 
Else
Begin
	Insert Into UserUnits (UserID,UnitID,FullRights,ViewRights) Values (@UserID, @UnitID, @FullRights, @ViewRights)
End						   
						   
