
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
    public partial class UnitListing : Form
    {
        public UnitListing()
        {
            InitializeComponent();
            LoadUnits();
        }

        public void LoadUnits()
        {
            List<Unit> units = Common.GetUnits(0);
            Unit unit = new Unit();
            unit.UnitID = 0;
            unit.UnitName = "--All--";
            units.Insert(0, unit);
            CmbUnits.DataSource = units;
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            LoadUnitGrid();
        }

        public void LoadUnitGrid()
        {
            Int64 unitId = 0;
            if (CmbUnits.SelectedIndex > 0)
            {
                Int64.TryParse(CmbUnits.SelectedValue.ToString(), out unitId);
            }
            List<Unit> units = Common.GetUnits(unitId);
            grid.AutoGenerateColumns = false;
            grid.DataSource = units;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            UnitCreation unitCreation = new UnitCreation(0);
            unitCreation.ShowDialog();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Int64 unitID = 0;
            if (grid.SelectedRows.Count > 0)
            {
                int rowIndex = grid.SelectedCells[0].RowIndex;
                Int64.TryParse(grid.Rows[rowIndex].Cells["DgvcolUnitID"].Value.ToString(), out unitID);
                UnitCreation unitCreation = new UnitCreation(unitID);
                unitCreation.ShowDialog();
            }
            
        }
    }

    public class UnitResponse
    {
        public List<TransferDatas.Unit> LstUnits { get; set; }
        public List<Designation> Designations { get; set; }
        public List<User> Users { get; set; }
        public List<UnitRight> UnitRights { get; set; }

    }

    public class UnitRight
    {
        public Int64 UnitRightsID { get; set; }
        public Int64 UnitID { get; set; }
        public Int64 DesignationID { get; set; }
        public Int64 UserID { get; set; }
        public bool Available { get; set; }
    }
}
