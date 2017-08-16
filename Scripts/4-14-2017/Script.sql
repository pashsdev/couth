go
Create Table cri_Templates
(
TemplateID BIGINT Identity(1,1) Constraint PK_cri_Templates Primary key,
TemplateName varchar(200),
Template nvarchar(max)
)

go

Insert Into cri_Templates (TemplateName,Template) Values ('Serial No','[@serialno@]')
Insert Into cri_Templates (TemplateName,Template) Values ('Job No','[@jobno@]')

go

Create Proc PG_Template_Listing
(
	@TemplateID BigInt = NULL
)
as
Select * From cri_Templates WITH (NOLOCK) 
Where TemplateID = COAlESCE(@TemplateID,TemplateID)

go

Create Proc PG_Template_Save
(
@TemplateID BigInt,
@TemplateName Varchar(200),
@TemplateText nvarchar(max),
@Mode Varchar(1)
)
as
If (@Mode = 'I')
Begin
	Insert Into cri_Templates(TemplateName,Template) Values
	(@TemplateName,@TemplateText)
End
if (@Mode = 'U')
Begin
	Update cri_Templates Set TemplateName = @TemplateName, Template = @TemplateText Where TemplateID = @TemplateID
End