
using NganHangPhanTan.DTO;
using NganHangPhanTan.Util;
using System;
using System.Data;
using System.Windows.Forms;

namespace NganHangPhanTan.SimpleForm
{
    public partial class fTaoLogin : DevExpress.XtraEditors.XtraForm
    {
        public fTaoLogin()
        {
            InitializeComponent();
        }

        private void Reload()
        {
            this.usp_LayNhanVienKhongCoTKTableAdapter.Connection.ConnectionString = Program.ConnectionStr;
            this.usp_LayNhanVienKhongCoTKTableAdapter.Fill(this.DS.usp_LayNhanVienKhongCoTK);

            if (bdsLayNhanVienKTK.Count > 0)
            {
                lbHeader.Text = "Chọn nhân viên để tạo tài khoản đăng nhập hệ thống:";
                pnInput.Enabled = gcLayNVKoTk.Enabled = true;
            }
            else
            {
                lbHeader.Text = "Hiện tất cả nhân viên trong chi nhánh đã có tài khoản đăng nhập.";
                pnInput.Enabled = gcLayNVKoTk.Enabled = false;
            }

            txbLoginName.Clear();
            txbPass.Clear();
        }

        private void fCreateLogin_Load(object sender, EventArgs e)
        {
            Reload();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginName = txbLoginName.Text.Trim();
            if (string.IsNullOrEmpty(loginName))
            {
                MessageUtil.ShowErrorMsgDialog("Tên đăng nhập hợp lệ");
                txbLoginName.Focus();
                return;
            }

            string pass = txbPass.Text.Trim();
            if (string.IsNullOrEmpty(pass))
            {
                MessageUtil.ShowErrorMsgDialog("Mật khẩu không hợp lệ");
                txbPass.Focus();
                return;
            }

            string NhanVienId = (((DataRowView)bdsLayNhanVienKTK[bdsLayNhanVienKTK.Position])[NhanVien.MANV_HEADER]).ToString();

            string query = "EXEC dbo.usp_CreateNewLogin @LoginName, @MaNV, @Pass, @Role";
            int res = Program.ExecuteNonQuery(query, new object[] {loginName, NhanVienId, pass, SecurityContext.User.GetGroupName()});
            if (res == -1)
            {
                MessageUtil.ShowInfoMsgDialog("Tạo tài khoản hệ thống thành công");
                Reload();
            }
        }
    }
}