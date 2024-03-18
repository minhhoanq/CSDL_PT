
using NganHangPhanTan.DTO;
using NganHangPhanTan.Util;
using System;
using System.Data;

using System.Windows.Forms;

namespace NganHangPhanTan.SimpleForm
{
    public partial class fNhanVienMove : DevExpress.XtraEditors.XtraForm
    {   
        private string NhanVienId;
        public fNhanVienMove(string NhanVienId)
        {
            InitializeComponent();
            this.NhanVienId = NhanVienId.Trim();
        }

 

        private void btnMove_Click(object sender, EventArgs e)
        {
            string selectedBrandId = ((DataRowView)bdsLayDsChiNhanhKhac[bdsLayDsChiNhanhKhac.Position])["MACN"].ToString();
            // Kiểm tra các ràng buộc
            string NhanVienIDNEW = txbId.Text.Trim();
            if (string.IsNullOrEmpty(NhanVienIDNEW))
            {
                MessageUtil.ShowErrorMsgDialog("Mã nhân viên không được để trống.");
                txbId.Focus();
                return;
            }

            if (NhanVienIDNEW.Contains(" "))
            {
                MessageUtil.ShowErrorMsgDialog("Mã nhân viên không hợp lệ");
                txbId.Focus();
                return;
            }

            if (NhanVienIDNEW.Length > 10)
            {
                MessageUtil.ShowErrorMsgDialog("Mã nhân viên không được vượt quá 10 kí tự");
                txbId.Focus();
                return;
            }

            // Kiểm tra mã nhân viên tồn tại trên site chủ
            if (Program.kiemTraNhanVienTonTai(NhanVienIDNEW)==1)
            {
                MessageUtil.ShowErrorMsgDialog("Mã nhân viên đã tồn tại. Vui lòng chọn mã khác");
                txbId.Focus();
                return;
            }

            NhanVienIDNEW = NhanVienIDNEW.ToUpper();
            txbId.Text = NhanVienIDNEW;


            if (MessageUtil.ShowWarnConfirmDialog("Xác nhận chuyển nhân viên?") == DialogResult.OK)
            {
                string query = "EXEC dbo.usp_DiChuyenNV2 @MANV, @MACN, @NEWMANV";
                int kt = Program.ExecuteNonQuery2(query, new object[] { NhanVienId, selectedBrandId, NhanVienIDNEW });
                if (kt == 0)
                {
                    MessageUtil.ShowInfoMsgDialog("Chuyển nhân viên thành công");
                    Close();
                    // Reload
                    User user = SecurityContext.User;
                    Program.SetServerToSubcriber(Program.serverName, user.Login, user.Pass);
                    if (Program.CheckConnection() == false) return;

                    
                }
            }

        }

        private void fNhanVienMove_Load(object sender, EventArgs e)
        {
            Program.SetServerToDistributor(Program.serverName);
            if (Program.CheckConnection() == false) return;

            this.usp_LayDsChiNhanhKhacTableAdapter.Connection.ConnectionString = Program.ConnectionStr;
            this.usp_LayDsChiNhanhKhacTableAdapter.Fill(this.dS.usp_LayDsChiNhanhKhac);
       
            btnMove.Enabled = bdsLayDsChiNhanhKhac.Count > 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}