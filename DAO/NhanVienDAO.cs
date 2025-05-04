using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class NhanVienDAO
    {
        public List<NhanVienDTO> LayDanhSachNhanVien(int maNV = -1, string chucVu = null, string trangThai = null)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            if(maNV != -1)
            {
                paramList.Add(new SqlParameter("@MaNV", maNV));
            }
            if(chucVu != null)
            {
                paramList.Add(new SqlParameter("@ChucVu", chucVu));
            }    
            if(trangThai != null)
            {
                paramList.Add(new SqlParameter("@TrangThai", trangThai));
            }
            SqlParameter[] parameters = paramList.ToArray();

            string proc = "sp_LayDanhSachNhanVien";

            List<NhanVienDTO> dsNhanVien = new List<NhanVienDTO>();
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            SqlDataReader dr = DataProvider.ExcuteProcedure(proc, conn, parameters);
            while(dr.Read())
            {
                NhanVienDTO nhanVien = new NhanVienDTO();
                nhanVien.MaNV = int.Parse(dr["MaNV"].ToString());
                nhanVien.HoTen = dr["HoTen"].ToString();
                nhanVien.GioiTinh = dr["GioiTinh"].ToString();

                if (DateTime.TryParse(dr["NgaySinh"].ToString(), out DateTime ngaySinh))
                {
                    nhanVien.NgaySinh = ngaySinh;
                }
                else
                {
                    nhanVien.NgaySinh = DateTime.MinValue; // Or handle as needed
                }

                nhanVien.Email = dr["Email"].ToString();
                nhanVien.SDT = dr["SDT"].ToString();
                nhanVien.DiaChi = dr["DiaChi"].ToString();
                nhanVien.ChucVu = dr["ChucVu"].ToString();
                if (DateTime.TryParse(dr["NgayVaoLam"].ToString(), out DateTime ngayVaoLam))
                {
                    nhanVien.NgayVaoLam = ngayVaoLam;
                }
                else
                {
                    nhanVien.NgayVaoLam = DateTime.MinValue; // Or handle as needed
                }

                nhanVien.Username = dr["Username"].ToString();
                nhanVien.Password_NV = dr["Password_NV"].ToString();
                nhanVien.TrangThai = dr["TrangThai"].ToString();
                dsNhanVien.Add(nhanVien);
            }
            dr.Close();
            conn.Close();

            return dsNhanVien;
        }

        public bool KiemTraDangNhap(string username, string password)
        {
            string proc = "sp_KiemTraDangNhap";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            int kq = DataProvider.ExcuteProcedureScalar(proc, conn, parameters);
            conn.Close();

            return kq > 0;
        }
    }
}
