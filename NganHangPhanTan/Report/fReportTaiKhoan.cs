using DevExpress.XtraReports.UI;
using NganHangPhanTan.DTO;
using NganHangPhanTan.Util;
using System;

namespace NganHangPhanTan.Report
{
    public partial class fReportTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        public fReportTaiKhoan()
        {
            InitializeComponent();
           
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
        }

        private void fReportOpenedAccount_Load(object sender, System.EventArgs e)
        {
            cbBrand.DataSource = Program.bindingSource;/*sao chep bingding source tu form dang nhap*/
            cbBrand.DisplayMember = "TENCN";
            cbBrand.ValueMember = "TENSERVER";
            cbBrand.SelectedIndex = SecurityContext.User.BrandIndex;

            dpDateFrom.DateTime = dpDateTo.DateTime = DateTime.Now;
            rbtChooseBrand.Checked = true;

            //switch (SecurityContext.User.Group)
            //{
            //    case DTO.User.GroupENM.NGAN_HANG:
            //        cbBrand.Enabled = true;
            //        break;
            //    case DTO.User.GroupENM.CHI_NHANH:
            //        cbBrand.Enabled = false;
            //        cbBrand.SelectedIndex = SecurityContext.User.BrandIndex;
            //        rbtBrandAll.Enabled = false;
            //        break;
            //    default:
            //        // DEBUG
            //        throw new Exception("User group is unidentified");
            //}

            //cbBrand_SelectionChangeCommitted(null, null);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dpDateFrom.DateTime > dpDateTo.DateTime)
                {
                    MessageUtil.ShowErrorMsgDialog("Chọn ngày không hợp lệ");
                    return;
                }
                string MACN;
                if (cbBrand.Text.Equals("CN_BENTHANH"))
                    MACN = "BENTHANH";
                else
                    MACN = "TANDINH";


                if (rbtChooseBrand.Checked)
                {
                    ReportMoTaiKhoanChiNhanh2 report  = new ReportMoTaiKhoanChiNhanh2(dpDateFrom.DateTime, dpDateTo.DateTime, MACN);
                    ReportPrintTool printTool = new ReportPrintTool(report);
                    printTool.ShowPreviewDialog();
                } else
                {
                    ReportMoTaiKhoanTatCaChiNhanh  report = new ReportMoTaiKhoanTatCaChiNhanh(dpDateFrom.DateTime, dpDateTo.DateTime);
                    ReportPrintTool printTool = new ReportPrintTool(report);
                    printTool.ShowPreviewDialog();
                }
            }
            catch (System.Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog(ex.Message);
                throw ex;
            }
        }

        private void rbtChooseBrand_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtChooseBrand.Checked)
                cbBrand.Enabled = true;
            else
                cbBrand.Enabled = false;
        }
    }
}