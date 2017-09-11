using System;
using System.Data;
using PG.Helper;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;
using TransferDatas;
using System.Net;

public partial class Validate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = Request.Form["UserName"].ToString();
        string password = Request.Form["Password"].ToString();

        ValidateUser(userName, password);
    }

    private void ValidateUser(string userName, string password)
    {
        string json = string.Empty;
        try
        {
            ParameterList parameters = new ParameterList();
            parameters.Add("Username", userName, SqlDbType.VarChar);
            parameters.Add("Password", password, SqlDbType.VarChar);

            string connectionstring = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();

            DataSet ds = SqlHelper.ExecuteDataSet(connectionstring, "GetValidUser", CommandType.StoredProcedure, parameters);
            User user = null;
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                user = new User();
                Int64 userID;
                Int64.TryParse(ds.Tables[0].Rows[0]["UserID"].ToString(), out userID);
                user.UserID = userID;

                user.IsAdmin = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsAdmin"]);
                user.IsApprover = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsApprover"]);
            }
            json = JsonConvert.SerializeObject(user);
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
