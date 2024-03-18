using DevExpress.XtraReports.UI;
using NganHangPhanTan.DTO;
using NganHangPhanTan.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace NganHangPhanTan.Report
{
    public partial class fReportSaoKe : DevExpress.XtraEditors.XtraForm
    {
        private readonly static Dictionary<string, string> transTypeMap = new Dictionary<string, string>
        {
            {"Tất cả", ""},
            {"Rút tiền", "RT"},
            {"Gửi tiền", "GT"},
            {"Chuyển tiền", "CT"}
        };

        public fReportSaoKe()
        {
            InitializeComponent();
        }

        private void fReportTransaction_Load(object sender, System.EventArgs e)
        {
            // TODO: This line of code loads data into the 'DS.TaiKhoan' table. You can move, or remove it, as needed.

            this.taiKhoanTableAdapter.Connection.ConnectionString = Program.ConnectionStr;
            this.taiKhoanTableAdapter.Fill(this.DS.TaiKhoan);
            // TODO: This line of code loads data into the 'dS.usp_GetKhachHangAccounts' table. You can move, or remove it, as needed.

            cbBrand.DataSource = Program.bindingSource;/*sao chep bingding source tu form dang nhap*/
            cbBrand.DisplayMember = "TENCN";
            cbBrand.ValueMember = "TENSERVER";
            cbBrand.SelectedIndex = SecurityContext.User.BrandIndex;

            switch (SecurityContext.User.Group)
            {
                case DTO.User.GroupENM.NGAN_HANG:
                    cbBrand.Enabled = true;
                    break;
                case DTO.User.GroupENM.CHI_NHANH:
                    cbBrand.Enabled = false;
                    break;
            }

           

            dpDateFrom.DateTime = dpDateTo.DateTime = DateTime.Now;
            cbBrand_SelectionChangeCommitted(null, null);
        }

        private void btnSubmit_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (taiKhoanBindingSource.Count == 0)
                {
                    MessageUtil.ShowErrorMsgDialog("Không thể xem báo cáo vì danh sách tài khoản rỗng");
                    return;
                }
                if (dpDateFrom.DateTime >= dpDateTo.DateTime)
                {
                    MessageUtil.ShowErrorMsgDialog("Chọn ngày không hợp lệ");
                    return;
                }

                string accountId = ((DataRowView)taiKhoanBindingSource[taiKhoanBindingSource.Position])["SOTK"].ToString();
                MessageUtil.ShowErrorMsgDialog(accountId);
                ReportSaoKe report = new ReportSaoKe(accountId, dpDateFrom.DateTime, dpDateTo.DateTime);
                ReportPrintTool printTool = new ReportPrintTool(report);
                printTool.ShowPreviewDialog();
                return;
            }
            catch (System.Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog("Tài khoản không có giao dịch ");
                return;
            }

        }

        private void cbBrand_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            // Nếu combobox chi nhánh chưa load danh sách phân mãnh thì thoát
            if (cbBrand.SelectedValue.ToString().Equals("System.Data.RowView"))
                return;
            string serverName = cbBrand.SelectedValue.ToString();
            User user = SecurityContext.User;
            if (cbBrand.SelectedIndex != user.BrandIndex)
                Program.SetServerToRemote(serverName);
            else
                Program.SetServerToSubcriber(serverName, user.Login, user.Pass);
            if (Program.CheckConnection() == false)
            {
                MessageUtil.ShowErrorMsgDialog("Lỗi kết nối sang chi nhánh mới.");
                return;
            }
            // Tải dữ liệu từ site mới về
            this.taiKhoanTableAdapter.Connection.ConnectionString = Program.ConnectionStr;
            this.taiKhoanTableAdapter.Fill(this.DS.TaiKhoan);
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}