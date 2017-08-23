using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CouthIntegration
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadWelcomePage();
            LoadMasterMenu();
            LoadTransactionMenu();
        }

        private void LoadWelcomePage()
        {
            string url = string.Concat(Common.GetWebServiceURL(), "welcome.aspx");
            webBrowser1.Navigate(url);
        }

        private void LoadMasterMenu()
        {
            ToolStripMenuItem menuUsers = new ToolStripMenuItem("Users");
            ToolStripMenuItem menuUserCreation = new ToolStripMenuItem();
            menuUserCreation.Name = "mnuUserCreation";
            menuUserCreation.Text = "Creation";
            menuUserCreation.Click += menuUserCreation_Click;
            menuUsers.DropDownItems.Add(menuUserCreation);

            //ToolStripMenuItem menuUserReport = new ToolStripMenuItem();
            //menuUserReport.Name = "menuUserReport";
            //menuUserReport.Text = "Report";
            //menuUsers.DropDownItems.Add(menuUserReport);

            MasterMenu.DropDownItems.Add(menuUsers);

            ToolStripMenuItem menuUnit = new ToolStripMenuItem();
            menuUnit.Name = "mnuUnitCreation";
            menuUnit.Text = "Unit";
            menuUnit.Click += menuUnitCreation_Click;
            MasterMenu.DropDownItems.Add(menuUnit);

            ToolStripMenuItem menuTemplate = new ToolStripMenuItem();
            menuTemplate.Name = "mnuTemplateCreation";
            menuTemplate.Text = "Template";
            menuTemplate.Click += menuTemplate_Click;
            MasterMenu.DropDownItems.Add(menuTemplate);

        }

        void menuUserCreation_Click(object sender, EventArgs e)
        {
            UserListing userListing = new UserListing();
            userListing.ShowDialog();
        }

        void menuUnitCreation_Click(object sender, EventArgs e)
        {
            UnitListing listing = new UnitListing();
            listing.ShowDialog();
        }

        void menuTemplate_Click(object sender, EventArgs e)
        {
            TemplateListing template = new TemplateListing();
            template.ShowDialog();
        }

        private void LoadTransactionMenu()
        {
            ToolStripMenuItem menuJobSerial = new ToolStripMenuItem("JobSerialSearch");
            menuJobSerial.Name = "mnuJobSerialSearch";
            menuJobSerial.Text = "Job / Serial no search";
            menuJobSerial.Click += menuJobSerial_Click;
            TransactionMenu.DropDownItems.Add(menuJobSerial);

            ToolStripMenuItem menuRequest = new ToolStripMenuItem("Request");
            menuRequest.Name = "mnuRequest";
            menuRequest.Text = "Request";
            menuRequest.Click += menuRequest_Click;
            TransactionMenu.DropDownItems.Add(menuRequest);

            ToolStripMenuItem menuApproval = new ToolStripMenuItem("Approval");
            menuApproval.Name = "mnuApproval";
            menuApproval.Text = "Approval";
            menuApproval.Click += menuApproval_Click;
            TransactionMenu.DropDownItems.Add(menuApproval);

            ToolStripMenuItem menuTestPrint = new ToolStripMenuItem("TestPrint");
            menuTestPrint.Name = "mnuTestPrint";
            menuTestPrint.Text = "Test Print";
            menuTestPrint.Click += menuTestPrint_Click;
            TransactionMenu.DropDownItems.Add(menuTestPrint);
        }

        void menuTestPrint_Click(object sender, EventArgs e)
        {
            string _fileDirectory = "D:\\Marking";
            string _fileName = "text.txt";
            string _filePath = Path.Combine(_fileDirectory, _fileName);

            if (!Directory.Exists(_fileDirectory))
            {
                MessageBox.Show("Directory not found");
                return;
            }

            if (!File.Exists(_filePath))
            {
                MessageBox.Show("File not found");
                return;
            }

            Process process = new Process();
            ProcessWindowStyle windowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo = new ProcessStartInfo(Path.Combine(Application.StartupPath, "COMMT2_2.exe"))
            {
                WorkingDirectory = Path.GetDirectoryName(Application.StartupPath),
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WindowStyle = windowStyle,
                CreateNoWindow = (windowStyle == ProcessWindowStyle.Hidden)
            };
            process.Start();
        }

        void menuJobSerial_Click(object sender, EventArgs e)
        {
            PrintData search = new PrintData();
            search.ShowDialog();
        }

        void menuRequest_Click(object sender, EventArgs e)
        {
            ReprintRequestListing request = new ReprintRequestListing();
            request.ShowDialog();
        }

        void menuApproval_Click(object sender, EventArgs e)
        {
            ReprintApproval approval = new ReprintApproval();
            approval.ShowDialog();
        }

        private void ExitMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
