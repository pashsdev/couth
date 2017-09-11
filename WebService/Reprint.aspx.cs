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

public partial class ReprintData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Int16 approved = -1;
        string jobNo = string.Empty;
        string serialNoFrom = string.Empty;
        string serialNoTo = string.Empty;
        Int64 oracleUnitID = 0;
        Int64 rePrintID = 0;
        DateTime FromDt = DateTime.MinValue;
        DateTime ToDt = DateTime.MinValue;
        Int64 unitID = 0;
        string code = string.Empty;
        if (Request.QueryString["JobNo"] != null)
        {
            jobNo = Request.QueryString["JobNo"].ToString();
        }
        if (Request.QueryString["serialnofrom"] != null)
        {
            serialNoFrom = Request.QueryString["serialnofrom"].ToString();
        }
        if (Request.QueryString["serialnoto"] != null)
        {
            serialNoTo = Request.QueryString["serialnoto"].ToString();
        }
        if (Request.QueryString["code"] != null)
        {
            code = Request.QueryString["code"].ToString();
        }
        if (Request.QueryString["OracleUnitID"] != null)
        {
            Int64.TryParse(Request.QueryString["OracleUnitID"].ToString(), out oracleUnitID);
        }
        if (Request.QueryString["approved"] != null)
        {
            Int16.TryParse(Request.QueryString["approved"].ToString(), out approved);
        }
        if (Request.QueryString["FromDt"] != null)
        {
            DateTime.TryParse(Request.QueryString["FromDt"].ToString(), out FromDt);
        }
        if (Request.QueryString["ToDate"] != null)
        {
            DateTime.TryParse(Request.QueryString["ToDate"].ToString(), out ToDt);
        }
        if (Request.QueryString["reprintid"] != null)
        {
            Int64.TryParse(Request.QueryString["reprintid"].ToString(), out rePrintID);
        }
        if (Request.QueryString["UnitID"] != null)
        {
            Int64.TryParse(Request.QueryString["UnitID"].ToString(), out unitID);
        }
        if (Request.QueryString["Cmd"] != null && Request.QueryString["cmd"].ToString().ToLower().Trim() == "save")
        {
            string ReprintNo = string.Empty;
            Int64 requestUserId = 0;

            if (Request.QueryString["ReprintNo"] != null)
            {
                ReprintNo = Request.QueryString["ReprintNo"].ToString();
            }
            if (Request.QueryString["RequestUserID"] != null)
            {
                Int64.TryParse(Request.QueryString["RequestUserID"].ToString(), out requestUserId);
            }

            string data = new System.IO.StreamReader(Request.InputStream).ReadToEnd();
            SaveData(ReprintNo, requestUserId, unitID, data);
        }
        else if (Request.QueryString["Cmd"] != null && Request.QueryString["cmd"].ToString().ToLower().Trim() == "requestno")
        {
            GenerateRequestNo();
        }
        else if (Request.QueryString["Cmd"] != null && Request.QueryString["cmd"].ToString().ToLower().Trim() == "listing")
        {
            GenerateRequestMaster(jobNo, serialNoFrom, serialNoTo, oracleUnitID, rePrintID, FromDt, ToDt);
        }
        else if (Request.QueryString["Cmd"] != null && Request.QueryString["cmd"].ToString().ToLower().Trim() == "reprintmaster")
        {
            GenerateRequestMaster(jobNo, serialNoFrom, serialNoTo, oracleUnitID, rePrintID, FromDt, ToDt);
        }
        else if (Request.QueryString["Cmd"] != null && Request.QueryString["cmd"].ToString().ToLower().Trim() == "detail")
        {
            GenerateRequestDetails(jobNo, serialNoFrom, serialNoTo, unitID, rePrintID, FromDt, ToDt, approved);
        }
        else
        {
            ReturnReprintable(jobNo, serialNoFrom, serialNoTo, oracleUnitID, code);
        }
    }

    private void GenerateRequestNo()
    {
        string rePrintNo = string.Empty;
        try
        {
            ParameterList parameters = new ParameterList();
            string connectionstring = Common.GetSQLConnectionString();
            IDataReader idr = SqlHelper.ExecuteReader(connectionstring, "PG_GET_ReprintNumber", CommandType.StoredProcedure, parameters);
            SqlDataReaderHelper helper = new SqlDataReaderHelper(idr);
            if (idr.Read())
            {
                rePrintNo = helper.GetString("ReprintNo");
            }
        }
        catch (Exception ex)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            Response.StatusDescription = ex.Message;
        }
        finally
        {
            Response.Write(rePrintNo);
            Response.End();
        }
    }

    private void GenerateRequestMaster(string jobno, string SerialNoFrom, string SerialNoTo, Int64 unitID, Int64 reprintID, DateTime FromDt, DateTime Todt)
    {
        string json = string.Empty;
        List<ReprintMaster> reprintMasters = new List<ReprintMaster>();
        try
        {
            ParameterList parameters = new ParameterList();
            if (unitID > 0)
            {
                parameters.Add("UnitId", unitID, SqlDbType.BigInt);
            }
            if (!string.IsNullOrEmpty(jobno))
            {
                parameters.Add("Jobno", jobno, SqlDbType.VarChar);
            }
            if (!string.IsNullOrEmpty(SerialNoFrom))
            {
                parameters.Add("SerialNoFrom", SerialNoFrom, SqlDbType.VarChar);
            }
            if (!string.IsNullOrEmpty(SerialNoTo))
            {
                parameters.Add("SerialNoTo", SerialNoTo, SqlDbType.VarChar);
            }
            if (reprintID > 0)
            {
                parameters.Add("reprintID", reprintID, SqlDbType.BigInt);
            }
            if (DateTime.MinValue != FromDt)
            {
                parameters.Add("FromDt", FromDt, SqlDbType.DateTime);
            }
            if (DateTime.MinValue != Todt)
            {
                parameters.Add("ToDt", Todt, SqlDbType.DateTime);
            }
            string connectionstring = Common.GetSQLConnectionString();
            IDataReader idr = SqlHelper.ExecuteReader(connectionstring, "PG_Get_Reprint", CommandType.StoredProcedure, parameters);
            SqlDataReaderHelper helper = new SqlDataReaderHelper(idr);
            Int64 sno = 1;
            while (idr.Read())
            {
                ReprintMaster master = new ReprintMaster();
                master.Sno = sno;
                master.ReprintID = helper.GetInt64("ReprintID");
                master.ReprintNo = helper.GetString("ReprintNo");
                master.RequestDate = helper.GetDateTime("ReprintDate");
                master.RequestUserID = helper.GetInt64("RequestUserID");
                master.RequestUser = helper.GetString("UserName");
                master.Unit = helper.GetString("Unit");
                master.UnitID = helper.GetInt64("UnitID");

                reprintMasters.Add(master);

                sno += 1;

            }

            json = JsonConvert.SerializeObject(reprintMasters);
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

    private void GenerateRequestDetails(string jobno, string SerialNoFrom, string SerialNoTo, Int64 unitID, Int64 reprintID, DateTime FromDt, DateTime Todt, Int16 approved)
    {
        string json = string.Empty;
        List<ReprintMaster> reprintMasters = new List<ReprintMaster>();
        try
        {
            ParameterList parameters = new ParameterList();
            if (unitID > 0)
            {
                parameters.Add("UnitId", unitID, SqlDbType.BigInt);
            }
            if (!string.IsNullOrEmpty(jobno))
            {
                parameters.Add("Jobno", jobno, SqlDbType.VarChar);
            }
            if (!string.IsNullOrEmpty(SerialNoFrom))
            {
                parameters.Add("SerialNoFrom", SerialNoFrom, SqlDbType.VarChar);
            }
            if (!string.IsNullOrEmpty(SerialNoTo))
            {
                parameters.Add("SerialNoTo", SerialNoTo, SqlDbType.VarChar);
            }
            if (reprintID > 0)
            {
                parameters.Add("reprintID", reprintID, SqlDbType.BigInt);
            }
            if (DateTime.MinValue != FromDt)
            {
                parameters.Add("FromDt", FromDt, SqlDbType.DateTime);
            }
            if (DateTime.MinValue != Todt)
            {
                parameters.Add("ToDt", Todt, SqlDbType.DateTime);
            }
            parameters.Add("approvalPending", approved, SqlDbType.SmallInt);


            string connectionstring = Common.GetSQLConnectionString();
            IDataReader idr = SqlHelper.ExecuteReader(connectionstring, "PG_Get_Reprint", CommandType.StoredProcedure, parameters);
            SqlDataReaderHelper helper = new SqlDataReaderHelper(idr);


            idr.NextResult();
            List<ReprintDetails> reprintDetails = new List<ReprintDetails>();
            Int64 sno = 1;
            while (idr.Read())
            {
                ReprintDetails detail = new ReprintDetails();
                detail.Sno = sno;
                detail.RequestDate = helper.GetDateTime("ReprintDate");
                detail.RequestUserID = helper.GetInt64("RequestUserID");
                detail.RequestUser = helper.GetString("UserName");
                detail.ApprovedStatus = helper.GetString("ApprovedStatus");
                detail.ApprovedDate = helper.GetDateTime("ApprovedDate");
                detail.ApprovedByUser = helper.GetString("ApprovedByUser");
                detail.UnitID = helper.GetInt64("UnitID");
                detail.Description = helper.GetString("Description");
                detail.Item_Code = helper.GetString("Item_Code");
                detail.Jobnumber = helper.GetString("Jobnumber");
                detail.ReprintDetailsID = helper.GetInt64("ReprintDetailsID");
                detail.ReprintID = helper.GetInt64("ReprintID");
                detail.ReprintNo = helper.GetString("ReprintNo");
                detail.Serial_Number = helper.GetString("Serial_Number");
                detail.ApprovedStatus = helper.GetString("ApprovedStatus");
                detail.ApprovedBy = helper.GetInt64("ApprovedBy");
                detail.ApprovedDate = helper.GetDateTime("ApprovedDate");
                detail.ApprovedByUser = helper.GetString("ApprovedByUser");
                detail.ApprovalRemarks = helper.GetString("ApprovalRemarks");
                detail.TemplateID = helper.GetInt64("TemplateID");
                detail.Template = helper.GetString("Template");
                detail.Remarks = helper.GetString("Remarks");
                detail.PrintCount = helper.GetInt64("PrintCount");
                detail.Code = helper.GetString("Code");
                reprintDetails.Add(detail);

                sno += 1;
            }

            json = JsonConvert.SerializeObject(reprintDetails);
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

    private void ReturnReprintable(string jobno, string SerialNoFrom, string SerialNoTo, Int64 oracleUnitID, string code)
    {
        string json = string.Empty;
        try
        {
            ParameterList parameters = new ParameterList();
            parameters.Add("p_org_id", oracleUnitID, SqlDbType.BigInt);
            if (!string.IsNullOrEmpty(jobno))
            {
                parameters.Add("Jobno", jobno, SqlDbType.VarChar);
            }
            else
            {
                parameters.Add("Jobno", DBNull.Value, SqlDbType.VarChar);
            }
            if (!string.IsNullOrEmpty(SerialNoFrom))
            {
                parameters.Add("p_from_serial", SerialNoFrom, SqlDbType.VarChar);
            }
            else
            {
                parameters.Add("p_from_serial", DBNull.Value, SqlDbType.VarChar);
            }
            if (!string.IsNullOrEmpty(SerialNoTo))
            {
                parameters.Add("p_to_serial", SerialNoTo, SqlDbType.VarChar);
            }
            else
            {
                parameters.Add("p_to_serial", DBNull.Value, SqlDbType.VarChar);
            }
            parameters.Add("code", code, SqlDbType.VarChar);
            //parameters.Add("Approved", approved, SqlDbType.Bit);
            string connectionstring = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
            IDataReader idr = SqlHelper.ExecuteReader(connectionstring, "PG_List_ReprintRequest", CommandType.StoredProcedure, parameters);
            SqlDataReaderHelper helper = new SqlDataReaderHelper(idr);
            List<Reprintable> lstReprint = new List<Reprintable>();
            Int64 i = 1;
            while (idr.Read())
            {
                Reprintable reprint = new Reprintable();
                reprint.Sno = i;
                reprint.Description = helper.GetString("Description");
                reprint.Item_Code = helper.GetString("Item_Code");
                reprint.Jobnumber = helper.GetString("Jobnumber");
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

    private void SaveData(string reprintno, Int64 userId, Int64 unitId, string json)
    {
        try
        {
            string connectionstring = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
            ParameterList parameters = new ParameterList();
            parameters.Add("RequestNo", reprintno, SqlDbType.VarChar);
            parameters.Add("RequestUserID", userId, SqlDbType.BigInt);
            parameters.Add("UnitID", unitId, SqlDbType.BigInt);
            SqlHelper.ExecuteNonQuery(connectionstring, "PG_Save_ReprintRequest", CommandType.StoredProcedure, parameters);

            List<ReprintDetails> reprintDetails = JsonConvert.DeserializeObject<List<ReprintDetails>>(json);
            foreach (ReprintDetails rePrint in reprintDetails)
            {
                ParameterList detailparameters = new ParameterList();
                detailparameters.Add("RequestNo ", reprintno, SqlDbType.VarChar);
                detailparameters.Add("Serial_Number", rePrint.Serial_Number, SqlDbType.VarChar);
                detailparameters.Add("JobNumber", rePrint.Jobnumber, SqlDbType.VarChar);
                detailparameters.Add("Item_Code", rePrint.Item_Code, SqlDbType.VarChar);
                detailparameters.Add("Description", rePrint.Description, SqlDbType.VarChar);
                detailparameters.Add("TemplateID", rePrint.TemplateID, SqlDbType.BigInt);
                detailparameters.Add("Remarks", rePrint.Remarks, SqlDbType.VarChar);
                SqlHelper.ExecuteNonQuery(connectionstring, "PG_Save_ReprintRequestDetails", CommandType.StoredProcedure, detailparameters);
            }
        }
        catch (Exception ex)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            Response.StatusDescription = ex.Message;
        }
    }
}