using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class SachBUS
    {
        public List<SachDTO> LayDanhSachSach(int maSach = -1, string nxb = null, string trangThai = null)
        {
            SachDAO sachDAO = new SachDAO();
            return sachDAO.LayDanhSachSach(maSach, nxb, trangThai);
        }

        public int ThemSach(SachDTO sach)
        {
            SachDAO sachDAO = new SachDAO();
            return sachDAO.ThemSach(sach);
        }

        public int XoaSach(int maSach)
        {
            SachDAO sachDAO = new SachDAO();
            return sachDAO.XoaSach(maSach);
        }

        public int CapNhatSach(SachDTO sach)
        {
            SachDAO sachDAO = new SachDAO();
            return sachDAO.CapNhatSach(sach);
        }

        public int CapNhatSoLuongTon(int maSach, int soLuong)
        {
            SachDAO sachDAO = new SachDAO();
            return sachDAO.CapNhatSoLuongTon(maSach, soLuong);
        }
    }
}
