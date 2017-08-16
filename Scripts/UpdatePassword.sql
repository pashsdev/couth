IF Exists(Select * From sys.objects Where name = 'PG_User_UpdatePassword' And type='p')
Drop Proc PG_User_UpdatePassword
go
Create Proc PG_User_UpdatePassword
(
	@UserID BigInt,
	@Password Varchar(200)
)
as

Update Users Set Password = @Password Where UserID = @UserID
Go