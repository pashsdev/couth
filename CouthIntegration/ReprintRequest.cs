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
    public partial class ReprintRequest : Form
    {
        List<Unit> _units = new List<Unit>();
        public ReprintRequest(Int64 ReprintID)
        {
            InitializeComponent();
            LoadUnits();
            LoadTemplate();
            if (ReprintID <= 0)
            {
                GenerateRequestNo();
            }
            else
            {
                LoadEditDetails(ReprintID);
                BtnSave.Enabled = false;
            }
        }

        private void LoadEditDetails(Int64 reprintID)
        {
            LoadTemplate();


            List<ReprintMaster> reprintMaster = Common.GetReprintMaster("", "", "", 0, reprintID, DateTime.MinValue, DateTime.MinValue);
            if (reprintMaster.Count > 0)
            {
                txtRequestNo.Text = reprintMaster[0].ReprintNo;
                CmbUnits.SelectedValue = reprintMaster[0].UnitID;
                CmbUnits.Enabled = false;
            }

            List<ReprintDetails> details = Common.GetReprintDetails("", "", "", 0, reprintID, DateTime.MinValue, DateTime.MinValue);
            Grid.AutoGenerateColumns = false;
            Grid.DataSource = details;
        }

        private void LoadTemplate()
        {
            List<Template> templates = Common.GetTemplates(0);

            DataGridViewComboBoxColumn CmbTemplate = (DataGridViewComboBoxColumn)Grid.Columns["DgvColTemplate"];
            CmbTemplate.DataSource = templates;
            CmbTemplate.DisplayMember = "TemplateName";
            CmbTemplate.ValueMember = "TemplateID";
        }

        private void GenerateRequestNo()
        {
            string webserviceURL = Common.GetWebServiceURL();
            webserviceURL = string.Concat(webserviceURL, "Reprint.aspx?cmd=requestno");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(webserviceURL));
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";

            WebResponse response = null;
            string responseString = string.Empty;
            try
            {
                response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    responseString = sr.ReadToEnd();
                }

                txtRequestNo.Text = responseString;
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

        private bool ValidateSearch()
        {
            //if (RadJobno.Checked && CmbJobNo.SelectedIndex <= 0)
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

            if (CmbCode.SelectedIndex < 0)
            {
                MessageBox.Show("Select Code", "Search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CmbCode.Focus();
                return false;
            }
            if (CmbUnits.SelectedIndex <= 0)
            {
                MessageBox.Show("Select Unit", "Search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CmbUnits.Focus();
                return false;
            }
            return true;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (ValidateSearch())
            {
                Int64 unitID = 0;
                Int64.TryParse(CmbUnits.SelectedValue.ToString(), out unitID);
                Int64 oracleUnitID = 0;
                string code = CmbCode.Text;
                if (unitID > 0)
                {
                    oracleUnitID = _units.Where(x => x.UnitID == unitID).Select(x => x.OracleUnitID).FirstOrDefault();
                }

                Grid.AutoGenerateColumns = false;
                Grid.DataSource = Common.GetReprintableRequest(txtJobNo.Text, txtSerialNoFrom.Text, txtSerialNoTo.Text, oracleUnitID, code);
            }
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
                Int64 unitID = 0;
                Int64.TryParse(CmbUnits.SelectedValue.ToString(), out unitID);
                Int64 oracleUnitID = 0;
                if (unitID > 0)
                {
                    oracleUnitID = _units.Where(x => x.UnitID == unitID).Select(x => x.OracleUnitID).FirstOrDefault();
                }
                string webserviceURL = Common.GetWebServiceURL();
                webserviceURL = string.Concat(webserviceURL, "Reprint.aspx?cmd=Save");
                string qs = string.Format("&ReprintNo={0}&RequestUserID={1}&UnitID={2}", txtRequestNo.Text, Common.UserID, unitID);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(webserviceURL, qs));
                request.Method = "Post";
                request.ContentType = "application/x-www-form-urlencoded";

                List<ReprintDetails> lstreprint = new List<ReprintDetails>();
                foreach (DataGridViewRow row in Grid.Rows)
                {
                    if (row.Cells["DgvColMark"].Value != null && Convert.ToBoolean(row.Cells["DgvColMark"].Value.ToString()))
                    {
                        ReprintDetails reprint = new ReprintDetails();
                        reprint.ReprintNo = txtRequestNo.Text;
                        reprint.Serial_Number = row.Cells["DgvColSerialNo"].Value.ToString();
                        reprint.Jobnumber = row.Cells["DgvColJobno"].Value.ToString();
                        reprint.Item_Code = row.Cells["DgvColItemCode"].Value.ToString();
                        reprint.Description = row.Cells["DgvColDesc"].Value.ToString();
                        Int64 templateID = 0;
                        Int64.TryParse(row.Cells["DgvColTemplate"].Value.ToString(), out templateID);
                        reprint.TemplateID = templateID;
                        reprint.Remarks = row.Cells["DgvColRemarks"].Value.ToString();
                        reprint.Code = CmbCode.Text;
                        reprint.OracleUnitID = oracleUnitID;
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
            bool selected = false;
            foreach (DataGridViewRow row in Grid.Rows)
            {
                if (row.Cells["DgvColMark"].Value != null && Convert.ToBoolean(row.Cells["DgvColMark"].Value.ToString()))
                {
                    selected = true;
                }
            }
            if (!selected)
            {
                MessageBox.Show("Please select any serial number to reprint");
                return false;
            }
            return true;
        }

        private void ChkMarkOdd_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkMarkEven_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkMarkAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void RdMarkOdd_CheckedChanged(object sender, EventArgs e)
        {
            if (RdMarkOdd.Checked)
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
        }

        private void RdMarkEven_CheckedChanged(object sender, EventArgs e)
        {
            if (RdMarkEven.Checked)
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
        }

        private void RdMarkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (RdMarkAll.Checked)
            {
                for (int i = 0; i < Grid.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)Grid.Rows[i].Cells["DgvColMark"];
                    chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
                }
            }
        }

        private void CmbUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int64 unitID = 0;
            Int64.TryParse(CmbUnits.SelectedValue.ToString(), out unitID);
            BtnSave.Enabled = Common.HasRights(unitID);
        }
    }
}
