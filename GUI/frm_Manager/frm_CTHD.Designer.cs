namespace GUI.frm_Manager
{
    partial class frm_CTHD
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
            this.foreverClose1 = new ReaLTaiizor.Controls.ForeverClose();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.lblTenKhachHang = new System.Windows.Forms.Label();
            this.lblNgLapHD = new System.Windows.Forms.Label();
            this.dgvCTHD = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTHD)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(67)))), ((int)(((byte)(120)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.foreverClose1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 42);
            this.panel1.TabIndex = 0;
            // 
            // foreverClose1
            // 
            this.foreverClose1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.foreverClose1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(67)))), ((int)(((byte)(120)))));
            this.foreverClose1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(67)))), ((int)(((byte)(120)))));
            this.foreverClose1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.foreverClose1.DefaultLocation = true;
            this.foreverClose1.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.foreverClose1.Font = new System.Drawing.Font("Marlett", 10F);
            this.foreverClose1.Location = new System.Drawing.Point(770, 12);
            this.foreverClose1.Name = "foreverClose1";
            this.foreverClose1.OverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.foreverClose1.Size = new System.Drawing.Size(18, 18);
            this.foreverClose1.TabIndex = 0;
            this.foreverClose1.Text = "foreverClose1";
            this.foreverClose1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "CHI TIẾT HÓA ĐƠN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label2.Location = new System.Drawing.Point(36, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã hóa đơn:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label3.Location = new System.Drawing.Point(14, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên nhân viên:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label4.Location = new System.Drawing.Point(381, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 26);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tên khách hàng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label5.Location = new System.Drawing.Point(365, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 26);
            this.label5.TabIndex = 1;
            this.label5.Text = "Ngày lập hóa đơn:";
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.bigLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel1.Location = new System.Drawing.Point(134, 56);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(537, 67);
            this.bigLabel1.TabIndex = 2;
            this.bigLabel1.Text = "TEMPEST BOOK STORE";
            // 
            // lblTenNV
            // 
            this.lblTenNV.AutoSize = true;
            this.lblTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblTenNV.Location = new System.Drawing.Point(188, 76);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(112, 26);
            this.lblTenNV.TabIndex = 1;
            this.lblTenNV.Text = "staffName";
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblMaHD.Location = new System.Drawing.Point(188, 15);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(84, 26);
            this.lblMaHD.TabIndex = 1;
            this.lblMaHD.Text = "orderID";
            // 
            // lblTenKhachHang
            // 
            this.lblTenKhachHang.AutoSize = true;
            this.lblTenKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenKhachHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblTenKhachHang.Location = new System.Drawing.Point(576, 15);
            this.lblTenKhachHang.Name = "lblTenKhachHang";
            this.lblTenKhachHang.Size = new System.Drawing.Size(161, 26);
            this.lblTenKhachHang.TabIndex = 1;
            this.lblTenKhachHang.Text = "customerName";
            // 
            // lblNgLapHD
            // 
            this.lblNgLapHD.AutoSize = true;
            this.lblNgLapHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgLapHD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblNgLapHD.Location = new System.Drawing.Point(576, 76);
            this.lblNgLapHD.Name = "lblNgLapHD";
            this.lblNgLapHD.Size = new System.Drawing.Size(105, 26);
            this.lblNgLapHD.TabIndex = 1;
            this.lblNgLapHD.Text = "createdAt";
            // 
            // dgvCTHD
            // 
            this.dgvCTHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCTHD.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCTHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTHD.Location = new System.Drawing.Point(16, 250);
            this.dgvCTHD.Name = "dgvCTHD";
            this.dgvCTHD.ReadOnly = true;
            this.dgvCTHD.RowHeadersWidth = 62;
            this.dgvCTHD.RowTemplate.Height = 28;
            this.dgvCTHD.Size = new System.Drawing.Size(772, 303);
            this.dgvCTHD.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblNgLapHD);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblMaHD);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblTenNV);
            this.panel2.Controls.Add(this.lblTenKhachHang);
            this.panel2.Location = new System.Drawing.Point(16, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(772, 121);
            this.panel2.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label6.Location = new System.Drawing.Point(11, 573);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 26);
            this.label6.TabIndex = 1;
            this.label6.Text = "Tổng tiền:";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblTongTien.Location = new System.Drawing.Point(134, 573);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(129, 26);
            this.lblTongTien.TabIndex = 1;
            this.lblTongTien.Text = "totalAmount";
            // 
            // frm_CTHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 623);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.dgvCTHD);
            this.Controls.Add(this.bigLabel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_CTHD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_CTHD";
            this.Load += new System.EventHandler(this.frm_CTHD_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTHD)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ReaLTaiizor.Controls.ForeverClose foreverClose1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.Label lblTenKhachHang;
        private System.Windows.Forms.Label lblNgLapHD;
        private System.Windows.Forms.DataGridView dgvCTHD;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTongTien;
    }
}