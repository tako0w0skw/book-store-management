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
        public List<KhachHangDTO> LayDanhSachKhachHang(int maKH = -1)
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            if (maKH != -1)
            {
                parameters = new SqlParameter[] { new SqlParameter("@MaKH", maKH) };
            }

            string proc = "sp_LayDanhSachKhachHang";
            List<KhachHangDTO> dsKhachHang = new List<KhachHangDTO>();
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            SqlDataReader dr = DataProvider.ExcuteProcedure(proc, conn, parameters);
            while(dr.Read())
            {
                KhachHangDTO khachHang = new KhachHangDTO();
                khachHang.MaKH = int.Parse(dr["MaKH"].ToString());
                khachHang.HoTen = dr["HoTen"].ToString();
                khachHang.SDT = dr["SDT"].ToString();
                khachHang.Email = dr["Email"].ToString();
                khachHang.Username = dr["Username"].ToString();
                khachHang.Password_KH = dr["Password_KH"].ToString();
                khachHang.GioiTinh = dr["GioiTinh"].ToString();
                khachHang.TrangThai = dr["TrangThai"].ToString();
                dsKhachHang.Add(khachHang);
            }
            dr.Close();
            conn.Close();
            return dsKhachHang;
        }

        public int ThemKhachHang(KhachHangDTO kh)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@HoTen", kh.HoTen),
                new SqlParameter("@SDT", kh.SDT),
                new SqlParameter("@Email", kh.Email),
                new SqlParameter("@Username", kh.Username),
                new SqlParameter("@Password_KH", kh.Password_KH),
                new SqlParameter("@GioiTinh", kh.GioiTinh),
                new SqlParameter("@TrangThai", kh.TrangThai)
            };

            string proc = "sp_ThemKhachHang";
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            int kq = DataProvider.ExcuteProcedureNonQuery(proc, conn, parameters);
            conn.Close();
            return kq;
        }

        public int XoaKhachHang(int maKH)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaKH", maKH)
            };
            string proc = "sp_XoaKhachHang";
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            int kq = DataProvider.ExcuteProcedureNonQuery(proc, conn, parameters);
            DataProvider.ThucThi("sp_ReseedIdentityKhachHang", conn);
            conn.Close();
            return kq;
        }

        public int CapNhatKhachHang(KhachHangDTO kh)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaKH", kh.MaKH),
                new SqlParameter("@HoTen", kh.HoTen),
                new SqlParameter("@SDT", kh.SDT),
                new SqlParameter("@Email", kh.Email),
                new SqlParameter("@Username", kh.Username),
                new SqlParameter("@Password_KH", kh.Password_KH),
                new SqlParameter("@GioiTinh", kh.GioiTinh),
                new SqlParameter("@TrangThai", kh.TrangThai)
            };
            string proc = "sp_CapNhatKhachHang";
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            int kq = DataProvider.ExcuteProcedureNonQuery(proc, conn, parameters);
            conn.Close();
            return kq;
        }
    }
}
