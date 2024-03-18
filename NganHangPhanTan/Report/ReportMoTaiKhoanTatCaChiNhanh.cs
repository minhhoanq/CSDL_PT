using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace NganHangPhanTan.Report
{
    public partial class ReportMoTaiKhoanTatCaChiNhanh : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportMoTaiKhoanTatCaChiNhanh()
        {
            InitializeComponent();
        }


        public ReportMoTaiKhoanTatCaChiNhanh(DateTime dateFrom, DateTime dateTo)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.ConnectionStr;
            var query = this.sqlDataSource1.Queries[0];
            query.Parameters[0].Value = dateFrom.Date.ToString("yyyy-MM-dd");
            query.Parameters[1].Value = dateTo.Date.ToString("yyyy-MM-dd");
            this.sqlDataSource1.Fill();

            lbDate.Text = dateFrom.Date.ToString("d") + " - " + dateTo.Date.ToString("d");
        }

    }
}
