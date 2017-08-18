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
    public partial class ReprintRequestListing : Form
    {
        List<Unit> _units = new List<Unit>();
        public ReprintRequestListing()
        {
            InitializeComponent();
            LoadUnits();
            LoadRequestNo();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ReprintRequest request = new ReprintRequest(0);
            request.ShowDialog();
        }

        public void LoadRequestNo()
        {
            List<ReprintMaster> masters = GetReprintMaster();
            if (masters != null)
            {
                ReprintMaster master = new ReprintMaster();
                master.ReprintID = 0;
                master.ReprintNo = "--All--";
                masters.Insert(0, master);
            }
            CmbRequestNo.DataSource = masters;
        }

        public void LoadUnits()
        {
            _units = Common.GetUnits(0);
            Unit unit = new Unit();
            unit.UnitID = 0;
            unit.UnitName = "--All--";
            _units.Insert(0, unit);
            CmbUnits.DataSource = _units;
        }

        public List<ReprintMaster> GetReprintMaster()
        {
            string webserviceURL = Common.GetWebServiceURL();
            webserviceURL = string.Concat(webserviceURL, "Reprint.aspx?cmd=reprintmaster");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(webserviceURL));
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";

            WebResponse response = null;
            string responseString = string.Empty;
            List<ReprintMaster> lstReprint = null;
            try
            {
                response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    responseString = sr.ReadToEnd();
                }

                lstReprint = JsonConvert.DeserializeObject<List<ReprintMaster>>(responseString);
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
            if (ValidateSearch())
            {
                Int64 unitID = 0;
                Int64.TryParse(CmbUnits.SelectedValue.ToString(), out unitID);
               
                Int64 reprintID = 0;
                Int64.TryParse(CmbRequestNo.SelectedValue.ToString(), out reprintID);
                Grid.AutoGenerateColumns = false;
                Grid.DataSource = GetReprintListing(txtJobNo.Text, txtSerialNoFrom.Text, txtSerialNoTo.Text, unitID, reprintID, DtFrom.Value, DtTo.Value);
            }
        }

        public List<ReprintMaster> GetReprintListing(string Jobno, string SerialNoFrom, string SerialNoTo, Int64 oracleUnitID, Int64 ReprintID, DateTime FromDt, DateTime ToDate)
        {
            string webserviceURL = Common.GetWebServiceURL();
            webserviceURL = string.Concat(webserviceURL, "Reprint.aspx");
            string qs = string.Format("&jobno={0}&serialnofrom={1}&serialnoto={2}&oracleUnitID={3}&reprintid={4}&FromDt={5}&ToDate={6}"
                , Jobno, SerialNoFrom, SerialNoTo, oracleUnitID, ReprintID, FromDt, ToDate);
            webserviceURL = string.Concat(webserviceURL, "?cmd=listing", qs);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(webserviceURL));
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            WebResponse response = null;
            string responseString = string.Empty;
            List<ReprintMaster> lstReprint = null;
            try
            {
                response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    responseString = sr.ReadToEnd();
                }

                lstReprint = JsonConvert.DeserializeObject<List<ReprintMaster>>(responseString);
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

        private bool ValidateSearch()
        {
            if (RadJobno.Checked && string.IsNullOrEmpty(txtJobNo.Text.Trim()))
            {
                MessageBox.Show("Enter Job No", "Search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtJobNo.Focus();
                return false;
            }
            if (RadSerialNo.Checked)
            {
                if (string.IsNullOrEmpty(txtSerialNoFrom.Text.Trim()))
                {
                    MessageBox.Show("Enter Serial No From", "Search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtSerialNoFrom.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtSerialNoTo.Text.Trim()))
                {
                    MessageBox.Show("Enter Serial No To", "Search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtSerialNoTo.Focus();
                    return false;
                }
            }
            if (CmbUnits.SelectedIndex <= 0)
            {
                MessageBox.Show("Select Unit", "Search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CmbUnits.Focus();
                return false;
            }

            return true;
        }
    }
}
