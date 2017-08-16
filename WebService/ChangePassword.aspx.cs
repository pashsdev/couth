using PG.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = string.Empty; ;
        string oldPassword = string.Empty;
        string newPassword = string.Empty;

        if (Request.QueryString["userName"] != null)
        {
            userName = Request.QueryString["UserName"].ToString();
        }
        if (Request.QueryString["oldPassword"] != null)
        {
            oldPassword = Request.QueryString["oldPassword"].ToString();
        } if (Request.QueryString["newPassword"] != null)
        {
            newPassword = Request.QueryString["newPassword"].ToString();
        }

        Int64 userID = ValidateUser(userName, oldPassword);
        if (userID > 0)
        {
            UpdatePassword(userID, newPassword);
            Response.StatusCode = (int)HttpStatusCode.Accepted;
            Response.StatusDescription = "Pasword updated";
        }
        else
        {
            Response.StatusCode = (int)HttpStatusCode.Forbidden;
            Response.StatusDescription = "User not valid or password not correct";
        }
    }

    private void UpdatePassword(Int64 userID, string password)
    {
        ParameterList parameters = new ParameterList();
        parameters.Add("UserID", userID, SqlDbType.BigInt);
        parameters.Add("Password", Common.FromBase64(password), SqlDbType.VarChar);

        string connectionstring = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
        SqlHelper.ExecuteNonQuery(connectionstring, "PG_User_UpdatePassword", CommandType.StoredProcedure, parameters);
    }

    private Int64 ValidateUser(string userName, string password)
    {
        Int64 userId = 0;
        try
        {
            ParameterList parameters = new ParameterList();
            parameters.Add("Username", userName, SqlDbType.VarChar);
            parameters.Add("Password", Common.FromBase64(password), SqlDbType.VarChar);

            string connectionstring = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();

            DataSet ds = SqlHelper.ExecuteDataSet(connectionstring, "GetValidUser", CommandType.StoredProcedure, parameters);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Int64.TryParse(ds.Tables[0].Rows[0]["UserID"].ToString(), out userId);
            }
        }
        catch (Exception ex)
        {
            userId = 0;
        }
        return userId;
    }

}