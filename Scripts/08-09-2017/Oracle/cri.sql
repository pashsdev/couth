Alter Table CRI_CATALOG_VALUES Add Printed CHAR(1);

create or replace PROCEDURE PG_UPDATE_JOBNODETAILS
(
  p_serial VARCHAR2
) AS
BEGIN
  UPDATE CRI_CATALOG_VALUES SET Printed = 'Y' Where serial_number = p_serial;
END PG_UPDATE_JOBNODETAILS;

create or replace PROCEDURE PG_GET_JOBNODETAILS
(
  JOBNO IN VARCHAR2,
  p_from_serial VARCHAR2,
  p_to_serial VARCHAR2,
  p_org_id number,
  cursor_ OUT sys_refcursor
) AS
BEGIN
Open cursor_ FOR
 
select csn.*,ccv.*,ccv.kw || '/' || ccv.hp as kwhp
from cri_catalog_values ccv, cri_serial_numbers csn
where csn.serial_number=ccv.serial_number
  and ccv.org_id=csn.organization_id
  and nvl(ccv.Printed,'N') = 'N' 
  and ccv.org_id=p_org_id
  And ccv.jobnumber = coalesce(Jobno,ccv.jobnumber)
  and ccv.serial_number between nvl(p_from_serial,ccv.serial_number) and nvl(p_to_serial,ccv.serial_number);
 
END PG_GET_JOBNODETAILS;