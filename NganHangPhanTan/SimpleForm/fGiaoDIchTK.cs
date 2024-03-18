using DevExpress.XtraEditors;
using NganHangPhanTan.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NganHangPhanTan.SimpleForm
{
    public partial class fGiaoDIchTK : DevExpress.XtraEditors.XtraForm
    {   


      
        public fGiaoDIchTK()
        {
        
            InitializeComponent();
            panelChuyenTien.Enabled = panelRutGuiTien.Enabled = false ;
        }

  
  
    
        private void showTien()
        {
            String cmd = $"SELECT SODU FROM [DBO].[TAIKHOAN] WHERE SOTK = {edTaiKhoanGD.Text}";
            SqlDataReader dataReader = Program.ExecuteSqlDataReader(cmd);
            dataReader.Read();

            String tien = dataReader.GetValue(0).ToString().Substring(0, dataReader.GetValue(0).ToString().IndexOf("."));
            edSoDuHT.Text = tien;

        }

   
        private void kiemTraBtn_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(edTaiKhoanGD.Text))
            {
                MessageUtil.ShowErrorMsgDialog("Vui lòng nhập stk ");
                edTaiKhoanGD.Focus();
                return;
            }

            if (Regex.IsMatch(edTaiKhoanGD.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Số tài khoản chỉ nhận số");
                edTaiKhoanGD.Text = "";
                edTaiKhoanGD.Focus();
                return;
            }
            else
            {
                if (Program.ExecSqlCheck("usp_KIEMTRASOTK", edTaiKhoanGD.Text) == 0)
                {
                    MessageBox.Show("Số tài khoản không tồn tại tồn tại");
                    edTaiKhoanGD.Text = "";
                    edTaiKhoanGD.Focus();
                    return;
                }
                showTien();
                panelChuyenTien.Enabled = panelRutGuiTien.Enabled = true;
            }
        }

        private void fGiaoDIchTK_Load(object sender, EventArgs e)
        {

        }

        private void xacNhanChuyenGDBtn_Click(object sender, EventArgs e)
        {
            Console.Write("==============danh========" + edSoTaiKhoanNhan.Text);
            if (Regex.IsMatch(edSoTaiKhoanNhan.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Số tài khoản chỉ nhận số");
                edSoTaiKhoanNhan.Text = "";
                edSoTaiKhoanNhan.Focus();
                return;
            }
            else
            {
                if (Program.ExecSqlCheck("usp_KIEMTRASOTK", edSoTaiKhoanNhan.Text) == 0)
                {
                    MessageBox.Show("Số tài khoản không tồn tại tồn tại");
                    edSoTaiKhoanNhan.Text = "";
                    edSoTaiKhoanNhan.Focus();
                    return;
                }
            }
            if (Int64.Parse(edSoTienChuyen.Text) < 100000)
            {
                MessageBox.Show("Số tiền chuyển phải lớn hơn 100000");
                edSoTienChuyen.Text = "";
                edSoTienChuyen.Focus();
                return;
            }
            if (Int64.Parse(edSoTienChuyen.Text) > Int64.Parse(edSoDuHT.Text))
            {
                MessageBox.Show("Số tiền chuyển phải nhỏ hơn số tiền hiên tại");
                edSoTienChuyen.Text = "";
                edSoTienChuyen.Focus();
                return;
            }



            int ktThucthi = Program.ExecuteNonQuery(
            "EXEC dbo.usp_GiaoDichChuyenTien @SOTK_NHAN , @SOTK_CHUYEN , @SOTIEN , @MANV ",
                new object[] { edSoTaiKhoanNhan.Text, edTaiKhoanGD.Text.Trim(), edSoTienChuyen.Text, SecurityContext.User.Username }
           );

            if (ktThucthi > 0)
            {
                MessageBox.Show("Giao dịch thành công");
                showTien();
            }

        }

        private void xacNhanRutGDBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(edSoTien.Text))
            {
                MessageUtil.ShowErrorMsgDialog("Vui lòng nhập số tiền ");
                edTaiKhoanGD.Focus();
                return;
            }

            if (Int64.Parse(edSoTien.Text) < 100000)
            {
                MessageBox.Show("Số tiền rút phải lớn hơn 100000");
                edSoTien.Text = "";
                edSoTien.Focus();
                return;
            }
            if (Int64.Parse(edSoTien.Text) > Int64.Parse(edSoDuHT.Text))
            {
                MessageBox.Show("Chê");
                edSoTien.Text = "";
                edSoTien.Focus();
                return;
            }


            int ktThucthi = Program.ExecuteNonQuery(
              "EXEC dbo.usp_GiaoDichGuiRut @TYPE , @SOTIEN , @SOTK , @MANV ",
                  new object[] { "RT", edSoTien.Text, edTaiKhoanGD.Text, SecurityContext.User.Username }
             );

            if (ktThucthi > 0)
            {
                MessageBox.Show("Giao dịch thành công");
                showTien();
            }

        }

        private void xacNhanGuiTxt_Click(object sender, EventArgs e)
        {
            if (Int64.Parse(edSoTien.Text) < 100000)
            {
                MessageBox.Show("Số tiền gửi phải lớn hơn 100000");
                edSoTien.Text = "";
                edSoTien.Focus();
                return;
            }

            int ktThucthi = Program.ExecuteNonQuery(
              "EXEC dbo.usp_GiaoDichGuiRut @TYPE , @SOTIEN , @SOTK , @MANV ",
                  new object[] { "GT", edSoTien.Text, edTaiKhoanGD.Text, SecurityContext.User.Username }
             );

            if (ktThucthi > 0)
            {
                MessageBox.Show("Giao dịch thành công");
                showTien();
            }
        }
    }
}