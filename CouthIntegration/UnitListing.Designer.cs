namespace CouthIntegration
{
    partial class UnitListing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnList = new System.Windows.Forms.Button();
            this.CmbUnits = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.PanAction = new System.Windows.Forms.Panel();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.DgvColUnitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColOracleUnitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.PanAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnList);
            this.panel1.Controls.Add(this.CmbUnits);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(9, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(789, 53);
            this.panel1.TabIndex = 3;
            // 
            // BtnList
            // 
            this.BtnList.Location = new System.Drawing.Point(707, 14);
            this.BtnList.Name = "BtnList";
            this.BtnList.Size = new System.Drawing.Size(75, 23);
            this.BtnList.TabIndex = 4;
            this.BtnList.Text = "List";
            this.BtnList.UseVisualStyleBackColor = true;
            this.BtnList.Click += new System.EventHandler(this.BtnList_Click);
            // 
            // CmbUnits
            // 
            this.CmbUnits.DisplayMember = "UnitName";
            this.CmbUnits.FormattingEnabled = true;
            this.CmbUnits.Location = new System.Drawing.Point(77, 16);
            this.CmbUnits.Name = "CmbUnits";
            this.CmbUnits.Size = new System.Drawing.Size(166, 21);
            this.CmbUnits.TabIndex = 3;
            this.CmbUnits.ValueMember = "UnitID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Unit Name";
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvColUnitID,
            this.DgvColUnit,
            this.DgvColOracleUnitID});
            this.grid.Location = new System.Drawing.Point(9, 67);
            this.grid.Name = "grid";
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(789, 353);
            this.grid.TabIndex = 4;
            // 
            // PanAction
            // 
            this.PanAction.Controls.Add(this.BtnEdit);
            this.PanAction.Controls.Add(this.BtnAdd);
            this.PanAction.Location = new System.Drawing.Point(12, 426);
            this.PanAction.Name = "PanAction";
            this.PanAction.Size = new System.Drawing.Size(786, 41);
            this.PanAction.TabIndex = 5;
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(705, 8);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(75, 23);
            this.BtnEdit.TabIndex = 6;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(624, 8);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 5;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // DgvColUnitID
            // 
            this.DgvColUnitID.DataPropertyName = "UnitId";
            this.DgvColUnitID.HeaderText = "UnitID";
            this.DgvColUnitID.Name = "DgvColUnitID";
            this.DgvColUnitID.Visible = false;
            // 
            // DgvColUnit
            // 
            this.DgvColUnit.DataPropertyName = "UnitName";
            this.DgvColUnit.HeaderText = "Unit";
            this.DgvColUnit.Name = "DgvColUnit";
            this.DgvColUnit.ReadOnly = true;
            this.DgvColUnit.Width = 300;
            // 
            // DgvColOracleUnitID
            // 
            this.DgvColOracleUnitID.DataPropertyName = "OracleUnitID";
            this.DgvColOracleUnitID.HeaderText = "OracleUnitID";
            this.DgvColOracleUnitID.Name = "DgvColOracleUnitID";
            this.DgvColOracleUnitID.ReadOnly = true;
            // 
            // UnitListing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 470);
            this.Controls.Add(this.PanAction);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UnitListing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UnitListing";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.PanAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnList;
        private System.Windows.Forms.ComboBox CmbUnits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel PanAction;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColUnitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColOracleUnitID;
    }
}