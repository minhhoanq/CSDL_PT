using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace NganHangPhanTan.Report
{
    public partial class ReportSaoKe : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportSaoKe(string accountId, DateTime dateFrom, DateTime dateTo)
        {
            InitializeComponent();

            var query = this.sqlDataSource1.Queries[0];
            query.Parameters[0].Value = accountId;
            query.Parameters[1].Value = dateFrom.Date.ToString("yyyy-MM-dd");
            query.Parameters[2].Value = dateTo.Date.ToString("yyyy-MM-dd");
            //query.Parameters[3].Value = type;
            this.sqlDataSource1.Fill();

            //lbBrandName.Text = brandName;
            //lbTransType.Text = typeName;
            lbAccountId.Text = accountId;
            lbDate.Text = dateFrom.Date.ToString("d") + " - " + dateTo.Date.ToString("d");
        }

    }
}
