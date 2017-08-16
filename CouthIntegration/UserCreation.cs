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
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TransferDatas;

namespace CouthIntegration
{
    public partial class UserCreation : Form
    {
        public Int64 _userID = 0;
        public UserCreation(Int64 userID)
        {
            InitializeComponent();
            //if (userID > 0)
            //{
            Users users = GetUser(userID);
            User user = null;
            if (userID > 0 && users.users != null)
            {
                if (users.users.Count > 0)
                {
                    user = users.users.FirstOrDefault();
                }
            }
            List<UserUnits> userUnits = null;
            if (users.userUnits != null)
            {
                if (users.userUnits.Count > 0)
                {
                    userUnits = users.userUnits;
                }
            }

            if (user != null)
            {
                _userID = userID;
                txtUserName.Text = user.UserName;
                txtPassword.Text = user.Password;
                txtEmail.Text = user.Email;
                if (DateTime.MinValue != user.FromDate)
                {
                    DtFrom.Value = user.FromDate;
                }
                else
                {
                    DtFrom.Checked = false;
                }
                if (DateTime.MinValue != user.ToDate)
                {
                    DtTo.Value = user.ToDate;
                }
                else
                {
                    DtTo.Checked = false;
                }
                ChkIsAdmin.Checked = user.IsAdmin;
                ChkIsApprover.Checked = user.IsApprover;
            }

            if (userUnits != null)
            {
                grid.AutoGenerateColumns = false;
                grid.DataSource = userUnits;
            }
            //}
        }

        private Users GetUser(Int64 userId)
        {
            string webserviceURL = Common.GetWebServiceURL();
            webserviceURL = string.Concat(webserviceURL, "GetUsers.aspx?UserId=", userId);
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
                    MessageBox.Show(((HttpWebResponse)ex.Response).StatusDescription, "User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                throw;
            }

            return users;

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                MessageBox.Show("Saved sucessfully!", "Unit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                UserListing listing = (UserListing)Common.CheckOpened("UserListing");
                if (listing != null)
                {
                    listing.LoadUsers();
                    listing.LoadUserGrid();
                }
            }
        }

        private bool Save()
        {
            bool retValue = false;
            if (SaveValidation())
            {
                string webserviceURL = Common.GetWebServiceURL();
                webserviceURL = string.Concat(webserviceURL, "GetUsers.aspx?cmd=Save");
                if (_userID > 0)
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
                Users users = new Users();
                User user = new User();
                user.UserName = txtUserName.Text;
                user.Password = Common.ToBase64(txtPassword.Text);
                user.Email = txtEmail.Text;
                if (DtFrom.Checked)
                {
                    user.FromDate = DtFrom.Value;
                }
                if (DtTo.Checked)
                {
                    user.ToDate = DtTo.Value;
                }
                user.IsAdmin = ChkIsAdmin.Checked;
                user.IsApprover = ChkIsApprover.Checked;
                user.UserID = _userID;

                List<UserUnits> lstUserUnits = new List<UserUnits>();
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.Cells["DgvColFull"] != null && row.Cells["DgvColView"] != null)
                    {
                        UserUnits userunits = new UserUnits();
                        userunits.FullRights = Convert.ToBoolean(row.Cells["DgvColFull"].Value);
                        userunits.ViewRights = Convert.ToBoolean(row.Cells["DgvColView"].Value);
                        userunits.UnitID = Convert.ToInt64(row.Cells["DgvColUnitID"].Value);
                        userunits.UserID = _userID;
                        userunits.UserUnitID = Convert.ToInt64(row.Cells["DgvColUserUnitID"].Value);
                        lstUserUnits.Add(userunits);
                    }
                }
                List<User> lstUser = new List<User>();
                lstUser.Add(user);
                users.users = lstUser;
                users.userUnits = lstUserUnits;

                string postString = JsonConvert.SerializeObject(users);

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
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "Enter User name");
                retValue = false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Enter password");
                retValue = false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Enter E-mail");
                retValue = false;
            }
            else
            {
                Regex mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                if (!mRegxExpression.IsMatch(txtEmail.Text.Trim()))
                {
                    errorProvider1.SetError(txtEmail, "E-mail address format is not correct.");
                    retValue = false;
                }
            }

            return retValue;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
