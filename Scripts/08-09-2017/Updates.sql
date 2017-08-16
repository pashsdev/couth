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
