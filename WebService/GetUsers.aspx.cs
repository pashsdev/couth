using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PG.Helper;
using System.Data;
using Newtonsoft.Json;
using TransferDatas;
using System.Net;

public partial class GetUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Int64 userID = 0;
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
            ReturnUsers(userID);
        }
    }

    private void ReturnUsers(Int64 UserID)
    {
        string json = string.Empty;
        try
        {
            ParameterList parameters = new ParameterList();
            if (UserID > 0)
            {
                parameters.Add("UserID", UserID, SqlDbType.BigInt);
            }
            string connectionstring = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
            IDataReader idr = SqlHelper.ExecuteReader(connectionstring, "PG_User_Listing", CommandType.StoredProcedure, parameters);
            SqlDataReaderHelper helper = new SqlDataReaderHelper(idr);
            List<User> lstuser = new List<User>();
            while (idr.Read())
            {
                User user = new User();
                user.UserID = helper.GetInt64("UserID");
                user.UserName = helper.GetString("UserName");
                user.Password = helper.GetString("Password");
                user.Email = helper.GetString("Email");
                user.IsApprover = helper.GetBoolean("IsApprover");
                user.IsAdmin = helper.GetBoolean("IsAdmin");
                user.FromDate = helper.GetDateTime("FromDate");
                user.ToDate = helper.GetDateTime("ToDate");
                lstuser.Add(user);
            }

            idr.NextResult();
            List<UserUnits> lstUserUnits = new List<UserUnits>();
            while (idr.Read())
            {
                UserUnits userUnits = new UserUnits();
                userUnits.FullRights = helper.GetBoolean("FullRights");
                userUnits.UnitID = helper.GetInt64("UnitID");
                userUnits.Unit = helper.GetString("Unit");
                userUnits.UserID = helper.GetInt64("UserID");
                userUnits.UserUnitID = helper.GetInt64("UserUnitID");
                userUnits.ViewRights = helper.GetBoolean("ViewRights");
                lstUserUnits.Add(userUnits);
            }

            Users users = new Users();
            users.users = lstuser;
            users.userUnits = lstUserUnits;
            json = JsonConvert.SerializeObject(users);
        }
        catch (Exception ex)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            Response.StatusDescription = ex.Message.ToString();
        }
        finally
        {
            Response.Write(json);
            Response.End();
        }
    }

    private void Save(string userJson, string mode)
    {
        try
        {
            Users users = JsonConvert.DeserializeObject<Users>(userJson);
            if (users != null && users.users.Count > 0)
            {
                User user = users.users.FirstOrDefault();
                ParameterList parameters = new ParameterList();
                parameters.Add("UserID", user.UserID, SqlDbType.BigInt);
                parameters.Add("UserName", user.UserName, SqlDbType.VarChar);
                parameters.Add("Password", Common.FromBase64(user.Password), SqlDbType.VarChar);
                parameters.Add("Email", user.Email, SqlDbType.VarChar);
                if (user.FromDate > DateTime.MinValue)
                {
                    parameters.Add("FromDate", user.FromDate, SqlDbType.DateTime);
                }
                if (user.ToDate > DateTime.MinValue)
                {
                    parameters.Add("ToDate", user.ToDate, SqlDbType.DateTime);
                }
                parameters.Add("IsApprover", user.IsApprover, SqlDbType.Bit);
                parameters.Add("IsAdmin", user.IsAdmin, SqlDbType.Bit);
                parameters.Add("Mode", mode, SqlDbType.VarChar);
                string connectionstring = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
                SqlHelper.ExecuteNonQuery(connectionstring, "PG_User_Save", CommandType.StoredProcedure, parameters);
            }
            if (users != null && users.userUnits.Count > 0)
            {
                foreach (UserUnits userUnit in users.userUnits)
                {
                    ParameterList parameters = new ParameterList();
                    parameters.Add("UserUnitID", userUnit.UserUnitID, SqlDbType.BigInt);
                    parameters.Add("Username", users.users.FirstOrDefault().UserName, SqlDbType.VarChar);
                    parameters.Add("UnitID", userUnit.UnitID, SqlDbType.VarChar);
                    parameters.Add("FullRights", userUnit.FullRights, SqlDbType.Bit);
                    parameters.Add("ViewRights", userUnit.ViewRights, SqlDbType.Bit);
                    string connectionstring = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
                    SqlHelper.ExecuteNonQuery(connectionstring, "PG_UserUnit_Save", CommandType.StoredProcedure, parameters);
                }
            }
        }
        catch (Exception ex)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            Response.StatusDescription = ex.Message;
        }
    }
}