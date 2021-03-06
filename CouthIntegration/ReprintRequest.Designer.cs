﻿namespace CouthIntegration
{
    partial class ReprintRequest
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
            this.CmbCode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CmbUnits = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.txtRequestNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RdMarkAll = new System.Windows.Forms.RadioButton();
            this.RdMarkEven = new System.Windows.Forms.RadioButton();
            this.RdMarkOdd = new System.Windows.Forms.RadioButton();
            this.txtSerialNoTo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSerialNoFrom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RadSerialNo = new System.Windows.Forms.RadioButton();
            this.RadJobno = new System.Windows.Forms.RadioButton();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnSave = new System.Windows.Forms.Button();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.DgvColSno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColJobno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColTemplate = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DgvColRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColMark = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CmbCode);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.CmbUnits);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtJobNo);
            this.panel1.Controls.Add(this.txtRequestNo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.txtSerialNoTo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtSerialNoFrom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.BtnSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(922, 99);
            this.panel1.TabIndex = 4;
            // 
            // CmbCode
            // 
            this.CmbCode.FormattingEnabled = true;
            this.CmbCode.Items.AddRange(new object[] {
            "Motor",
            "Pump Only",
            "Pump",
            "Valve",
            "Motor Only",
            "Pump Set",
            "Cable",
            "Pannel Box"});
            this.CmbCode.Location = new System.Drawing.Point(56, 71);
            this.CmbCode.Name = "CmbCode";
            this.CmbCode.Size = new System.Drawing.Size(164, 21);
            this.CmbCode.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Code *";
            // 
            // CmbUnits
            // 
            this.CmbUnits.DisplayMember = "UnitName";
            this.CmbUnits.FormattingEnabled = true;
            this.CmbUnits.Location = new System.Drawing.Point(580, 46);
            this.CmbUnits.Name = "CmbUnits";
            this.CmbUnits.Size = new System.Drawing.Size(187, 21);
            this.CmbUnits.TabIndex = 20;
            this.CmbUnits.ValueMember = "UnitID";
            this.CmbUnits.SelectedIndexChanged += new System.EventHandler(this.CmbUnits_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(507, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Unit *";
            // 
            // txtJobNo
            // 
            this.txtJobNo.Location = new System.Drawing.Point(56, 45);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(164, 20);
            this.txtJobNo.TabIndex = 18;
            // 
            // txtRequestNo
            // 
            this.txtRequestNo.Location = new System.Drawing.Point(580, 18);
            this.txtRequestNo.Name = "txtRequestNo";
            this.txtRequestNo.ReadOnly = true;
            this.txtRequestNo.Size = new System.Drawing.Size(187, 20);
            this.txtRequestNo.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(507, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Request No";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RdMarkAll);
            this.groupBox2.Controls.Add(this.RdMarkEven);
            this.groupBox2.Controls.Add(this.RdMarkOdd);
            this.groupBox2.Location = new System.Drawing.Point(768, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(149, 32);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mark";
            // 
            // RdMarkAll
            // 
            this.RdMarkAll.AutoSize = true;
            this.RdMarkAll.Location = new System.Drawing.Point(114, 13);
            this.RdMarkAll.Name = "RdMarkAll";
            this.RdMarkAll.Size = new System.Drawing.Size(36, 17);
            this.RdMarkAll.TabIndex = 6;
            this.RdMarkAll.TabStop = true;
            this.RdMarkAll.Text = "All";
            this.RdMarkAll.UseVisualStyleBackColor = true;
            this.RdMarkAll.CheckedChanged += new System.EventHandler(this.RdMarkAll_CheckedChanged);
            // 
            // RdMarkEven
            // 
            this.RdMarkEven.AutoSize = true;
            this.RdMarkEven.Location = new System.Drawing.Point(58, 13);
            this.RdMarkEven.Name = "RdMarkEven";
            this.RdMarkEven.Size = new System.Drawing.Size(50, 17);
            this.RdMarkEven.TabIndex = 5;
            this.RdMarkEven.TabStop = true;
            this.RdMarkEven.Text = "Even";
            this.RdMarkEven.UseVisualStyleBackColor = true;
            this.RdMarkEven.CheckedChanged += new System.EventHandler(this.RdMarkEven_CheckedChanged);
            // 
            // RdMarkOdd
            // 
            this.RdMarkOdd.AutoSize = true;
            this.RdMarkOdd.Location = new System.Drawing.Point(7, 13);
            this.RdMarkOdd.Name = "RdMarkOdd";
            this.RdMarkOdd.Size = new System.Drawing.Size(45, 17);
            this.RdMarkOdd.TabIndex = 4;
            this.RdMarkOdd.TabStop = true;
            this.RdMarkOdd.Text = "Odd";
            this.RdMarkOdd.UseVisualStyleBackColor = true;
            this.RdMarkOdd.CheckedChanged += new System.EventHandler(this.RdMarkOdd_CheckedChanged);
            // 
            // txtSerialNoTo
            // 
            this.txtSerialNoTo.Location = new System.Drawing.Point(309, 46);
            this.txtSerialNoTo.Name = "txtSerialNoTo";
            this.txtSerialNoTo.Size = new System.Drawing.Size(187, 20);
            this.txtSerialNoTo.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(226, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Serial No To";
            // 
            // txtSerialNoFrom
            // 
            this.txtSerialNoFrom.Location = new System.Drawing.Point(309, 16);
            this.txtSerialNoFrom.Name = "txtSerialNoFrom";
            this.txtSerialNoFrom.Size = new System.Drawing.Size(187, 20);
            this.txtSerialNoFrom.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Serial No From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Job No";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RadSerialNo);
            this.groupBox1.Controls.Add(this.RadJobno);
            this.groupBox1.Location = new System.Drawing.Point(69, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 34);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // RadSerialNo
            // 
            this.RadSerialNo.AutoSize = true;
            this.RadSerialNo.Location = new System.Drawing.Point(72, 12);
            this.RadSerialNo.Name = "RadSerialNo";
            this.RadSerialNo.Size = new System.Drawing.Size(68, 17);
            this.RadSerialNo.TabIndex = 7;
            this.RadSerialNo.Text = "Serial No";
            this.RadSerialNo.UseVisualStyleBackColor = true;
            // 
            // RadJobno
            // 
            this.RadJobno.AutoSize = true;
            this.RadJobno.Checked = true;
            this.RadJobno.Location = new System.Drawing.Point(6, 12);
            this.RadJobno.Name = "RadJobno";
            this.RadJobno.Size = new System.Drawing.Size(59, 17);
            this.RadJobno.TabIndex = 6;
            this.RadJobno.TabStop = true;
            this.RadJobno.Text = "Job No";
            this.RadJobno.UseVisualStyleBackColor = true;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(838, 49);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search By";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.BtnSave);
            this.panel2.Location = new System.Drawing.Point(5, 439);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(922, 34);
            this.panel2.TabIndex = 16;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(793, 6);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(120, 23);
            this.BtnSave.TabIndex = 14;
            this.BtnSave.Text = "Send To Approval";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvColSno,
            this.DgvColItemCode,
            this.DgvColJobno,
            this.DgvColDesc,
            this.DgvColSerialNo,
            this.DgvColTemplate,
            this.DgvColRemarks,
            this.DgvColMark});
            this.Grid.Location = new System.Drawing.Point(5, 110);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(922, 323);
            this.Grid.TabIndex = 17;
            this.Grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Grid_DataError);
            // 
            // DgvColSno
            // 
            this.DgvColSno.DataPropertyName = "Sno";
            this.DgvColSno.Frozen = true;
            this.DgvColSno.HeaderText = "Sno";
            this.DgvColSno.Name = "DgvColSno";
            this.DgvColSno.ReadOnly = true;
            this.DgvColSno.Width = 60;
            // 
            // DgvColItemCode
            // 
            this.DgvColItemCode.DataPropertyName = "Item_Code";
            this.DgvColItemCode.HeaderText = "ItemCode";
            this.DgvColItemCode.Name = "DgvColItemCode";
            this.DgvColItemCode.ReadOnly = true;
            this.DgvColItemCode.Visible = false;
            // 
            // DgvColJobno
            // 
            this.DgvColJobno.DataPropertyName = "Jobnumber";
            this.DgvColJobno.HeaderText = "Job No";
            this.DgvColJobno.Name = "DgvColJobno";
            this.DgvColJobno.ReadOnly = true;
            this.DgvColJobno.Width = 150;
            // 
            // DgvColDesc
            // 
            this.DgvColDesc.DataPropertyName = "Description";
            this.DgvColDesc.HeaderText = "Prod. Desc";
            this.DgvColDesc.Name = "DgvColDesc";
            this.DgvColDesc.ReadOnly = true;
            this.DgvColDesc.Width = 200;
            // 
            // DgvColSerialNo
            // 
            this.DgvColSerialNo.DataPropertyName = "Serial_Number";
            this.DgvColSerialNo.HeaderText = "Serial No";
            this.DgvColSerialNo.Name = "DgvColSerialNo";
            this.DgvColSerialNo.ReadOnly = true;
            this.DgvColSerialNo.Width = 150;
            // 
            // DgvColTemplate
            // 
            this.DgvColTemplate.DataPropertyName = "TemplateID";
            this.DgvColTemplate.HeaderText = "Template";
            this.DgvColTemplate.Name = "DgvColTemplate";
            this.DgvColTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvColTemplate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DgvColTemplate.Width = 150;
            // 
            // DgvColRemarks
            // 
            this.DgvColRemarks.DataPropertyName = "Remarks";
            this.DgvColRemarks.HeaderText = "Remarks";
            this.DgvColRemarks.Name = "DgvColRemarks";
            // 
            // DgvColMark
            // 
            this.DgvColMark.HeaderText = "Mark";
            this.DgvColMark.Name = "DgvColMark";
            // 
            // ReprintRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 480);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReprintRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reprint Request";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSerialNoTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSerialNoFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RadSerialNo;
        private System.Windows.Forms.RadioButton RadJobno;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRequestNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColSno;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColJobno;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColSerialNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn DgvColTemplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColRemarks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DgvColMark;
        private System.Windows.Forms.RadioButton RdMarkAll;
        private System.Windows.Forms.RadioButton RdMarkEven;
        private System.Windows.Forms.RadioButton RdMarkOdd;
        private System.Windows.Forms.ComboBox CmbCode;
        private System.Windows.Forms.Label label7;
    }
}