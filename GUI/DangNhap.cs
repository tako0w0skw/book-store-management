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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMK.Text) || string.IsNullOrWhiteSpace(txtTK.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            else
            {
                string username = txtTK.Text.Trim(); // nguyen van a -> nguyenvana
                string password = txtMK.Text;

                if (UsersManager.KiemTraDangNhap(username, password))
                {
                    NhanVienDTO nhanVien = UsersManager.LayThongTinUser(username, password);
                    this.Hide();
                    Main main = new Main(nhanVien);
                    main.ShowDialog();
                    this.Close(); // đóng luôn khi main đóng

                }
                else
                {
                    MessageBox.Show("Vui lòng nhập lại đúng tên tài khoản và mật khẩu");
                }
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangKy dangky = new DangKy();
            dangky.ShowDialog();
            this.Show();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
