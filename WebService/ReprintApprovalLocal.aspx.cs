using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PG.Helper;
using System.Data;
using TransferDatas;
using Newtonsoft.Json;
using System.Net;
using System;
using System.Collections.Generic;

public partial class ReprintApprovalLocal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Cmd"] != null && Request.QueryString["cmd"].ToString().ToLower().Trim() == "save")
        {
            string data = new System.IO.StreamReader(Request.InputStream).ReadToEnd();
            SaveData(data);
        }
    }

    private void SaveData(string data)
    {
        try
        {
            string connectionstring = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();

            List<ReprintDetails> reprint = JsonConvert.DeserializeObject<List<ReprintDetails>>(data);
            foreach (ReprintDetails rePrint in reprint)
            {
                ParameterList detailparameters = new ParameterList();
                detailparameters.Add("ReprintDetailsID", rePrint.ReprintID, SqlDbType.BigInt);
                detailparameters.Add("ApprovedStatus", rePrint.ApprovedStatus, SqlDbType.VarChar);
                detailparameters.Add("ApprovedBy", rePrint.ApprovedBy, SqlDbType.BigInt);
                detailparameters.Add("ApprovalRemarks", rePrint.ApprovalRemarks, SqlDbType.VarChar);

                SqlHelper.ExecuteNonQuery(connectionstring, "PG_Save_ReprintApproval", CommandType.StoredProcedure, detailparameters);

                UpdatePrintData(rePrint.Serial_Number, rePrint.Code, rePrint.OracleUnitID);

            }
        }
        catch (Exception ex)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            Response.StatusDescription = ex.Message;
        }
    }

    private void UpdatePrintData(string SerialNoFrom, string code, Int64 orgId)
    {
        string json = string.Empty;
        try
        {
            ParameterList parameters = new ParameterList();
            string connectionString = Common.GetSQLConnectionString();
            string query = "PG_UPDATE_JOBNODETAILS";
            //string query = "SELECT sn.Item_name,e.Jobnumber,e.SERIAL_NUMBER,'tt' as TemplateName FROM cri_catalog_values e INNER JOIN cri_serial_numbers sn ON e.Item_Code=sn.Item_name ";
            //string query = "Select * From cri_catalog_values";

            if (!string.IsNullOrEmpty(SerialNoFrom))
            {
                parameters.Add("p_serial", SerialNoFrom, SqlDbType.VarChar);
            }
            else
            {
                parameters.Add("p_serial", DBNull.Value, SqlDbType.VarChar);
            }
            parameters.Add("Org_ID", orgId, SqlDbType.BigInt);
            parameters.Add("Code", code, SqlDbType.VarChar);
            parameters.Add("Printed", "N", SqlDbType.VarChar);
            SqlHelper.ExecuteNonQuery(connectionString, query, CommandType.StoredProcedure, parameters, -1);
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