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
