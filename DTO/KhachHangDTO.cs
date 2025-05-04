using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        public int MaKH { get; set; }
        public string HoTen { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password_KH { get; set; }
        public string GioiTinh { get; set; }
        public string TrangThai { get; set; }

        public bool IsActive
        {
            get => TrangThai.Equals("Hoạt động", StringComparison.OrdinalIgnoreCase);
            set => TrangThai = value ? "Hoạt động" : "Không hoạt động";
        }

        public KhachHangDTO() { }

        public KhachHangDTO(int maKH, string hoTen, string sdt, string email,
                          string username, string password, string gioiTinh, string trangThai)
        {
            MaKH = maKH;
            HoTen = hoTen;
            SDT = sdt;
            Email = email;
            Username = username;
            Password_KH = password;
            GioiTinh = gioiTinh;
            TrangThai = trangThai;
        }
    }
}
