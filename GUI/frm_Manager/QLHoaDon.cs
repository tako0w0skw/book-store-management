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
using BUS;
using GUI.frm_Manager;

namespace GUI
{
    public partial class QLHoaDon : Form
    {
        public QLHoaDon()
        {
            InitializeComponent();
        }

        HoaDonBUS hoaDonBUS = new HoaDonBUS();
        List<HoaDonDTO> dsHoaDon = new List<HoaDonDTO>();

        NhanVienBUS nhanVienBUS = new NhanVienBUS();
        List<NhanVienDTO> dsNhanVien = new List<NhanVienDTO>();

        KhachHangBUS khachHangBUS = new KhachHangBUS();
        List<KhachHangDTO> dsKhachHang = new List<KhachHangDTO>();

        private void QLHoaDon_Load(object sender, EventArgs e)
        {
            LayDanhSachHoaDon();
        }

        public void LayDanhSachHoaDon()
        {
            dsHoaDon = hoaDonBUS.LayDanhSachHoaDon();
            dgvDSHD.DataSource = dsHoaDon;
            dgvDSHD.Columns["MaHD"].HeaderText = "Mã Hóa Đơn";
            dgvDSHD.Columns["TamTinh"].HeaderText = "Tạm Tính";
            dgvDSHD.Columns["PhiVanChuyen"].HeaderText = "Phí Vận Chuyển";
            dgvDSHD.Columns["TongTien"].HeaderText = "Tổng Tiền";
            dgvDSHD.Columns["PT_ThanhToan"].HeaderText = "Phương Thức Thanh Toán";
            dgvDSHD.Columns["PT_GiaoHang"].HeaderText = "Phương Thức Giao Hàng";
            dgvDSHD.Columns["SDT"].HeaderText = "Số Điện Thoại";
            dgvDSHD.Columns["TrangThai"].HeaderText = "Trạng Thái";
            dgvDSHD.Columns["MaKH"].HeaderText = "Mã Khách Hàng";
            dgvDSHD.Columns["MaKM"].HeaderText = "Mã Khuyến Mãi";
            dgvDSHD.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            dgvDSHD.Columns["NgayLapHD"].HeaderText = "Ngày Lập Hóa Đơn";
            dgvDSHD.AutoGenerateColumns = false;
        }

        private void cbKey_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cbKey.SelectedIndex == 0) // Mã hóa đơn
            {
                dsHoaDon = hoaDonBUS.LayDanhSachHoaDon();
                cbValue.DataSource = dsHoaDon;
                cbValue.DisplayMember = "MaHD";
                cbValue.ValueMember = "MaHD";
            }    
            else if(cbKey.SelectedIndex == 1) // Mã nhân viên
            {
                dsNhanVien = nhanVienBUS.LayDanhSachNhanVien();
                cbValue.DataSource = dsNhanVien;
                cbValue.DisplayMember = "MaNV";
                cbValue.ValueMember = "MaNV";
            }
            else
            {
                dsKhachHang = khachHangBUS.LayDanhSachKhachHang();
                cbValue.DataSource = dsKhachHang;
                cbValue.DisplayMember = "MaKH";
                cbValue.ValueMember = "MaKH";
            }    
        }

        private void cbValue_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbKey.SelectedIndex == 0) // Mã hóa đơn
            {
                int maHD = int.Parse(cbValue.SelectedValue.ToString());
                dsHoaDon = hoaDonBUS.LayDanhSachHoaDon(maHD);
                dgvDSHD.DataSource = dsHoaDon;
            }
            else if (cbKey.SelectedIndex == 1) // Mã nhân viên
            {
                int maNV = int.Parse(cbValue.SelectedValue.ToString());
                dsHoaDon = hoaDonBUS.LayDanhSachHoaDon(-1, maNV);
                dgvDSHD.DataSource = dsHoaDon;
            }
            else // Mã khách hàng
            {
                int maKH = int.Parse(cbValue.SelectedValue.ToString());
                dsHoaDon = hoaDonBUS.LayDanhSachHoaDon(-1, -1, maKH);
                dgvDSHD.DataSource = dsHoaDon;
            }
        }

        private void btnXemCTHD_Click(object sender, EventArgs e)
        {
            if(dgvDSHD.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHD = int.Parse(dgvDSHD.SelectedRows[0].Cells["MaHD"].Value.ToString());
            frm_CTHD cthd = new frm_CTHD(maHD);
            cthd.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cbKey.SelectedIndex = -1;
            cbValue.DataSource = null;
            QLHoaDon_Load(sender, e);
        }
    }
}
