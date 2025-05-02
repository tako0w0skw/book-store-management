using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class TacGiaSachDAO
    {
        public List<TacGiaSachDTO> LayDanhSachTacGiaSach(int maSach = -1)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            if (maSach != -1)
            {
                paramList.Add(new SqlParameter("@MaSach", maSach));
            }
            SqlParameter[] parameters = paramList.ToArray();
            List<TacGiaSachDTO> dsTacGiaSach = new List<TacGiaSachDTO>();
            string proc = "sp_LayDanhSachTGSach";
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            SqlDataReader dr = DataProvider.ExcuteProcedure(proc, conn, parameters);
            while (dr.Read())
            {
                TacGiaSachDTO tacGiaSach = new TacGiaSachDTO();
                tacGiaSach.MaSach = int.Parse(dr["MaSach"].ToString());
                tacGiaSach.MaTacGia = int.Parse(dr["MaTacGia"].ToString());
                tacGiaSach.TenSach = dr["TenSach"].ToString();
                tacGiaSach.TenTacGia = dr["TenTacGia"].ToString();
                dsTacGiaSach.Add(tacGiaSach);
            }
            dr.Close();
            conn.Close();
            return dsTacGiaSach;
        }

        public int ThemTacGiaSach(TacGiaSachDTO tacGiaSachDTO)
        {
            string proc = "sp_ThemTGSach";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@MaSach", tacGiaSachDTO.MaSach));
            paramList.Add(new SqlParameter("@MaTacGia", tacGiaSachDTO.MaTacGia));
            SqlParameter[] parameters = paramList.ToArray();
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            int kq = DataProvider.ExcuteProcedureNonQuery(proc, conn, parameters);
            conn.Close();
            return kq;
        }

        public int XoaTacGiaSach(TacGiaSachDTO tacGiaSachDTO)
        {
            string proc = "sp_XoaTGSach";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@MaSach", tacGiaSachDTO.MaSach));
            paramList.Add(new SqlParameter("@MaTacGia", tacGiaSachDTO.MaTacGia));
            SqlParameter[] parameters = paramList.ToArray();
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            int kq = DataProvider.ExcuteProcedureNonQuery(proc, conn, parameters);
            conn.Close();
            return kq;
        }

        public int CapNhatTacGiaSach(TacGiaSachDTO tacGiaSachDTO)
        {
            string proc = "sp_CapNhatTGSach";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@MaSach", tacGiaSachDTO.MaSach));
            paramList.Add(new SqlParameter("@MaTacGia", tacGiaSachDTO.MaTacGia));
            SqlParameter[] parameters = paramList.ToArray();
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            int kq = DataProvider.ExcuteProcedureNonQuery(proc, conn, parameters);
            conn.Close();
            return kq;
        }
    }
}
