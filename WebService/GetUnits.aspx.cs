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

public partial class GetUnits : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Int64 unitID = 0;
        Int64 userID = 0;
        if (Request.QueryString["UnitID"] != null)
        {
            Int64.TryParse(Request.QueryString["UnitID"].ToString(), out unitID);
        }
        if (Request.QueryString["UserID"] != null)
        {
            Int64.TryParse(Request.QueryString["UserID"].ToString(), out userID);
        }
        if (Request.QueryString["Cmd"] != null && Request.QueryString["cmd"].ToString().ToLower().Trim() == "save")
        {
            string data = new System.IO.StreamReader(Request.InputStream).ReadToEnd();
            string mode = Request.QueryString["mode"].ToString();
            Save(data, mode);
        }
        else
        {
            ReturnUnits(userID,unitID);
        }
    }

    private void ReturnUnits(Int64 userID, Int64 UnitID)
    {
        string json = string.Empty;
        try
        {
            ParameterList parameters = new ParameterList();
            if (userID > 0)
            {
                parameters.Add("UserID", userID, SqlDbType.BigInt);
            }
            if (UnitID > 0)
            {
                parameters.Add("UnitID", UnitID, SqlDbType.BigInt);
            }
            string connectionstring = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
            IDataReader idr = SqlHelper.ExecuteReader(connectionstring, "PG_Unit_Listing", CommandType.StoredProcedure, parameters);
            SqlDataReaderHelper helper = new SqlDataReaderHelper(idr);
            List<TransferDatas.Unit> lstunit = new List<TransferDatas.Unit>();
            List<Designation> lstDesignation = new List<Designation>();
            List<User> users = new List<User>();
            while (idr.Read())
            {
                TransferDatas.Unit unit = new TransferDatas.Unit();
                unit.UnitID = helper.GetInt64("UnitID");
                unit.UnitName = helper.GetString("Unit");
                unit.OracleUnitID = helper.GetInt64("OracleUnitID");
                unit.Active = helper.GetBoolean("Active");
                lstunit.Add(unit);
            }
            idr.NextResult();

            List<UnitRight> unitRights = new List<UnitRight>();
            while (idr.Read())
            {
                UnitRight right = new UnitRight();
                right.Available = helper.GetBoolean("Available");
                right.DesignationID = helper.GetInt64("DesignationID");
                right.UnitID = helper.GetInt64("UnitID");
                right.UnitRightsID = helper.GetInt64("UnitRightsID");
                right.UserID = helper.GetInt64("UserID");
                right.Designation = helper.GetString("Designation");
                unitRights.Add(right);
            }

            idr.NextResult();
            while (idr.Read())
            {
                Designation designation = new Designation();
                designation.DesignationID = helper.GetInt64("designationID");
                designation.DesignationName = helper.GetString("designation");
                lstDesignation.Add(designation);
            }

            idr.NextResult();
            while (idr.Read())
            {
                User user = new User();
                user.UserID = helper.GetInt64("UserID");
                user.UserName = helper.GetString("UserName");
                users.Add(user);
            }

            Units units = new Units();
            units.units = lstunit;

            UnitResponse responseJson = new UnitResponse();
            responseJson.Designations = lstDesignation;
            responseJson.LstUnits = lstunit;
            responseJson.Users = users;
            responseJson.UnitRights = unitRights;
            json = JsonConvert.SerializeObject(responseJson);
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
            //Response.End();
        }

    }

    private void Save(string unitJson, string mode)
    {
        try
        {
            UnitRequest unitRequest = JsonConvert.DeserializeObject<UnitRequest>(unitJson);
            TransferDatas.Unit unit = unitRequest.unit;

            ParameterList parameters = new ParameterList();
            parameters.Add("UnitID", unit.UnitID, SqlDbType.BigInt);
            parameters.Add("UnitName", unit.UnitName, SqlDbType.VarChar);
            parameters.Add("Mode", mode, SqlDbType.VarChar);
            parameters.Add("OracleUnitID", unit.OracleUnitID, SqlDbType.BigInt);
            parameters.Add("Active", Convert.ToInt16(unit.Active), SqlDbType.Bit);

            string connectionstring = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
            SqlHelper.ExecuteNonQuery(connectionstring, "PG_Unit_Save", CommandType.StoredProcedure, parameters);


            List<UnitRight> unitRights = unitRequest.UnitRights;
            foreach (UnitRight rights in unitRights)
            {
                if (rights.UserID > 0)
                {
                    parameters = new ParameterList();
                    parameters.Add("UnitRightsID", rights.UnitRightsID, SqlDbType.BigInt);
                    parameters.Add("UnitID", rights.UnitID, SqlDbType.BigInt);
                    parameters.Add("UserID", rights.UserID, SqlDbType.BigInt);
                    parameters.Add("DesignationID", rights.DesignationID, SqlDbType.BigInt);
                    parameters.Add("IsAvailable", rights.Available, SqlDbType.Bit);

                    SqlHelper.ExecuteNonQuery(connectionstring, "PG_UnitRights_Save", CommandType.StoredProcedure, parameters);
                }
            }
        }
        catch (Exception ex)
        {
            Response.Headers.Add("Error", ex.Message);
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            Response.StatusDescription = ex.Message;
            Response.Write(ex.Message);

            //throw;
        }
        finally
        {

            //Response.Write("Error");
            Response.End();
        }
    }

    public class UnitResponse
    {
        public List<TransferDatas.Unit> LstUnits { get; set; }
        public List<Designation> Designations { get; set; }
        public List<User> Users { get; set; }
        public List<UnitRight> UnitRights { get; set; }
    }

    public class UnitRequest
    {
        public TransferDatas.Unit unit { get; set; }
        public List<UnitRight> UnitRights { get; set; }
    }

    public class UnitRight
    {
        public Int64 UnitRightsID { get; set; }
        public Int64 UnitID { get; set; }
        public Int64 DesignationID { get; set; }
        public Int64 UserID { get; set; }
        public bool Available { get; set; }
        public string Designation { get; set; }
    }
}