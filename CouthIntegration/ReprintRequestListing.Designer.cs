namespace CouthIntegration
{
    partial class ReprintRequestListing
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
            this.CmbUnits = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DtTo = new System.Windows.Forms.DateTimePicker();
            this.DtFrom = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbRequestNo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.Grid = new System.Windows.Forms.DataGridView();
            this.DgvColReprintID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColReprintNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColReprintDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColRequestUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CmbUnits);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtJobNo);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.DtTo);
            this.panel1.Controls.Add(this.DtFrom);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.CmbRequestNo);
            this.panel1.Controls.Add(this.label5);
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
            this.panel1.Size = new System.Drawing.Size(922, 100);
            this.panel1.TabIndex = 5;
            // 
            // CmbUnits
            // 
            this.CmbUnits.DisplayMember = "UnitName";
            this.CmbUnits.FormattingEnabled = true;
            this.CmbUnits.Location = new System.Drawing.Point(69, 71);
            this.CmbUnits.Name = "CmbUnits";
            this.CmbUnits.Size = new System.Drawing.Size(151, 21);
            this.CmbUnits.TabIndex = 24;
            this.CmbUnits.ValueMember = "UnitID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Unit";
            // 
            // txtJobNo
            // 
            this.txtJobNo.Location = new System.Drawing.Point(69, 45);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(151, 20);
            this.txtJobNo.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(739, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "To";
            // 
            // DtTo
            // 
            this.DtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtTo.Location = new System.Drawing.Point(765, 45);
            this.DtTo.Name = "DtTo";
            this.DtTo.Size = new System.Drawing.Size(148, 20);
            this.DtTo.TabIndex = 20;
            // 
            // DtFrom
            // 
            this.DtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFrom.Location = new System.Drawing.Point(578, 46);
            this.DtFrom.Name = "DtFrom";
            this.DtFrom.Size = new System.Drawing.Size(149, 20);
            this.DtFrom.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(507, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "From";
            // 
            // CmbRequestNo
            // 
            this.CmbRequestNo.DisplayMember = "ReprintNo";
            this.CmbRequestNo.FormattingEnabled = true;
            this.CmbRequestNo.Location = new System.Drawing.Point(578, 17);
            this.CmbRequestNo.Name = "CmbRequestNo";
            this.CmbRequestNo.Size = new System.Drawing.Size(254, 21);
            this.CmbRequestNo.TabIndex = 17;
            this.CmbRequestNo.ValueMember = "ReprintID";
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
            this.BtnSearch.Location = new System.Drawing.Point(838, 14);
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
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvColReprintID,
            this.DgvColReprintNo,
            this.DgvColReprintDate,
            this.DgvColRequestUser,
            this.DgvColUnit});
            this.Grid.Location = new System.Drawing.Point(4, 111);
            this.Grid.MultiSelect = false;
            this.Grid.Name = "Grid";
            this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid.Size = new System.Drawing.Size(922, 323);
            this.Grid.TabIndex = 18;
            // 
            // DgvColReprintID
            // 
            this.DgvColReprintID.DataPropertyName = "ReprintID";
            this.DgvColReprintID.Frozen = true;
            this.DgvColReprintID.HeaderText = "ID";
            this.DgvColReprintID.Name = "DgvColReprintID";
            this.DgvColReprintID.ReadOnly = true;
            this.DgvColReprintID.Width = 60;
            // 
            // DgvColReprintNo
            // 
            this.DgvColReprintNo.DataPropertyName = "ReprintNo";
            this.DgvColReprintNo.HeaderText = "Reprint No";
            this.DgvColReprintNo.Name = "DgvColReprintNo";
            this.DgvColReprintNo.ReadOnly = true;
            // 
            // DgvColReprintDate
            // 
            this.DgvColReprintDate.DataPropertyName = "RequestDate";
            this.DgvColReprintDate.HeaderText = "Date";
            this.DgvColReprintDate.Name = "DgvColReprintDate";
            this.DgvColReprintDate.ReadOnly = true;
            // 
            // DgvColRequestUser
            // 
            this.DgvColRequestUser.DataPropertyName = "RequestUser";
            this.DgvColRequestUser.HeaderText = "Request User";
            this.DgvColRequestUser.Name = "DgvColRequestUser";
            this.DgvColRequestUser.ReadOnly = true;
            this.DgvColRequestUser.Width = 150;
            // 
            // DgvColUnit
            // 
            this.DgvColUnit.DataPropertyName = "Unit";
            this.DgvColUnit.HeaderText = "Unit";
            this.DgvColUnit.Name = "DgvColUnit";
            this.DgvColUnit.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.BtnAdd);
            this.panel2.Location = new System.Drawing.Point(4, 440);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(922, 34);
            this.panel2.TabIndex = 19;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(852, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(62, 26);
            this.btnEdit.TabIndex = 15;
            this.btnEdit.Text = "&View";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(784, 2);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(62, 26);
            this.BtnAdd.TabIndex = 14;
            this.BtnAdd.Text = "&Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // ReprintRequestListing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 480);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReprintRequestListing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reprint Request Listing";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker DtTo;
        private System.Windows.Forms.DateTimePicker DtFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbRequestNo;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.ComboBox CmbUnits;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColReprintID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColReprintNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColReprintDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColRequestUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColUnit;
    }
}