using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class SachDAO
    {
        public List<SachDTO> LayDanhSachSach(int maSach = -1, string nxb = null, string trangThai = null)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();

            if (maSach != -1)
            {
                paramList.Add(new SqlParameter("@MaSach", maSach));
            }
            if (nxb != null)
            {
                paramList.Add(new SqlParameter("@NXB", nxb));
            }
            if (trangThai != null)
            {
                paramList.Add(new SqlParameter("@TrangThai", trangThai));
            }

            SqlParameter[] parameters = paramList.ToArray();

            List<SachDTO> dsSach = new List<SachDTO>();
            string proc = "sp_LayDanhSachSach";

            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            SqlDataReader dr = DataProvider.ExcuteProcedure(proc, conn, parameters);
            while (dr.Read())
            {
                SachDTO sach = new SachDTO();
                sach.MaSach = int.Parse(dr["MaSach"].ToString());
                sach.HinhAnh = dr["HinhAnh"].ToString();
                sach.TenSach = dr["TenSach"].ToString();
                sach.Gia = double.Parse(dr["Gia"].ToString());
                sach.SoLuongTon = int.Parse(dr["SoLuongTon"].ToString());
                sach.NhaXuatBan = dr["NhaXuatBan"].ToString();
                sach.MoTa = dr["MoTa"].ToString();
                sach.SoTrang = int.Parse(dr["SoTrang"].ToString());
                sach.NgayPhatHanh = DateTime.Parse(dr["NgayPhatHanh"].ToString());
                sach.DichGia = dr["DichGia"].ToString();
                sach.MaKM = dr["MaKM"].ToString();
                sach.TrangThai = dr["TrangThai"].ToString();
                dsSach.Add(sach);
            }
            dr.Close();
            conn.Close();
            return dsSach;
        }

        public int ThemSach(SachDTO sach)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@HinhAnh", sach.HinhAnh));
            paramList.Add(new SqlParameter("@TenSach", sach.TenSach));
            paramList.Add(new SqlParameter("@Gia", sach.Gia));
            paramList.Add(new SqlParameter("@SoLuongTon", sach.SoLuongTon));
            paramList.Add(new SqlParameter("@NhaXuatBan", sach.NhaXuatBan));
            paramList.Add(new SqlParameter("@MoTa", sach.MoTa));
            paramList.Add(new SqlParameter("@SoTrang", sach.SoTrang));
            paramList.Add(new SqlParameter("@NgayPhatHanh", sach.NgayPhatHanh));
            paramList.Add(new SqlParameter("@DichGia", sach.DichGia));
            paramList.Add(new SqlParameter("@MaKM", sach.MaKM));
            paramList.Add(new SqlParameter("@TrangThai", sach.TrangThai));

            SqlParameter[] parameters = paramList.ToArray();
            string proc = "sp_ThemSach";
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            int kq = DataProvider.ExcuteProcedureNonQuery(proc, conn, parameters);
            conn.Close();
            return kq;
        }

        public int XoaSach(int maSach)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@MaSach", maSach));
            SqlParameter[] parameters = paramList.ToArray();
            string proc = "sp_XoaSach";
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            int kq = DataProvider.ExcuteProcedureNonQuery(proc, conn, parameters);
            DataProvider.ThucThi("sp_ReseedIdentitySach", conn);
            conn.Close();
            return kq;
        }

        public int CapNhatSach(SachDTO sach)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@MaSach", sach.MaSach));
            paramList.Add(new SqlParameter("@HinhAnh", sach.HinhAnh));
            paramList.Add(new SqlParameter("@TenSach", sach.TenSach));
            paramList.Add(new SqlParameter("@Gia", sach.Gia));
            paramList.Add(new SqlParameter("@SoLuongTon", sach.SoLuongTon));
            paramList.Add(new SqlParameter("@NhaXuatBan", sach.NhaXuatBan));
            paramList.Add(new SqlParameter("@MoTa", sach.MoTa));
            paramList.Add(new SqlParameter("@SoTrang", sach.SoTrang));
            paramList.Add(new SqlParameter("@NgayPhatHanh", sach.NgayPhatHanh));
            paramList.Add(new SqlParameter("@DichGia", sach.DichGia));
            paramList.Add(new SqlParameter("@MaKM", sach.MaKM));
            paramList.Add(new SqlParameter("@TrangThai", sach.TrangThai));
            SqlParameter[] parameters = paramList.ToArray();
            string proc = "sp_CapNhatSach";
            SqlConnection conn = DataProvider.TaoKetNoi();
            conn.Open();
            int kq = DataProvider.ExcuteProcedureNonQuery(proc, conn, parameters);
            conn.Close();
            return kq;
        }
    }
}
