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
    public partial class QL_TacGia : Form
    {
        public QL_TacGia()
        {
            InitializeComponent();
        }

        TacGiaBUS tacGiaBUS = new TacGiaBUS();
        List<TacGiaDTO> dsTacGia = new List<TacGiaDTO>();

        private void QL_TacGia_Load(object sender, EventArgs e)
        {
            LayDanhSachTacGia();
        }

        public void LayDanhSachTacGia()
        {
            dsTacGia = tacGiaBUS.LayDanhSachTacGia();
            dgvTacGia.DataSource = dsTacGia;
            dgvTacGia.Columns["MaTacGia"].HeaderText = "Mã tác giả";
            dgvTacGia.Columns["TenTacGia"].HeaderText = "Tên tác giả";
            dgvTacGia.AutoGenerateColumns = false;
        }

        private void dgvTacGia_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvTacGia.SelectedRows.Count > 0)
            {
                TacGiaDTO tacGia = dgvTacGia.SelectedRows[0].DataBoundItem as TacGiaDTO;
                if (tacGia != null)
                {
                    txtMaTG.Text = tacGia.MaTacGia.ToString();
                    txtTenTG.Text = tacGia.TenTacGia;
                }
            }    
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenTG.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tác giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                TacGiaDTO tacGia = new TacGiaDTO();
                tacGia.TenTacGia = txtTenTG.Text;
                int kq = tacGiaBUS.ThemTacGia(tacGia);
                if (kq > 0)
                {
                    MessageBox.Show("Thêm tác giả thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LayDanhSachTacGia();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Thêm tác giả thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm tác giả: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Clear()
        {
            txtMaTG.Clear();
            txtTenTG.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(dgvTacGia.SelectedRows.Count > 0)
            {
                TacGiaDTO tacGia = dgvTacGia.SelectedRows[0].DataBoundItem as TacGiaDTO;
                if(tacGia != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tác giả này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int kq = tacGiaBUS.XoaTacGia(tacGia.MaTacGia);
                        if (kq > 0)
                        {
                            MessageBox.Show("Xóa tác giả thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LayDanhSachTacGia();
                            Clear();
                        }
                        else
                        {
                            MessageBox.Show("Xóa tác giả thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }    
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tác giả cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvTacGia.SelectedRows.Count > 0)
            {
                TacGiaDTO tacGia = dgvTacGia.SelectedRows[0].DataBoundItem as TacGiaDTO;
                if (tacGia != null)
                {
                    tacGia.TenTacGia = txtTenTG.Text;
                    int kq = tacGiaBUS.CapNhatTacGia(tacGia);
                    if (kq > 0)
                    {
                        MessageBox.Show("Sửa tác giả thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LayDanhSachTacGia();
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Sửa tác giả thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tác giả cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearchKey_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtSearchKey.Text, out int maTacGia))
            {
                dsTacGia = tacGiaBUS.LayDanhSachTacGia(maTacGia);
                dgvTacGia.DataSource = dsTacGia;
            }
            else
            {
                LayDanhSachTacGia();
            }
        }
    }
}
