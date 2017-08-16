namespace CouthIntegration
{
    partial class UserListing
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnList = new System.Windows.Forms.Button();
            this.CmbUsers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.DgvColUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColFromDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColToDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColIsApprover = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DgvColIsAdmin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DgvColResetPassword = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PanAction = new System.Windows.Forms.Panel();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.PanAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnList);
            this.panel1.Controls.Add(this.CmbUsers);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(9, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(789, 53);
            this.panel1.TabIndex = 2;
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
            // CmbUsers
            // 
            this.CmbUsers.DisplayMember = "UserName";
            this.CmbUsers.FormattingEnabled = true;
            this.CmbUsers.Location = new System.Drawing.Point(77, 16);
            this.CmbUsers.Name = "CmbUsers";
            this.CmbUsers.Size = new System.Drawing.Size(166, 21);
            this.CmbUsers.TabIndex = 3;
            this.CmbUsers.ValueMember = "UserID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "User Name";
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvColUserID,
            this.DgvColUserName,
            this.DgvColEmail,
            this.DgvColFromDate,
            this.DgvColToDate,
            this.DgvColIsApprover,
            this.DgvColIsAdmin,
            this.DgvColResetPassword});
            this.grid.Location = new System.Drawing.Point(9, 67);
            this.grid.Name = "grid";
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(789, 353);
            this.grid.TabIndex = 3;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            this.grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grid_CellFormatting);
            // 
            // DgvColUserID
            // 
            this.DgvColUserID.DataPropertyName = "UserID";
            this.DgvColUserID.HeaderText = "UserID";
            this.DgvColUserID.Name = "DgvColUserID";
            this.DgvColUserID.ReadOnly = true;
            this.DgvColUserID.Visible = false;
            // 
            // DgvColUserName
            // 
            this.DgvColUserName.DataPropertyName = "UserName";
            this.DgvColUserName.HeaderText = "User";
            this.DgvColUserName.Name = "DgvColUserName";
            this.DgvColUserName.ReadOnly = true;
            // 
            // DgvColEmail
            // 
            this.DgvColEmail.DataPropertyName = "Email";
            this.DgvColEmail.HeaderText = "Email";
            this.DgvColEmail.Name = "DgvColEmail";
            this.DgvColEmail.ReadOnly = true;
            this.DgvColEmail.Width = 150;
            // 
            // DgvColFromDate
            // 
            this.DgvColFromDate.DataPropertyName = "FromDate";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            dataGridViewCellStyle1.NullValue = null;
            this.DgvColFromDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgvColFromDate.HeaderText = "From Date";
            this.DgvColFromDate.Name = "DgvColFromDate";
            this.DgvColFromDate.ReadOnly = true;
            // 
            // DgvColToDate
            // 
            this.DgvColToDate.DataPropertyName = "ToDate";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.DgvColToDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvColToDate.HeaderText = "To Date";
            this.DgvColToDate.Name = "DgvColToDate";
            this.DgvColToDate.ReadOnly = true;
            // 
            // DgvColIsApprover
            // 
            this.DgvColIsApprover.DataPropertyName = "IsApprover";
            this.DgvColIsApprover.HeaderText = "Is Approver";
            this.DgvColIsApprover.Name = "DgvColIsApprover";
            this.DgvColIsApprover.ReadOnly = true;
            this.DgvColIsApprover.Width = 70;
            // 
            // DgvColIsAdmin
            // 
            this.DgvColIsAdmin.DataPropertyName = "IsAdmin";
            this.DgvColIsAdmin.HeaderText = "Is Admin";
            this.DgvColIsAdmin.Name = "DgvColIsAdmin";
            this.DgvColIsAdmin.ReadOnly = true;
            this.DgvColIsAdmin.Width = 70;
            // 
            // DgvColResetPassword
            // 
            this.DgvColResetPassword.DataPropertyName = "ResetPassword";
            this.DgvColResetPassword.HeaderText = "Reset Password";
            this.DgvColResetPassword.Name = "DgvColResetPassword";
            this.DgvColResetPassword.Text = "Reset";
            // 
            // PanAction
            // 
            this.PanAction.Controls.Add(this.BtnEdit);
            this.PanAction.Controls.Add(this.BtnAdd);
            this.PanAction.Location = new System.Drawing.Point(12, 427);
            this.PanAction.Name = "PanAction";
            this.PanAction.Size = new System.Drawing.Size(786, 41);
            this.PanAction.TabIndex = 4;
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
            // UserListing
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
            this.Name = "UserListing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Creation";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.PanAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox CmbUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button BtnList;
        private System.Windows.Forms.Panel PanAction;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColFromDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColToDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DgvColIsApprover;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DgvColIsAdmin;
        private System.Windows.Forms.DataGridViewButtonColumn DgvColResetPassword;
    }
}