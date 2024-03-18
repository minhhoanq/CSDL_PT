
using NganHangPhanTan.DTO;
using NganHangPhanTan.Report;
using NganHangPhanTan.SimpleForm;
using NganHangPhanTan.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NganHangPhanTan
{
    public partial class fMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
       

        public fMain()
        {
            InitializeComponent();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            btnCreateLogin.Enabled = btnLogout.Enabled = true;
            ribCategory.Visible = ribService.Visible = ribReport.Visible = true;

            User user = SecurityContext.User;
            if (user == null) return;

            // Update status bar
            tssNhanVienID.Text = $"Mã nhân viên: {user.Username}";
            tssNhanVienName.Text = $"Họ tên: {user.Fullname}";
            tssNhanVienGroup.Text = $"Nhóm: {user.GetGroupName()}";
        }

        //public void UpdateUserInfo()
        //{
        //    User user = SecurityContext.User;
        //    if (user == null) return;

        //    // Update status bar
        //    tssNhanVienID.Text = $"Mãaaaa nhân viên: {user.Username}";
        //    tssNhanVienName.Text = $"Họ tên: {user.Fullname}";
        //    tssNhanVienGroup.Text = $"Nhóm: {user.GetGroupName()}";

        //    btnLogin.Enabled = false;
        //    btnCreateLogin.Enabled = btnLogout.Enabled = true;

        //    ribCategory.Visible = ribService.Visible = ribReport.Visible = true;
        //}


        private void CreateAndShowLoginForm()
        {
            fLogin f = new fLogin
            {
                MdiParent = this
            };
            f.Show();
        }


        //private void btnLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Form form = ControlUtil.CheckFormExists(this, typeof(fLogin));
        //    if (form != null)
        //        form.Activate();
        //    else
        //        CreateAndShowLoginForm();
        //}

        private void btnManageNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fNhanVien));
            if (form != null)
                form.Activate();
            else
            {
                fNhanVien f = new fNhanVien()
                {
                    MdiParent = this,
               
                };
                f.Show();
               
            }


          
        }

        private void btnKhachHangManage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fKhachHang));
            if (form != null)
                form.Activate();
            else
            {
                fKhachHang f = new fKhachHang()
                {
                    MdiParent = this,


                };
                f.Show();

            }
        }

        private void btnLogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (MessageUtil.ShowWarnConfirmDialog("Xác nhận đăng xuất?") == DialogResult.OK)
            {
                //foreach (Form form in MdiChildren)
                //{
                //    form.Close();
                //}

                foreach (Form f in this.MdiChildren)
                    f.Dispose();

                //CreateAndShowLoginForm();

                SecurityContext.ClearUser();

                // Clear user info in status bar
                tssNhanVienID.Text = "Mã nhân viên: trống";
                tssNhanVienName.Text = "Họ tên: trống";
                tssNhanVienGroup.Text = "Nhóm: trống";

                btnLogin.Enabled = true;
                btnCreateLogin.Enabled = btnLogout.Enabled = false;
                ribCategory.Visible = ribService.Visible = ribReport.Visible = false;
                Form form2 = ControlUtil.CheckFormExists(this, typeof(fLogin));
                if (form2 != null)
                    form2.Activate();
                else
                    CreateAndShowLoginForm();
            }
        }
    
        private void btnCreateAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fTaoLogin));
            if (form != null)
                form.Activate();
            else
            {
                fTaoLogin f = new fTaoLogin()
                {
                    MdiParent = this,
                };
                f.Show();
              
            }
        }

        private void btnCreateLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fTaoLogin));
            if (form != null)
                form.Activate();
            else
            {
                fTaoLogin f = new fTaoLogin()
                {
                    MdiParent = this,
                };
                f.Show();
            
            }
        }

        private void btnGuiRutChuyenTien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fGiaoDIchTK));
            if (form != null)
                form.Activate();
            else
            {
                fGiaoDIchTK f = new fGiaoDIchTK()
                {
                    MdiParent = this,
                };

                f.Show();

            }
        }

        private void btnMoTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fMoTaiKhoan));
            if (form != null)
                form.Activate();
            else
            {
                fMoTaiKhoan f = new fMoTaiKhoan()
                {
                    MdiParent = this,

                };
                f.Show();

            }
        }

        private void btnThongKeKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fReportKhachHang));
            if (form != null)
                form.Activate();
            else
            {
                fReportKhachHang f = new fReportKhachHang()
                {
                    MdiParent = this,
                };
                f.Show();

            }
        }

        private void btnThongKeTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fReportTaiKhoan));
            if (form != null)
                form.Activate();
            else
            {
                fReportTaiKhoan f = new fReportTaiKhoan()
                {
                    MdiParent = this,
                };
                f.Show();
            }
        }

        private void btnSaoKe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fReportSaoKe));
            if (form != null)
                form.Activate();
            else
            {
                fReportSaoKe f = new fReportSaoKe()
                {
                    MdiParent = this,
                };
                f.Show();

            }
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageUtil.ShowInfoConfirmDialog("Xác nhận thoátt chương trình?") == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

        }
    }
}
