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
    public partial class QL_KhachHang : Form
    {
        public QL_KhachHang()
        {
            InitializeComponent();
        }

        KhachHangBUS khachHangBUS = new KhachHangBUS();
        List<KhachHangDTO> dsKhachHang = new List<KhachHangDTO>();

        private void QL_KhachHang_Load(object sender, EventArgs e)
        {
            LayDanhSachKhachHang();
        }

        public void LayDanhSachKhachHang()
        {
            dsKhachHang = khachHangBUS.LayDanhSachKhachHang();
            dgvKhachHang.DataSource = dsKhachHang;
            dgvKhachHang.Columns["MaKH"].HeaderText = "Mã khách hàng";
            dgvKhachHang.Columns["HoTen"].HeaderText = "Họ tên";
            dgvKhachHang.Columns["SDT"].HeaderText = "Số điện thoại";
            dgvKhachHang.Columns["Email"].HeaderText = "Email";
            dgvKhachHang.Columns["Username"].HeaderText = "Tên đăng nhập";
            dgvKhachHang.Columns["Password_KH"].HeaderText = "Mật khẩu";
            dgvKhachHang.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvKhachHang.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvKhachHang.AutoGenerateColumns = false;
        }

        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvKhachHang.SelectedRows.Count > 0)
            {
                KhachHangDTO khachHang = dgvKhachHang.SelectedRows[0].DataBoundItem as KhachHangDTO;
                if(khachHang != null)
                {
                    txtMaKH.Text = khachHang.MaKH.ToString();
                    txtHoTen.Text = khachHang.HoTen;
                    txtSDT.Text = khachHang.SDT;
                    txtEmail.Text = khachHang.Email;
                    txtUsername.Text = khachHang.Username;
                    txtPassword.Text = khachHang.Password_KH;
                    if (khachHang.GioiTinh == "Nam")
                    {
                        radNam.Checked = true;
                        radNu.Checked = false;
                    }
                    else
                    {
                        radNam.Checked = false;
                        radNu.Checked = true;
                    }
                    chkHoatDong.Checked = khachHang.TrangThai == "Hoạt động" ? true : false;
                }    
            }    
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtSDT.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || !(radNam.Checked == true || radNu.Checked == true) || chkHoatDong.Checked == false)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                KhachHangDTO khachHang = new KhachHangDTO();
                khachHang.HoTen = txtHoTen.Text;
                khachHang.SDT = txtSDT.Text;
                khachHang.Email = txtEmail.Text;
                khachHang.Username = txtUsername.Text;
                khachHang.Password_KH = txtPassword.Text;
                khachHang.GioiTinh = radNam.Checked ? "Nam" : "Nữ";
                khachHang.TrangThai = chkHoatDong.Checked ? "Hoạt động" : "Không hoạt động";
                int kq = khachHangBUS.ThemKhachHang(khachHang);
                if (kq > 0)
                {
                    MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LayDanhSachKhachHang();
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm khách hàng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvKhachHang.SelectedRows.Count > 0)
                {
                    KhachHangDTO khachHang = dgvKhachHang.SelectedRows[0].DataBoundItem as KhachHangDTO;
                    if (khachHang != null)
                    {
                        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            int kq = khachHangBUS.XoaKhachHang(int.Parse(khachHang.MaKH.ToString()));
                            if (kq > 0)
                            {
                                MessageBox.Show("Xóa khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LayDanhSachKhachHang();
                            }
                            else
                            {
                                MessageBox.Show("Xóa khách hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn khách hàng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi xóa khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvKhachHang.SelectedRows.Count > 0)
                {
                    KhachHangDTO khachHang = dgvKhachHang.SelectedRows[0].DataBoundItem as KhachHangDTO;
                    if (khachHang != null)
                    {
                        khachHang.HoTen = txtHoTen.Text;
                        khachHang.SDT = txtSDT.Text;
                        khachHang.Email = txtEmail.Text;
                        khachHang.Username = txtUsername.Text;
                        khachHang.Password_KH = txtPassword.Text;
                        khachHang.GioiTinh = radNam.Checked ? "Nam" : "Nữ";
                        khachHang.TrangThai = chkHoatDong.Checked ? "Hoạt động" : "Không hoạt động";
                        int kq = khachHangBUS.CapNhatKhachHang(khachHang);
                        if (kq > 0)
                        {
                            MessageBox.Show("Cập nhật khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LayDanhSachKhachHang();
                            Clear();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật khách hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn khách hàng để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật khách hàng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Clear()
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            radNam.Checked = false;
            radNu.Checked = false;
            chkHoatDong.Checked = false;
        }

        private void txtSearchKey_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtSearchKey.Text, out int maKH))
            {
                dsKhachHang = khachHangBUS.LayDanhSachKhachHang(maKH);
                dgvKhachHang.DataSource = dsKhachHang;
            }
            else
            {
                LayDanhSachKhachHang();
            }
        }
    }
}
