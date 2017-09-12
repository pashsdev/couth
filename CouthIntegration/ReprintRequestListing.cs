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
    public partial class ReprintRequestListing : Form
    {
        List<Unit> _units = new List<Unit>();
        public ReprintRequestListing()
        {
            InitializeComponent();
            LoadUnits();
            LoadRequestNo();
            DtFrom.Value = DateTime.Now.AddDays(-30);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ReprintRequest request = new ReprintRequest(0);
            request.ShowDialog();
        }

        public void LoadRequestNo()
        {
            List<ReprintMaster> masters = Common.GetReprintMaster("", "", "", 0, 0, DateTime.MinValue, DateTime.MinValue);
            if (masters != null)
            {
                ReprintMaster master = new ReprintMaster();
                master.ReprintID = 0;
                master.ReprintNo = "--All--";
                masters.Insert(0, master);
            }
            CmbRequestNo.DataSource = masters;
        }

        public void LoadUnits()
        {
            _units = Common.GetUnits(0);
            Unit unit = new Unit();
            unit.UnitID = 0;
            unit.UnitName = "--All--";
            _units.Insert(0, unit);
            CmbUnits.DataSource = _units;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Int64 unitID = 0;
            Int64.TryParse(CmbUnits.SelectedValue.ToString(), out unitID);
            DateTime toDate = DtTo.Value.AddDays(1);
            Int64 reprintID = 0;
            Int64.TryParse(CmbRequestNo.SelectedValue.ToString(), out reprintID);
            Grid.AutoGenerateColumns = false;
            Grid.DataSource = Common.GetReprintMaster(txtJobNo.Text, txtSerialNoFrom.Text, txtSerialNoTo.Text, unitID, reprintID, DtFrom.Value, toDate);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Int64 reprintID = 0;
            if (Grid.SelectedRows.Count > 0)
            {
                int rowIndex = Grid.SelectedCells[0].RowIndex;
                Int64.TryParse(Grid.Rows[rowIndex].Cells["DgvcolReprintID"].Value.ToString(), out reprintID);
                ReprintRequest reprintRequest = new ReprintRequest(reprintID);
                reprintRequest.ShowDialog();
            }
        }
    }
}
