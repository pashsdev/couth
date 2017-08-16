namespace CouthIntegration
{
    partial class ReprintApproval
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
            this.Grid = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.DgvColSno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColRequestNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColRequestDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColRequestedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColJobno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColTemplate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColPrintCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColReqRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DgvColRejRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnList);
            this.panel1.Controls.Add(this.CmbUnits);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(954, 32);
            this.panel1.TabIndex = 4;
            // 
            // BtnList
            // 
            this.BtnList.Location = new System.Drawing.Point(874, 4);
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
            this.CmbUnits.Location = new System.Drawing.Point(77, 6);
            this.CmbUnits.Name = "CmbUnits";
            this.CmbUnits.Size = new System.Drawing.Size(166, 21);
            this.CmbUnits.TabIndex = 3;
            this.CmbUnits.ValueMember = "UnitID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Unit Name";
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvColSno,
            this.DgvColRequestNo,
            this.DgvColRequestDate,
            this.DgvColRequestedBy,
            this.DgvColJobno,
            this.DgvColDesc,
            this.DgvColSerialNo,
            this.DgvColTemplate,
            this.DgvColPrintCount,
            this.DgvColReqRemarks,
            this.DgvColStatus,
            this.DgvColRejRemarks});
            this.Grid.Location = new System.Drawing.Point(8, 46);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(954, 323);
            this.Grid.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.BtnCancel);
            this.panel2.Controls.Add(this.BtnSave);
            this.panel2.Location = new System.Drawing.Point(8, 375);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(954, 34);
            this.panel2.TabIndex = 16;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(874, 6);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 15;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(793, 6);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 14;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // DgvColSno
            // 
            this.DgvColSno.DataPropertyName = "Sno";
            this.DgvColSno.HeaderText = "Sno";
            this.DgvColSno.Name = "DgvColSno";
            this.DgvColSno.ReadOnly = true;
            // 
            // DgvColRequestNo
            // 
            this.DgvColRequestNo.DataPropertyName = "RequestNo";
            this.DgvColRequestNo.HeaderText = "Request No";
            this.DgvColRequestNo.Name = "DgvColRequestNo";
            this.DgvColRequestNo.ReadOnly = true;
            // 
            // DgvColRequestDate
            // 
            this.DgvColRequestDate.DataPropertyName = "RequestDate";
            this.DgvColRequestDate.HeaderText = "Req. Date";
            this.DgvColRequestDate.Name = "DgvColRequestDate";
            // 
            // DgvColRequestedBy
            // 
            this.DgvColRequestedBy.DataPropertyName = "RequestUser";
            this.DgvColRequestedBy.HeaderText = "Req. By";
            this.DgvColRequestedBy.Name = "DgvColRequestedBy";
            this.DgvColRequestedBy.ReadOnly = true;
            // 
            // DgvColJobno
            // 
            this.DgvColJobno.DataPropertyName = "Jobnumber";
            this.DgvColJobno.HeaderText = "Job No";
            this.DgvColJobno.Name = "DgvColJobno";
            this.DgvColJobno.ReadOnly = true;
            // 
            // DgvColDesc
            // 
            this.DgvColDesc.DataPropertyName = "Description";
            this.DgvColDesc.HeaderText = "Prod. Desc";
            this.DgvColDesc.Name = "DgvColDesc";
            this.DgvColDesc.ReadOnly = true;
            // 
            // DgvColSerialNo
            // 
            this.DgvColSerialNo.DataPropertyName = "Serial_Number";
            this.DgvColSerialNo.HeaderText = "Serial No";
            this.DgvColSerialNo.Name = "DgvColSerialNo";
            this.DgvColSerialNo.ReadOnly = true;
            // 
            // DgvColTemplate
            // 
            this.DgvColTemplate.DataPropertyName = "Template";
            this.DgvColTemplate.HeaderText = "Template";
            this.DgvColTemplate.Name = "DgvColTemplate";
            this.DgvColTemplate.ReadOnly = true;
            // 
            // DgvColPrintCount
            // 
            this.DgvColPrintCount.HeaderText = "Print Count";
            this.DgvColPrintCount.Name = "DgvColPrintCount";
            this.DgvColPrintCount.ReadOnly = true;
            // 
            // DgvColReqRemarks
            // 
            this.DgvColReqRemarks.HeaderText = "Remarks";
            this.DgvColReqRemarks.Name = "DgvColReqRemarks";
            this.DgvColReqRemarks.ReadOnly = true;
            // 
            // DgvColStatus
            // 
            this.DgvColStatus.HeaderText = "Status";
            this.DgvColStatus.Items.AddRange(new object[] {
            "Approved",
            "Rejected"});
            this.DgvColStatus.Name = "DgvColStatus";
            // 
            // DgvColRejRemarks
            // 
            this.DgvColRejRemarks.HeaderText = "Rej. Remarks";
            this.DgvColRejRemarks.Name = "DgvColRejRemarks";
            this.DgvColRejRemarks.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvColRejRemarks.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ReprintApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 412);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.panel1);
            this.Name = "ReprintApproval";
            this.Text = "Reprint Approval";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnList;
        private System.Windows.Forms.ComboBox CmbUnits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColSno;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColRequestNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColRequestDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColRequestedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColJobno;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColSerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColTemplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColPrintCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColReqRemarks;
        private System.Windows.Forms.DataGridViewComboBoxColumn DgvColStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColRejRemarks;
    }
}