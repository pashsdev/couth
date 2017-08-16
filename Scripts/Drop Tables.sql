IF Exists(Select * From sys.tables Where name = 'Users' And type='u')
Drop Table Users
Go
IF Exists(Select * From sys.tables Where name = 'Designation' And type='u')
Drop Table Designation
GO

IF Exists(Select * From sys.tables Where name = 'Units' And type='u')
Drop Table Units
GO

IF Exists(Select * From sys.tables Where name = 'UnitRights' And type='u')
Drop Table UnitRights
GO