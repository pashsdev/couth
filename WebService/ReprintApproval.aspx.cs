using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PG.Helper;
using System.Data;
using TransferDatas;
using Newtonsoft.Json;
using System.Net;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;

public partial class ReprintApproval : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool approved = false;
        
        if (Request.QueryString["Cmd"] != null && Request.QueryString["cmd"].ToString().ToLower().Trim() == "save")
        {
            string data = new System.IO.StreamReader(Request.InputStream).ReadToEnd();
            //SaveData(data);
        }
        else
        {
            ReturnReprint(approved);
        }
    }

    private void ReturnReprint(bool approved)
    {
        string json = string.Empty;
        try
        {
            ParameterList parameters = new ParameterList();
            parameters.Add("Approved", 0, SqlDbType.Bit);
            string connectionstring = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
            IDataReader idr = SqlHelper.ExecuteReader(connectionstring, "PG_List_PendingReprintRequest", CommandType.StoredProcedure, parameters);
            SqlDataReaderHelper helper = new SqlDataReaderHelper(idr);
            List<Reprint> lstReprint = new List<Reprint>();
            Int64 i = 1;
            while (idr.Read())
            {
                Reprint reprint = new Reprint();
                reprint.Sno = i;
                reprint.Approved = helper.GetBoolean("Approved");
                reprint.ApprovedBy = helper.GetInt64("ApprovedBy");
                reprint.ApprovedDate = helper.GetDateTime("ApprovedDate");
                reprint.Description = helper.GetString("Description");
                reprint.Item_Code = helper.GetString("Item_Code");
                reprint.Jobnumber = helper.GetString("Jobnumber");
                reprint.RequestDate = helper.GetDateTime("RequestDate");
                reprint.RequestID = helper.GetInt64("RequestID");
                reprint.RequestNo = helper.GetString("RequestNo");
                reprint.RequestUser = helper.GetString("RequestUser");
                reprint.RequestUserID = helper.GetInt64("RequestUserID");
                reprint.Serial_Number = helper.GetString("Serial_Number");

                lstReprint.Add(reprint);
                i += 1;

            }

            json = JsonConvert.SerializeObject(lstReprint);
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