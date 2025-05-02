using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class QL_TGSach : Form
    {
        public QL_TGSach()
        {
            InitializeComponent();
        }
        TacGiaSachBUS tacGiaSachBUS = new TacGiaSachBUS();
        List<TacGiaSachDTO> dsTacGiaSach = new List<TacGiaSachDTO>();

        SachBUS sachBUS = new SachBUS();
        List<SachDTO> dsSach = new List<SachDTO>();

        TacGiaBUS tacGiaBUS = new TacGiaBUS();
        List<TacGiaDTO> dsTacGia = new List<TacGiaDTO>();

        private void QL_TGSach_Load(object sender, EventArgs e)
        {
            LayDanhSachTacGiaSach();
            LoadComboBoxTenSach();
            LoadComboBoxTenTacGia();
        }

        public void LayDanhSachTacGiaSach()
        {
            dsTacGiaSach = tacGiaSachBUS.LayDanhSachTacGiaSach();
            dgvTGS.DataSource = dsTacGiaSach;
            dgvTGS.Columns["MaSach"].HeaderText = "Mã Sách";
            dgvTGS.Columns["TenSach"].HeaderText = "Tên Sách";
            dgvTGS.Columns["TenTacGia"].HeaderText = "Tên Tác Giả";
            dgvTGS.AutoGenerateColumns = false; // không tự động sinh cột
        }

        public void LoadComboBoxTenSach()
        {
            sachBUS = new SachBUS();
            dsSach = sachBUS.LayDanhSachSach();
            cbTenSach.DataSource = dsSach;
            cbTenSach.DisplayMember = "TenSach";
            cbTenSach.ValueMember = "MaSach";
        }

        public void LoadComboBoxTenTacGia()
        {
            dsTacGia = tacGiaBUS.LayDanhSachTacGia();
            cbTenTacGia.DataSource = dsTacGia;
            cbTenTacGia.DisplayMember = "TenTacGia";
            cbTenTacGia.ValueMember = "MaTacGia";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int maSach = int.Parse(cbTenSach.SelectedValue.ToString());
                int maTG = int.Parse(cbTenTacGia.SelectedValue.ToString());
                TacGiaSachDTO tacGiaSach = new TacGiaSachDTO();
                tacGiaSach.MaSach = maSach;
                tacGiaSach.MaTacGia = maTG;
                int kq = tacGiaSachBUS.ThemTacGiaSach(tacGiaSach);
                if (kq > 0)
                {
                    MessageBox.Show("Thêm tác giả sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm tác giả sách thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm tác giả sách: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LayDanhSachTacGiaSach();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int maSach = int.Parse(cbTenSach.SelectedValue.ToString());
                int maTG = int.Parse(cbTenTacGia.SelectedValue.ToString());
                TacGiaSachDTO tacGiaSach = new TacGiaSachDTO();
                tacGiaSach.MaSach = maSach;
                tacGiaSach.MaTacGia = maTG;
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tác giả sách này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int kq = tacGiaSachBUS.XoaTacGiaSach(tacGiaSach);
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa tác giả sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa tác giả sách thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa tác giả sách: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LayDanhSachTacGiaSach();
            }
        }

        private void dgvTGS_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTGS.SelectedRows.Count > 0)
            {
                TacGiaSachDTO tgs = dgvTGS.SelectedRows[0].DataBoundItem as TacGiaSachDTO;
                cbTenSach.SelectedValue = tgs.MaSach;
                cbTenTacGia.SelectedValue = tgs.MaTacGia;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTGS.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn sách để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int maSach = int.Parse(cbTenSach.SelectedValue.ToString());
                int maTG = int.Parse(cbTenTacGia.SelectedValue.ToString());
                TacGiaSachDTO tacGiaSach = new TacGiaSachDTO();
                tacGiaSach.MaSach = maSach;
                tacGiaSach.MaTacGia = maTG;
                int kq = tacGiaSachBUS.CapNhatTacGiaSach(tacGiaSach);
                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật tác giả sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật tác giả sách thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật tác giả sách: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LayDanhSachTacGiaSach();
            }
        }
    }
}
