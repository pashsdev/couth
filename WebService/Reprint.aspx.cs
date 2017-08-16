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

public partial class ReprintData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool approved = false;
        if (Request.QueryString["Approved"] != null)
        {
            bool.TryParse(Request.QueryString["Approved"].ToString(),out approved);
        }
        if (Request.QueryString["Cmd"] != null && Request.QueryString["cmd"].ToString().ToLower().Trim() == "save")
        {
            string data = new System.IO.StreamReader(Request.InputStream).ReadToEnd();
            SaveData(data);
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
                parameters.Add("Approved", approved, SqlDbType.Bit);
            string connectionstring = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
            IDataReader idr = SqlHelper.ExecuteReader(connectionstring, "PG_List_ReprintRequest", CommandType.StoredProcedure, parameters);
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

    private void SaveData(string json)
    {
        try
        {
            string connectionstring = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
            List<Reprint> lstsearchRequest = JsonConvert.DeserializeObject<List<Reprint>>(json);
            foreach (Reprint rePrint in lstsearchRequest)
            {
                ParameterList parameters = new ParameterList();
                parameters.Add("RequestNo ", rePrint.RequestNo, SqlDbType.BigInt);
                parameters.Add("RequestUserID ", rePrint.RequestUserID, SqlDbType.VarChar);
                parameters.Add("Serial_Number", rePrint.Serial_Number, SqlDbType.VarChar);
                parameters.Add("JobNumber", rePrint.Jobnumber, SqlDbType.VarChar);
                parameters.Add("Item_Code", rePrint.Item_Code, SqlDbType.VarChar);
                parameters.Add("Description", rePrint.Description, SqlDbType.VarChar);

                SqlHelper.ExecuteNonQuery(connectionstring, "PG_Save_ReprintRequest", CommandType.StoredProcedure, parameters);
            }
        }
        catch (Exception ex)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            Response.StatusDescription = ex.Message;
        }
    }
}