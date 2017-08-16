using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Common
/// </summary>
public class Common
{
    public static string ToBase64(string data)
    {
        string retValue = string.Empty;
        if (!string.IsNullOrEmpty(data))
        {
            retValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
        }

        return retValue;
    }

    public static string FromBase64(string data)
    {
        string retValue = string.Empty;
        if (!string.IsNullOrEmpty(data))
        {
            retValue = Encoding.UTF8.GetString(Convert.FromBase64String(data));
        }

        return retValue;
    }

    public static string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.AppSettings["OracleConStr"].ToString();
    }

    public static string GetSQLConnectionString()
    {
        return System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
    }
}