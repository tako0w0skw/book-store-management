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
    public partial class QL_TheLoai : Form
    {
        public QL_TheLoai()
        {
            InitializeComponent();
        }

        TheLoaiBUS theLoaiBUS = new TheLoaiBUS();
        List<TheLoaiDTO> dsTheLoai = new List<TheLoaiDTO>();

        private void QL_TheLoai_Load(object sender, EventArgs e)
        {
            LayDanhSachTheLoai();
        }

        private void LayDanhSachTheLoai()
        {
            dsTheLoai = theLoaiBUS.LayDanhSachTheLoai();
            dgvTheLoai.DataSource = dsTheLoai;
            dgvTheLoai.Columns["MaTheLoai"].HeaderText = "Mã thể loại";
            dgvTheLoai.Columns["TenTheLoai"].HeaderText = "Tên thể loại";
            dgvTheLoai.AutoGenerateColumns = false;
        }

        private void dgvTheLoai_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvTheLoai.SelectedRows.Count > 0)
            {
                TheLoaiDTO theLoai = dgvTheLoai.SelectedRows[0].DataBoundItem as TheLoaiDTO;
                if (theLoai != null)
                {
                    txtMaTL.Text = theLoai.MaTheLoai.ToString();
                    txtTenTL.Text = theLoai.TenTheLoai;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TheLoaiDTO theLoai = new TheLoaiDTO();
            theLoai.TenTheLoai = txtTenTL.Text;

            int kq = theLoaiBUS.ThemTheLoai(theLoai);

            if(kq > 0)
            {
                MessageBox.Show("Thêm thể loại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm thể loại thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LayDanhSachTheLoai();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(dgvTheLoai.SelectedRows.Count > 0)
            {
                TheLoaiDTO theLoai = dgvTheLoai.SelectedRows[0].DataBoundItem as TheLoaiDTO;
                if(theLoai != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thể loại này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(result == DialogResult.Yes)
                    {
                        int kq = theLoaiBUS.XoaTheLoai(theLoai.MaTheLoai);
                        if (kq > 0)
                        {
                            MessageBox.Show("Xóa thể loại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LayDanhSachTheLoai();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thể loại thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thể loại để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LayDanhSachTheLoai();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTheLoai.SelectedRows.Count > 0)
                {
                    TheLoaiDTO theLoai = new TheLoaiDTO();
                    theLoai.MaTheLoai = int.Parse(txtMaTL.Text);
                    theLoai.TenTheLoai = txtTenTL.Text;

                    int kq = theLoaiBUS.CapNhatTheLoai(theLoai);

                    if (kq > 0)
                    {
                        MessageBox.Show("Cập nhật thể loại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thể loại thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn thể loại để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa thể loại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LayDanhSachTheLoai();
            }
        }

        private void txtSearchKey_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(txtSearchKey.Text, out int maTL))
            {
                dsTheLoai = theLoaiBUS.LayDanhSachTheLoai(maTL);
                dgvTheLoai.DataSource = dsTheLoai;
            }
            else
            {
                LayDanhSachTheLoai();
            }    
        }
    }
}
