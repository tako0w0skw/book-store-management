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
    public partial class QLKM : Form
    {
        public QLKM()
        {
            InitializeComponent();
        }

        KhuyenMaiBUS khuyenMaiBUS = new KhuyenMaiBUS();
        List<KhuyenMaiDTO> dsKhuyenMai = new List<KhuyenMaiDTO>();

        private void QLKM_Load(object sender, EventArgs e)
        {
            LayDanhSachKhuyenMai();
        }

        public void LayDanhSachKhuyenMai()
        {
            dsKhuyenMai = khuyenMaiBUS.LayDanhSachKhuyenMai();
            dgvKhuyenMai.DataSource = dsKhuyenMai;
            dgvKhuyenMai.Columns["MaKM"].HeaderText = "Mã khuyến mãi";
            dgvKhuyenMai.Columns["TenMa"].HeaderText = "Tên mã";
            dgvKhuyenMai.Columns["LoaiGiam"].HeaderText = "Loại giảm";
            dgvKhuyenMai.Columns["MucGiam"].HeaderText = "Mức giảm";
            dgvKhuyenMai.Columns["NgayBatDau"].HeaderText = "Ngày bắt đầu";
            dgvKhuyenMai.Columns["NgayKetThuc"].HeaderText = "Ngày kết thúc";
            dgvKhuyenMai.Columns["MaNV"].HeaderText = "Mã nhân viên";
            dgvKhuyenMai.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvKhuyenMai.AutoGenerateColumns = false;
        }

        public void Clear()
        {
            txtMaKM.Text = "";
            txtTenMa.Text = "";
            cbLoaiMa.SelectedIndex = -1;
            txtMucGiam.Text = "";
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now;
            txtMaNV.Text = "";
            cbTrangThai.SelectedIndex = -1;
        }

        private void dgvKhuyenMai_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvKhuyenMai.SelectedRows.Count > 0)
            {
                KhuyenMaiDTO khuyenMai = dgvKhuyenMai.SelectedRows[0].DataBoundItem as KhuyenMaiDTO;
                if (khuyenMai != null)
                {
                    txtMaKM.Text = khuyenMai.MaKM.ToString();
                    txtTenMa.Text = khuyenMai.TenMa;
                    cbLoaiMa.SelectedItem = khuyenMai.LoaiGiam.ToString();
                    txtMucGiam.Text = khuyenMai.MucGiam.ToString();
                    nudSoLuong.Text = khuyenMai.SoLuong.ToString();
                    txtLuotSuDung.Text = khuyenMai.LuotSuDung.ToString();
                    dtpNgayBatDau.Value = khuyenMai.NgayBatDau;
                    dtpNgayKetThuc.Value = khuyenMai.NgayKetThuc;
                    txtMaNV.Text = khuyenMai.MaNV.ToString();
                    cbTrangThai.SelectedItem = khuyenMai.TrangThai;
                }
            }    
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTenMa.Text) || string.IsNullOrEmpty(txtMucGiam.Text) || string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                KhuyenMaiDTO khuyenMai = new KhuyenMaiDTO();
                khuyenMai.MaKM = txtMaKM.Text;
                khuyenMai.TenMa = txtTenMa.Text;
                khuyenMai.LoaiGiam = cbLoaiMa.SelectedItem.ToString();
                khuyenMai.MucGiam = Convert.ToDouble(txtMucGiam.Text);
                khuyenMai.SoLuong = Convert.ToInt32(nudSoLuong.Value);
                khuyenMai.LuotSuDung = Convert.ToInt32(txtLuotSuDung.Text);
                khuyenMai.NgayBatDau = dtpNgayBatDau.Value;
                khuyenMai.NgayKetThuc = dtpNgayKetThuc.Value;
                khuyenMai.MaNV = Convert.ToInt32(txtMaNV.Text);
                khuyenMai.TrangThai = cbTrangThai.SelectedItem.ToString();
                int kq = khuyenMaiBUS.ThemKhuyenMai(khuyenMai);
                if (kq > 0)
                {
                    MessageBox.Show("Thêm khuyến mãi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LayDanhSachKhuyenMai();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Thêm khuyến mãi thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm khuyến mãi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhuyenMai.SelectedRows.Count > 0)
            {
                KhuyenMaiDTO khuyenMai = dgvKhuyenMai.SelectedRows[0].DataBoundItem as KhuyenMaiDTO;
                if (khuyenMai != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khuyến mãi này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int kq = khuyenMaiBUS.XoaKhuyenMai(khuyenMai.MaKM);
                        if (kq > 0)
                        {
                            MessageBox.Show("Xóa khuyến mãi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LayDanhSachKhuyenMai();
                            Clear();
                        }
                        else
                        {
                            MessageBox.Show("Xóa khuyến mãi thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(dgvKhuyenMai.SelectedRows.Count > 0)
            {
                KhuyenMaiDTO khuyenMai = dgvKhuyenMai.SelectedRows[0].DataBoundItem as KhuyenMaiDTO;
                if (khuyenMai != null)
                {
                    khuyenMai.TenMa = txtTenMa.Text;
                    khuyenMai.LoaiGiam = cbLoaiMa.SelectedItem.ToString();
                    khuyenMai.MucGiam = Convert.ToDouble(txtMucGiam.Text);
                    khuyenMai.SoLuong = Convert.ToInt32(nudSoLuong.Value);
                    khuyenMai.LuotSuDung = Convert.ToInt32(txtLuotSuDung.Text);
                    khuyenMai.NgayBatDau = dtpNgayBatDau.Value;
                    khuyenMai.NgayKetThuc = dtpNgayKetThuc.Value;
                    khuyenMai.MaNV = Convert.ToInt32(txtMaNV.Text);
                    khuyenMai.TrangThai = cbTrangThai.SelectedItem.ToString();
                    int kq = khuyenMaiBUS.CapNhatKhuyenMai(khuyenMai);
                    if (kq > 0)
                    {
                        MessageBox.Show("Sửa khuyến mãi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LayDanhSachKhuyenMai();
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Sửa khuyến mãi thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }    
        }

        private void txtMaKMTK_TextChanged(object sender, EventArgs e)
        {
            dsKhuyenMai = khuyenMaiBUS.LayDanhSachKhuyenMai(txtMaKMTK.Text);
            dgvKhuyenMai.DataSource = dsKhuyenMai;
        }
    }
}
