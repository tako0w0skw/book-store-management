using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using Microsoft.Reporting.WinForms;

namespace GUI.frm_Manager
{
    public partial class XemCTHD : Form
    {

        List<ChiTietHoaDonDTO> dsCTHD = new List<ChiTietHoaDonDTO>();
        string tenNV;
        string tenKH;

        public XemCTHD()
        {
            InitializeComponent();
        }

        public XemCTHD(List<ChiTietHoaDonDTO> dsCTHD, string tenNV, string tenKH)
        {
            this.dsCTHD = dsCTHD;
            InitializeComponent();
            this.tenNV = tenNV;
            this.tenKH = tenKH;
        }

        private void XemCTHD_Load(object sender, EventArgs e)
        {
            this.rpvCTHD.LocalReport.ReportEmbeddedResource = "GUI.frm_Manager.Report_CTHD.rdlc";
            this.rpvCTHD.LocalReport.DataSources.Add(new ReportDataSource("CHITIETHOADON", dsCTHD));
            this.rpvCTHD.LocalReport.SetParameters(new ReportParameter("paOrderID", dsCTHD[0].MaHD.ToString()));
            this.rpvCTHD.LocalReport.SetParameters(new ReportParameter("paStaffName", tenNV));
            this.rpvCTHD.LocalReport.SetParameters(new ReportParameter("paCustomerName", tenKH));
            this.rpvCTHD.RefreshReport();
        }
    }
}
