using PG.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Int64 userId = 0;
        if (Request.QueryString["UserID"] != null)
        {
            Int64.TryParse(Request.QueryString["UserID"].ToString(), out userId);
            string password;
            if (Request.QueryString["password"] != null)
            {
                password = Request.QueryString["password"].ToString();
                UpdatePassword(userId, password);
                Response.StatusCode = (int)HttpStatusCode.Accepted;
                Response.StatusDescription = "Pasword updated";
            }
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
}