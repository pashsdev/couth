CREATE USER hr IDENTIFIED BY oePSWRD;
Drop table test_c;
Create Table test_c (
    deptno number(3,0) PRIMARY KEY,
    dname varchar2(15),
    loc varchar2(25))

Insert Into test_c(deptno,dname,loc) values (1,'abc','loc')
Select * From test_c
Drop Table cri_catalog_values 
Create Table cri_catalog_values (
Serial_Number Varchar(30),
Jobnumber varchar2(30),
Item_Code Varchar2(40),
Description Varchar2(240)
)

Insert Into cri_catalog_values (Serial_Number,Jobnumber,Item_Code,Description) values ('123','aad1233','Code1','This is item 1')
Insert Into cri_catalog_values (Serial_Number,Jobnumber,Item_Code,Description) values ('124','aad1234','Code2','This is item 2')
Insert Into cri_catalog_values (Serial_Number,Jobnumber,Item_Code,Description) values ('125','aad1235','Code3','This is item 3')

Select * From cri_catalog_values Where Jobnumber = 'aad1233'
Select * From cri_serial_numbers 

Create Table cri_serial_numbers 
(
Inventory_Item_Id number,
Item_Name Varchar2(40),
Item_Desc Varchar2(240)
)

Insert Into cri_serial_numbers (Inventory_Item_Id, Item_Name, Item_Desc)
Values (1,'Code1', 'this is the Item 1')
Insert Into cri_serial_numbers (Inventory_Item_Id, Item_Name, Item_Desc)
Values (3,'Code2', 'this is the Item 2')

SELECT sn.Item_name,e.Jobnumber,e.SERIAL_NUMBER,'' as TemplateName
FROM cri_catalog_values e
INNER JOIN cri_serial_numbers sn ON e.Item_Code=sn.Item_name

SELECT sn.Item_name,e.Jobnumber,e.SERIAL_NUMBER,'tt' as TemplateName FROM cri_catalog_values e INNER JOIN cri_serial_numbers sn ON e.Item_Code=sn.Item_name 

DECLARE cur sys_refcursor ;
Exec PG_GET_JOBNODETAILS('adas',cur);
print cur;