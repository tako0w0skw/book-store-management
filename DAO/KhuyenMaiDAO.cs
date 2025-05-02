using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class KhuyenMaiDAO
    {
        public List<KhuyenMaiDTO> LayDanhSachKhuyenMai(string maKM = null, int maNV = -1, string loaiGiam = null)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            if (maKM != null)
            {
                paramList.Add(new SqlParameter("@MaKM", maKM));
            }
            if (maNV != -1)
            {
                paramList.Add(new SqlParameter("@MaNV", maNV));
            }
            if (loaiGiam != null)
            {
                paramList.Add(new SqlParameter("@LoaiGiam", loaiGiam));
            }
            SqlParameter[] parameters = paramList.ToArray();

            List<KhuyenMaiDTO> dsKhuyenMai = new List<KhuyenMaiDTO>();
            string proc = "sp_LayDanhSachKhuyenMai";
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            SqlDataReader dr = DataProvider.ExcuteProcedure(proc, conn, parameters);
            while (dr.Read())
            {
                KhuyenMaiDTO khuyenMai = new KhuyenMaiDTO();
                khuyenMai.MaKM = dr["MaKM"].ToString();
                khuyenMai.TenMa = dr["TenMa"].ToString();
                khuyenMai.LoaiGiam = dr["LoaiGiam"].ToString();
                khuyenMai.MucGiam = double.Parse(dr["MucGiam"].ToString());
                khuyenMai.SoLuong = int.Parse(dr["SoLuong"].ToString());
                khuyenMai.LuotSuDung = int.Parse(dr["LuotSuDung"].ToString());
                khuyenMai.NgayBatDau = DateTime.Parse(dr["NgayBatDau"].ToString());
                khuyenMai.NgayKetThuc = DateTime.Parse(dr["NgayKetThuc"].ToString());
                khuyenMai.TrangThai = dr["TrangThai"].ToString();
                khuyenMai.MaNV = int.Parse(dr["MaNV"].ToString());
                dsKhuyenMai.Add(khuyenMai);
            }
            dr.Close();
            conn.Close();
            return dsKhuyenMai;
        }
    }
}
