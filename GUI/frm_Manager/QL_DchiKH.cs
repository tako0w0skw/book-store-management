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
    public partial class QL_DchiKH : Form
    {
        public QL_DchiKH()
        {
            InitializeComponent();
            LoadDanhSachDiaChi();
            SetupDataGridView();
        }

        private DiaChiKhachHangBUS diaChiKH_BUS = new DiaChiKhachHangBUS();
        private DiaChiKhachHangDTO diaChiDangChon = null;
        private bool isEditMode = false;

        private void SetupDataGridView()
        {
            dgvDchiKH.AutoGenerateColumns = false;
            dgvDchiKH.Columns.Clear();

            // Thêm các cột
            dgvDchiKH.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "MaDiaChi",
                HeaderText = "Mã Địa Chỉ",
                DataPropertyName = "MaDiaChi"
            });

            dgvDchiKH.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "MaKH",
                HeaderText = "Mã KH",
                DataPropertyName = "MaKH"
            });

            dgvDchiKH.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "DiaChi",
                HeaderText = "Địa Chỉ",
                DataPropertyName = "DiaChi",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void LoadDanhSachDiaChi(int? maDiaChi = null)
        {
            try
            {
                dgvDchiKH.DataSource = diaChiKH_BUS.LayDanhSachDiaChi(maDiaChi);
                dgvDchiKH.AutoGenerateColumns = true;
                dgvDchiKH.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDchiKH_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDchiKH.SelectedRows.Count > 0 && !isEditMode)
            {
                diaChiDangChon = dgvDchiKH.SelectedRows[0].DataBoundItem as DiaChiKhachHangDTO;
                if (diaChiDangChon != null)
                {
                    txtMaDiaChi.Text = diaChiDangChon.MaDiaChi.ToString();
                    txtMaKH.Text = diaChiDangChon.MaKH?.ToString() ?? "";
                    txtDiaChi.Text = diaChiDangChon.DiaChi;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ");
                    return;
                }

                DiaChiKhachHangDTO dc = new DiaChiKhachHangDTO
                {
                    MaKH = string.IsNullOrWhiteSpace(txtMaKH.Text) ? (int?)null : int.Parse(txtMaKH.Text),
                    DiaChi = txtDiaChi.Text.Trim()
                };

                if (diaChiKH_BUS.ThemDiaChi(dc) > 0)
                {
                    MessageBox.Show("Thêm địa chỉ thành công");
                    LoadDanhSachDiaChi();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm địa chỉ thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (diaChiDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn địa chỉ cần sửa");
                return;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ");
                    return;
                }

                DiaChiKhachHangDTO dc = new DiaChiKhachHangDTO
                {
                    MaDiaChi = diaChiDangChon.MaDiaChi,
                    MaKH = string.IsNullOrWhiteSpace(txtMaKH.Text) ? (int?)null : int.Parse(txtMaKH.Text),
                    DiaChi = txtDiaChi.Text.Trim()
                };

                if (diaChiKH_BUS.CapNhatDiaChi(dc) > 0)
                {
                    MessageBox.Show("Cập nhật địa chỉ thành công");
                    LoadDanhSachDiaChi();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Cập nhật địa chỉ thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (diaChiDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn địa chỉ cần xóa");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa địa chỉ này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (diaChiKH_BUS.XoaDiaChi(diaChiDangChon.MaDiaChi) > 0)
                    {
                        MessageBox.Show("Xóa địa chỉ thành công");
                        LoadDanhSachDiaChi();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa địa chỉ thất bại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearForm()
        {
            txtMaDiaChi.Clear();
            txtMaKH.Clear();
            txtDiaChi.Clear();
            diaChiDangChon = null;
        }

        private void txtMaDiaChiTK_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtMaDiaChiTK.Text, out int maDiaChi))
            {
                LoadDanhSachDiaChi(maDiaChi);
            }
            else
            {
                LoadDanhSachDiaChi();
            }
        }
    }
}
