using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using GUI.frm_Manager;

namespace GUI
{
    public partial class Main : Form
    {
        public static NhanVienDTO user;

        public Main(NhanVienDTO nhanVien)
        {
            InitializeComponent();
            Main.user = nhanVien;
        }
        public Main()
        {
            InitializeComponent();
        }

        private void btnQLDH_Click(object sender, EventArgs e)
        {
            btnQLDH_timer.Start();
        }
        bool btnQLDH_flag = false;
        private void btnQLDH_timer_Tick(object sender, EventArgs e)
        {
            if(!btnQLDH_flag)
            {
                QLDH_container.Height = QLDH_container.Height + 10;
                if (QLDH_container.Height >= 180)
                {
                    btnQLDH_flag = true;
                    btnQLDH_timer.Stop();
                }
            }
            else
            {
                QLDH_container.Height = QLDH_container.Height - 10;
                if (QLDH_container.Height <= 60)
                {
                    btnQLDH_flag = false;
                    btnQLDH_timer.Stop();
                }
            }
        }
        bool btnQLS_flag = false;
        private void btnQLS_timer_Tick(object sender, EventArgs e)
        {
            if (!btnQLS_flag)
            {
                QLS_container.Height = QLS_container.Height + 10;
                if (QLS_container.Height >= 240)
                {
                    btnQLS_flag = true;
                    btnQLS_timer.Stop();
                }
            }
            else
            {
                QLS_container.Height = QLS_container.Height - 10;
                if (QLS_container.Height <= 60)
                {
                    btnQLS_flag = false;
                    btnQLS_timer.Stop();
                }
            }
        }
        private void btnQLS_Click(object sender, EventArgs e)
        {
            btnQLS_timer.Start();
        }
        
        QL_TGSach qltgsach;
        private void btnTGSach_Click(object sender, EventArgs e)
        {
            if (qltgsach == null)
            {
                qltgsach = new QL_TGSach();
                qltgsach.MdiParent = this;
                qltgsach.Dock = DockStyle.Fill;
                qltgsach.Show();
            }
            else
            {
                qltgsach.Activate();
            }
        }
        QL_TLSach qltlsach;
        private void btnTLSach_Click(object sender, EventArgs e)
        {
            if (qltlsach == null)
            {
                qltlsach = new QL_TLSach();
                qltlsach.MdiParent = this;
                qltlsach.Dock = DockStyle.Fill;
                qltlsach.Show();
            }
            else
            {
                qltlsach.Activate();
            }
        }
        QL_KhachHang qlkh;
        private void btnQLKH_Click(object sender, EventArgs e)
        {
            if(qlkh == null)
            {
                qlkh = new QL_KhachHang();
                qlkh.MdiParent = this;
                qlkh.Dock = DockStyle.Fill;
                qlkh.Show();
            }
            else
            {
                qlkh.Activate();
            }    
        }
        QL_KhuyenMai qlkm;
        private void btnQLKM_Click(object sender, EventArgs e)
        {
            if(qlkm == null)
            {
                qlkm = new QL_KhuyenMai();
                qlkm.MdiParent = this;
                qlkm.Dock = DockStyle.Fill;
                qlkm.Show();
            }
            else
            {
                qlkm.Activate();
            }
        }
        QL_TheLoai qltl;
        private void btnQLTL_Click(object sender, EventArgs e)
        {
            if (qltl == null)
            {
                qltl = new QL_TheLoai();
                qltl.MdiParent = this;
                qltl.Dock = DockStyle.Fill;
                qltl.Show();
            }
            else
            {
                qltl.Activate();
            }
        }
        QL_TacGia qltg;
        private void btnQLTG_Click(object sender, EventArgs e)
        {
            if (qltg == null)
            {
                qltg = new QL_TacGia();
                qltg.MdiParent = this;
                qltg.Dock = DockStyle.Fill;
                qltg.Show();
            }
            else
            {
                qltg.Activate();
            }
        }

        private void btnSideBar_Click(object sender, EventArgs e)
        {
            btnSideBar_timer.Start();
        }
        bool btnSideBar_flag = true;
        private void btnSideBar_timer_Tick(object sender, EventArgs e)
        {
            if (!btnSideBar_flag)
            {
                sideBar.Width = sideBar.Width + 15;
                if (sideBar.Width >= 290)
                {
                    btnSideBar_flag = true;
                    btnSideBar_timer.Stop();
                    QLDH_container.Width = sideBar.Width;
                    QLS_container.Width = sideBar.Width;
                    pnDangXuat.Width = sideBar.Width;
                    pnQLKH.Width = sideBar.Width;
                    pnQLKM.Width = sideBar.Width;
                    pnQLTG.Width = sideBar.Width;
                    pnQLTL.Width = sideBar.Width;
                    pnQLNV.Width = sideBar.Width;
                    pnQLDchiKH.Width = sideBar.Width;
                    pnTTTK.Width = sideBar.Width;
                }
            }
            else
            {
                sideBar.Width = sideBar.Width - 15;
                if (sideBar.Width <= 80)
                {
                    btnSideBar_flag = false;
                    btnSideBar_timer.Stop();
                    QLDH_container.Width = sideBar.Width;
                    QLS_container.Width = sideBar.Width;
                    pnDangXuat.Width = sideBar.Width;
                    pnQLKH.Width = sideBar.Width;
                    pnQLKM.Width = sideBar.Width;
                    pnQLTG.Width = sideBar.Width;
                    pnQLTL.Width = sideBar.Width;
                    pnQLNV.Width = sideBar.Width;
                    pnQLDchiKH.Width = sideBar.Width;
                    pnTTTK.Width = sideBar.Width;
                }
            }
        }
        QL_Sach qlsach;
        private void btnSach_Click(object sender, EventArgs e)
        {
            if (qlsach == null)
            {
                qlsach = new QL_Sach();
                qlsach.MdiParent = this;
                qlsach.Dock = DockStyle.Fill;
                qlsach.Show();
            }
            else
            {
                qlsach.Activate();
            }
        }
        QL_NhanVien qlnv;
        private void btnQLNV_Click(object sender, EventArgs e)
        {
            if (qlnv == null)
            {
                qlnv = new QL_NhanVien();
                qlnv.MdiParent = this;
                qlnv.Dock = DockStyle.Fill;
                qlnv.Show();
            }
            else
            {
                qlnv.Activate();
            }
        }
        QL_DchiKH qldchi;
        private void btnQLDChiKH_Click(object sender, EventArgs e)
        {
            if (qldchi == null)
            {
                qldchi = new QL_DchiKH();
                qldchi.MdiParent = this;
                qldchi.Dock = DockStyle.Fill;
                qldchi.Show();
            }
            else
            {
                qldchi.Activate();
            }
        }
        QL_CTHD qlcthd;
        private void btnLapHD_Click(object sender, EventArgs e)
        {
            if(qlcthd == null)
            {
                qlcthd = new QL_CTHD();
                qlcthd.MdiParent = this;
                qlcthd.Dock = DockStyle.Fill;
                qlcthd.Show();
            }
            else
            {
                qlcthd.Activate();
            }
        }
        QLHoaDon qlhd;
        private void btnDSHD_Click(object sender, EventArgs e)
        {
            if (qlhd == null)
            {
                qlhd = new QLHoaDon();
                qlhd.MdiParent = this;
                qlhd.Dock = DockStyle.Fill;
                qlhd.Show();
            }
            else
            {
                qlhd.Activate();
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                this.Hide();
                DangNhap dangNhap = new DangNhap();
                dangNhap.ShowDialog();
                this.Close();
            }    
        }

        private void Main_Load(object sender, EventArgs e)
        {
            lblUserName.Text = user.HoTen;
            lblRole.Text = user.ChucVu;
            if (user.ChucVu == "Nhân viên")
            {
                btnQLNV.Visible = false;
                pnQLNV.Visible = false;
            }    
        }
    }
}
