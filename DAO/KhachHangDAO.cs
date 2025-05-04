using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class KhachHangDAO
    {
        private static string strKetNoi = "Data Source=.;Initial Catalog=QuanLyPMBanSach;Integrated Security=True";

        public List<KhachHangDTO> LayDanhSachKhachHang(int maKH = -1, string tenKH = null)
        {
            List<KhachHangDTO> ds = new List<KhachHangDTO>();

            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                string query = "SELECT * FROM KHACHHANG";
                if (maKH != -1)
                {
                    query += " WHERE MaKH = @MaKH";
                }
                else if (!string.IsNullOrEmpty(tenKH))
                {
                    query += " WHERE HoTen LIKE @TenKH";
                }

                SqlCommand cmd = new SqlCommand(query, conn);

                if (maKH != -1)
                    cmd.Parameters.AddWithValue("@MaKH", maKH);
                else if (!string.IsNullOrEmpty(tenKH))
                    cmd.Parameters.AddWithValue("@TenKH", "%" + tenKH + "%");

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        KhachHangDTO kh = new KhachHangDTO(
                            maKH: Convert.ToInt32(reader["MaKH"]),
                            hoTen: reader["HoTen"].ToString(),
                            sdt: reader["SDT"].ToString(),
                            email: reader["Email"].ToString(),
                            username: reader["Username"].ToString(),
                            password: reader["Password_KH"].ToString(),
                            gioiTinh: reader["GioiTinh"].ToString(),
                            trangThai: reader["TrangThai"].ToString()
                        );
                        ds.Add(kh);
                    }
                }
            }
            return ds;
        }

        public int ThemKhachHang(KhachHangDTO kh)
        {
            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                string query = @"INSERT INTO KHACHHANG(HoTen, SDT, Email, Username, Password_KH, GioiTinh, TrangThai) 
                                VALUES (@HoTen, @SDT, @Email, @Username, @Password_KH, @GioiTinh, @TrangThai)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@HoTen", kh.HoTen);
                cmd.Parameters.AddWithValue("@SDT", kh.SDT);
                cmd.Parameters.AddWithValue("@Email", kh.Email);
                cmd.Parameters.AddWithValue("@Username", kh.Username);
                cmd.Parameters.AddWithValue("@Password_KH", kh.Password_KH);
                cmd.Parameters.AddWithValue("@GioiTinh", kh.GioiTinh);
                cmd.Parameters.AddWithValue("@TrangThai", kh.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int XoaKhachHang(int maKH)
        {
            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                string query = "DELETE FROM KHACHHANG WHERE MaKH = @MaKH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int CapNhatKhachHang(KhachHangDTO kh)
        {
            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                string query = @"UPDATE KHACHHANG SET 
                                HoTen = @HoTen, 
                                SDT = @SDT, 
                                Email = @Email, 
                                Username = @Username, 
                                Password_KH = @Password_KH, 
                                GioiTinh = @GioiTinh, 
                                TrangThai = @TrangThai
                                WHERE MaKH = @MaKH";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);
                cmd.Parameters.AddWithValue("@HoTen", kh.HoTen);
                cmd.Parameters.AddWithValue("@SDT", kh.SDT);
                cmd.Parameters.AddWithValue("@Email", kh.Email);
                cmd.Parameters.AddWithValue("@Username", kh.Username);
                cmd.Parameters.AddWithValue("@Password_KH", kh.Password_KH);
                cmd.Parameters.AddWithValue("@GioiTinh", kh.GioiTinh);
                cmd.Parameters.AddWithValue("@TrangThai", kh.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
