namespace GUI
{
    partial class QLHoaDon
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
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDSHD = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbValue = new System.Windows.Forms.ComboBox();
            this.cbKey = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXemCTHD = new FontAwesome.Sharp.IconButton();
            this.elipseControl1 = new GUI.ElipseControl();
            this.btnRefresh = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHD)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel14.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.bigLabel1.ForeColor = System.Drawing.Color.White;
            this.bigLabel1.Location = new System.Drawing.Point(24, 9);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(356, 48);
            this.bigLabel1.TabIndex = 1;
            this.bigLabel1.Text = "QUẢN LÝ HÓA ĐƠN";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(67)))), ((int)(((byte)(120)))));
            this.panel1.Controls.Add(this.bigLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 68);
            this.panel1.TabIndex = 27;
            // 
            // dgvDSHD
            // 
            this.dgvDSHD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDSHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDSHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSHD.Location = new System.Drawing.Point(25, 38);
            this.dgvDSHD.MultiSelect = false;
            this.dgvDSHD.Name = "dgvDSHD";
            this.dgvDSHD.ReadOnly = true;
            this.dgvDSHD.RowHeadersWidth = 62;
            this.dgvDSHD.RowTemplate.Height = 28;
            this.dgvDSHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSHD.Size = new System.Drawing.Size(1183, 465);
            this.dgvDSHD.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.dgvDSHD);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(32, 339);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1231, 530);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách hóa đơn";
            // 
            // panel14
            // 
            this.panel14.AutoSize = true;
            this.panel14.Controls.Add(this.btnRefresh);
            this.panel14.Controls.Add(this.groupBox4);
            this.panel14.Controls.Add(this.groupBox1);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(0, 68);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(1300, 898);
            this.panel14.TabIndex = 29;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox4.AutoSize = true;
            this.groupBox4.Controls.Add(this.btnXemCTHD);
            this.groupBox4.Controls.Add(this.cbValue);
            this.groupBox4.Controls.Add(this.cbKey);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(389, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(524, 313);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tìm kiếm";
            // 
            // cbValue
            // 
            this.cbValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cbValue.FormattingEnabled = true;
            this.cbValue.Location = new System.Drawing.Point(164, 176);
            this.cbValue.Name = "cbValue";
            this.cbValue.Size = new System.Drawing.Size(199, 38);
            this.cbValue.TabIndex = 36;
            this.cbValue.SelectionChangeCommitted += new System.EventHandler(this.cbValue_SelectionChangeCommitted);
            // 
            // cbKey
            // 
            this.cbKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cbKey.FormattingEnabled = true;
            this.cbKey.Items.AddRange(new object[] {
            "Mã hóa đơn",
            "Mã nhân viên",
            "Mã khách hàng"});
            this.cbKey.Location = new System.Drawing.Point(164, 78);
            this.cbKey.Name = "cbKey";
            this.cbKey.Size = new System.Drawing.Size(199, 38);
            this.cbKey.TabIndex = 36;
            this.cbKey.SelectionChangeCommitted += new System.EventHandler(this.cbKey_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 30);
            this.label1.TabIndex = 37;
            this.label1.Text = "Tìm kiếm theo:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 30);
            this.label2.TabIndex = 37;
            this.label2.Text = "Nội dung tìm kiếm:";
            // 
            // btnXemCTHD
            // 
            this.btnXemCTHD.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXemCTHD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(67)))), ((int)(((byte)(120)))));
            this.btnXemCTHD.FlatAppearance.BorderSize = 0;
            this.btnXemCTHD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnXemCTHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemCTHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemCTHD.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnXemCTHD.IconChar = FontAwesome.Sharp.IconChar.FileText;
            this.btnXemCTHD.IconColor = System.Drawing.Color.AliceBlue;
            this.btnXemCTHD.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXemCTHD.IconSize = 35;
            this.btnXemCTHD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemCTHD.Location = new System.Drawing.Point(96, 229);
            this.btnXemCTHD.Name = "btnXemCTHD";
            this.btnXemCTHD.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.btnXemCTHD.Size = new System.Drawing.Size(334, 48);
            this.btnXemCTHD.TabIndex = 31;
            this.btnXemCTHD.Text = "     Xem chi tiết hóa đơn";
            this.btnXemCTHD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemCTHD.UseVisualStyleBackColor = false;
            this.btnXemCTHD.Click += new System.EventHandler(this.btnXemCTHD_Click);
            // 
            // elipseControl1
            // 
            this.elipseControl1.CornerRadius = 50;
            this.elipseControl1.TargetControl = null;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(67)))), ((int)(((byte)(120)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnRefresh.IconChar = FontAwesome.Sharp.IconChar.Redo;
            this.btnRefresh.IconColor = System.Drawing.Color.AliceBlue;
            this.btnRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRefresh.IconSize = 35;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnRefresh.Location = new System.Drawing.Point(1069, 281);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnRefresh.Size = new System.Drawing.Size(194, 48);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Text = "       Làm mới";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // QLHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1300, 966);
            this.Controls.Add(this.panel14);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QLHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "QLHoaDon";
            this.Load += new System.EventHandler(this.QLHoaDon_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ElipseControl elipseControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDSHD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbKey;
        private System.Windows.Forms.ComboBox cbValue;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnXemCTHD;
        private FontAwesome.Sharp.IconButton btnRefresh;
    }
}