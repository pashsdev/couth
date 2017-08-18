using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using TransferDatas;

namespace CouthIntegration
{
    public partial class PrintData : Form
    {
        string _fileDirectory = "D:\\Marking";
        string _fileName = "text.txt";
        List<Template> _templates = new List<Template>();
        List<Unit> _units = new List<Unit>();
        public PrintData()
        {
            InitializeComponent();
            loadFilter();
            RadJobno.Checked = true;
        }

        private void loadFilter()
        {
            //List<Search> jobnos = GetSearchDetails("", "", "");
            //Search search = new Search();
            //search.JobNo = "--All--";
            //if (jobnos != null)
            //{
            //    jobnos.Insert(0, search);
            //}
            //CmbJobNo.DataSource = jobnos;

            _units = Common.GetUnits(0);
            CmbUnits.DataSource = _units;

            List<Template> templates = Common.GetTemplates(0);
            CmbTemplate.DataSource = templates;
            _templates = templates;
        }

        private void BtnPrintPreview_Click(object sender, EventArgs e)
        {

        }

        public List<Search> GetSearchDetails(string Jobno, string SerialNoFrom, string SerialNoTo, Int64 oracleUnitID)
        {
            string webserviceURL = Common.GetWebServiceURL();

            string qs = string.Format("?jobno={0}&serialnofrom={1}&serialnoto={2}&oracleunitid={3}", Jobno, SerialNoFrom, SerialNoTo, oracleUnitID);
            if (Debugger.IsAttached)
            {
                webserviceURL = string.Concat(webserviceURL, "GetPrintDataLocal.aspx", qs);
            }
            else
            {
                webserviceURL = string.Concat(webserviceURL, "GetPrintData.aspx", qs);
            }
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
                    MessageBox.Show(((HttpWebResponse)ex.Response).StatusDescription, "Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                throw;
            }
            return lstSearch;
        }

        public List<Reprintable> GetReprintRequest()
        {
            string webserviceURL = Common.GetWebServiceURL();
            webserviceURL = string.Concat(webserviceURL, "Reprint.aspx?Approved=0");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(webserviceURL));
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            //StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
            //requestWriter.Write(postString);
            //requestWriter.Close();
            WebResponse response = null;
            string responseString = string.Empty;
            List<Reprintable> lstReprint = null;
            try
            {
                response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    responseString = sr.ReadToEnd();
                }

                lstReprint = JsonConvert.DeserializeObject<List<Reprintable>>(responseString);
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

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string jobno = string.Empty;
            if (ValidateSearch())
            {
                //if (CmbJobNo.SelectedIndex > 0)
                //{
                //jobno = CmbJobNo.Text;
                jobno = txtJobNo.Text;
                //}
                Int64 unitID = 0;
                Int64.TryParse(CmbUnits.SelectedValue.ToString(), out unitID);
                Int64 oracleUnitID = 0;
                if (unitID > 0)
                {
                    oracleUnitID = _units.Where(x => x.UnitID == unitID).Select(x => x.OracleUnitID).FirstOrDefault();
                }
                List<Search> lstSearch = GetSearchDetails(jobno, txtSerialNoFrom.Text, txtSerialNoTo.Text, oracleUnitID);

                //List<Reprint> lstPrinted = GetReprintRequest();

                //lstSearch = lstSearch.Where(x => x.JobNo == (lstPrinted.Select(y => y.Jobnumber)));
                Grid.AutoGenerateColumns = false;
                Grid.DataSource = lstSearch;
            }
        }

        private bool ValidateSearch()
        {
            bool retValue = true;
            //if (RadJobno.Checked && CmbJobNo.SelectedIndex <= 0)
            if (RadJobno.Checked && string.IsNullOrEmpty(txtJobNo.Text.Trim()))
            {
                MessageBox.Show("Enter Job No", "Search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtJobNo.Focus();
                retValue = false;
            }
            if (RadSerialNo.Checked)
            {
                if (string.IsNullOrEmpty(txtSerialNoFrom.Text.Trim()))
                {
                    MessageBox.Show("Enter Serial No From", "Search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtSerialNoFrom.Focus();
                    retValue = false;
                }
                else if (string.IsNullOrEmpty(txtSerialNoTo.Text.Trim()))
                {
                    MessageBox.Show("Enter Serial No To", "Search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtSerialNoTo.Focus();
                    retValue = false;
                }
            }
            return retValue;
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            Save();
            Int64 templateID = 0;
            Int64.TryParse(CmbTemplate.SelectedValue.ToString(), out templateID);
            string templateText = _templates.Where(x => x.TemplateID == templateID).Select(x => x.TemplateText).FirstOrDefault();
            PrintPreview preview = new PrintPreview(Grid, templateText);
            preview.ShowDialog();
            //StringBuilder template = new StringBuilder();

            //string _filePath = Path.Combine(Application.StartupPath, _fileName);

            //foreach (DataGridViewRow row in Grid.Rows)
            //{
            //    if (row.Cells["DgvColJobno"] != null && row.Cells["DgvColMark"].Value != null && Convert.ToBoolean(row.Cells["DgvColMark"].Value))
            //    {
            //        StringBuilder jobnos = new StringBuilder(templateText);
            //        jobnos = jobnos.Replace("[@jobno@]", row.Cells["DgvColJobno"].Value.ToString());
            //        jobnos = jobnos.Replace("[@serialno@]", row.Cells["DgvColSerialNo"].Value.ToString());
            //        template.Append(jobnos.ToString());
            //        template.Append(Environment.NewLine);
            //    }
            //}

            //try
            //{
            //    //if (!Directory.Exists(_fileDirectory))
            //    //{
            //    //    Directory.CreateDirectory(_fileDirectory);
            //    //}

            //    File.WriteAllText(_filePath, template.ToString());
            //}
            //catch
            //{
            //    throw new Exception("Path not valid");
            //}

            //Process process = new Process();
            //ProcessWindowStyle windowStyle = ProcessWindowStyle.Hidden;
            //process.StartInfo = new ProcessStartInfo(Path.Combine(Application.StartupPath, "COMMT2_2.exe"))
            //{
            //    WorkingDirectory = Path.GetDirectoryName(Application.StartupPath),
            //    UseShellExecute = false,
            //    RedirectStandardInput = true,
            //    RedirectStandardOutput = true,
            //    RedirectStandardError = true,
            //    WindowStyle = windowStyle,
            //    //Verb = "runas",
            //    CreateNoWindow = (windowStyle == ProcessWindowStyle.Hidden)
            //};
            //process.Start();
        }

        private Boolean Save()
        {
            bool retValue = false;
            if (SaveValidation())
            {
                string webserviceURL = Common.GetWebServiceURL();
                if (Debugger.IsAttached)
                {
                    webserviceURL = string.Concat(webserviceURL, "GetPrintDataLocal.aspx?cmd=Save");
                }
                else
                {
                    webserviceURL = string.Concat(webserviceURL, "GetPrintData.aspx?cmd=Save");
                }
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(webserviceURL));
                request.Method = "Post";
                request.ContentType = "application/x-www-form-urlencoded";
                List<Search> lstSearch = new List<Search>();
                foreach (DataGridViewRow row in Grid.Rows)
                {
                    if (row.Cells["DgvColMark"].Value != null && Convert.ToBoolean(row.Cells["DgvColMark"].Value))
                    {
                        Search searchRequest = new Search();
                        if (row.Cells["DgvColItemID"].Value != null)
                        {
                            Int64 itemID = 0;
                            Int64.TryParse(row.Cells["DgvColItemID"].Value.ToString(), out itemID);
                            searchRequest.Inventory_Item_Id = itemID;
                        }
                        searchRequest.JobNo = row.Cells["DgvColJobno"].Value.ToString();
                        searchRequest.Product = row.Cells["DgvColProduct"].Value.ToString();
                        searchRequest.ProductDesc = row.Cells["DgvColDesc"].Value.ToString();
                        searchRequest.SerialNo = row.Cells["DgvColSerialNo"].Value.ToString();
                        if (row.Cells["DgvColTemplate"].Value != null)
                        {
                            searchRequest.Template = row.Cells["DgvColTemplate"].Value.ToString();
                        }
                        searchRequest.Printed = true;
                        lstSearch.Add(searchRequest);
                    }
                }

                string postString = JsonConvert.SerializeObject(lstSearch);

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
                        MessageBox.Show(((HttpWebResponse)ex.Response).StatusDescription, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            bool retValue = true;
            return retValue;
        }

        private void RadJobno_CheckedChanged(object sender, EventArgs e)
        {
            if (RadJobno.Checked)
            {
                lblJobno.Text = "Job No *";
            }
            else
            {
                lblJobno.Text = "Job No";
            }
        }

        private void RadSerialNo_CheckedChanged(object sender, EventArgs e)
        {
            if (RadSerialNo.Checked)
            {
                lblSerialNoFrom.Text = "Serial No From *";
                lblSerialNoTo.Text = "Serial No To *";
            }
            else
            {
                lblSerialNoFrom.Text = "Serial No From";
                lblSerialNoTo.Text = "Serial No To";
            }
        }

        private void ChkMarkOdd_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Grid.Rows.Count; i++)
            {
                if (!Common.IsOdd(i))
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)Grid.Rows[i].Cells["DgvColMark"];
                    chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
                }
            }
        }

        private void ChkMarkEven_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Grid.Rows.Count; i++)
            {
                if (Common.IsOdd(i))
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)Grid.Rows[i].Cells["DgvColMark"];
                    chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
                }
            }
        }

        private void ChkMarkAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Grid.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)Grid.Rows[i].Cells["DgvColMark"];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            RadJobno.Checked = true;
            txtSerialNoFrom.Text = "";
            txtSerialNoTo.Text = "";
            txtJobNo.Text = "";
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Grid.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)Grid.Rows[i].Cells["DgvColMark"];
                chk.Value = false;
            }
        }
    }
}
