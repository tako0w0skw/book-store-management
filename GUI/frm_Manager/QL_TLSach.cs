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
    public partial class QL_TLSach : Form
    {
        public QL_TLSach()
        {
            InitializeComponent();
        }
        TheLoaiSachBUS theLoaiSachBUS = new TheLoaiSachBUS();
        List<TheLoaiSachDTO> dsTheLoaiSach = new List<TheLoaiSachDTO>();

        SachBUS sachBUS = new SachBUS();
        List<SachDTO> dsSach = new List<SachDTO>();

        TheLoaiBUS theLoaiBUS = new TheLoaiBUS();
        List<TheLoaiDTO> dsTheLoai = new List<TheLoaiDTO>();

        private void QL_TLSach_Load(object sender, EventArgs e)
        {
            LayDanhSachTheLoaiSach();
            LoadComboBoxTenSach();
            LoadComboBoxTenTheLoai();
        }

        public void LayDanhSachTheLoaiSach()
        {
            dsTheLoaiSach = theLoaiSachBUS.LayDanhSachTheLoaiSach();
            dgvTLS.DataSource = dsTheLoaiSach;
            dgvTLS.Columns["MaSach"].HeaderText = "Mã Sách";
            dgvTLS.Columns["MaTheLoai"].HeaderText = "Mã Thể Loại";
            dgvTLS.Columns["TenSach"].HeaderText = "Tên Sách";
            dgvTLS.Columns["TenTheLoai"].HeaderText = "Tên Thể Loại";
            dgvTLS.AutoGenerateColumns = false; // không tự động sinh cột
        }

        public void LoadComboBoxTenSach()
        {
            dsSach = sachBUS.LayDanhSachSach();
            cbTenSach.DataSource = dsSach;
            cbTenSach.DisplayMember = "TenSach";
            cbTenSach.ValueMember = "MaSach";
        }

        public void LoadComboBoxTenTheLoai()
        {
            dsTheLoai = theLoaiBUS.LayDanhSachTheLoai();
            cbTenTheLoai.DataSource = dsTheLoai;
            cbTenTheLoai.DisplayMember = "TenTheLoai";
            cbTenTheLoai.ValueMember = "MaTheLoai";
        }

        private void dgvTLS_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvTLS.SelectedRows.Count > 0)
            {
                TheLoaiSachDTO tls = dgvTLS.SelectedRows[0].DataBoundItem as TheLoaiSachDTO;
                cbTenSach.SelectedValue = tls.MaSach;
                cbTenTheLoai.SelectedValue = tls.MaTheLoai;
            }    
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if(cbTenSach.SelectedIndex == -1 || cbTenTheLoai.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn sách và thể loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                TheLoaiSachDTO tls = new TheLoaiSachDTO();
                tls.MaSach = int.Parse(cbTenSach.SelectedValue.ToString());
                tls.MaTheLoai = int.Parse(cbTenTheLoai.SelectedValue.ToString());
                int kq = theLoaiSachBUS.ThemTheLoaiSach(tls);
                if (kq > 0)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LayDanhSachTheLoaiSach();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm thể loại sách: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Reset lại combobox
                cbTenSach.SelectedIndex = -1;
                cbTenTheLoai.SelectedIndex = -1;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTLS.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thể loại sách này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        TheLoaiSachDTO tls = dgvTLS.SelectedRows[0].DataBoundItem as TheLoaiSachDTO;
                        int kq = theLoaiSachBUS.XoaTheLoaiSach(tls);
                        if (kq > 0)
                        {
                            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LayDanhSachTheLoaiSach();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }    
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn thể loại sách để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa thể loại sách: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Reset lại combobox
                cbTenSach.SelectedIndex = -1;
                cbTenTheLoai.SelectedIndex = -1;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTLS.SelectedRows.Count > 0)
                {
                    TheLoaiSachDTO tls = dgvTLS.SelectedRows[0].DataBoundItem as TheLoaiSachDTO;
                    tls.MaSach = int.Parse(cbTenSach.SelectedValue.ToString());
                    tls.MaTheLoai = int.Parse(cbTenTheLoai.SelectedValue.ToString());
                    int kq = theLoaiSachBUS.CapNhatTheLoaiSach(tls);
                    if (kq > 0)
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LayDanhSachTheLoaiSach();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn thể loại sách để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa thể loại sách: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Reset lại combobox
                cbTenSach.SelectedIndex = -1;
                cbTenTheLoai.SelectedIndex = -1;
            }
        }

        private void txtSearchKey_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtSearchKey.Text, out int maSach))
            {
                dsTheLoaiSach = theLoaiSachBUS.LayDanhSachTheLoaiSach(maSach);
                dgvTLS.DataSource = dsTheLoaiSach;
            }
            else
            {
                LayDanhSachTheLoaiSach();
            }
        }
    }
}
