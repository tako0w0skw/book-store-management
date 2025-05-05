using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace DAO
{
    public class DiaChiKhachHangDAO
    {
        private static string strKetNoi = "Data Source=.;Initial Catalog=QuanLyPMBanSach;Integrated Security=True";

        public List<DiaChiKhachHangDTO> LayDanhSachDiaChi(int? maDiaChi = null, int? maKH = null)
        {
            List<DiaChiKhachHangDTO> ds = new List<DiaChiKhachHangDTO>();

            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                string query = "SELECT * FROM DIACHI_KH WHERE 1=1";

                if (maDiaChi.HasValue)
                    query += " AND MaDiaChi = @MaDiaChi";

                if (maKH.HasValue)
                    query += " AND MaKH = @MaKH";

                SqlCommand cmd = new SqlCommand(query, conn);

                if (maDiaChi.HasValue)
                    cmd.Parameters.AddWithValue("@MaDiaChi", maDiaChi);

                if (maKH.HasValue)
                    cmd.Parameters.AddWithValue("@MaKH", maKH);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DiaChiKhachHangDTO dc = new DiaChiKhachHangDTO(
                            maDiaChi: Convert.ToInt32(reader["MaDiaChi"]),
                            maKH: reader["MaKH"] != DBNull.Value ? Convert.ToInt32(reader["MaKH"]) : (int?)null,
                            diaChi: reader["DiaChi"].ToString()
                        );
                        ds.Add(dc);
                    }
                }
            }
            return ds;
        }

        public int ThemDiaChi(DiaChiKhachHangDTO dc)
        {
            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                string query = "INSERT INTO DIACHI_KH(MaKH, DiaChi) VALUES (@MaKH, @DiaChi)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MaKH", (object)dc.MaKH ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DiaChi", dc.DiaChi);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int CapNhatDiaChi(DiaChiKhachHangDTO dc)
        {
            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                string query = "UPDATE DIACHI_KH SET MaKH = @MaKH, DiaChi = @DiaChi WHERE MaDiaChi = @MaDiaChi";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MaDiaChi", dc.MaDiaChi);
                cmd.Parameters.AddWithValue("@MaKH", (object)dc.MaKH ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DiaChi", dc.DiaChi);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int XoaDiaChi(int maDiaChi)
        {
            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                string query = "DELETE FROM DIACHI_KH WHERE MaDiaChi = @MaDiaChi";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDiaChi", maDiaChi);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
