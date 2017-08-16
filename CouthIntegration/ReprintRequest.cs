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
    public partial class ReprintRequest : Form
    {
        public ReprintRequest()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            List<Template> templates = Common.GetTemplates(0);

            DataGridViewComboBoxColumn CmbTemplate = (DataGridViewComboBoxColumn)Grid.Columns["DgvColTemplate"];
            CmbTemplate.DataSource = templates;
            CmbTemplate.DisplayMember = "TemplateName";
            CmbTemplate.ValueMember = "TemplateID";

            Grid.AutoGenerateColumns = false;
            Grid.DataSource = GetReprintRequest("", txtSerialNoFrom.Text, txtSerialNoTo.Text);
        }

        public List<Search> GetReprintRequest(string Jobno, string SerialNoFrom, string SerialNoTo)
        {
            string webserviceURL = Common.GetWebServiceURL();
            webserviceURL = string.Concat(webserviceURL, "GetPrintData.aspx");
            string qs = string.Format("&jobno={0}&serialnofrom={1}&serialnoto={2}", Jobno, SerialNoFrom, SerialNoTo);
            webserviceURL = string.Concat(webserviceURL, "?Approved=0", qs);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(webserviceURL));
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            //StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
            //requestWriter.Write(postString);
            //requestWriter.Close();
            WebResponse response = null;
            string responseString = string.Empty;
            List<Search> lstSearch = null;
            try
            {
                response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    responseString = sr.ReadToEnd();
                }

                lstSearch = JsonConvert.DeserializeObject<List<Search>>(responseString);
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
            return lstSearch;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                MessageBox.Show("Saved sucessfully!", "Unit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private bool Save()
        {
            bool retValue = false;
            if (SaveValidation())
            {
                string webserviceURL = Common.GetWebServiceURL();
                webserviceURL = string.Concat(webserviceURL, "Reprint.aspx?cmd=Save");

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(webserviceURL));
                request.Method = "Post";
                request.ContentType = "application/x-www-form-urlencoded";

                List<Reprint> lstreprint = new List<Reprint>();
                foreach (DataGridViewRow row in Grid.Rows)
                {
                    if (row.Cells["DgvColMark"].Value != null && Convert.ToBoolean(row.Cells["DgvColMark"].Value.ToString()))
                    {
                        Reprint reprint = new Reprint();
                        reprint.Description = row.Cells["DgvColDesc"].Value.ToString();
                        reprint.Jobnumber = row.Cells["DgvColJobno"].Value.ToString();
                        reprint.Item_Code = row.Cells["DgvColItemCode"].Value.ToString();
                        reprint.RequestNo = "1";
                        reprint.RequestUserID = 1;
                        reprint.Serial_Number = row.Cells["DgvColSerialNo"].Value.ToString();

                        lstreprint.Add(reprint);
                    }
                }


                string postString = JsonConvert.SerializeObject(lstreprint);

                StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
                requestWriter.Write(postString);
                requestWriter.Close();
                WebResponse response = null;
                string responseString = string.Empty;
                try
                {
                    response = request.GetResponse();
                    retValue = true;
                }
                catch (WebException ex)
                {
                    if (((HttpWebResponse)ex.Response).StatusCode != HttpStatusCode.OK)
                    {
                        MessageBox.Show(((HttpWebResponse)ex.Response).StatusDescription, "Reprint Request", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    throw;
                }

            }

            return retValue;
        }

        private bool SaveValidation()
        {
            return true;
        }
    }
}
