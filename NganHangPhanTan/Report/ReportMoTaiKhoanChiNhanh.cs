using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace NganHangPhanTan.Report
{
    public partial class ReportMoTaiKhoanChiNhanh : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportMoTaiKhoanChiNhanh()
        {
            InitializeComponent();
        }


        public ReportMoTaiKhoanChiNhanh(DateTime dateFrom, DateTime dateTo, string brandName)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.ConnectionStr;
            var query = this.sqlDataSource1.Queries[0];
            query.Parameters[0].Value = dateFrom.Date.ToString("yyyy-MM-dd");
            query.Parameters[1].Value = dateTo.Date.ToString("yyyy-MM-dd");
            this.sqlDataSource1.Fill();

            lbBrandName.Text = brandName;
            lbDate.Text = dateFrom.Date.ToString("d") + " - " + dateTo.Date.ToString("d");
        }

    }
}
