using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class ChiTietHoaDonDAO
    {
        public List<ChiTietHoaDonDTO> LayDanhSachChiTietHoaDon(int maHD = -1)
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            if (maHD != -1)
            {
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaHD", maHD)
                };
            }

            string proc = "sp_LayDanhSachChiTietHoaDon";

            List<ChiTietHoaDonDTO> dsChiTietHoaDon = new List<ChiTietHoaDonDTO>();
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            SqlDataReader dr = DataProvider.ExcuteProcedure(proc, conn, parameters);
            while(dr.Read())
            {
                ChiTietHoaDonDTO chiTietHoaDon = new ChiTietHoaDonDTO();
                chiTietHoaDon.MaHD = int.Parse(dr["MaHD"].ToString());
                chiTietHoaDon.MaSach = int.Parse(dr["MaSach"].ToString());
                chiTietHoaDon.TenSach = dr["TenSach"].ToString();
                chiTietHoaDon.SoLuong = int.Parse(dr["SoLuong"].ToString());
                chiTietHoaDon.DonGia = double.Parse(dr["DonGia"].ToString());

                if (double.TryParse(dr["ThanhTien"]?.ToString(), out double thanhTien))
                {
                    chiTietHoaDon.ThanhTien = thanhTien;
                }
                else
                {
                    chiTietHoaDon.ThanhTien = 0; // Or handle the error appropriately
                }

                dsChiTietHoaDon.Add(chiTietHoaDon);
            }    
            dr.Close();
            conn.Close();
            return dsChiTietHoaDon;
        }

        public int ThemChiTietHoaDon(ChiTietHoaDonDTO chiTietHoaDon)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@MaHD", chiTietHoaDon.MaHD));
            paramList.Add(new SqlParameter("@MaSach", chiTietHoaDon.MaSach));
            paramList.Add(new SqlParameter("@TenSach", chiTietHoaDon.TenSach));
            paramList.Add(new SqlParameter("@SoLuong", chiTietHoaDon.SoLuong));
            paramList.Add(new SqlParameter("@DonGia", chiTietHoaDon.DonGia));
            paramList.Add(new SqlParameter("@ThanhTien", chiTietHoaDon.ThanhTien));
            SqlParameter[] parameters = paramList.ToArray();

            string proc = "sp_ThemChiTietHoaDon";
            
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            int kq = DataProvider.ExcuteProcedureNonQuery(proc, conn, parameters);
            conn.Close();
            return kq;
        }
    }
}
