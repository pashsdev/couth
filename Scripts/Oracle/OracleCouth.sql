create or replace 
PROCEDURE PG_GET_JOBNODETAILS 
(
  JOBNO IN VARCHAR2,
  p_from_serial VARCHAR2,
  p_to_serial VARCHAR2,
  cursor_ OUT sys_refcursor
) AS
BEGIN
Open cursor_ FOR 

select csn.Inventory_Item_Id,csn.Item_name,csn.Item_desc,ccv.Jobnumber,csn.SERIAL_NUMBER, csn.NamePlate as TemplateName 
from cri_catalog_values ccv, cri_serial_numbers csn
where csn.serial_number=ccv.serial_number
  And ccv.jobnumber = coalesce(Jobno,ccv.jobnumber) 
  and ccv.serial_number between nvl(p_from_serial,ccv.serial_number) and nvl(p_to_serial,ccv.serial_number);

END PG_GET_JOBNODETAILS;