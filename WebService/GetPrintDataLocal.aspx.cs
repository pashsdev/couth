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

public partial class GetPrintDataLocal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string jobNo = string.Empty;
        string serialNoFrom = string.Empty;
        string serialNoTo = string.Empty;
        Int64 oracleUnitID = 0;
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
        if (Request.QueryString["Cmd"] != null && Request.QueryString["cmd"].ToString().ToLower().Trim() == "save")
        {
            string data = new System.IO.StreamReader(Request.InputStream).ReadToEnd();
            SaveData(data);
            UpdatePrintData(data);
        }
        else
        {
            PrintData(jobNo, serialNoFrom, serialNoTo, oracleUnitID);
        }
    }

    private void PrintData(string jobno, string SerialNoFrom, string SerialNoTo, Int64 oracleUnitID)
    {
        string json = string.Empty;
        try
        {
            ParameterList parameters = new ParameterList();
            string connectionString = Common.GetSQLConnectionString();
            string query = "PG_GET_JOBNODETAILS";
            //string query = "SELECT sn.Item_name,e.Jobnumber,e.SERIAL_NUMBER,'tt' as TemplateName FROM cri_catalog_values e INNER JOIN cri_serial_numbers sn ON e.Item_Code=sn.Item_name ";
            //string query = "Select * From cri_catalog_values";
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

            IDataReader idr = SqlHelper.ExecuteReader(connectionString, query, CommandType.StoredProcedure, parameters);
            SqlDataReaderHelper helper = new SqlDataReaderHelper(idr);
            List<Search> lstSearch = new List<Search>();
            Int64 i = 1;
            while (idr.Read())
            {
                Search search = new Search();
                search.Sno = i;
                search.Inventory_Item_Id = helper.GetInt64("Inventory_Item_Id");
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

                SqlHelper.ExecuteNonQuery(connectionstring, "PG_Save_SerialJobNumber", CommandType.StoredProcedure, parameters);
            }
        }
        catch (Exception ex)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            Response.StatusDescription = ex.Message;
        }
    }

    private void UpdatePrintData(string json)
    {
        try
        {
            List<Search> lstsearchRequest = JsonConvert.DeserializeObject<List<Search>>(json);
            foreach (Search searchRequest in lstsearchRequest)
            {
                ParameterList parameters = new ParameterList();
                string connectionString = Common.GetSQLConnectionString();
                string query = "PG_UPDATE_JOBNODETAILS";
                //string query = "SELECT sn.Item_name,e.Jobnumber,e.SERIAL_NUMBER,'tt' as TemplateName FROM cri_catalog_values e INNER JOIN cri_serial_numbers sn ON e.Item_Code=sn.Item_name ";
                //string query = "Select * From cri_catalog_values";

                if (!string.IsNullOrEmpty(searchRequest.SerialNo))
                {
                    parameters.Add("p_serial", searchRequest.SerialNo, SqlDbType.VarChar);
                }
                else
                {
                    parameters.Add("p_serial", DBNull.Value, SqlDbType.VarChar);
                }

                SqlHelper.ExecuteNonQuery(connectionString, query, CommandType.StoredProcedure, parameters, -1);
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
}