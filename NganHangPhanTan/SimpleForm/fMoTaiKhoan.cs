using DevExpress.XtraGrid.Views.Grid;
using NganHangPhanTan.DTO;
using NganHangPhanTan.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NganHangPhanTan.SimpleForm
{
    public partial class fMoTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
       
  

        public fMoTaiKhoan()
        {
            InitializeComponent();
        }

        private void fOpenKhachHangAccount_Load(object sender, System.EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.taiKhoanTableAdapter.Connection.ConnectionString = Program.ConnectionStr;
            this.taiKhoanTableAdapter.Fill(this.DS.TaiKhoan);

            // TODO: This line of code loads data into the 'DS.GD_CHUYENTIEN' table. You can move, or remove it, as needed.
            this.gD_CHUYENTIENTableAdapter.Fill(this.DS.GD_CHUYENTIEN);
            // TODO: This line of code loads data into the 'DS.GD_GOIRUT' table. You can move, or remove it, as needed.
            this.gD_GOIRUTTableAdapter.Fill(this.DS.GD_GOIRUT);
        
            cbBrand.DataSource = Program.bindingSource;/*sao chep bingding source tu form dang nhap*/
            cbBrand.DisplayMember = "TENCN";
            cbBrand.ValueMember = "TENSERVER";

            cbBrand.SelectedIndex = SecurityContext.User.BrandIndex;

            switch (SecurityContext.User.Group)
            {
                case DTO.User.GroupENM.NGAN_HANG:
                    cbBrand.Enabled = false;
                    btnInsert.Enabled = btnDelete.Enabled = false;
                    break;
                case DTO.User.GroupENM.CHI_NHANH:
                    cbBrand.Enabled = false;
                    btnInsert.Enabled = btnDelete.Enabled = true;

                  

                    // Tao cac cot cho data table luu du lieu
                 

                    break;
                default:
                    // DEBUG
                    throw new Exception("User group is unidentified");
            }

            btnKiemTra.Enabled = btnReload.Enabled = true;
            gCInput.Enabled = gCInput.Enabled = btnSave.Enabled = btnUndo.Enabled  = false;
      
        }


        

       
        

        private void cbBrand_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

       

   
  

        

        private void fOpenKhachHangAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
           
                e.Cancel = btnSave.Enabled;
            }
        }

       

       

       
     
       

           
     

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int gridPos = bdsTaiKhoan.Position;

            bdsTaiKhoan.AddNew();
            gCInput.Enabled = true;
            gcTaiKhoan.Enabled = false;
            edMaCn.Text = Program.MACNHT;
            edSoTK.Enabled = true;
            edSoTK.Focus();
            edNgayMoTK.Enabled = false;
            edNgayMoTK.Text = DateTime.Now.ToString("yyyy/MM/dd");

             btnInsert.Enabled = btnDelete.Enabled = btnReload.Enabled = false;
            gCInput.Enabled =  btnSave.Enabled = btnUndo.Enabled = true;
            btnUndo.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String soTK = ((DataRowView)bdsTaiKhoan[bdsTaiKhoan.Position])["SOTK"].ToString();
            if (gD_GOIRUTBindingSource.Count > 0)
            {
                MessageBox.Show("Không thể xóa tài khoản này vì đã có giao dịch gởi hoặc rút tiền", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (gD_CHUYENTIENBindingSource.Count > 0)
            {
                MessageBox.Show("Không thể xóa tài khoản này vì đã có giao dịch gởi hoặc rút tiền", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Program.CheckConnection()) return;

            if (MessageUtil.ShowWarnConfirmDialog($"Xác nhận xóa tài khoản mã số {soTK}?") == DialogResult.OK)
            {
                try
                {
                    soTK = ((DataRowView)bdsTaiKhoan[bdsTaiKhoan.Position])["SOTK"].ToString();
                    bdsTaiKhoan.RemoveCurrent();
                    this.taiKhoanTableAdapter.Connection.ConnectionString = Program.ConnectionStr;
                    this.taiKhoanTableAdapter.Update(this.DS.TaiKhoan);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình xóa nhân viên: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.taiKhoanTableAdapter.Fill(this.DS.TaiKhoan);
                    bdsTaiKhoan.Position = bdsTaiKhoan.Find("SOTK", soTK);
                }

                btnDelete.Enabled = (bdsTaiKhoan.Count > 0);



            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            int kiemtra;
            if (Regex.IsMatch(edCMND.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Chứng minh chỉ nhận số");
                edCMND.Text = "";
                edCMND.Focus();
                return;
            }
            else
            {

                kiemtra = Program.ExecSqlCheck("usp_KIEMTRAKHACHHANG", edCMND.Text);
                if (kiemtra == 0)
                {
                    MessageBox.Show("Chứng minh không tồn tại");
                    edCMND.Text = "";
                    edCMND.Focus();
                    return;
                }
            }

            if (Regex.IsMatch(edSoTK.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Số tài khoản chỉ nhận số");
                edSoTK.Text = "";
                edSoTK.Focus();
                return;
            }
            else
            {    
                if (Program.ExecSqlCheck("usp_KIEMTRASOTK", edSoTK.Text) == 1)
                {
                    MessageBox.Show("Số tài khoản đã tồn tại tồn tại");
                    edSoTK.Text = "";
                    edSoTK.Focus();
                    return;
                }
            }

            if (string.IsNullOrEmpty(edSoTK.Text))
            {
                MessageUtil.ShowErrorMsgDialog("Số dư không được để trống");
                edSoTK.Focus();
                return;
            }

            if (Int64.Parse(edSoDu.Text.ToString()) < 100000)
            {
                MessageBox.Show("Số dư phải lớn hơn 100000");
                edSoTK.Text = "";
                edSoDu.Focus();
                return;
            }
            if (!Program.CheckConnection()) return;

            if (MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào Database?", "Thông báo",
                       MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {


                //if (kiemtra == 2)
                //{
                //    // String sql = "EXEC dbo.sp_TaoTaiKhoanKhacChiNhanh " + soTk + ", " + cmnd + ", " + soDU + ", " + maCN + ", " + "'" + DateTime.ParseExact(edNgayMoTK.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd") + "'";
                //    // Console.WriteLine(sql);

                //    int ktThucthi = Program.ExecuteNonQuery(
                //     "EXEC dbo.sp_TaoTaiKhoanKhacChiNhanh @SOTK, @CMND, @SODU, @MACN ",
                //         new object[] { edSoTK.Text, edCMND.Text, edSoDu.Text, Program.LayChiNhanhHT() }
                //     );

                //    // Program.myReader = Program.ExecSqlDataReader(sql);
                //    if (ktThucthi > 0)
                //    {
                //        MessageBox.Show("Tạo tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        this.taiKhoanTableAdapter.Fill(this.DS.TaiKhoan);
                //    }
                //}
                //else
                //{

                    try
                    {
                        bdsTaiKhoan.EndEdit();
                        bdsTaiKhoan.ResetCurrentItem();
                        this.taiKhoanTableAdapter.Update(this.DS.TaiKhoan);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi tài khoản : " + ex.Message, "", MessageBoxButtons.OK);
                    }

                //}



            }


            gcTaiKhoan.Enabled = true;
            gCInput.Enabled = false;

            gc1.Enabled = true;
            btnInsert.Enabled = btnDelete.Enabled = btnReload.Enabled = true;
            btnSave.Enabled = false;

        }

        private void btnUndo_Click_1(object sender, EventArgs e)
        {
            bdsTaiKhoan.CancelEdit();

            gcTaiKhoan.Enabled = true;
            gc1.Enabled = true;
            gCInput.Enabled = false;

            btnReload.Enabled = btnInsert.Enabled = btnDelete.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled  = false;
        }

        private void kiemTraBtn_Click(object sender, EventArgs e)
        {
            int kiemtra;
            if (Regex.IsMatch(edCMND.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Chứng minh chỉ nhận số");
                edCMND.Text = "";
                edCMND.Focus();
                return;
            }
            else
            {

                kiemtra = Program.ExecSqlCheck("usp_KIEMTRAKHACHHANG", edCMND.Text);
                if (kiemtra == 0)
                {
                    MessageBox.Show("Chứng minh không tồn tại");
                    edCMND.Text = "";
                    edCMND.Focus();
                    return;
                }

            }

            if (Regex.IsMatch(edSoTK.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Số tài khoản chỉ nhận số");
                edSoTK.Text = "";
                edSoTK.Focus();
                return;
            }
            else
            {
                if (Program.ExecSqlCheck("usp_KIEMTRASOTK", edSoTK.Text) == 1)
                {
                    MessageBox.Show("Số tài khoản đã tồn tại tồn tại");
                    edSoTK.Text = "";
                    edSoTK.Focus();
                    return;
                }
            }

            MessageBox.Show("DỮ LIỆU ĐÚNG ");
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                taiKhoanTableAdapter.Fill(this.DS.TaiKhoan);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog(ex.Message);
                throw;
            }
        }
    }
}