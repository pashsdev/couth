using Oracle.DataAccess.Client;
using PG.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TestOracle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PrintData("", "", "");
    }

    private void PrintData(string jobno, string SerialNoFrom, string SerialNoTo)
    {
        OracleParameterList parameters = new OracleParameterList();
        string connectionString = Common.GetConnectionString();
        string query = "PG_GET_JOBNODETAILS";
        //string query = "SELECT sn.Item_name,e.Jobnumber,e.SERIAL_NUMBER,'tt' as TemplateName FROM cri_catalog_values e INNER JOIN cri_serial_numbers sn ON e.Item_Code=sn.Item_name ";
        //string query = "Select * From cri_catalog_values";
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
        parameters.Add("cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

        IDataReader idr = OracleHelper.ExcuteOracleReader(connectionString, query, CommandType.StoredProcedure, parameters);
    }

}