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
    public partial class UserListing : Form
    {
        public UserListing()
        {
            InitializeComponent();
            LoadUsers();
        }

        public void LoadUsers()
        {
            Users users = GetUsers(0);
            if (users != null)
            {
                User user = new User();
                user.UserID = 0;
                user.UserName = "--All--";
                users.users.Insert(0, user);
                CmbUsers.DataSource = users.users;
            }
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
                    MessageBox.Show(((HttpWebResponse)ex.Response).StatusDescription, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                throw;
            }
            return users;
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            LoadUserGrid();

        }

        public void LoadUserGrid()
        {
            Int64 userId = 0;
            if (CmbUsers.SelectedIndex > 0)
            {
                Int64.TryParse(CmbUsers.SelectedValue.ToString(), out userId);
            }
            Users users = GetUsers(userId);
            grid.AutoGenerateColumns = false;
            grid.DataSource = users.users;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            UserCreation userCreation = new UserCreation(0);
            userCreation.ShowDialog();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Int64 userId = 0;
            if (grid.SelectedRows.Count > 0)
            {
                int rowIndex = grid.SelectedCells[0].RowIndex;
                Int64.TryParse(grid.Rows[rowIndex].Cells["DgvcolUserID"].Value.ToString(), out userId);
            }
            UserCreation userCreation = new UserCreation(userId);
            userCreation.ShowDialog();
        }

        private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (grid.Columns[e.ColumnIndex].Name == "DgvColFromDate" || grid.Columns[e.ColumnIndex].Name == "DgvColToDate")
            {
                DateTime dateTime = new DateTime();
                DateTime.TryParse(e.Value.ToString(), out dateTime);
                if (dateTime == DateTime.MinValue)
                {
                    e.Value = null;
                }
            }
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                    Int64 userID = 0;
                string userName = string.Empty;
                if (senderGrid.Rows[e.RowIndex].Cells["DgvColUserID"] != null)
                {
                    Int64.TryParse(senderGrid.Rows[e.RowIndex].Cells["DgvColUserID"].Value.ToString(),out userID);
                }

                if (senderGrid.Rows[e.RowIndex].Cells["DgvColUserName"] != null)
                {
                    userName = senderGrid.Rows[e.RowIndex].Cells["DgvColUserName"] .Value.ToString();
                }
                if (userID > 0)
                {
                    ResetPassword resetPassword = new ResetPassword(userName, userID);
                    resetPassword.ShowDialog();
                }
                else
                {
                    MessageBox.Show("User not selected!");
                }
            }
        }
    }
}
