using Newtonsoft.Json;
using PG.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TransferDatas;

public partial class GetTemplate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Int64 templateID = 0;
        if (Request.QueryString["TemplateID"] != null)
        {
            Int64.TryParse(Request.QueryString["TemplateID"].ToString(), out templateID);
        }
        if (Request.QueryString["Cmd"] != null && Request.QueryString["cmd"].ToString().ToLower().Trim() == "save")
        {
            string data = new System.IO.StreamReader(Request.InputStream).ReadToEnd();
            string mode = Request.QueryString["mode"].ToString();
            Save(data, mode);
        }
        else
        {
            ReturnTemplates(templateID);
        }
    }

    private void Save(string templateJson, string mode)
    {
        try
        {
            Template template = JsonConvert.DeserializeObject<Template>(templateJson);

            ParameterList parameters = new ParameterList();
            parameters.Add("TemplateID", template.TemplateID, SqlDbType.BigInt);
            parameters.Add("TemplateName", template.TemplateName, SqlDbType.VarChar);
            parameters.Add("TemplateText", template.TemplateText, SqlDbType.VarChar);
            parameters.Add("Mode", mode, SqlDbType.VarChar);

            string connectionstring = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
            SqlHelper.ExecuteNonQuery(connectionstring, "PG_Template_Save", CommandType.StoredProcedure, parameters);
           
        }
        catch (Exception ex)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            Response.StatusDescription = ex.Message;
        }
    }
    private void ReturnTemplates(Int64 TemplateID)
    {
        string json = string.Empty;
        try
        {
            ParameterList parameters = new ParameterList();
            if (TemplateID > 0)
            {
                parameters.Add("TemplateID", TemplateID, SqlDbType.BigInt);
            }
            string connectionstring = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
            IDataReader idr = SqlHelper.ExecuteReader(connectionstring, "PG_Template_Listing", CommandType.StoredProcedure, parameters);
            SqlDataReaderHelper helper = new SqlDataReaderHelper(idr);
            List<Template> lstTemplate = new List<Template>();
            
            while (idr.Read())
            {
                Template template = new Template();
                template.TemplateID = helper.GetInt64("TemplateID");
                template.TemplateName = helper.GetString("TemplateName");
                template.TemplateText = helper.GetString("Template");
                lstTemplate.Add(template);
            }

            json = JsonConvert.SerializeObject(lstTemplate);
            idr.Close();
            //string designationJson = JsonConvert.SerializeObject(lstDesignation);
            //string userJson = JsonConvert.SerializeObject(users);

            //string returnString = string.Concat(json, designationJson, userJson);
        }
        catch (Exception ex)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            Response.StatusDescription = ex.Message;
        }
        finally
        {
            Response.Write(json);
            Response.End();
        }

    }
}