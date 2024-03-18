using DevExpress.XtraReports.UI;
using NganHangPhanTan.Util;
using System;

namespace NganHangPhanTan.Report
{
    public partial class fReportKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public fReportKhachHang()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ReportKhachHang report = new ReportKhachHang();
                ReportPrintTool printTool = new ReportPrintTool(report);
                printTool.ShowPreviewDialog();
            }
            catch (System.Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog(ex.Message);
                throw ex;
            }
        }
    }
}