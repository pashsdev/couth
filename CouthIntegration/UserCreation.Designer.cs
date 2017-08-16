namespace CouthIntegration
{
    partial class UserCreation
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
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.ChkIsApprover = new System.Windows.Forms.CheckBox();
            this.ChkIsAdmin = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DtFrom = new System.Windows.Forms.DateTimePicker();
            this.DtTo = new System.Windows.Forms.DateTimePicker();
            this.grid = new System.Windows.Forms.DataGridView();
            this.DgvColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColUserUnitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColUnitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColFull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DgvColView = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "* User Name";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(79, 12);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(251, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // ChkIsApprover
            // 
            this.ChkIsApprover.AutoSize = true;
            this.ChkIsApprover.Location = new System.Drawing.Point(492, 66);
            this.ChkIsApprover.Name = "ChkIsApprover";
            this.ChkIsApprover.Size = new System.Drawing.Size(80, 17);
            this.ChkIsApprover.TabIndex = 2;
            this.ChkIsApprover.Text = "Is Approver";
            this.ChkIsApprover.UseVisualStyleBackColor = true;
            // 
            // ChkIsAdmin
            // 
            this.ChkIsAdmin.AutoSize = true;
            this.ChkIsAdmin.Location = new System.Drawing.Point(591, 66);
            this.ChkIsAdmin.Name = "ChkIsAdmin";
            this.ChkIsAdmin.Size = new System.Drawing.Size(66, 17);
            this.ChkIsAdmin.TabIndex = 3;
            this.ChkIsAdmin.Text = "Is Admin";
            this.ChkIsAdmin.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(79, 38);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(251, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "* Password";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(79, 64);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(251, 20);
            this.txtEmail.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "* Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(381, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "From Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(381, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "To Date";
            // 
            // DtFrom
            // 
            this.DtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFrom.Location = new System.Drawing.Point(457, 12);
            this.DtFrom.Name = "DtFrom";
            this.DtFrom.ShowCheckBox = true;
            this.DtFrom.Size = new System.Drawing.Size(200, 20);
            this.DtFrom.TabIndex = 10;
            // 
            // DtTo
            // 
            this.DtTo.Checked = false;
            this.DtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtTo.Location = new System.Drawing.Point(457, 38);
            this.DtTo.Name = "DtTo";
            this.DtTo.ShowCheckBox = true;
            this.DtTo.Size = new System.Drawing.Size(200, 20);
            this.DtTo.TabIndex = 11;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvColUnit,
            this.DgvColUserUnitID,
            this.DgvColUnitID,
            this.DgvColFull,
            this.DgvColView});
            this.grid.Location = new System.Drawing.Point(12, 90);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(645, 168);
            this.grid.TabIndex = 12;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            // 
            // DgvColUnit
            // 
            this.DgvColUnit.DataPropertyName = "Unit";
            this.DgvColUnit.HeaderText = "UnitName";
            this.DgvColUnit.Name = "DgvColUnit";
            this.DgvColUnit.ReadOnly = true;
            this.DgvColUnit.Width = 200;
            // 
            // DgvColUserUnitID
            // 
            this.DgvColUserUnitID.DataPropertyName = "UserUnitID";
            this.DgvColUserUnitID.HeaderText = "UserUnitID";
            this.DgvColUserUnitID.Name = "DgvColUserUnitID";
            this.DgvColUserUnitID.ReadOnly = true;
            this.DgvColUserUnitID.Visible = false;
            // 
            // DgvColUnitID
            // 
            this.DgvColUnitID.DataPropertyName = "UnitID";
            this.DgvColUnitID.HeaderText = "UnitID";
            this.DgvColUnitID.Name = "DgvColUnitID";
            this.DgvColUnitID.ReadOnly = true;
            this.DgvColUnitID.Visible = false;
            // 
            // DgvColFull
            // 
            this.DgvColFull.DataPropertyName = "FullRights";
            this.DgvColFull.HeaderText = "Full";
            this.DgvColFull.Name = "DgvColFull";
            // 
            // DgvColView
            // 
            this.DgvColView.DataPropertyName = "ViewRights";
            this.DgvColView.HeaderText = "View";
            this.DgvColView.Name = "DgvColView";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Controls.Add(this.BtnSave);
            this.panel1.Location = new System.Drawing.Point(12, 265);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 34);
            this.panel1.TabIndex = 14;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(565, 6);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 15;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(479, 6);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 14;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // UserCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 305);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.DtTo);
            this.Controls.Add(this.DtFrom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChkIsAdmin);
            this.Controls.Add(this.ChkIsApprover);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserCreation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Creation";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.CheckBox ChkIsApprover;
        private System.Windows.Forms.CheckBox ChkIsAdmin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DtFrom;
        private System.Windows.Forms.DateTimePicker DtTo;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColUserUnitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColUnitID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DgvColFull;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DgvColView;
    }
}