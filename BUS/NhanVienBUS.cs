using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data.SqlClient;

namespace BUS
{
    public class NhanVienBUS
    {
        public List<NhanVienDTO> LayDanhSachNhanVien(int maNV = -1, string chucVu = null, string trangThai = null)
        {
            NhanVienDAO nhanVienDAO = new NhanVienDAO();
            return nhanVienDAO.LayDanhSachNhanVien(maNV, chucVu, trangThai);
        }

        public bool KiemTraDangNhap(string username, string password)
        {
            NhanVienDAO nhanVienDAO = new NhanVienDAO();
            return nhanVienDAO.KiemTraDangNhap(username, password);
        }
    }
}
