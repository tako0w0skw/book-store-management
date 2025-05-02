using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class KhuyenMaiBUS
    {
        public List<KhuyenMaiDTO> LayDanhSachKhuyenMai(string maKM = null, int maNV = -1, string loaiGiam = null)
        {
            KhuyenMaiDAO khuyenMaiDAO = new KhuyenMaiDAO();
            return khuyenMaiDAO.LayDanhSachKhuyenMai(maKM, maNV, loaiGiam);
        }
    }
}
