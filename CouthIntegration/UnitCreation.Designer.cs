namespace CouthIntegration
{
    partial class UnitCreation
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtOracleUnitID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.DgvColDesignation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColApprover = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DgvColUnitRightsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColDesignationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColAvailable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unit Name";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(82, 10);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(300, 20);
            this.txtUnit.TabIndex = 1;
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvColDesignation,
            this.DgvColApprover,
            this.DgvColUnitRightsID,
            this.DgvColDesignationID,
            this.DgvColAvailable});
            this.Grid.Location = new System.Drawing.Point(8, 86);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(473, 243);
            this.Grid.TabIndex = 2;
            this.Grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Grid_DataError);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Controls.Add(this.BtnSave);
            this.panel1.Location = new System.Drawing.Point(8, 335);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 34);
            this.panel1.TabIndex = 15;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(393, 6);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 15;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(312, 6);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 14;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtOracleUnitID
            // 
            this.txtOracleUnitID.Location = new System.Drawing.Point(82, 36);
            this.txtOracleUnitID.MaxLength = 5;
            this.txtOracleUnitID.Name = "txtOracleUnitID";
            this.txtOracleUnitID.Size = new System.Drawing.Size(300, 20);
            this.txtOracleUnitID.TabIndex = 17;
            this.txtOracleUnitID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOracleUnitID_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Oracle UnitID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Active";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(82, 66);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(15, 14);
            this.chkActive.TabIndex = 19;
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // DgvColDesignation
            // 
            this.DgvColDesignation.DataPropertyName = "Designation";
            this.DgvColDesignation.HeaderText = "Designation";
            this.DgvColDesignation.Name = "DgvColDesignation";
            this.DgvColDesignation.ReadOnly = true;
            this.DgvColDesignation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvColDesignation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColDesignation.Width = 150;
            // 
            // DgvColApprover
            // 
            this.DgvColApprover.DataPropertyName = "UserID";
            this.DgvColApprover.HeaderText = "Approver";
            this.DgvColApprover.Name = "DgvColApprover";
            this.DgvColApprover.Width = 150;
            // 
            // DgvColUnitRightsID
            // 
            this.DgvColUnitRightsID.DataPropertyName = "UnitRightsID";
            this.DgvColUnitRightsID.HeaderText = "UnitRightsID";
            this.DgvColUnitRightsID.Name = "DgvColUnitRightsID";
            this.DgvColUnitRightsID.ReadOnly = true;
            this.DgvColUnitRightsID.Visible = false;
            // 
            // DgvColDesignationID
            // 
            this.DgvColDesignationID.DataPropertyName = "DesignationID";
            this.DgvColDesignationID.HeaderText = "DesignationID";
            this.DgvColDesignationID.Name = "DgvColDesignationID";
            this.DgvColDesignationID.ReadOnly = true;
            this.DgvColDesignationID.Visible = false;
            // 
            // DgvColAvailable
            // 
            this.DgvColAvailable.DataPropertyName = "Available";
            this.DgvColAvailable.HeaderText = "Available";
            this.DgvColAvailable.Name = "DgvColAvailable";
            // 
            // UnitCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 382);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOracleUnitID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UnitCreation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UnitCreation";
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtOracleUnitID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColDesignation;
        private System.Windows.Forms.DataGridViewComboBoxColumn DgvColApprover;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColUnitRightsID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColDesignationID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DgvColAvailable;
    }
}