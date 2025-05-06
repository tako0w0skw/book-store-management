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
    public partial class QL_NhanVien : Form
    {
        public QL_NhanVien()
        {
            InitializeComponent();
        }

        NhanVienBUS nhanVienBUS = new NhanVienBUS();
        List<NhanVienDTO> dsNhanVien = new List<NhanVienDTO>();

        private void QL_NhanVien_Load(object sender, EventArgs e)
        {
            LayDanhSachNhanVien();
        }

        public void LayDanhSachNhanVien()
        {
            dsNhanVien = nhanVienBUS.LayDanhSachNhanVien();
            dgvDSNV.DataSource = dsNhanVien;
            dgvDSNV.Columns["MaNV"].HeaderText = "Mã nhân viên";
            dgvDSNV.Columns["HoTen"].HeaderText = "Họ tên";
            dgvDSNV.Columns["SDT"].HeaderText = "Số điện thoại";
            dgvDSNV.Columns["Email"].HeaderText = "Email";
            dgvDSNV.Columns["Username"].HeaderText = "Tên đăng nhập";
            dgvDSNV.Columns["Password_NV"].HeaderText = "Mật khẩu";
            dgvDSNV.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvDSNV.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvDSNV.AutoGenerateColumns = false;
        }

        private void dgvDSNV_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSNV.SelectedRows.Count > 0)
            {
                NhanVienDTO nhanVien = dgvDSNV.SelectedRows[0].DataBoundItem as NhanVienDTO;
                if (nhanVien != null)
                {
                    txtMaNV.Text = nhanVien.MaNV.ToString();
                    txtHoTen.Text = nhanVien.HoTen;
                    txtSDT.Text = nhanVien.SDT;
                    txtEmail.Text = nhanVien.Email;
                    txtDiaChi.Text = nhanVien.DiaChi;
                    txtUsername.Text = nhanVien.Username;
                    txtPassword.Text = nhanVien.Password_NV;
                    cbChucVu.Text = nhanVien.ChucVu;
                    if (nhanVien.GioiTinh == "Nam")
                    {
                        radNam.Checked = true;
                    }
                    else
                    {
                        radNu.Checked = true;
                    }
                    chkTrangThai.Checked = nhanVien.TrangThai == "Hoạt động" ? true : false;
                }
            }
        }

        public void Clear()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            radNam.Checked = false;
            radNu.Checked = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtSDT.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || !(radNam.Checked == true || radNu.Checked == true))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                NhanVienDTO nhanVien = new NhanVienDTO();
                nhanVien.HoTen = txtHoTen.Text;
                nhanVien.GioiTinh = radNam.Checked ? "Nam" : "Nữ";
                nhanVien.NgaySinh = (DateTime)dtpNgSinh.Value;
                nhanVien.Email = txtEmail.Text;
                nhanVien.SDT = txtSDT.Text;
                nhanVien.DiaChi = txtDiaChi.Text;
                nhanVien.ChucVu = cbChucVu.Text;
                nhanVien.NgayVaoLam = (DateTime)dtpNgVaoLam.Value;
                nhanVien.Username = txtUsername.Text;
                nhanVien.Password_NV = txtPassword.Text;
                nhanVien.TrangThai = "Hoạt động";
                int kq = nhanVienBUS.ThemNhanVien(nhanVien);
                if (kq > 0)
                {
                    MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LayDanhSachNhanVien();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm nhân viên: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(dgvDSNV.SelectedRows.Count > 0)
            {
                NhanVienDTO nhanVien = dgvDSNV.SelectedRows[0].DataBoundItem as NhanVienDTO;
                if (nhanVien != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int kq = nhanVienBUS.XoaNhanVien(nhanVien.MaNV);
                        if (kq > 0)
                        {
                            MessageBox.Show("Xóa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LayDanhSachNhanVien();
                            Clear();
                        }
                        else
                        {
                            MessageBox.Show("Xóa nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDSNV.SelectedRows.Count > 0)
            {
                // Validate Date of Birth
                DateTime ngaySinh;
                try
                {
                    ngaySinh = dtpNgSinh.Value; // Use DateTimePicker value
                    if (ngaySinh < new DateTime(1753, 1, 1) || ngaySinh > new DateTime(9999, 12, 31))
                    {
                        MessageBox.Show("Ngày sinh phải nằm trong khoảng từ 01/01/1753 đến 31/12/9999.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (ngaySinh > DateTime.Now)
                    {
                        MessageBox.Show("Ngày sinh không được lớn hơn ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ngày sinh không hợp lệ. Vui lòng chọn lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NhanVienDTO nhanVien = dgvDSNV.SelectedRows[0].DataBoundItem as NhanVienDTO;

                int kq = nhanVienBUS.CapNhatNhanVien(nhanVien);
                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LayDanhSachNhanVien();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Cập nhật nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearchKey_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtSearchKey.Text, out int maNV))
            {
                dsNhanVien = nhanVienBUS.LayDanhSachNhanVien(maNV);
                dgvDSNV.DataSource = dsNhanVien;
            }
            else
            {
                LayDanhSachNhanVien();
            }
        }
    }
}
