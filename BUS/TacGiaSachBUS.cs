using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class TacGiaSachBUS
    {
        public List<TacGiaSachDTO> LayDanhSachTacGiaSach(int maSach = -1)
        {
            TacGiaSachDAO tacGiaSachDAO = new TacGiaSachDAO();
            return tacGiaSachDAO.LayDanhSachTacGiaSach(maSach);
        }

        public int ThemTacGiaSach(TacGiaSachDTO tacGiaSachDTO)
        {
            TacGiaSachDAO tacGiaSachDAO = new TacGiaSachDAO();
            return tacGiaSachDAO.ThemTacGiaSach(tacGiaSachDTO);
        }

        public int XoaTacGiaSach(TacGiaSachDTO tacGiaSachDTO)
        {
            TacGiaSachDAO tacGiaSachDAO = new TacGiaSachDAO();
            return tacGiaSachDAO.XoaTacGiaSach(tacGiaSachDTO);
        }

        public int CapNhatTacGiaSach(TacGiaSachDTO tacGiaSachDTO)
        {
            TacGiaSachDAO tacGiaSachDAO = new TacGiaSachDAO();
            return tacGiaSachDAO.CapNhatTacGiaSach(tacGiaSachDTO);
        }
    }
}
