using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class TheLoaiSachBUS
    {
        public List<TheLoaiSachDTO> LayDanhSachTheLoaiSach(int maSach = -1, int maTheLoai = -1)
        {
            TheLoaiSachDAO theLoaiSachDAO = new TheLoaiSachDAO();
            return theLoaiSachDAO.LayDanhSachTheLoaiSach(maSach, maTheLoai);
        }

        public int ThemTheLoaiSach(TheLoaiSachDTO tls)
        {
            TheLoaiSachDAO theLoaiSachDAO = new TheLoaiSachDAO();
            return theLoaiSachDAO.ThemTheLoaiSach(tls);
        }

        public int XoaTheLoaiSach(TheLoaiSachDTO tls)
        {
            TheLoaiSachDAO theLoaiSachDAO = new TheLoaiSachDAO();
            return theLoaiSachDAO.XoaTheLoaiSach(tls);
        }

        public int CapNhatTheLoaiSach(TheLoaiSachDTO tls)
        {
            TheLoaiSachDAO theLoaiSachDAO = new TheLoaiSachDAO();
            return theLoaiSachDAO.CapNhatTheLoaiSach(tls);
        }
    }
}
