using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using TransferDatas;

namespace CouthIntegration
{
    public partial class ReprintApproval : Form
    {
        public ReprintApproval()
        {
            InitializeComponent();
            LoadUnits();

        }

        public void LoadUnits()
        {
            List<Unit> units = Common.GetUnits(0);
            Unit unit = new Unit();
            unit.UnitID = 0;
            unit.UnitName = "--All--";
            units.Insert(0, unit);
            CmbUnits.DataSource = units;
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            Grid.AutoGenerateColumns = false;
            Grid.DataSource = GetReprintRequest();
        }

        public List<Reprint> GetReprintRequest()
        {
            string webserviceURL = Common.GetWebServiceURL();
            webserviceURL = string.Concat(webserviceURL, "ReprintApproval.aspx?Approved=0");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(webserviceURL));
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            //StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
            //requestWriter.Write(postString);
            //requestWriter.Close();
            WebResponse response = null;
            string responseString = string.Empty;
            List<Reprint> lstReprint = null;
            try
            {
                response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    responseString = sr.ReadToEnd();
                }

                lstReprint = JsonConvert.DeserializeObject<List<Reprint>>(responseString);
            }
            catch (WebException ex)
            {
                if (((HttpWebResponse)ex.Response).StatusCode != HttpStatusCode.OK)
                {
                    MessageBox.Show(((HttpWebResponse)ex.Response).StatusDescription, "Reprint", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                throw;
            }
            return lstReprint;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
