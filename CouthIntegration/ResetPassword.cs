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
    public partial class ResetPassword : Form
    {
        private Int64 _userID = 0;

        public ResetPassword(string userName, Int64 userID)
        {
            InitializeComponent();
            txtUser.Text = userName;
            _userID = userID;
        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string webserviceURL = Common.GetWebServiceURL();
            webserviceURL = string.Concat(webserviceURL, "ResetPassword.aspx?");
            string qs = string.Format("userId={0}&password={1}", _userID, Common.ToBase64(txtNewPassword.Text));
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
                    this.Close();
                }
            }
            catch (WebException ex)
            {
                if (((HttpWebResponse)ex.Response).StatusCode != HttpStatusCode.OK)
                {
                    MessageBox.Show(((HttpWebResponse)ex.Response).StatusDescription, "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
