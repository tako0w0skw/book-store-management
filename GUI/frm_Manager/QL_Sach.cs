using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI.frm_Manager
{
    public partial class QL_Sach : Form
    {
        public QL_Sach()
        {
            InitializeComponent();
        }

        SachBUS sachBUS = new SachBUS();
        List<SachDTO> dsSach = new List<SachDTO>();

        KhuyenMaiBUS khuyenMaiBUS = new KhuyenMaiBUS();
        List<KhuyenMaiDTO> dsKhuyenMai = new List<KhuyenMaiDTO>();

        private void QL_Sach_Load(object sender, EventArgs e)
        {
            LayDanhSachSach();
            LayDanhSachKhuyenMai();
        }
        public void LayDanhSachKhuyenMai()
        {
            dsKhuyenMai = khuyenMaiBUS.LayDanhSachKhuyenMai();
            cbMaKM.DataSource = dsKhuyenMai;
            cbMaKM.DisplayMember = "TenMa";
            cbMaKM.ValueMember = "MaKM";
        }

        public void LayDanhSachSach()
        {
            dsSach = sachBUS.LayDanhSachSach();
            dgvSach.DataSource = dsSach;
            dgvSach.Columns["MaSach"].HeaderText = "Mã Sách";
            dgvSach.Columns["HinhAnh"].HeaderText = "Hình Ảnh";
            dgvSach.Columns["TenSach"].HeaderText = "Tên Sách";
            dgvSach.Columns["Gia"].HeaderText = "Giá";
            dgvSach.Columns["SoLuongTon"].HeaderText = "Số Lượng Tồn";
            dgvSach.Columns["NhaXuatBan"].HeaderText = "Nhà Xuất Bản";
            dgvSach.Columns["MoTa"].HeaderText = "Mô Tả";
            dgvSach.Columns["SoTrang"].HeaderText = "Số Trang";
            dgvSach.Columns["NgayPhatHanh"].HeaderText = "Ngày Phát Hành";
            dgvSach.Columns["DichGia"].HeaderText = "Dịch Giả";
            dgvSach.Columns["MaKM"].HeaderText = "Mã Khuyến Mãi";
            dgvSach.Columns["TrangThai"].HeaderText = "Trạng Thái";
            dgvSach.AutoGenerateColumns = false; // không tự động sinh cột
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(filePath);
                pbSach.ImageLocation = filePath;
                MessageBox.Show("Hình ảnh đã được tải lên thành công: " + fileName);
            }
        }

        public void LuuHinhAnh()
        {
            string fileName = Path.GetFileName(pbSach.ImageLocation);
            if(fileName != null)
            {
                string destinationPath = Path.Combine(Application.StartupPath, "Images", fileName);

                // Kiểm tra xem thư mục Images đã tồn tại chưa, nếu chưa thì tạo mới
                if (!Directory.Exists(Path.Combine(Application.StartupPath, "Images")))
                {
                    Directory.CreateDirectory(Path.Combine(Application.StartupPath, "Images"));
                }

                // Kiểm tra xem file đã tồn tại chưa, nếu chưa thì copy
                if (!File.Exists(destinationPath))
                {
                    File.Copy(pbSach.ImageLocation, destinationPath);
                }
            }   
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenSach.Text) || string.IsNullOrWhiteSpace(txtGia.Text) || string.IsNullOrWhiteSpace(txtSLT.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    return;
                }
                SachDTO sach = new SachDTO();
                sach.HinhAnh = Path.GetFileName(pbSach.ImageLocation);
                sach.TenSach = txtTenSach.Text;
                sach.Gia = double.TryParse(txtGia.Text, out double gia) ? gia : 0;
                sach.SoLuongTon = int.TryParse(txtSLT.Text, out int sl) ? sl : 0;
                sach.NhaXuatBan = cbNXB.Text ?? null;
                sach.MoTa = txtMoTa.Text ?? null;
                sach.SoTrang = int.TryParse(txtSoTrang.Text, out int st) ? st : 0;
                sach.NgayPhatHanh = dtpNgPhatHanh.Value;
                sach.DichGia = txtDichGia.Text ?? null;
                sach.MaKM = cbMaKM.SelectedValue?.ToString() ?? null;
                sach.TrangThai = cbTrangThai.Text ?? null;

                int kq = sachBUS.ThemSach(sach);
                if (kq > 0)
                {
                    LuuHinhAnh();
                    MessageBox.Show("Thêm sách thành công");
                    LayDanhSachSach();
                }
                else
                {
                    MessageBox.Show("Thêm sách thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sách: " + ex.Message);
                return;
            }
        }

        private void dgvSach_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvSach.SelectedRows.Count > 0)
            {
                SachDTO sach = dgvSach.SelectedRows[0].DataBoundItem as SachDTO;
                txtMaSach.Text = sach.MaSach.ToString();
                txtTenSach.Text = sach.TenSach;
                txtGia.Text = sach.Gia.ToString();
                txtSLT.Text = sach.SoLuongTon.ToString();
                cbNXB.Text = sach.NhaXuatBan;
                txtMoTa.Text = sach.MoTa;
                txtSoTrang.Text = sach.SoTrang.ToString();
                dtpNgPhatHanh.Value = sach.NgayPhatHanh;
                txtDichGia.Text = sach.DichGia;
                cbMaKM.SelectedValue = sach.MaKM;
                cbTrangThai.Text = sach.TrangThai;
                if (!string.IsNullOrEmpty(sach.HinhAnh))
                {
                    if (File.Exists(Path.Combine(Application.StartupPath, "Images", sach.HinhAnh)))
                    {
                        pbSach.ImageLocation = Path.Combine(Application.StartupPath, "Images", sach.HinhAnh);
                    }
                    else
                    {
                        pbSach.ImageLocation = null;
                    }
                }
                else
                {
                    pbSach.ImageLocation = null;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maSach = int.Parse(txtMaSach.Text);
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sách này không?", "Xóa sách", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int kq = sachBUS.XoaSach(maSach);
                if (kq > 0)
                {
                    MessageBox.Show("Xóa sách thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LayDanhSachSach();
                }
                else
                {
                    MessageBox.Show("Xóa sách thất bại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(dgvSach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sách cần cập nhật","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            try
            { 
                SachDTO sach = new SachDTO();
                sach.MaSach = int.Parse(txtMaSach.Text);
                sach.HinhAnh = Path.GetFileName(pbSach.ImageLocation);
                sach.TenSach = txtTenSach.Text;
                sach.Gia = double.TryParse(txtGia.Text, out double gia) ? gia : 0;
                sach.SoLuongTon = int.TryParse(txtSLT.Text, out int sl) ? sl : 0;
                sach.NhaXuatBan = cbNXB.Text ?? null;
                sach.MoTa = txtMoTa.Text ?? null;
                sach.SoTrang = int.TryParse(txtSoTrang.Text, out int st) ? st : 0;
                sach.NgayPhatHanh = dtpNgPhatHanh.Value;
                sach.DichGia = txtDichGia.Text ?? null;
                sach.MaKM = cbMaKM.SelectedValue?.ToString() ?? null;
                sach.TrangThai = cbTrangThai.Text ?? null;
                int kq = sachBUS.CapNhatSach(sach);
                if (kq > 0)
                {
                    LuuHinhAnh();
                    MessageBox.Show("Cập nhật sách thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LayDanhSachSach();
                }
                else
                {
                    MessageBox.Show("Cập nhật sách thất bại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật sách: " + ex.Message);
            }
        }

        private void txtSearchKey_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtSearchKey.Text, out int maSach))
            {
                dsSach = sachBUS.LayDanhSachSach(maSach);
                dgvSach.DataSource = dsSach;
            }
            else
            {
                LayDanhSachSach();
            }
        }
    }
}
