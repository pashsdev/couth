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

public partial class ReprintApproval : System.Web.UI.Page
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
            }
        }
        catch (Exception ex)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            Response.StatusDescription = ex.Message;
        }
    }
}