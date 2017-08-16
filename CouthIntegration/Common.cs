using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using TransferDatas;

namespace CouthIntegration
{
    public class Common
    {
        public static string GetWebServiceURL()
        {
            string webserviceURL = string.Empty;
            if (Debugger.IsAttached)
            {
                webserviceURL = String.Concat(ConfigurationSettings.AppSettings["DevWebServiceURL"]);
            }
            else
            {
                webserviceURL = String.Concat(ConfigurationSettings.AppSettings["WebServiceURL"]);
            }
            return webserviceURL;
        }

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

        public static List<Unit> GetUnits(Int64 UnitID)
        {
            string webserviceURL = Common.GetWebServiceURL();
            webserviceURL = string.Concat(webserviceURL, "GetUnits.aspx?UnitId=", UnitID);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(webserviceURL));
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            //StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
            //requestWriter.Write(postString);
            //requestWriter.Close();
            WebResponse response = null;
            string responseString = string.Empty;
            List<Unit> units = null;
            UnitResponse unitResponse = null;
            try
            {
                response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    responseString = sr.ReadToEnd();
                }

                unitResponse = JsonConvert.DeserializeObject<UnitResponse>(responseString);
                units = unitResponse.LstUnits;
            }
            catch (WebException ex)
            {
                if (((HttpWebResponse)ex.Response).StatusCode != HttpStatusCode.OK)
                {
                    MessageBox.Show(((HttpWebResponse)ex.Response).StatusDescription, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                throw;
            }
            return units;
        }

        public static List<Template> GetTemplates(Int64 TemplateID)
        {
            string webserviceURL = Common.GetWebServiceURL();
            webserviceURL = string.Concat(webserviceURL, "GetTemplate.aspx?TemplateId=", TemplateID);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(webserviceURL));
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            WebResponse response = null;
            string responseString = string.Empty;
            List<Template> templates = null;
            
            try
            {
                response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    responseString = sr.ReadToEnd();
                }

                templates = JsonConvert.DeserializeObject<List<Template>>(responseString);
                
            }
            catch (WebException ex)
            {
                if (((HttpWebResponse)ex.Response).StatusCode != HttpStatusCode.OK)
                {
                    MessageBox.Show(((HttpWebResponse)ex.Response).StatusDescription, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                throw;
            }
            return templates;
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        public static Form CheckOpened(string name, string pmessage = "")
        {
            FormCollection fc = Application.OpenForms;
            Form tmpfrm = null;
            foreach (Form frm in fc)
            {
                if (frm.Name == name)
                {
                    tmpfrm = frm;
                }
            }

            return tmpfrm;
        }
    }
}
