namespace CouthIntegration
{
    partial class PrintPreview
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
            this.rtfPreview = new System.Windows.Forms.RichTextBox();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtfPreview
            // 
            this.rtfPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfPreview.Location = new System.Drawing.Point(12, 12);
            this.rtfPreview.Name = "rtfPreview";
            this.rtfPreview.ReadOnly = true;
            this.rtfPreview.Size = new System.Drawing.Size(544, 404);
            this.rtfPreview.TabIndex = 0;
            this.rtfPreview.Text = "";
            // 
            // BtnPrint
            // 
            this.BtnPrint.Location = new System.Drawing.Point(477, 438);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(75, 23);
            this.BtnPrint.TabIndex = 1;
            this.BtnPrint.Text = "Print && Next";
            this.BtnPrint.UseVisualStyleBackColor = true;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // PrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 473);
            this.Controls.Add(this.BtnPrint);
            this.Controls.Add(this.rtfPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PrintPreview";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtfPreview;
        private System.Windows.Forms.Button BtnPrint;
    }
}