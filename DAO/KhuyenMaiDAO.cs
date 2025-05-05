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
        private static string strKetNoi = "Data Source=.;Initial Catalog=QuanLyPMBanSach;Integrated Security=True";

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

        public int ThemKhuyenMai(KhuyenMaiDTO km)
        {
            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                string query = @"INSERT INTO KHUYENMAI(MaKM, TenMa, LoaiGiam, MucGiam, SoLuong, 
                                LuotSuDung, NgayBatDau, NgayKetThuc, TrangThai, MaNV) 
                                VALUES (@MaKM, @TenMa, @LoaiGiam, @MucGiam, @SoLuong, 
                                @LuotSuDung, @NgayBatDau, @NgayKetThuc, @TrangThai, @MaNV)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MaKM", km.MaKM);
                cmd.Parameters.AddWithValue("@TenMa", km.TenMa);
                cmd.Parameters.AddWithValue("@LoaiGiam", km.LoaiGiam);
                cmd.Parameters.AddWithValue("@MucGiam", km.MucGiam);
                cmd.Parameters.AddWithValue("@SoLuong", km.SoLuong);
                cmd.Parameters.AddWithValue("@LuotSuDung", (object)km.LuotSuDung ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NgayBatDau", (object)km.NgayBatDau ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NgayKetThuc", km.NgayKetThuc);
                cmd.Parameters.AddWithValue("@TrangThai", km.TrangThai);
                cmd.Parameters.AddWithValue("@MaNV", (object)km.MaNV ?? DBNull.Value);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int CapNhatKhuyenMai(KhuyenMaiDTO km)
        {
            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                string query = @"UPDATE KHUYENMAI SET 
                                TenMa = @TenMa, 
                                LoaiGiam = @LoaiGiam, 
                                MucGiam = @MucGiam, 
                                SoLuong = @SoLuong, 
                                LuotSuDung = @LuotSuDung, 
                                NgayBatDau = @NgayBatDau, 
                                NgayKetThuc = @NgayKetThuc, 
                                TrangThai = @TrangThai, 
                                MaNV = @MaNV
                                WHERE MaKM = @MaKM";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MaKM", km.MaKM);
                cmd.Parameters.AddWithValue("@TenMa", km.TenMa);
                cmd.Parameters.AddWithValue("@LoaiGiam", km.LoaiGiam);
                cmd.Parameters.AddWithValue("@MucGiam", km.MucGiam);
                cmd.Parameters.AddWithValue("@SoLuong", km.SoLuong);
                cmd.Parameters.AddWithValue("@LuotSuDung", (object)km.LuotSuDung ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NgayBatDau", (object)km.NgayBatDau ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NgayKetThuc", km.NgayKetThuc);
                cmd.Parameters.AddWithValue("@TrangThai", km.TrangThai);
                cmd.Parameters.AddWithValue("@MaNV", (object)km.MaNV ?? DBNull.Value);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int XoaKhuyenMai(string maKM)
        {
            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                string query = "DELETE FROM KHUYENMAI WHERE MaKM = @MaKM";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKM", maKM);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
