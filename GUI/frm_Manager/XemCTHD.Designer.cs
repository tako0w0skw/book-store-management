namespace GUI.frm_Manager
{
    partial class XemCTHD
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
            this.rpvCTHD = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.foreverClose1 = new ReaLTaiizor.Controls.ForeverClose();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rpvCTHD
            // 
            this.rpvCTHD.AutoSize = true;
            this.rpvCTHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvCTHD.Location = new System.Drawing.Point(0, 50);
            this.rpvCTHD.Name = "rpvCTHD";
            this.rpvCTHD.ServerReport.BearerToken = null;
            this.rpvCTHD.Size = new System.Drawing.Size(1500, 1056);
            this.rpvCTHD.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(67)))), ((int)(((byte)(120)))));
            this.panel1.Controls.Add(this.foreverClose1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1500, 50);
            this.panel1.TabIndex = 1;
            // 
            // foreverClose1
            // 
            this.foreverClose1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.foreverClose1.BackColor = System.Drawing.Color.White;
            this.foreverClose1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(67)))), ((int)(((byte)(120)))));
            this.foreverClose1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.foreverClose1.DefaultLocation = false;
            this.foreverClose1.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.foreverClose1.Font = new System.Drawing.Font("Marlett", 10F);
            this.foreverClose1.Location = new System.Drawing.Point(1464, 12);
            this.foreverClose1.Name = "foreverClose1";
            this.foreverClose1.OverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.foreverClose1.Size = new System.Drawing.Size(18, 18);
            this.foreverClose1.TabIndex = 0;
            this.foreverClose1.Text = "foreverClose1";
            this.foreverClose1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // XemCTHD
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1500, 1106);
            this.Controls.Add(this.rpvCTHD);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "XemCTHD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XemCTHD";
            this.Load += new System.EventHandler(this.XemCTHD_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvCTHD;
        private System.Windows.Forms.Panel panel1;
        private ReaLTaiizor.Controls.ForeverClose foreverClose1;
    }
}