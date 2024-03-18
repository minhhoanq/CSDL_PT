
using NganHangPhanTan.DTO;
using NganHangPhanTan.Util;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Principal;
using System.Windows.Forms;

namespace NganHangPhanTan
{
    public partial class fLogin : DevExpress.XtraEditors.XtraForm
    {
        private Action changeUserInfo;
        private fMain frmChinh = new fMain();

        public Action ChangeUserInfo { get => changeUserInfo; set => changeUserInfo = value; }

        private SqlConnection connPublisher = new SqlConnection();

        public fLogin()
        {
            InitializeComponent();
        }

        private void fLogin_Load(object sender, System.EventArgs e)
        {
            // Load danh sách phân mãnh vào combobox

            if (KetNoiDatabaseGoc() == 0)
                return;

            layDanhSachPhanManh("SELECT * FROM dbo.v_GetSubcribers");
            txbLoginName.Focus();
        }
       
        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            string loginName = txbLoginName.Text.Trim();
            if (string.IsNullOrEmpty(loginName))
            {
                MessageUtil.ShowErrorMsgDialog("Mã nhân viên không được trống");
                return;
            }

            string pass = txbPass.Text.Trim();
            if (string.IsNullOrEmpty(pass))
            {
                MessageUtil.ShowErrorMsgDialog("Mật khẩu không được trống");
                return;
            }

            string serverName = cbBrand.SelectedValue.ToString();
            Program.serverName = serverName;
            Program.SetServerToSubcriber(serverName, loginName, pass);


            if (Program.CheckConnection() == false)
                return;

            Program.MACNHT = Program.LayChiNhanhHT().Trim();
            User user = Program.Login(loginName);
            if (user != null)
            {
                user.Login = loginName;
                user.Pass = pass;
                user.BrandIndex = cbBrand.SelectedIndex;
                SecurityContext.User = user;
                //frmChinh.UpdateUserInfo();
                //ChangeUserInfo.Invoke();
                //Close();
                Program.frmChinh = new fMain();
                Program.frmChinh.Activate();
                Program.frmChinh.Show();
                this.Visible = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        private int KetNoiDatabaseGoc()
        {
            if (connPublisher != null && connPublisher.State == ConnectionState.Open)
                connPublisher.Close();
            try
            {
                connPublisher.ConnectionString = Program.connstrPublisher;
                connPublisher.Open();
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        private void layDanhSachPhanManh(String cmd)
        {
            if (connPublisher.State == ConnectionState.Closed)
            {
                connPublisher.Open();
            }
            DataTable dt = new DataTable();
            // adapter dùng để đưa dữ liệu từ view sang database
            SqlDataAdapter da = new SqlDataAdapter(cmd, connPublisher);
            // dùng adapter thì mới đổ vào data table được
            da.Fill(dt);


            connPublisher.Close();
            Program.bindingSource.DataSource = dt;


            cbBrand.DataSource = Program.bindingSource;
            cbBrand.DisplayMember = "TENCN";
            cbBrand.ValueMember = "TENSERVER";
        }

    }
}