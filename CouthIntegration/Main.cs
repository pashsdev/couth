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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadMasterMenu();
            LoadSearchMenu();
            LoadReprintMenu();
            LoadToolsMenu();
            //ToolStripMenuItem menuSearch = new ToolStripMenuItem("Search");
            //menuSearch.DropDownItems.Add("Print");
            //menuStrip1.Items.Add(menuSearch);

            //ToolStripMenuItem menuReprint = new ToolStripMenuItem("Reprint");
            //menuReprint.DropDownItems.Add("Request");
            //menuReprint.DropDownItems.Add("Approval");
            //menuStrip1.Items.Add(menuReprint);

            //ToolStripMenuItem menuReports = new ToolStripMenuItem("Reports");
            //menuReports.DropDownItems.Add("Audits");
            //menuStrip1.Items.Add(menuReports);

            ToolStripMenuItem menuExit = new ToolStripMenuItem("Exit");
            menuExit.Click += menuExit_Click;
            menuStrip1.Items.Add(menuExit);
        }

        private void LoadReprintMenu()
        {
            ToolStripMenuItem menuReprint = new ToolStripMenuItem("Reprint");

            ToolStripMenuItem menuRequest = new ToolStripMenuItem("Request");
            menuRequest.Name = "mnuRequest";
            menuRequest.Text = "Request";
            menuRequest.Click += menuRequest_Click;
            menuReprint.DropDownItems.Add(menuRequest);

            ToolStripMenuItem menuApproval = new ToolStripMenuItem("Approval");
            menuApproval.Name = "mnuApproval";
            menuApproval.Text = "Approval";
            menuApproval.Click += menuApproval_Click;
            menuReprint.DropDownItems.Add(menuApproval);
            menuStrip1.Items.Add(menuReprint);
        }

        void menuApproval_Click(object sender, EventArgs e)
        {
            ReprintApproval approval = new ReprintApproval();
            approval.ShowDialog();
        }

        void menuRequest_Click(object sender, EventArgs e)
        {
            ReprintRequestListing request = new ReprintRequestListing();
            request.ShowDialog();
        }

        private void LoadToolsMenu()
        {
            ToolStripMenuItem menuTools = new ToolStripMenuItem("Tools");

            ToolStripMenuItem menuTestPrint = new ToolStripMenuItem("TestPrint");
            menuTestPrint.Name = "mnuTestPrint";
            menuTestPrint.Text = "Test Print";
            menuTestPrint.Click += menuTestPrint_Click;
            menuTools.DropDownItems.Add(menuTestPrint);
            menuStrip1.Items.Add(menuTools);
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

        private void LoadSearchMenu()
        {
            ToolStripMenuItem menuSearch = new ToolStripMenuItem("Search");

            ToolStripMenuItem menuJobSerial = new ToolStripMenuItem("JobSerialSearch");
            menuJobSerial.Name = "mnuJobSerialSearch";
            menuJobSerial.Text = "Job / Serial no search";
            menuJobSerial.Click += menuJobSerial_Click;
            menuSearch.DropDownItems.Add(menuJobSerial);
            menuStrip1.Items.Add(menuSearch);
        }

        void menuJobSerial_Click(object sender, EventArgs e)
        {
            PrintData search = new PrintData();
            search.ShowDialog();
        }
        
        private void LoadMasterMenu()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem("Master");

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

            menuItem.DropDownItems.Add(menuUsers);

            ToolStripMenuItem menuUnit = new ToolStripMenuItem();
            menuUnit.Name = "mnuUnitCreation";
            menuUnit.Text = "Unit";
            menuUnit.Click += menuUnitCreation_Click;
            menuItem.DropDownItems.Add(menuUnit);

            ToolStripMenuItem menuTemplate = new ToolStripMenuItem();
            menuTemplate.Name = "mnuTemplateCreation";
            menuTemplate.Text = "Template";
            menuTemplate.Click += menuTemplate_Click;
            menuItem.DropDownItems.Add(menuTemplate);

            menuStrip1.Items.Add(menuItem);
        }

        void menuTemplate_Click(object sender, EventArgs e)
        {
            TemplateListing template = new TemplateListing();
            template.ShowDialog();
        }

        void menuUnitCreation_Click(object sender, EventArgs e)
        {
            UnitListing listing = new UnitListing();
            listing.ShowDialog();
        }

        void menuUserCreation_Click(object sender, EventArgs e)
        {
            UserListing userListing = new UserListing();
            userListing.ShowDialog();
        }

        void menuExit_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }


        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
