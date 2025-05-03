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
    }
}
