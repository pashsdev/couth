using System;
using System.Collections.Generic;
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

public partial class GetPrintData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string jobNo = string.Empty;
        string serialNoFrom = string.Empty;
        string serialNoTo = string.Empty;
        Int64 oracleUnitID = 0;
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
        if (Request.QueryString["OracleUnitID"] != null)
        {
            Int64.TryParse(Request.QueryString["OracleUnitID"].ToString(), out oracleUnitID);
        }
        if (Request.QueryString["code"] != null)
        {
            code = Request.QueryString["code"].ToString();
        }
        if (Request.QueryString["Cmd"] != null && Request.QueryString["cmd"].ToString().ToLower().Trim() == "save")
        {
            string data = new System.IO.StreamReader(Request.InputStream).ReadToEnd();
            SaveData(data);
            UpdatePrintData(data);
        }
        else
        {
            PrintData(jobNo, serialNoFrom, serialNoTo, oracleUnitID, code);
        }

    }

    private void PrintData(string jobno, string SerialNoFrom, string SerialNoTo, Int64 oracleUnitID, string code)
    {
        string json = string.Empty;
        try
        {
            OracleParameterList parameters = new OracleParameterList();
            string connectionString = Common.GetConnectionString();
            string query = "PG_GET_JOBNODETAILS";
            //string query = "SELECT sn.Item_name,e.Jobnumber,e.SERIAL_NUMBER,'tt' as TemplateName FROM cri_catalog_values e INNER JOIN cri_serial_numbers sn ON e.Item_Code=sn.Item_name ";
            //string query = "Select * From cri_catalog_values";
            parameters.Add("p_org_id", oracleUnitID, OracleDbType.Long);
            if (!string.IsNullOrEmpty(jobno))
            {
                parameters.Add("Jobno", jobno, OracleDbType.Varchar2);
            }
            else
            {
                parameters.Add("Jobno", DBNull.Value, OracleDbType.Varchar2);
            }
            if (!string.IsNullOrEmpty(SerialNoFrom))
            {
                parameters.Add("p_from_serial", SerialNoFrom, OracleDbType.Varchar2);
            }
            else
            {
                parameters.Add("p_from_serial", DBNull.Value, OracleDbType.Varchar2);
            }
            if (!string.IsNullOrEmpty(SerialNoTo))
            {
                parameters.Add("p_to_serial", SerialNoTo, OracleDbType.Varchar2);
            }
            else
            {
                parameters.Add("p_to_serial", DBNull.Value, OracleDbType.Varchar2);
            }
            if (!string.IsNullOrEmpty(code))
            {
                parameters.Add("code", code, OracleDbType.Varchar2);
            }
            else
            {
                parameters.Add("code", DBNull.Value, OracleDbType.Varchar2);
            }
            parameters.Add("cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader idr = OracleHelper.ExcuteOracleReader(connectionString, query, CommandType.StoredProcedure, parameters);
            SqlDataReaderHelper helper = new SqlDataReaderHelper(idr);
            
            List<Search> lstSearch = new List<Search>();
            Int64 i = 1;
            while (idr.Read())
            {
                Search search = new Search();
                search.Sno = i;
                search.Inventory_Item_Id = idr. ("Inventory_Item_Id");
                search.Printed = false;
                search.Product = helper.GetString("Item_name");
                search.JobNo = helper.GetString("Jobnumber");
                search.ProductDesc = helper.GetString("Item_desc");
                search.SerialNo = helper.GetString("SERIAL_NUMBER");
                search.R01_PUMP_MODEL = helper.GetString("R01_PUMP_MODEL");
                search.R01_VOLTS = helper.GetString("R01_VOLTS");
                search.CATEGORY = helper.GetString("CATEGORY");
                search.kwhp = helper.GetString("kwhp");
                search.AMPS = helper.GetString("AMPS");
                search.PHASE = helper.GetString("PHASE");
                search.RPM = helper.GetString("RPM");
                search.MIN_BORE_SIZE = helper.GetString("MIN_BORE_SIZE");
                search.DISCHARGE = helper.GetString("DISCHARGE");
                search.HEAD_MAX = helper.GetString("HEAD_MAX");
                search.C_SIZE = helper.GetString("C_SIZE");
                search.R01_AMPS = helper.GetString("R01_AMPS");
                //search.Template = helper.GetString("TemplateName");
                lstSearch.Add(search);
                i += 1;
            }

            //List<Search> printerSearch = Printed();
            //List<Search> result = lstSearch.Where(x => x.Product == "a").ToList();

            json = JsonConvert.SerializeObject(lstSearch);
            idr.Close();
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

    private void LoadData()
    {
        string connectionString = Common.GetConnectionString();
        OracleConnection con = new OracleConnection(connectionString);
        OracleCommand cmd = new OracleCommand();
        cmd.CommandText = "PG_GET_JOBNODETAILS";
        cmd.Connection = con;
        con.Open();

        OracleParameter p_org_id = new OracleParameter();
        p_org_id.OracleDbType = OracleDbType.Int62;
        p_department_id.Value = departmentID.Text;
        cmd.Parameters.Add(p_department_id);

        OracleDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            Response.Write("<table border='1'>");
            Response.Write("<tr><th>Name</th><th>Roll No</th></tr>");
            while (dr.Read())
            {

                Response.Write("<tr>");
                Response.Write("<td>" + dr["name"].ToString() + "</td>");
                Response.Write("<td>" + dr["roll_no"].ToString() + "</td>");
                Response.Write("</tr>");
            }
            Response.Write("</table>");
        }
    }

    private void UpdatePrintData(string json)
    {
        try
        {
            List<Search> lstsearchRequest = JsonConvert.DeserializeObject<List<Search>>(json);
            foreach (Search searchRequest in lstsearchRequest)
            {
                OracleParameterList parameters = new OracleParameterList();
                string connectionString = Common.GetConnectionString();
                string query = "PG_UPDATE_JOBNODETAILS";
                //string query = "SELECT sn.Item_name,e.Jobnumber,e.SERIAL_NUMBER,'tt' as TemplateName FROM cri_catalog_values e INNER JOIN cri_serial_numbers sn ON e.Item_Code=sn.Item_name ";
                //string query = "Select * From cri_catalog_values";

                if (!string.IsNullOrEmpty(searchRequest.SerialNo))
                {
                    parameters.Add("p_serial", searchRequest.SerialNo, OracleDbType.Varchar2);
                }
                else
                {
                    parameters.Add("p_serial", DBNull.Value, OracleDbType.Varchar2);
                }
                parameters.Add("p_printed", "Y", OracleDbType.Varchar2);
                parameters.Add("Org_ID", searchRequest.ORG_ID, OracleDbType.Decimal);
                parameters.Add("Code", searchRequest.CODE, OracleDbType.VarChar2);
                OracleHelper.ExecuteNonQuery(connectionString, query, CommandType.StoredProcedure, parameters, -1);
            }

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

    private List<Search> Printed()
    {
        ParameterList parameters = new ParameterList();
        string connectionstring = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
        IDataReader idr = SqlHelper.ExecuteReader(connectionstring, "PG_List_Printed", CommandType.StoredProcedure, parameters);
        SqlDataReaderHelper helper = new SqlDataReaderHelper(idr);
        List<Search> lstSearch = new List<Search>();
        while (idr.Read())
        {
            Search search = new Search();
            search.Inventory_Item_Id = helper.GetInt64("Inventory_Item_Id");
            search.Printed = false;
            search.Product = helper.GetString("Item_name");
            search.JobNo = helper.GetString("Jobnumber");
            search.ProductDesc = helper.GetString("Item_desc");
            search.SerialNo = helper.GetString("SERIAL_NUMBER");
            search.Template = helper.GetString("TemplateName");
            lstSearch.Add(search);
        }

        idr.Close();
        return lstSearch;
    }

    private void SaveData(string json)
    {
        try
        {
            string connectionstring = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
            List<Search> lstsearchRequest = JsonConvert.DeserializeObject<List<Search>>(json);
            foreach (Search searchRequest in lstsearchRequest)
            {
                ParameterList parameters = new ParameterList();
                parameters.Add("Inventory_Item_Id ", searchRequest.Inventory_Item_Id, SqlDbType.BigInt);
                parameters.Add("Item_Name ", searchRequest.Product, SqlDbType.VarChar);
                parameters.Add("Item_Desc", searchRequest.ProductDesc, SqlDbType.VarChar);
                parameters.Add("Serial_Number", searchRequest.SerialNo, SqlDbType.VarChar);
                parameters.Add("JobNumber", searchRequest.JobNo, SqlDbType.VarChar);
                parameters.Add("Item_Code", searchRequest.Product, SqlDbType.VarChar);
                parameters.Add("Description", searchRequest.ProductDesc, SqlDbType.VarChar);
                parameters.Add("Printed", searchRequest.Printed, SqlDbType.Bit);
                parameters.Add("ORG_ID", searchRequest.ORG_ID, SqlDbType.BigInt);
                parameters.Add("CODE", searchRequest.CODE, SqlDbType.VarChar);

                SqlHelper.ExecuteNonQuery(connectionstring, "PG_Save_SerialJobNumber", CommandType.StoredProcedure, parameters);
            }
        }
        catch (Exception ex)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            Response.StatusDescription = ex.Message;
        }
    }
}