using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace CouthIntegration
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                string webserviceURL = Common.GetWebServiceURL();
                webserviceURL = string.Concat(webserviceURL, "ChangePassword.aspx?");
                string qs = string.Format("username={0}&oldpassword={1}&newpassword={2}", txtUser.Text, Common.ToBase64(txtOldPassword.Text), Common.ToBase64(txtNewPassword.Text));
                webserviceURL = string.Concat(webserviceURL, qs);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(webserviceURL));
                request.ContentType = "application/x-www-form-urlencoded";
                WebResponse response = null;
                string responseString = string.Empty;
                try
                {
                    response = request.GetResponse();
                    if (((HttpWebResponse)response).StatusCode == HttpStatusCode.Accepted)
                    {
                        MessageBox.Show("Password updated", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
        }

        private bool Validation()
        {
            bool retValue = true;
            if (string.IsNullOrEmpty(txtUser.Text.Trim()))
            {
                errorProvider1.SetError(txtUser, "Enter User name");
                retValue = false;
            }
            
            if (string.IsNullOrEmpty(txtOldPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtOldPassword, "Enter old password");
                retValue = false;
            }
            
            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtNewPassword, "Enter new password");
                retValue = false;
            }

            return retValue;
        }
    }
}
