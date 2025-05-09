﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data.SqlClient;

namespace BUS
{
    public class TheLoaiBUS
    {
        public List<TheLoaiDTO> LayDanhSachTheLoai(int maTL = -1)
        {
            TheLoaiDAO theLoaiDAO = new TheLoaiDAO();
            return theLoaiDAO.LayDanhSachTheLoai(maTL);
        }

        public int ThemTheLoai(TheLoaiDTO tl)
        {
            TheLoaiDAO theLoaiDAO = new TheLoaiDAO();
            return theLoaiDAO.ThemTheLoai(tl);
        }

        public int CapNhatTheLoai(TheLoaiDTO tl)
        {
            TheLoaiDAO theLoaiDAO = new TheLoaiDAO();
            return theLoaiDAO.CapNhatTheLoai(tl);
        }

        public int XoaTheLoai(int maTL)
        {
            TheLoaiDAO theLoaiDAO = new TheLoaiDAO();
            return theLoaiDAO.XoaTheLoai(maTL);
        }
    }
}
