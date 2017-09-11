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
    public partial class ReprintApproval : Form
    {
        private List<Unit> _units = new List<Unit>();
        public ReprintApproval()
        {
            InitializeComponent();
            LoadUnits();
            LoadRequestNo();
        }

        public void LoadRequestNo()
        {
            List<ReprintMaster> masters = Common.GetReprintMaster("", "", "", 0, 0, DateTime.MinValue, DateTime.MinValue);
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

        private void BtnList_Click(object sender, EventArgs e)
        {
            if (ValidateSearch())
            {
                Int64 unitID = 0;
                Int64.TryParse(CmbUnits.SelectedValue.ToString(), out unitID);

                Int64 reprintID = 0;
                Int64.TryParse(CmbRequestNo.SelectedValue.ToString(), out reprintID);

                Grid.AutoGenerateColumns = false;
                Grid.DataSource = Common.GetReprintDetails(txtJobNo.Text, "", "", unitID, reprintID, DateTime.MinValue, DateTime.MinValue, 0);
            }
        }

        private bool ValidateSearch()
        {
            if (CmbUnits.SelectedIndex <= 0)
            {
                MessageBox.Show("Select Unit", "Search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CmbUnits.Focus();
                return false;
            }
            return true;
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
                if (Debugger.IsAttached)
                {
                    webserviceURL = string.Concat(webserviceURL, "ReprintApprovalLocal.aspx?cmd=Save");
                }
                else
                {
                    webserviceURL = string.Concat(webserviceURL, "ReprintApproval.aspx?cmd=Save");
                }
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(webserviceURL);
                request.Method = "Post";
                request.ContentType = "application/x-www-form-urlencoded";

                Int64 unitID = 0;
                Int64.TryParse(CmbUnits.SelectedValue.ToString(), out unitID);
                Int64 oracleUnitID = 0;
                if (unitID > 0)
                {
                    oracleUnitID = _units.Where(x => x.UnitID == unitID).Select(x => x.OracleUnitID).FirstOrDefault();
                }

                List<ReprintDetails> lstreprint = new List<ReprintDetails>();
                foreach (DataGridViewRow row in Grid.Rows)
                {
                    if (row.Cells["DgvColStatus"].Value != null && !string.IsNullOrEmpty(row.Cells["DgvColStatus"].Value.ToString()))
                    {
                        ReprintDetails reprint = new ReprintDetails();
                        Int64 reprintID = 0;
                        Int64.TryParse(Common.GetValue(row.Cells["DgvColReprintDetailsID"]), out reprintID);

                        reprint.ApprovedStatus = Common.GetValue(row.Cells["DgvColStatus"]);
                        reprint.ReprintID = reprintID;
                        reprint.ApprovedBy = Common.UserID;
                        reprint.ApprovalRemarks = Common.GetValue(row.Cells["DgvColRejRemarks"]);
                        reprint.Serial_Number = Common.GetValue(row.Cells["DgvColSerialNo"]);
                        reprint.Code = Common.GetValue(row.Cells["DgvColCode"]);
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
                if (row.Cells["DgvColStatus"].Value != null && !string.IsNullOrEmpty(row.Cells["DgvColStatus"].Value.ToString()))
                {
                    selected = true;
                }
            }
            if (!selected)
            {
                MessageBox.Show("Please approve any one reprint");
                return false;
            }
            return true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)Grid.Rows[e.RowIndex].Cells["DgvColStatus"];
                if (cb.Value != null)
                {
                    DataGridViewTextBoxCell remarksCell = (DataGridViewTextBoxCell)Grid.Rows[e.RowIndex].Cells["DgvColRejRemarks"];
                    if (cb.Value.ToString().ToLower() == "rejected")
                    {
                        remarksCell.ReadOnly = false;
                    }
                    else
                    {
                        remarksCell.ReadOnly = true;
                    }
                    //Grid.Invalidate();
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
