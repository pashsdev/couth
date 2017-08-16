using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TransferDatas;

namespace CouthIntegration
{
    public partial class TemplateListing : Form
    {
        public TemplateListing()
        {
            InitializeComponent();
            List<Template> templates = Common.GetTemplates(0);
            Template template = new Template();
            template.TemplateID = 0;
            template.TemplateName = "--All--";
            templates.Insert(0, template);
            CmbTemplate.DataSource = templates;
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            Int64 templateID = 0;
            if (CmbTemplate.SelectedIndex > 0)
            {
                Int64.TryParse(CmbTemplate.SelectedValue.ToString(), out templateID);
            }
            List<Template> templates = Common.GetTemplates(templateID);
            grid.AutoGenerateColumns = false;
            grid.DataSource = templates;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            TemplateMaster templateMaster = new TemplateMaster(0);
            templateMaster.ShowDialog();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Int64 templateID = 0;
            if (grid.SelectedRows.Count > 0)
            {
                int rowIndex = grid.SelectedCells[0].RowIndex;
                Int64.TryParse(grid.Rows[rowIndex].Cells["DgvcolTemplateID"].Value.ToString(), out templateID);
                TemplateMaster templateMaster = new TemplateMaster(templateID);
                templateMaster.ShowDialog();
            }
        }
    }
}
