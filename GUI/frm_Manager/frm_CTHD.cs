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

namespace GUI.frm_Manager
{
    public partial class frm_CTHD : Form
    {
        int maHD;
        public frm_CTHD()
        {
            InitializeComponent();
        }

        ChiTietHoaDonBUS cthdBUS = new ChiTietHoaDonBUS();
        List<ChiTietHoaDonDTO> dsCTHD = new List<ChiTietHoaDonDTO>();

        HoaDonBUS hoaDonBUS = new HoaDonBUS();
        List<HoaDonDTO> dsHoaDon = new List<HoaDonDTO>();

        NhanVienBUS nhanVienBUS = new NhanVienBUS();
        List<NhanVienDTO> dsNhanVien = new List<NhanVienDTO>();

        KhachHangBUS khachHangBUS = new KhachHangBUS();
        List<KhachHangDTO> dsKhachHang = new List<KhachHangDTO>();

        public frm_CTHD(int maHD)
        {
            InitializeComponent();
            this.maHD = maHD;
        }

        private void frm_CTHD_Load(object sender, EventArgs e)
        {
            dsCTHD = cthdBUS.LayDanhSachChiTietHoaDon(maHD);
            dgvCTHD.DataSource = dsCTHD;
            dgvCTHD.Columns["MaHD"].HeaderText = "Mã Hóa Đơn";
            dgvCTHD.Columns["MaSach"].HeaderText = "Mã Sách";
            dgvCTHD.Columns["TenSach"].HeaderText = "Tên Sách";
            dgvCTHD.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvCTHD.Columns["DonGia"].HeaderText = "Đơn Giá";
            dgvCTHD.Columns["ThanhTien"].HeaderText = "Thành Tiền";
            dgvCTHD.AutoGenerateColumns = false;

            LayHoaDon(maHD);
            LayNhanVien(int.Parse(dsHoaDon[0].MaNV.ToString()));
            LayKhachHang(int.Parse(dsHoaDon[0].MaKH.ToString()));


            if (dsNhanVien.Count > 0)
            {
                lblMaHD.Text = maHD.ToString();
                lblNgLapHD.Text = dsHoaDon[0].NgayLapHD.ToString("dd/MM/yyyy");
                lblTenNV.Text = dsNhanVien[0].HoTen.ToString();
                lblTenKhachHang.Text = dsKhachHang[0].HoTen.ToString();
                lblTongTien.Text = dsHoaDon[0].TongTien.ToString() + " VNĐ";
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên hoặc khách hàng tương ứng với hóa đơn này.");
            }
        }

        private void LayHoaDon(int maHD = -1)
        {
            dsHoaDon = hoaDonBUS.LayDanhSachHoaDon(maHD);
        }

        private void LayNhanVien(int maNV = -1)
        {
            dsNhanVien = nhanVienBUS.LayDanhSachNhanVien(maNV);
        }

        private void LayKhachHang(int maKH = -1)
        {
            dsKhachHang = khachHangBUS.LayDanhSachKhachHang(maKH);
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            dsCTHD = cthdBUS.LayDanhSachChiTietHoaDon(maHD);
            LayNhanVien(int.Parse(dsHoaDon[0].MaNV.ToString()));
            LayKhachHang(int.Parse(dsHoaDon[0].MaKH.ToString()));
            XemCTHD xemCTHD = new XemCTHD(dsCTHD, dsNhanVien[0].HoTen, dsKhachHang[0].HoTen);
            xemCTHD.ShowDialog();
        }
    }
}
