using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class TacGiaBUS
    {
        public List<TacGiaDTO> LayDanhSachTacGia(int maTG = -1)
        {
            TacGiaDAO tacGiaDAO = new TacGiaDAO();
            return tacGiaDAO.LayDanhSachTacGia(maTG);
        }

        public int ThemTacGia(TacGiaDTO tacGia)
        {
            TacGiaDAO tacGiaDAO = new TacGiaDAO();
            return tacGiaDAO.ThemTacGia(tacGia);
        }

        public int CapNhatTacGia(TacGiaDTO tacGia)
        {
            TacGiaDAO tacGiaDAO = new TacGiaDAO();
            return tacGiaDAO.CapNhatTacGia(tacGia);
        }

        public int XoaTacGia(int maTacGia)
        {
            TacGiaDAO tacGiaDAO = new TacGiaDAO();
            return tacGiaDAO.XoaTacGia(maTacGia);
        }
    }
}
