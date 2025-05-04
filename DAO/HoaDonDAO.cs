using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class HoaDonDAO
    {
        public List<HoaDonDTO> LayDanhSachHoaDon(int maHD = -1, int maNV = -1, int maKH = -1)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            if (maHD != -1)
            {
                paramList.Add(new SqlParameter("@MaHD", maHD));
            }
            if (maNV != -1)
            {
                paramList.Add(new SqlParameter("@MaNV", maNV));
            }
            if (maKH != -1)
            {
                paramList.Add(new SqlParameter("@MaKH", maKH));
            }
            SqlParameter[] parameters = paramList.ToArray();

            string proc = "sp_LayDanhSachHoaDon";

            List<HoaDonDTO> dsHoaDon = new List<HoaDonDTO>();
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            SqlDataReader dr = DataProvider.ExcuteProcedure(proc, conn, parameters);
            while (dr.Read())
            {
                HoaDonDTO hoaDon = new HoaDonDTO();
                hoaDon.MaHD = int.Parse(dr["MaHD"].ToString());
                hoaDon.TamTinh = double.Parse(dr["TamTinh"].ToString());
                hoaDon.PhiVanChuyen = double.Parse(dr["PhiVanChuyen"].ToString());
                hoaDon.TongTien = double.Parse(dr["TongTien"].ToString());
                hoaDon.PT_ThanhToan = dr["PT_ThanhToan"].ToString();
                hoaDon.PT_GiaoHang = dr["PT_GiaoHang"].ToString();
                hoaDon.SDT = dr["SDT"].ToString();
                hoaDon.TrangThai = dr["TrangThai"].ToString();
                hoaDon.MaKH = int.Parse(dr["MaKH"].ToString());
                hoaDon.MaKM = dr["MaKM"].ToString();
                hoaDon.MaNV = dr["MaNV"] != DBNull.Value && !string.IsNullOrEmpty(dr["MaNV"].ToString())? int.Parse(dr["MaNV"].ToString()): 0; // Or a default value

                dsHoaDon.Add(hoaDon);
            }
            dr.Close();
            conn.Close();
            return dsHoaDon;
        }

        public int ThemHoaDon(HoaDonDTO hoaDon)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@TamTinh", hoaDon.TamTinh));
            paramList.Add(new SqlParameter("@PhiVanChuyen", hoaDon.PhiVanChuyen));
            paramList.Add(new SqlParameter("@TongTien", hoaDon.TongTien));
            paramList.Add(new SqlParameter("@PT_ThanhToan", hoaDon.PT_ThanhToan));
            paramList.Add(new SqlParameter("@PT_GiaoHang", hoaDon.PT_GiaoHang));
            paramList.Add(new SqlParameter("@SDT", hoaDon.SDT));
            paramList.Add(new SqlParameter("@TrangThai", hoaDon.TrangThai));
            paramList.Add(new SqlParameter("@MaKH", hoaDon.MaKH));
            paramList.Add(new SqlParameter("@MaKM", hoaDon.MaKM));
            paramList.Add(new SqlParameter("@MaNV", hoaDon.MaNV));
            SqlParameter[] parameters = paramList.ToArray();

            string proc = "sp_ThemHoaDon";

            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            int kq = DataProvider.ExcuteProcedureNonQuery(proc, conn, parameters);
            conn.Close();
            return kq;
        }

        public HoaDonDTO LayHoaDonVuaTao()
        {
            string proc = "sp_LayHoaDonVuaTao";

            HoaDonDTO hoaDon = new HoaDonDTO();
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            SqlDataReader dr = DataProvider.ExcuteProcedure(proc, conn, null);
            while(dr.Read())
            {
                hoaDon.MaHD = int.Parse(dr["MaHD"].ToString());
            }
            dr.Close();
            conn.Close();
            return hoaDon;
        }
    }
}
