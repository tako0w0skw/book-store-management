using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class TacGiaDAO
    {
        public List<TacGiaDTO> LayDanhSachTacGia(int maTG = -1)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            if (maTG != -1)
            {
                paramList.Add(new SqlParameter("@MaTacGia", maTG));
            }
            SqlParameter[] parameters = paramList.ToArray();
            List<TacGiaDTO> dsTacGia = new List<TacGiaDTO>();
            string proc = "sp_LayDanhSachTacGia";
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            SqlDataReader dr = DataProvider.ExcuteProcedure(proc, conn, parameters);
            while (dr.Read())
            {
                TacGiaDTO tacGia = new TacGiaDTO();
                tacGia.MaTacGia = int.Parse(dr["MaTacGia"].ToString());
                tacGia.TenTacGia = dr["TenTacGia"].ToString();
                dsTacGia.Add(tacGia);
            }
            conn.Close();
            return dsTacGia;
        }
    }
}
