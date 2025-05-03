using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace DAO
{
    public class TheLoaiSachDAO
    {
        public List<TheLoaiSachDTO> LayDanhSachTheLoaiSach(int maSach = -1, int maTheLoai = -1)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            if (maSach != -1)
            {
                paramList.Add(new SqlParameter("@MaSach", maSach));
            }
            if (maTheLoai != -1)
            {
                paramList.Add(new SqlParameter("@MaTheLoai", maTheLoai));
            }
            SqlParameter[] parameters = paramList.ToArray();
            List<TheLoaiSachDTO> dsTheLoaiSach = new List<TheLoaiSachDTO>();
            string proc = "sp_LayDanhSachTheLoaiSach";
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            SqlDataReader dr = DataProvider.ExcuteProcedure(proc, conn, parameters);
            while (dr.Read())
            {
                TheLoaiSachDTO theLoaiSach = new TheLoaiSachDTO();
                theLoaiSach.MaSach = int.Parse(dr["MaSach"].ToString());
                theLoaiSach.MaTheLoai = int.Parse(dr["MaTheLoai"].ToString());
                theLoaiSach.TenSach = dr["TenSach"].ToString();
                theLoaiSach.TenTheLoai = dr["TenTheLoai"].ToString();
                dsTheLoaiSach.Add(theLoaiSach);
            }
            dr.Close();
            conn.Close();
            return dsTheLoaiSach;
        }

        public int ThemTheLoaiSach(TheLoaiSachDTO tls)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@MaSach", tls.MaSach));
            paramList.Add(new SqlParameter("@MaTheLoai", tls.MaTheLoai));
            SqlParameter[] parameters = paramList.ToArray();

            string proc = "sp_ThemTheLoaiSach";

            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            int kq = DataProvider.ExcuteProcedureNonQuery(proc, conn, parameters);
            conn.Close();

            return kq;
        }

        public int XoaTheLoaiSach(TheLoaiSachDTO tls)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@MaSach", tls.MaSach));
            paramList.Add(new SqlParameter("@MaTheLoai", tls.MaTheLoai));
            SqlParameter[] parameters = paramList.ToArray();

            string proc = "sp_XoaTheLoaiSach";

            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            int kq = DataProvider.ExcuteProcedureNonQuery(proc, conn, parameters);
            conn.Close();

            return kq;
        }

        public int CapNhatTheLoaiSach(TheLoaiSachDTO tls)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@MaSach", tls.MaSach));
            paramList.Add(new SqlParameter("@MaTheLoai", tls.MaTheLoai));
            SqlParameter[] parameters = paramList.ToArray();

            string proc = "sp_CapNhatTheLoaiSach";

            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            int kq = DataProvider.ExcuteProcedureNonQuery(proc, conn, parameters);
            conn.Close();

            return kq;
        }
    }
}
