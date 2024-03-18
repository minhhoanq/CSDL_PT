using DevExpress.XtraGrid.Views.Grid;
using NganHangPhanTan.DTO;
using NganHangPhanTan.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NganHangPhanTan.SimpleForm
{
    public partial class fKhachHang : DevExpress.XtraEditors.XtraForm
    {

        private LinkedList<UserEventData> undoStack = new LinkedList<UserEventData>();
        private LinkedList<UserEventData> redoStack = new LinkedList<UserEventData>();


        public fKhachHang()
        {
            InitializeComponent();
        }

        private void fKhachHangManage_Load(object sender, EventArgs e)
        {

            DS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.KhachHang' table. You can move, or remove it, as needed.
            this.taKhachHang.Connection.ConnectionString = Program.ConnectionStr;
            this.taKhachHang.Fill(this.DS.KhachHang);

            // TODO: This line of code loads data into the 'DS.TaiKhoan' table. You can move, or remove it, as needed.
            this.taTaiKhoan.Connection.ConnectionString = Program.ConnectionStr;
            this.taTaiKhoan.Fill(this.DS.TaiKhoan);



            cbBrand.DataSource = Program.bindingSource;
            cbBrand.DisplayMember = "TENCN";
            cbBrand.ValueMember = "TENSERVER";

            cbBrand.SelectedIndex = SecurityContext.User.BrandIndex;

            switch (SecurityContext.User.Group)
            {
                case DTO.User.GroupENM.NGAN_HANG:
                    cbBrand.Enabled = true;
                    btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = false;
                    break;
                case DTO.User.GroupENM.CHI_NHANH:
                    cbBrand.Enabled = false;
                    btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = true;
                    break;
                default:
                    // DEBUG
                    throw new Exception("User group is unidentified");
            }
            btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled = btnRedo.Enabled = false;
            pnInput.Enabled = false;
            txbId.Enabled = false;

            
        }
        
       


        private void UndoUnSaveAction(UserEventData action)
        {
            bdsKhachHang.CancelEdit();

            if (btnSave.Tag == btnInsert)
            {
                bdsKhachHang.Position = action.GridPos;
                bdsKhachHang.RemoveAt(bdsKhachHang.Count - 1);
            }

            gcKhachHang.Enabled = true;
            pnInput.Enabled = false;
            btnInsert.Enabled = btnUpdate.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = false;
            txbId.Enabled = false;
            btnUndo.Enabled = undoStack.Count > 0;

            btnSave.Tag = null;

            btnDelete.Enabled = bdsKhachHang.Count > 0;

       

            btnRedo.Enabled = redoStack.Count > 0;
        }

        private bool UndoByInsertAction(UserEventData action)
        {
            if (action == null)
                throw new Exception();

            bdsKhachHang.AddNew();

            txbBrandId.Text = Program.MACNHT;

            KhachHang KhachHang = (KhachHang)action.Content;
            txbId.Text = KhachHang.Cmnd;
            txbLastName.Text = KhachHang.Ho;
            txbFirstName.Text = KhachHang.Ten;
            txbAddress.Text = KhachHang.DiaChi;
            txbPhoneNum.Text = KhachHang.SoDT;
            cbGender.SelectedItem = KhachHang.Phai;
            deDateAccept.DateTime = KhachHang.NgayCapKhach;

            cbGender.DataBindings[0].WriteValue();
            deDateAccept.DataBindings[0].WriteValue();


            try
            {
                // Lưu thông tin trên binding source
                bdsKhachHang.EndEdit();
                // Đặt thông tin nhân viên mới lên grid control
                bdsKhachHang.ResetCurrentItem();
                taKhachHang.Update(this.DS.KhachHang);
                taKhachHang.Fill(this.DS.KhachHang);
                bdsKhachHang.Position = bdsKhachHang.Find(KhachHang.CMND_HEADER, KhachHang.Cmnd);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog($"Lỗi không thể khôi phục khách hàng đã xóa có số CMND là {KhachHang.Cmnd}, thử thực hiện lại.\nChi tiết: {ex.Message}");
                return false;
            }
            return true;
        }

        private int UndoByDeleteAction(UserEventData action)
        {
            KhachHang KhachHang = (KhachHang)action.Content;
            bdsKhachHang.Position = bdsKhachHang.Find(KhachHang.CMND_HEADER, KhachHang.Cmnd);

            if (bdsTaiKhoan.Count > 0)
            {
                MessageUtil.ShowErrorMsgDialog("Không thể xóa khách hàng đã có tài khoản. Vui lòng thực hiện xóa tài khoản trước.\n");
                return 0;
            }

            if (MessageUtil.ShowWarnConfirmDialog($"Xác nhận xóa khách hàng có số CMND {KhachHang.Cmnd}?") != DialogResult.OK)
                return 0;

            try
            {
                // Xóa trên máy trước
                bdsKhachHang.RemoveCurrent();
                // Xóa trên server
                taKhachHang.Update(this.DS.KhachHang);
            }
            catch (Exception ex)
            {
                // Phục hồi nếu xóa không thành công
                MessageUtil.ShowErrorMsgDialog($"Lỗi không thể xóa khách hàng, vui lòng thực hiện lại.\nChi tiết: {ex.Message}");
                taKhachHang.Fill(this.DS.KhachHang);
                bdsKhachHang.Position = bdsKhachHang.Find(KhachHang.CMND_HEADER, KhachHang.Cmnd);
                return 0;
            }

            btnDelete.Enabled = bdsKhachHang.Count != 0;
            return 1;
        }

        private bool UndoByUpdateAction(UserEventData action)
        {
            KhachHang updatedKhachHang = (KhachHang)action.Content;

            bdsKhachHang.Position = bdsKhachHang.Find(KhachHang.CMND_HEADER, updatedKhachHang.Cmnd);

            txbLastName.Text = updatedKhachHang.Ho;
            txbFirstName.Text = updatedKhachHang.Ten;
            txbAddress.Text = updatedKhachHang.DiaChi;
            txbPhoneNum.Text = updatedKhachHang.SoDT;
            cbGender.SelectedItem = updatedKhachHang.Phai;
            deDateAccept.DateTime = updatedKhachHang.NgayCapKhach;

            cbGender.DataBindings[0].WriteValue();
            deDateAccept.DataBindings[0].WriteValue();

            try
            {
                // Lưu thông tin trên binding source
                bdsKhachHang.EndEdit();
                // Đặt thông tin nhân viên mới lên grid control
                bdsKhachHang.ResetCurrentItem();
                taKhachHang.Update(this.DS.KhachHang);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog($"Lỗi không thể hiệu chỉnh khách hàng, thử thực hiện lại.\nChi tiết: {ex.Message}");
                return false;
            }

            return true;
        }


        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (undoStack.Count > 0)
            {
                UserEventData action = undoStack.Last();
                undoStack.RemoveLast();
                switch (action.Type)
                {
                    case UserEventData.EventType.CANCEL_EDIT:
                        {
                            UndoUnSaveAction(action);
                            break;
                        }
                    case UserEventData.EventType.INSERT:
                        {
                            int gridPos = bdsKhachHang.Position;
                            if (UndoByInsertAction(action))
                            {
                                action.Type = UserEventData.EventType.DELETE;
                                action.GridPos = gridPos;
                                redoStack.AddLast(action);
                            }
                            else
                            {
                                undoStack.AddLast(action);
                            }
                            break;
                        }
                    case UserEventData.EventType.DELETE:
                        {
                            int res = UndoByDeleteAction(action);
                            if (res == 1)
                            {
                                action.Type = UserEventData.EventType.INSERT;
                                redoStack.AddLast(action);
                                bdsKhachHang.Position = action.GridPos;
                            }
                            else if (res == 0)
                            {
                                undoStack.AddLast(action);
                            }
                            break;
                        }
                    case UserEventData.EventType.UPDATE:
                        {
                            KhachHang oldKhachHang = new KhachHang((DataRowView)bdsKhachHang[bdsKhachHang.Find(KhachHang.CMND_HEADER, ((KhachHang)action.Content).Cmnd)]);
                            if (UndoByUpdateAction(action))
                            {
                                action.Type = UserEventData.EventType.UPDATE;
                                action.Content = oldKhachHang;
                                redoStack.AddLast(action);
                            }
                            else
                            {
                                undoStack.AddLast(action);
                            }
                            break;
                        }
                    default:
                        break;
                }
                btnRedo.Enabled = (redoStack.Count > 0);
            }
            btnUndo.Enabled = (undoStack.Count > 0);
        }

        private void btnRedo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (redoStack.Count > 0)
            {
                UserEventData action = redoStack.Last();
                redoStack.RemoveLast();
                switch (action.Type)
                {
                    case UserEventData.EventType.INSERT:
                        {
                            int gridPos = bdsKhachHang.Position;
                            if (UndoByInsertAction(action))
                            {
                                action.Type = UserEventData.EventType.DELETE;
                                action.GridPos = gridPos;
                                undoStack.AddLast(action);
                            }
                            else
                            {
                                redoStack.AddLast(action);
                            }
                            break;
                        }
                    case UserEventData.EventType.DELETE:
                        {
                            int res = UndoByDeleteAction(action);
                            if (res == 1)
                            {
                                action.Type = UserEventData.EventType.INSERT;
                                undoStack.AddLast(action);
                                bdsKhachHang.Position = action.GridPos;
                            }
                            else if (res == 0)
                            {
                                redoStack.AddLast(action);
                            }
                            break;
                        }
                    case UserEventData.EventType.UPDATE:
                        {
                            KhachHang oldKhachHang = new KhachHang(((DataRowView)bdsKhachHang[bdsKhachHang.Find(KhachHang.CMND_HEADER, ((KhachHang)action.Content).Cmnd)]));
                            if (UndoByUpdateAction(action))
                            {
                                action.Type = UserEventData.EventType.UPDATE;
                                action.Content = oldKhachHang;
                                undoStack.AddLast(action);
                            }
                            else
                            {
                                redoStack.AddLast(action);
                            }
                            break;
                        }
                    default:
                        break;
                }
                btnUndo.Enabled = (undoStack.Count > 0);
            }
            btnRedo.Enabled = (redoStack.Count > 0);
        }




        //cac nut insert update delete
        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int gridPos = bdsKhachHang.Position;

            bdsKhachHang.AddNew();

            pnInput.Enabled = true;
            gcKhachHang.Enabled = false;
            txbBrandId.Text = Program.MACNHT;
            cbGender.SelectedIndex = 0;
            txbId.Enabled = true;
            txbId.Focus();
            btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            btnRedo.Enabled = false;

            btnSave.Tag = btnInsert;

            // Push cancel-editing event to undo stack
            undoStack.AddLast(new UserEventData(UserEventData.EventType.CANCEL_EDIT, null, gridPos));
            btnUndo.Enabled = true;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string KhachHangId = ((DataRowView)bdsKhachHang[bdsKhachHang.Position])[KhachHang.CMND_HEADER].ToString();
            if (bdsTaiKhoan.Count>0)
            {
                MessageUtil.ShowErrorMsgDialog("Không thể xóa khách hàng đã có tài khoản. Vui lòng thực hiện xóa tài khoản trước.\n");
                return;
            }

            if (MessageUtil.ShowWarnConfirmDialog($"Xác nhận xóa khách hàng có số CMND {KhachHangId}?") == DialogResult.OK)
            {
                string deletedKhachHangId = ((DataRowView)bdsKhachHang[bdsKhachHang.Position])[KhachHang.CMND_HEADER].ToString();
                KhachHang deletedKhachHang;
                try
                {
                    deletedKhachHang = new KhachHang((DataRowView)bdsKhachHang[bdsKhachHang.Position]);
                    // Xóa trên máy trước
                    bdsKhachHang.RemoveCurrent();
                    // Xóa trên server
                    taKhachHang.Update(this.DS.KhachHang);
                }
                catch (Exception ex)
                {
                    // Phục hồi nếu xóa không thành công
                    MessageUtil.ShowErrorMsgDialog($"Lỗi không thể xóa khách hàng. Thử thực hiện lại.\n{ex.Message}");
                    taKhachHang.Fill(this.DS.KhachHang);
                    bdsKhachHang.Position = bdsKhachHang.Find(KhachHang.CMND_HEADER, deletedKhachHangId);
                    return;
                }

                btnDelete.Enabled = bdsKhachHang.Count != 0;

                // Ignore save grid pos
                undoStack.AddLast(new UserEventData(UserEventData.EventType.INSERT, deletedKhachHang, -1));
                btnUndo.Enabled = true;
                ControlUtil.ResolveStackStorage(undoStack);
                redoStack.Clear();
                btnRedo.Enabled = false;
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhachHang oldKhachHang = null;
            string KhachHangId = "";

            if (btnSave.Tag == btnUpdate)
            {
                oldKhachHang = new KhachHang((DataRowView)bdsKhachHang[bdsKhachHang.Position]);
            }
            else
            {
                // Chỉ kiểm tra mã KH khi INSERT
                KhachHangId = txbId.Text.Trim();
                if (string.IsNullOrEmpty(KhachHangId))
                {
                    MessageUtil.ShowErrorMsgDialog("Mã khách hàng (CMND) không được để trống");
                    txbId.Focus();
                    return;
                }

                if (KhachHangId.Contains(" ") || !Regex.Match(KhachHangId, "\\d{10}").Success)
                {
                    MessageUtil.ShowErrorMsgDialog("Mã khách hàng (CMND) không hợp lệ hoặc chưa đủ 10 chữ số");
                    txbId.Focus();
                    return;
                }

                // Kiểm tra mã KH (CMND) đã tồn tại trong bảng KHACHHANG trên site chủ
                // Vì 1 khách hàng chỉ đăng ký thuộc 1 chi nhánh duy nhất
                if (Program.kiemTraKhachHangTonTai(KhachHangId)>0)
                {
                    MessageUtil.ShowErrorMsgDialog("Lỗi không thể thêm vì khách hàng đã đăng ký chi nhánh khác.");
                    txbId.Focus();
                    return;
                }

                KhachHangId = KhachHangId.ToUpper();
                txbId.Text = KhachHangId;
            }

            string lastName = txbLastName.Text.Trim();
            if (string.IsNullOrEmpty(lastName))
            {
                MessageUtil.ShowErrorMsgDialog("Họ tên khách hàng không được để trống");
                txbLastName.Focus();
                return;
            }

            lastName = ControlUtil.RemoveDuplicateSpace(lastName);
            lastName = ControlUtil.CapitalizeFirstLetter(lastName);
            txbLastName.Text = lastName;

            string firstName = txbFirstName.Text.Trim();
            if (string.IsNullOrEmpty(firstName))
            {
                MessageUtil.ShowErrorMsgDialog("Họ tên khách hàng không được để trống");
                txbFirstName.Focus();
                return;
            }

            if (firstName.Contains(" "))
            {
                MessageUtil.ShowErrorMsgDialog("Tên khách hàng không hợp lệ");
                txbFirstName.Focus();
                return;
            }

            firstName = ControlUtil.CapitalizeFirstLetter(firstName);
            txbFirstName.Text = firstName;

            string address = txbAddress.Text.Trim();
            if (string.IsNullOrEmpty(address))
            {
                MessageUtil.ShowErrorMsgDialog("Địa chỉ khách hàng không được để trống");
                txbAddress.Focus();
                return;
            }

            address = ControlUtil.RemoveDuplicateSpace(address);
            txbAddress.Text = address;

            string phoneNum = txbPhoneNum.Text.Trim();
            if (string.IsNullOrEmpty(phoneNum))
            {
                MessageUtil.ShowErrorMsgDialog("Số điện thoại khách hàng không được để trống");
                txbPhoneNum.Focus();
                return;
            }

            if (!phoneNum.All(Char.IsDigit))
            {
                MessageUtil.ShowErrorMsgDialog("Số điện thoại khách hàng không hợp lệ");
                txbPhoneNum.Focus();
                return;
            }

            if (phoneNum.Length != 10)
            {
                MessageUtil.ShowErrorMsgDialog("Số điện thoại khách hàng không đúng 10 chữ số");
                txbPhoneNum.Focus();
                return;
            }

            txbPhoneNum.Text = phoneNum;

            if (deDateAccept.DateTime > DateTime.Now)
            {
                MessageUtil.ShowErrorMsgDialog("Ngày cấp CMND khách hàng không hợp lệ");
                deDateAccept.Focus();
                return;
            }

            cbGender.DataBindings[0].WriteValue();
            deDateAccept.DataBindings[0].WriteValue();

            try
            {
                // Lưu thông tin trên binding source
                bdsKhachHang.EndEdit();
                // Đặt thông tin nhân viên mới lên grid control
                bdsKhachHang.ResetCurrentItem();
                taKhachHang.Update(this.DS.KhachHang);
                MessageUtil.ShowInfoMsgDialog("Ghi thành công");
            }
            catch (Exception ex)
            {
                string msg = btnSave.Tag == btnInsert ? "Lỗi không thể thêm khách hàng mới" : "Lỗi không thể hiệu chỉnh khách hàng";
                MessageUtil.ShowErrorMsgDialog($"{msg}.\n{ex.Message}");
                return;
            }






            // bat su kien undo
            if (btnSave.Tag == btnInsert)
            {
                taKhachHang.Fill(this.DS.KhachHang);
                bdsKhachHang.Position = bdsKhachHang.Find(KhachHang.CMND_HEADER, KhachHangId);
            }

            // xoa cancel trong stack undo
            UserEventData action = undoStack.Last();
            undoStack.RemoveLast();

            if (btnSave.Tag == btnInsert)
            {
                // Nếu INSERT, thêm vào undo stack DELETE action
                action.Type = UserEventData.EventType.DELETE;
                action.Content = new KhachHang((DataRowView)bdsKhachHang[bdsKhachHang.Position]);
                // Không cần lưu action.GridPos vì là DELETE action
            }
            else
            {
                // Nếu UPDATE, thêm vào undo stack UPDATE action
                action.Type = UserEventData.EventType.UPDATE;
                action.Content = oldKhachHang;
                // Không cần lưu action.GridPos vì không cần phục hồi gridPos khi UPDATE
            }

            undoStack.AddLast(action);
            ControlUtil.ResolveStackStorage(undoStack);



            btnUndo.Enabled = true;

            // Xóa redo stack
            redoStack.Clear();
            btnRedo.Enabled = false;

            gcKhachHang.Enabled = true;
            pnInput.Enabled = false;
            btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = false;
            txbId.Enabled = false;
            btnSave.Tag = null;


        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int gridPos = bdsKhachHang.Position;
            pnInput.Enabled = true;
            gcKhachHang.Enabled = false;
            btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            btnRedo.Enabled = false;
            btnSave.Tag = btnUpdate;


            undoStack.AddLast(new UserEventData(UserEventData.EventType.CANCEL_EDIT, null, gridPos));
            btnUndo.Enabled = true;
            ControlUtil.ResolveStackStorage(undoStack);
        }

      
        private void cbBrand_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbBrand.SelectedValue.ToString().Equals("System.Data.RowView"))
                return;
            string serverName = cbBrand.SelectedValue.ToString();
            User user = SecurityContext.User;
            if (cbBrand.SelectedIndex != user.BrandIndex)
                Program.SetServerToRemote(serverName);
            else
                Program.SetServerToSubcriber(serverName, user.Login, user.Pass);
            if (!Program.CheckConnection())
            {
                MessageUtil.ShowErrorMsgDialog("Lỗi kết nối sang chi nhánh mới");
                return;
            }

            // Tải dữ liệu từ site mới về
            taKhachHang.Connection.ConnectionString = Program.ConnectionStr;
            taKhachHang.Fill(this.DS.KhachHang);
        }


       

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                taKhachHang.Fill(this.DS.KhachHang);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog(ex.Message);
                throw;
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void cbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nếu combobox chi nhánh chưa load danh sách phân mãnh thì thoát

        }

        private void fKhachHangManage_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

    }
}