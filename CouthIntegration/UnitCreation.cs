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
    public partial class UnitCreation : Form
    {
        public Int64 _unitID = 0;
        public List<Unit> _units = new List<Unit>();
        public UnitCreation(Int64 UnitID)
        {
            InitializeComponent();
            List<Unit> units = GetUnits(UnitID);
            _units = units;

            if (UnitID > 0)
            {
                if (units != null && units.Count > 0)
                {
                    _unitID = UnitID;
                    txtUnit.Text = units[0].UnitName;
                    txtOracleUnitID.Text = units[0].OracleUnitID.ToString();
                    chkActive.Checked = units[0].Active;
                }
            }

            //List<Designation> designations = new List<Designation>();
            //Designation designation = new Designation();
            //designation.DesignationID = 1;
            //designation.DesignationName = "Sr. Manager";
            //designations.Add(designation);

            //designation = new Designation();
            //designation.DesignationID = 2;
            //designation.DesignationName = "Manager";
            //designations.Add(designation);

            //designation = new Designation();
            //designation.DesignationID = 3;
            //designation.DesignationName = "Supervisor";
            //designations.Add(designation);

            //DataGridViewComboBoxColumn CmbDesignation = (DataGridViewComboBoxColumn)Grid.Columns["DgvColDesignation"];
            //CmbDesignation.DataSource = designations;
            //CmbDesignation.DisplayMember = "DesignationName";
            //CmbDesignation.ValueMember = "DesignationID";

            Users users = GetUsers(0);
            List<User> user = users.users.Where(x => x.IsApprover).ToList();
            DataGridViewComboBoxColumn CmbApprover = (DataGridViewComboBoxColumn)Grid.Columns["DgvColApprover"];
            CmbApprover.DataSource = user;
            CmbApprover.DisplayMember = "UserName";
            CmbApprover.ValueMember = "UserID";


        }

        public Users GetUsers(Int64 UserID)
        {
            string webserviceURL = Common.GetWebServiceURL();
            webserviceURL = string.Concat(webserviceURL, "GetUsers.aspx?UserId=", UserID);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(webserviceURL));
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            //StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
            //requestWriter.Write(postString);
            //requestWriter.Close();
            WebResponse response = null;
            string responseString = string.Empty;
            Users users = null;
            try
            {
                response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    responseString = sr.ReadToEnd();
                }

                users = JsonConvert.DeserializeObject<Users>(responseString);
            }
            catch (WebException ex)
            {
                if (((HttpWebResponse)ex.Response).StatusCode != HttpStatusCode.OK)
                {
                    MessageBox.Show(((HttpWebResponse)ex.Response).StatusDescription, "Unit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                throw;
            }
            return users;
        }

        public List<Unit> GetUnits(Int64 UnitID)
        {
            string webserviceURL = Common.GetWebServiceURL();
            webserviceURL = string.Concat(webserviceURL, "GetUnits.aspx?UserID=" , Common.UserID , "&UnitId=", UnitID);
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

                //DataGridViewComboBoxColumn CmbDesignation = (DataGridViewComboBoxColumn)Grid.Columns["DgvColDesignation"];
                //CmbDesignation.DataSource = unitResponse.Designations;
                //CmbDesignation.DisplayMember = "DesignationName";
                //CmbDesignation.ValueMember = "DesignationID";

                DataGridViewComboBoxColumn CmbApprover = (DataGridViewComboBoxColumn)Grid.Columns["DgvColApprover"];
                CmbApprover.DataSource = unitResponse.Users;
                CmbApprover.DisplayMember = "UserName";
                CmbApprover.ValueMember = "UserID";

                Grid.AutoGenerateColumns = false;
                Grid.DataSource = unitResponse.UnitRights;

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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                MessageBox.Show("Saved sucessfully!", "Unit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UnitListing listing = (UnitListing)Common.CheckOpened("UnitListing");
                if (listing != null)
                {
                    listing.LoadUnits();
                    listing.LoadUnitGrid();
                }
                this.Close();
            }
        }

        private bool Save()
        {
            bool retValue = false;
            if (SaveValidation())
            {
                string webserviceURL = Common.GetWebServiceURL();
                webserviceURL = string.Concat(webserviceURL, "GetUnits.aspx?cmd=Save");
                if (_unitID > 0)
                {
                    webserviceURL = string.Concat(webserviceURL, "&mode=u");
                }
                else
                {
                    webserviceURL = string.Concat(webserviceURL, "&mode=I");
                }
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(webserviceURL));
                request.Method = "Post";
                request.ContentType = "application/x-www-form-urlencoded";
                request.KeepAlive = false;
                Unit unit = new Unit();
                unit.UnitName = txtUnit.Text;
                unit.UnitID = _unitID;
                unit.Active = chkActive.Checked;
                unit.OracleUnitID = Convert.ToInt64(txtOracleUnitID.Text);
                List<UnitRight> unitRights = new List<UnitRight>();
                foreach (DataGridViewRow row in Grid.Rows)
                {
                    if (row.Cells["DgvColDesignation"].Value != null && row.Cells["DgvColApprover"].Value != null)
                    {
                        Int64 unitRightsID = 0;
                        Int64 designationID = 0;
                        Int64 userID = 0;
                        bool isAvailable = false;

                        Int64.TryParse(string.Concat(row.Cells["DgvColUnitRightsID"].Value), out unitRightsID);
                        Int64.TryParse(row.Cells["DgvColDesignationID"].Value.ToString(), out designationID);
                        Int64.TryParse(row.Cells["DgvColApprover"].Value.ToString(), out userID);
                        if (row.Cells["DgvColAvailable"].Value != null)
                        {
                            bool.TryParse(string.Concat(row.Cells["DgvColAvailable"].Value), out isAvailable);
                        }
                        UnitRight unitright = new UnitRight();
                        unitright.UnitRightsID = unitRightsID;
                        unitright.Available = isAvailable;
                        unitright.DesignationID = designationID;
                        unitright.UserID = userID;
                        unitright.UnitID = unit.UnitID;

                        unitRights.Add(unitright);
                    }
                }
                UnitRequest requestUnit = new UnitRequest();
                requestUnit.unit = unit;
                requestUnit.UnitRights = unitRights;
                string postString = JsonConvert.SerializeObject(requestUnit);

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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //catch (WebException ex)
                //{
                //    if (((HttpWebResponse)ex.Response).StatusCode != HttpStatusCode.OK)
                //    {
                //        MessageBox.Show(string.Concat(ex.Message, Environment.NewLine, ex.StackTrace), "Unit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
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
            if (string.IsNullOrEmpty(txtUnit.Text))
            {
                errorProvider1.SetError(txtUnit, "Enter Unit name");
                retValue = false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (_unitID == 0 && ChkDuplicate())
            {
                errorProvider1.SetError(txtUnit, "Unit already exists");
                retValue = false;
            }

            if (String.IsNullOrEmpty(txtOracleUnitID.Text))
            {
                errorProvider1.SetError(txtOracleUnitID, "Enter Oracle UnitID");
                retValue = false;
            }

            return retValue;
        }

        private bool ChkDuplicate()
        {
            bool retValue = false;
            if (_units.Where(x => x.UnitName == txtUnit.Text).ToList().Count > 0)
            {
                retValue = true;
            }

            return retValue;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOracleUnitID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null)
            {
                //MessageBox.Show(e.Exception.Message);
            }
        }

    }

    public class UnitRequest
    {
        public Unit unit { get; set; }
        public List<UnitRight> UnitRights { get; set; }
    }

}
