namespace CouthIntegration
{
    partial class MainForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.MasterMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.TransactionMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.ExitMenu = new System.Windows.Forms.ToolStripButton();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MasterMenu,
            this.TransactionMenu,
            this.ExitMenu});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(860, 54);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // MasterMenu
            // 
            this.MasterMenu.Image = global::CouthIntegration.Properties.Resources.Transactions;
            this.MasterMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MasterMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MasterMenu.Name = "MasterMenu";
            this.MasterMenu.Size = new System.Drawing.Size(61, 51);
            this.MasterMenu.Text = "Masters";
            this.MasterMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // TransactionMenu
            // 
            this.TransactionMenu.Image = global::CouthIntegration.Properties.Resources.Transactions;
            this.TransactionMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TransactionMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TransactionMenu.Name = "TransactionMenu";
            this.TransactionMenu.Size = new System.Drawing.Size(81, 51);
            this.TransactionMenu.Text = "Transaction";
            this.TransactionMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ExitMenu
            // 
            this.ExitMenu.Image = global::CouthIntegration.Properties.Resources.if_exit_3226;
            this.ExitMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ExitMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExitMenu.Name = "ExitMenu";
            this.ExitMenu.Size = new System.Drawing.Size(36, 51);
            this.ExitMenu.Text = "Exit";
            this.ExitMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ExitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 54);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(860, 386);
            this.webBrowser1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 440);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton MasterMenu;
        private System.Windows.Forms.ToolStripDropDownButton TransactionMenu;
        private System.Windows.Forms.ToolStripButton ExitMenu;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}