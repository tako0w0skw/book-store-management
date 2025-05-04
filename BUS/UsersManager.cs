using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class UsersManager
    {
        public static bool KiemTraDangNhap(string username, string password)
        {
            NhanVienBUS nhanVienBUS = new NhanVienBUS();
            return nhanVienBUS.KiemTraDangNhap(username, password);
        }

        public static NhanVienDTO LayThongTinUser(string username, string password)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };

            NhanVienDTO nhanVien = new NhanVienDTO();

            string proc = "sp_LayThongTinUser";
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            SqlDataReader dr = DataProvider.ExcuteProcedure(proc, conn, parameters);
            while (dr.Read())
            {
                nhanVien.MaNV = int.Parse(dr["MaNV"].ToString());
                nhanVien.HoTen = dr["HoTen"].ToString();
                nhanVien.GioiTinh = dr["GioiTinh"].ToString();

                // Sử dụng DateTime.TryParseExact để parse ngày sinh từ chuỗi
                CultureInfo culture = new CultureInfo("vi-VN"); // Đặt culture để hiểu định dạng tiếng Việt
                DateTime ngaySinh;
                DateTime ngayVaoLam;
                if (DateTime.TryParseExact(dr["NgaySinh"].ToString(), "dd/MM/yyyy h:mm:ss tt", culture, DateTimeStyles.None, out ngaySinh))
                {
                    nhanVien.NgaySinh = ngaySinh;
                }
                else
                {
                    nhanVien.NgaySinh = DateTime.MinValue; // Giá trị mặc định nếu không parse được
                }

                nhanVien.Email = dr["Email"].ToString();
                nhanVien.SDT = dr["SDT"].ToString();
                nhanVien.DiaChi = dr["DiaChi"].ToString();
                nhanVien.ChucVu = dr["ChucVu"].ToString();

                // Sử dụng DateTime.TryParseExact để parse ngày vào làm từ chuỗi
                if (DateTime.TryParseExact(dr["NgayVaoLam"].ToString(), "dd/MM/yyyy h:mm:ss tt", culture, DateTimeStyles.None, out ngayVaoLam))
                {
                    nhanVien.NgayVaoLam = ngayVaoLam;
                }
                else
                {
                    nhanVien.NgayVaoLam = DateTime.MinValue; // Giá trị mặc định nếu không parse được
                }

                nhanVien.Username = dr["Username"].ToString();
                nhanVien.Password_NV = dr["Password_NV"].ToString();
                nhanVien.TrangThai = dr["TrangThai"].ToString();
            }
            dr.Close();
            conn.Close();
            return nhanVien;
        }


        //public static Dictionary<string, string> Users = new Dictionary<string, string>()
        //{
        //    {"admin", "123" } // tài khoản admin
        //};

        //public static bool KiemtraDangnhap(string username, string password)
        //{
        //    return Users.ContainsKey(username) && Users[username] == password; // trả về true khi tồn tài username và pass tương ứng
        //}

        //public static bool KiemtraDangky(string username, string password)
        //{
        //    if (Users.ContainsKey(username))
        //    {
        //        return false;
        //    }
        //    Users.Add(username, password); // thêm người dùng mới
        //    return true;
        //}
    }
}
