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
            if (Common.CurrentUser != null && Common.CurrentUser.IsAdmin)
            {
                LoadMasterMenu();
            }
            LoadTransactionMenu();
            LoadExitMenu();
        }

        private void LoadWelcomePage()
        {
            string url = string.Concat(Common.GetWebServiceURL(), "welcome.aspx");
            webBrowser1.Navigate(url);
        }

        private void LoadMasterMenu()
        {
            ToolStripDropDownButton masters = new ToolStripDropDownButton();
            masters.Image = CouthIntegration.Properties.Resources.Transactions;
            masters.ImageScaling = ToolStripItemImageScaling.None;
            masters.Text = "Masters";
            masters.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStrip1.Items.Add(masters);

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

            masters.DropDownItems.Add(menuUsers);

            ToolStripMenuItem menuUnit = new ToolStripMenuItem();
            menuUnit.Name = "mnuUnitCreation";
            menuUnit.Text = "Unit";
            menuUnit.Click += menuUnitCreation_Click;
            masters.DropDownItems.Add(menuUnit);

            ToolStripMenuItem menuTemplate = new ToolStripMenuItem();
            menuTemplate.Name = "mnuTemplateCreation";
            menuTemplate.Text = "Template";
            menuTemplate.Click += menuTemplate_Click;
            masters.DropDownItems.Add(menuTemplate);

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
            ToolStripDropDownButton transactions = new ToolStripDropDownButton();
            transactions.Image = CouthIntegration.Properties.Resources.Transactions;
            transactions.ImageScaling = ToolStripItemImageScaling.None;
            transactions.Text = "Transactions";
            transactions.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStrip1.Items.Add(transactions);

            ToolStripMenuItem menuJobSerial = new ToolStripMenuItem("JobSerialSearch");
            menuJobSerial.Name = "mnuJobSerialSearch";
            menuJobSerial.Text = "Job / Serial no search";
            menuJobSerial.Click += menuJobSerial_Click;
            transactions.DropDownItems.Add(menuJobSerial);

            ToolStripMenuItem menuRequest = new ToolStripMenuItem("Request");
            menuRequest.Name = "mnuRequest";
            menuRequest.Text = "Request";
            menuRequest.Click += menuRequest_Click;
            transactions.DropDownItems.Add(menuRequest);

            ToolStripMenuItem menuApproval = new ToolStripMenuItem("Approval");
            menuApproval.Name = "mnuApproval";
            menuApproval.Text = "Approval";
            menuApproval.Click += menuApproval_Click;
            transactions.DropDownItems.Add(menuApproval);

            ToolStripMenuItem menuTestPrint = new ToolStripMenuItem("TestPrint");
            menuTestPrint.Name = "mnuTestPrint";
            menuTestPrint.Text = "Test Print";
            menuTestPrint.Click += menuTestPrint_Click;
            transactions.DropDownItems.Add(menuTestPrint);
        }

        private void LoadExitMenu()
        {
            ToolStripButton exitMenu = new ToolStripButton();
            exitMenu.Image = CouthIntegration.Properties.Resources.if_exit_3226;
            exitMenu.ImageScaling = ToolStripItemImageScaling.None;
            exitMenu.Text = "Exit";
            exitMenu.TextImageRelation = TextImageRelation.ImageAboveText;
            exitMenu.Click += exitMenu_Click;
            toolStrip1.Items.Add(exitMenu);
        }

        void exitMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

       

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
