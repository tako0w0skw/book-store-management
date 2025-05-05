using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class TheLoaiDAO
    {
        public List<TheLoaiDTO> LayDanhSachTheLoai(int maTL = -1)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            if(maTL != -1)
            {
                paramList.Add(new SqlParameter("@MaTheLoai", maTL));
            }
            SqlParameter[] parameters = paramList.ToArray();

            string proc = "sp_LayDanhSachTheLoai";
            List<TheLoaiDTO> dsTheLoai = new List<TheLoaiDTO>();

            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            SqlDataReader dr = DataProvider.ExcuteProcedure(proc, conn, parameters);
            while(dr.Read())
            {
                TheLoaiDTO tl = new TheLoaiDTO();
                tl.MaTheLoai = int.Parse(dr["MaTheLoai"].ToString());
                tl.TenTheLoai = dr["TenTheLoai"].ToString();
                dsTheLoai.Add(tl);
            }
            dr.Close();
            conn.Close();
            return dsTheLoai;
        }

        public int ThemTheLoai(TheLoaiDTO tl)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@TenTheLoai", tl.TenTheLoai));
            SqlParameter[] parameters = paramList.ToArray();
            string proc = "sp_ThemTheLoai";
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            int kq = DataProvider.ExcuteProcedureNonQuery(proc, conn, parameters);
            conn.Close();
            return kq;
        }

        public int CapNhatTheLoai(TheLoaiDTO tl)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@MaTheLoai", tl.MaTheLoai));
            paramList.Add(new SqlParameter("@TenTheLoai", tl.TenTheLoai));
            SqlParameter[] parameters = paramList.ToArray();
            string proc = "sp_CapNhatTheLoai";
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            int kq = DataProvider.ExcuteProcedureNonQuery(proc, conn, parameters);
            conn.Close();
            return kq;
        }

        public int XoaTheLoai(int maTL)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@MaTheLoai", maTL));
            SqlParameter[] parameters = paramList.ToArray();
            string proc = "sp_XoaTheLoai";
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            int kq = DataProvider.ExcuteProcedureNonQuery(proc, conn, parameters);
            DataProvider.ThucThi("sp_ReseedIdentityTheLoai", conn);
            conn.Close();
            return kq;
        }
    }
}
