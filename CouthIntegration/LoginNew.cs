using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Deployment;
using System.Deployment.Application;
using Newtonsoft.Json;
using TransferDatas;

namespace CouthIntegration
{
    public partial class LoginNew : Form
    {
        public LoginNew()
        {
            InitializeComponent();
            if (Debugger.IsAttached)
            {
                txtUser.Text = "Admin";
                txtPassword.Text = "Admin";
            }
        }

        private void rectLogin_Click(object sender, EventArgs e)
        {
            LoginClick();
        }
       
        private void LoginClick()
        {
            User user = ValidateLogin(txtUser.Text, txtPassword.Text);
            if (user != null)
            {
                Form frmlogin = null;

                foreach (Form form in Application.OpenForms)
                {
                    if (string.Compare(form.Name, "loginnew", true) == 0)
                    {
                        frmlogin = (LoginNew)form;
                        break;
                    }
                }

                Common.UserID = user.UserID;
                MainForm main = new MainForm();
                main.Show();
                if (frmlogin != null)
                {
                    frmlogin.Visible = false;
                }
            }
        }

        private User ValidateLogin(string userName, string password)
        {
            User user = null;
            if (string.IsNullOrEmpty(userName.Trim()) && string.IsNullOrEmpty(password.Trim()))
            {
                MessageBox.Show("Enter credential!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Focus();
                return user;
            }

            Cursor.Current = Cursors.WaitCursor;

            string postString = string.Format("UserName={0}&Password={1}", txtUser.Text, txtPassword.Text);

            string webserviceURL = string.Empty;
            webserviceURL = Common.GetWebServiceURL();
            webserviceURL = string.Concat(webserviceURL, "validate.aspx");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(webserviceURL));
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
            requestWriter.Write(postString);
            requestWriter.Close();
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

                user = JsonConvert.DeserializeObject<User>(responseString);
                if (user == null)
                {
                    MessageBox.Show("Invalid User name or Password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            return user;
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            LoginClick();
        }

        private void lnkChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            changePassword.ShowDialog();
        }

        private string GetClickOnceVersion()
        {
            Version version = new Version();
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                version = ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }

            return version.ToString();
        }

        private void LoginNew_Load(object sender, EventArgs e)
        {
            string version = GetClickOnceVersion();
            if (!string.IsNullOrEmpty(version) && !version.Equals("0.0", StringComparison.OrdinalIgnoreCase))
            {
                LblVersion.Text = string.Concat("Version: ", version);
                LblVersion.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginClick();
        }
    }
}
