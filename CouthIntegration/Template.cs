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
    public partial class TemplateMaster : Form
    {
        public Int64 _templateID = 0;
        public TemplateMaster(Int64 templateID)
        {
            InitializeComponent();
            lstVariables.AllowDrop = true;
            rtfTemplate.AllowDrop = true;
            rtfTemplate.DragEnter += rtfTemplate_DragEnter;
            rtfTemplate.DragDrop += rtfTemplate_DragDrop;
            List<Template> templates = Common.GetTemplates(templateID);
            if (templateID > 0 && templates.Count > 0)
            {
                _templateID = templateID;
                txtTemplate.Text = templates[0].TemplateName;
                rtfTemplate.Text = templates[0].TemplateText;
            }
        }

        void rtfTemplate_DragDrop(object sender, DragEventArgs e)
        {
            int i = rtfTemplate.SelectionStart;
            string s = rtfTemplate.Text.Substring(i);
            rtfTemplate.Text = rtfTemplate.Text.Substring(0, i);
            rtfTemplate.Text = rtfTemplate.Text + e.Data.GetData(DataFormats.Text).ToString();
            rtfTemplate.Text = rtfTemplate.Text + s;
        }

        void rtfTemplate_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                MessageBox.Show("Saved sucessfully!", "Template", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool Save()
        {
            bool retValue = false;
            if (SaveValidation())
            {
                string webserviceURL = Common.GetWebServiceURL();
                webserviceURL = string.Concat(webserviceURL, "GetTemplate.aspx?cmd=Save");
                if (_templateID > 0)
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
                Template template = new Template();
                template.TemplateID = _templateID;
                template.TemplateName = txtTemplate.Text;
                template.TemplateText = rtfTemplate.Text.Replace("\n", Environment.NewLine);

                string postString = JsonConvert.SerializeObject(template);

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
                        MessageBox.Show(((HttpWebResponse)ex.Response).StatusDescription, "Template", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (string.IsNullOrEmpty(txtTemplate.Text))
            {
                errorProvider1.SetError(txtTemplate, "Enter Template name");
                retValue = false;
            }
            else if (string.IsNullOrEmpty(rtfTemplate.Text))
            {
                errorProvider1.SetError(rtfTemplate, "Enter any format name");
                retValue = false;
            }
            else
            {
                errorProvider1.Clear();
            }

            return retValue;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstVariables_MouseDown(object sender, MouseEventArgs e)
        {
            lstVariables.Refresh();
            lstVariables.DoDragDrop(lstVariables.SelectedItem, DragDropEffects.Copy);
            rtfTemplate.DoDragDrop(lstVariables.SelectedItem, DragDropEffects.Copy);
        }
    }
}
