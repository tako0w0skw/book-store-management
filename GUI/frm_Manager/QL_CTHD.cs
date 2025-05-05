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

namespace GUI
{
    public partial class QL_CTHD : Form
    {
        NhanVienDTO user = Main.user;
        public QL_CTHD()
        {
            InitializeComponent();

            lblTongTien.Text = "0 VNĐ";
            txtTamTinh.Text = "0 VNĐ";
        }
        double tamTinh = 0;
        double tongTien = 0;

        SachBUS sachBUS = new SachBUS();
        List<SachDTO> dsSach = new List<SachDTO>();

        KhuyenMaiBUS khuyenMaiBUS = new KhuyenMaiBUS();
        List<KhuyenMaiDTO> dsKhuyenMai = new List<KhuyenMaiDTO>();

        KhachHangBUS khachHangBUS = new KhachHangBUS();
        List<KhachHangDTO> dsKhachHang = new List<KhachHangDTO>();

        HoaDonBUS hoaDonBUS = new HoaDonBUS();

        ChiTietHoaDonBUS chiTietHoaDonBUS = new ChiTietHoaDonBUS();


        public void TinhTongTien()
        {
            if(lvwCTHD.Items.Count == 0)
            {
                Reset();
            }    

            double phiVC = txtPhiVC.Text == "" ? 0 : double.Parse(txtPhiVC.Text);
            double giamGia = 0;
            if(txtSoTienGiam.Text != "")
            {
                if(txtSoTienGiam.Text.Contains("%"))
                {
                    giamGia = (tamTinh * double.Parse(txtSoTienGiam.Text.Replace(" %", ""))) / 100;
                }
                else
                {
                    giamGia = double.Parse(txtSoTienGiam.Text.Replace(" VNĐ", ""));
                }    
            }
            
            txtTamTinh.Text = tamTinh.ToString() + " VNĐ";

            tongTien = tamTinh - giamGia + phiVC;
            lblTongTien.Text = tongTien.ToString() + " VNĐ";
        }

        private void QL_CTHD_Load(object sender, EventArgs e)
        {
            LoadComboBoxTenSach();
            LoadComboBoxKhuyenMai();
            LoadComboBoxKhachHang();
            cbMaKM.SelectedIndex = -1;
            cbMaKH.SelectedIndex = -1;
        }
        
        public void LoadComboBoxTenSach()
        {
            dsSach = sachBUS.LayDanhSachSach();
            cbTenSach.DataSource = dsSach;
            cbTenSach.DisplayMember = "TenSach";
            cbTenSach.ValueMember = "MaSach";
        }

        public void LoadComboBoxKhuyenMai()
        {
            dsKhuyenMai = khuyenMaiBUS.LayDanhSachKhuyenMai();
            cbMaKM.DataSource = dsKhuyenMai;
            cbMaKM.DisplayMember = "TenMa";
            cbMaKM.ValueMember = "MaKM";
        }

        private void cbTenSach_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbTenSach.SelectedValue != null)
            {
                int maSach = int.Parse(cbTenSach.SelectedValue.ToString());
                dsSach = sachBUS.LayDanhSachSach(maSach);
                txtTonKho.Text = dsSach[0].SoLuongTon.ToString();
                txtDonGia.Text = dsSach[0].Gia.ToString();
                nmSoLuong_ValueChanged(sender, e);
            }
        }

        private void nmSoLuong_ValueChanged(object sender, EventArgs e)
        {
            int soLuong = (int)nmSoLuong.Value;
            if (soLuong > dsSach[0].SoLuongTon)
            {
                MessageBox.Show("Vượt quá số lượng tồn kho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nmSoLuong.Value = dsSach[0].SoLuongTon;
            }
            else
            {
                double thanhTien = soLuong * dsSach[0].Gia;
                txtThanhTien.Text = thanhTien.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(nmSoLuong.Value == 0)
            {
                MessageBox.Show("Số lượng không được bằng 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSach = cbTenSach.SelectedValue?.ToString();

            ListViewItem items = new ListViewItem(maSach);
            items.Name = maSach;
            items.SubItems.Add(cbTenSach.Text);
            items.SubItems.Add(nmSoLuong.Value.ToString());
            items.SubItems.Add(txtDonGia.Text);
            items.SubItems.Add(txtThanhTien.Text);

            // Kiểm tra xem mã sách đã tồn tại trong ListView chưa, nếu có thì cập nhật số lượng và thành tiền
            int indexOfExistItem = lvwCTHD.Items.IndexOfKey(maSach);
            if (indexOfExistItem >= 0)
            {
                if (int.TryParse(lvwCTHD.Items[indexOfExistItem].SubItems[2].Text, out int soLuongHienTai) &&
                    double.TryParse(lvwCTHD.Items[indexOfExistItem].SubItems[3].Text, out double donGiaHienTai))
                {
                    int soLuongMoi = soLuongHienTai + (int)nmSoLuong.Value;
                    double thanhTienMoi = donGiaHienTai * soLuongMoi;
                    lvwCTHD.Items[indexOfExistItem].SubItems[2].Text = soLuongMoi.ToString();
                    lvwCTHD.Items[indexOfExistItem].SubItems[4].Text = thanhTienMoi.ToString();
                }
            }
            else
            {
                lvwCTHD.Items.Add(items);
            }

            tamTinh += double.Parse(txtThanhTien.Text);
            txtTamTinh.Text = tamTinh.ToString() + " VNĐ";

            TinhTongTien();

            Clear();
        }

        private void lvwCTHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvwCTHD.SelectedItems.Count > 0)
            {
                ListViewItem item = lvwCTHD.SelectedItems[0];
                cbTenSach.SelectedValue = int.Parse(item.Name);
                nmSoLuong.Value = int.Parse(item.SubItems[2].Text);
            }    
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(lvwCTHD.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    ListViewItem item = lvwCTHD.SelectedItems[0];
                    tamTinh -= double.Parse(item.SubItems[4].Text);
                    lvwCTHD.Items.Remove(item);
                    TinhTongTien();
                    Clear();
                }    
            }    
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
        }

        public void Clear()
        {
            cbTenSach.SelectedIndex = -1;
            nmSoLuong.Value = 0;
            txtTonKho.Text = "";
            txtDonGia.Text = "";
            txtThanhTien.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(lvwCTHD.SelectedItems.Count > 0)
            {
                ListViewItem item = lvwCTHD.SelectedItems[0];
                item.SubItems[2].Text = nmSoLuong.Value.ToString();

                item.SubItems[4].Text = (int.Parse(item.SubItems[2].Text) * double.Parse(item.SubItems[3].Text)).ToString();

                TinhTongTien();

                MessageBox.Show("Đã cập nhật số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm muốn sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
        }

        public void LoadComboBoxKhachHang()
        {
            dsKhachHang = khachHangBUS.LayDanhSachKhachHang();
            cbMaKH.DataSource = dsKhachHang;
            cbMaKH.DisplayMember = "HoTen";
            cbMaKH.ValueMember = "MaKH";
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }    
            if(txtSDT.Text.Length > 9 && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Số điện thoại không được vượt quá 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }    
        }

        private void txtPhiVC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }

        private void cbMaKM_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dsKhuyenMai = khuyenMaiBUS.LayDanhSachKhuyenMai(cbMaKM.SelectedValue.ToString());
            if (dsKhuyenMai.Count > 0)
            {
                txtSoTienGiam.Text = dsKhuyenMai[0].MucGiam.ToString();
                if (dsKhuyenMai[0].LoaiGiam == "Phần trăm (%)" || dsKhuyenMai[0].LoaiGiam == "percent")
                {
                    txtSoTienGiam.Text += " %";
                }
                else
                {
                    txtSoTienGiam.Text += " VNĐ";
                }
            }
            else
            {
                txtSoTienGiam.Text = "";
            }
            TinhTongTien();
        }

        private void txtPhiVC_TextChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void btnLapHD_Click(object sender, EventArgs e)
        {
            if (lvwCTHD.Items.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm sản phẩm vào hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbMaKH.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtPhiVC.Text == "")
            {
                MessageBox.Show("Vui lòng nhập phí vận chuyển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbPTTT.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbPTGH.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phương thức giao hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn lập hóa đơn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.No)
            {
                return;
            }

            try
            {
                HoaDonDTO hoaDon = new HoaDonDTO();
                hoaDon.TamTinh = tamTinh;
                hoaDon.PhiVanChuyen = double.Parse(txtPhiVC.Text);
                hoaDon.TongTien = tongTien;
                hoaDon.PT_ThanhToan = cbPTTT.Text;
                hoaDon.PT_GiaoHang = cbPTGH.Text;
                hoaDon.SDT = txtSDT.Text;
                hoaDon.MaKH = int.Parse(cbMaKH.SelectedValue.ToString());
                hoaDon.MaKM = cbMaKM.SelectedValue.ToString();
                hoaDon.MaNV = user.MaNV;

                int kq = hoaDonBUS.ThemHoaDon(hoaDon);
                if (kq > 0)
                {
                    ChiTietHoaDonDTO chiTietHoaDon = new ChiTietHoaDonDTO();
                    chiTietHoaDon.MaHD = hoaDonBUS.LayHoaDonVuaTao().MaHD;

                    foreach (ListViewItem item in lvwCTHD.Items)
                    {
                        chiTietHoaDon.MaSach = int.Parse(item.Name);
                        chiTietHoaDon.TenSach = item.SubItems[1].Text;
                        chiTietHoaDon.SoLuong = int.Parse(item.SubItems[2].Text);
                        chiTietHoaDon.DonGia = double.Parse(item.SubItems[3].Text);
                        chiTietHoaDon.ThanhTien = double.Parse(item.SubItems[4].Text);

                        // Thêm chi tiết hóa đơn
                        int kq2 = chiTietHoaDonBUS.ThemChiTietHoaDon(chiTietHoaDon);
                        // Cập nhật số lượng tồn kho
                        sachBUS.CapNhatSoLuongTon(chiTietHoaDon.MaSach, chiTietHoaDon.SoLuong);
                    }

                    MessageBox.Show("Lập hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lập hóa đơn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lập hóa đơn: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Reset();
            }
        }

        public void Reset()
        {
            // Reset lại các trường thông tin sau khi lập hóa đơn
            lvwCTHD.Items.Clear();
            tamTinh = 0;
            txtTamTinh.Text = "0 VNĐ";
            lblTongTien.Text = "0 VNĐ";
            txtPhiVC.Text = "";
            txtSDT.Text = "";
            txtSoTienGiam.Text = "";
            cbMaKH.SelectedIndex = -1;
            cbMaKM.SelectedIndex = -1;
            cbPTGH.SelectedIndex = -1;
            cbPTTT.SelectedIndex = -1;
        }
    }
}
