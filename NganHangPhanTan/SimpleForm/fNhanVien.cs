
using NganHangPhanTan.DTO;
using NganHangPhanTan.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace NganHangPhanTan.SimpleForm
{
    public partial class fNhanVien : DevExpress.XtraEditors.XtraForm
    {
     
        private string serverName;


        private LinkedList<UserEventData> undoStack = new LinkedList<UserEventData>();
        private LinkedList<UserEventData> redoStack = new LinkedList<UserEventData>();

        private fNhanVienMove formNhanVienMove;

  

        public fNhanVien()
        {
            InitializeComponent();
        }


        private void fNhanVienManage_Load(object sender, EventArgs e)
        {
           
            // Không báo lỗi do thiếu dữ liệu FK
            DS.EnforceConstraints = false;
            this.taNhanVien.Connection.ConnectionString = Program.ConnectionStr;
            this.taNhanVien.Fill(this.DS.NhanVien);

            this.taChuyenTien.Connection.ConnectionString = Program.ConnectionStr;
            this.taChuyenTien.Fill(this.DS.GD_CHUYENTIEN);

            this.taGuiRut.Connection.ConnectionString = Program.ConnectionStr;
            this.taGuiRut.Fill(this.DS.GD_GOIRUT);

            cbBrand.DataSource = Program.bindingSource;
            cbBrand.DisplayMember = "TENCN";
            cbBrand.ValueMember = "TENSERVER";

            cbBrand.SelectedIndex = SecurityContext.User.BrandIndex;
            serverName = cbBrand.SelectedValue.ToString();
 
            switch (SecurityContext.User.Group)
            {
                case DTO.User.GroupENM.NGAN_HANG:
                    cbBrand.Enabled = true;
                    btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = false;
                    btnNhanVienMove.Enabled = false;
                    break;
                case DTO.User.GroupENM.CHI_NHANH:
                    cbBrand.Enabled = false;
                    btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = true;
                    btnNhanVienMove.Enabled = bdsNhanVien.Count > 0;
                    break;
                default:
                    // DEBUG
                    throw new Exception("User group is unidentified");
            }

            btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled = btnRedo.Enabled = false;
            pnInput.Enabled = false;

        }

       
        //ham viet undo va redo
        private void UndoUnSaveAction(UserEventData action)
        {
            bdsNhanVien.CancelEdit();

            if (btnSave.Tag == btnInsert)
            {
                bdsNhanVien.Position = action.GridPos;
                bdsNhanVien.RemoveAt(bdsNhanVien.Count - 1);
            }

            gcNhanVien.Enabled = true;
            pnInput.Enabled = false;
            btnNhanVienMove.Enabled = btnInsert.Enabled = btnUpdate.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = false;
            txbId.Enabled = false;
            btnUndo.Enabled = undoStack.Count > 0;

            btnSave.Tag = null;

            btnDelete.Enabled = bdsNhanVien.Count > 0;

            btnRedo.Enabled = redoStack.Count > 0;
        }

        private bool UndoByInsertAction(UserEventData action)
        {
            if (action == null)
                throw new Exception();

            bdsNhanVien.AddNew();

            txbBrandId.Text = Program.MACNHT;

            NhanVien NhanVien = (NhanVien)action.Content;
            txbId.Text = NhanVien.MaNV;
            txbLastName.Text = NhanVien.Ho;
            txbFirstName.Text = NhanVien.Ten;
            txbAddress.Text = NhanVien.DiaChi;
            txbPhoneNum.Text = NhanVien.SoDT;
            cbGender.SelectedItem = NhanVien.Phai;
            edTrangThaiXoa.Text = Convert.ToString(0);
            cbGender.DataBindings[0].WriteValue();

            try
            {
                // Lưu thông tin trên binding source
                bdsNhanVien.EndEdit();
                // Đặt thông tin nhân viên mới lên grid control
                bdsNhanVien.ResetCurrentItem();
                taNhanVien.Update(this.DS.NhanVien);
                taNhanVien.Fill(this.DS.NhanVien);
                bdsNhanVien.Position = bdsNhanVien.Find(NhanVien.MANV_HEADER, NhanVien.MaNV);
                btnNhanVienMove.Enabled = SecurityContext.User.Group == DTO.User.GroupENM.CHI_NHANH;
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog($"Lỗi không thể khôi phục nhân viên đã xóa có mã số {NhanVien.MaNV}.\nChi tiết: {ex.Message}");
                return false;
            }
            return true;
        }

        private int UndoByDeleteAction(UserEventData action)
        {
            NhanVien NhanVien = (NhanVien)action.Content;
            bdsNhanVien.Position = bdsNhanVien.Find(NhanVien.MANV_HEADER, NhanVien.MaNV);

            if (bdsGuiRut.Count > 0 || bdsChuyenTien.Count > 0)
            {
                MessageUtil.ShowErrorMsgDialog("Không thể xóa nhân viên đã thực hiện giao dịch cho khách hàng");
                return -1;
            }

            if (MessageUtil.ShowWarnConfirmDialog($"Xác nhận xóa nhân viên có mã số {NhanVien.MaNV}?") != DialogResult.OK)
                return 0;

            try
            {
                // Xóa trên máy trước
                bdsNhanVien.RemoveCurrent();
                // Xóa trên server
                taNhanVien.Update(this.DS.NhanVien);
            }
            catch (Exception ex)
            {
                // Phục hồi nếu xóa không thành công
                MessageUtil.ShowErrorMsgDialog($"Lỗi không thể xóa nhân viên. Thử thực hiện lại.\nChi tiết: {ex.Message}");
                taNhanVien.Fill(this.DS.NhanVien);
                bdsNhanVien.Position = bdsNhanVien.Find(NhanVien.MANV_HEADER, NhanVien.MaNV);
                return 0;
            }
            btnNhanVienMove.Enabled = btnDelete.Enabled = bdsNhanVien.Count != 0;
            return 1;
        }

        private bool UndoByUpdateAction(UserEventData action)
        {
            NhanVien updatedNhanVien = (NhanVien)action.Content;

            bdsNhanVien.Position = bdsNhanVien.Find(NhanVien.MANV_HEADER, updatedNhanVien.MaNV);

            txbLastName.Text = updatedNhanVien.Ho;
            txbFirstName.Text = updatedNhanVien.Ten;
            txbAddress.Text = updatedNhanVien.DiaChi;
            txbPhoneNum.Text = updatedNhanVien.SoDT;
            cbGender.SelectedItem = updatedNhanVien.Phai;

            cbGender.DataBindings[0].WriteValue();

            try
            {
                // Lưu thông tin trên binding source
                bdsNhanVien.EndEdit();
                // Đặt thông tin nhân viên mới lên grid control
                bdsNhanVien.ResetCurrentItem();
                taNhanVien.Update(this.DS.NhanVien);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog($"Lỗi không thể hiệu chỉnh nhân viên.Thử thực hiện lại.\nChi tiết: {ex.Message}");
                return false;
            }
            return true;
        }

        //su kien click undo va redo
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
                            int gridPos = bdsNhanVien.Position;
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
                                bdsNhanVien.Position = action.GridPos;
                            }
                            else if (res == 0)
                            {
                                undoStack.AddLast(action);
                            }
                            break;
                        }
                    case UserEventData.EventType.UPDATE:
                        {
                            NhanVien oldNhanVien = new NhanVien(((DataRowView)bdsNhanVien[bdsNhanVien.Find(NhanVien.MANV_HEADER, ((NhanVien)action.Content).MaNV)]));
                            if (UndoByUpdateAction(action))
                            {
                                action.Type = UserEventData.EventType.UPDATE;
                                action.Content = oldNhanVien;
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
                            int gridPos = bdsNhanVien.Position;
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
                                bdsNhanVien.Position = action.GridPos;
                            }
                            else if (res == 0)
                            {
                                redoStack.AddLast(action);
                            }
                            break;
                        }
                    case UserEventData.EventType.UPDATE:
                        {
                            NhanVien oldNhanVien = new NhanVien(((DataRowView)bdsNhanVien[bdsNhanVien.Find(NhanVien.MANV_HEADER, ((NhanVien)action.Content).MaNV)]));
                            if (UndoByUpdateAction(action))
                            {
                                action.Type = UserEventData.EventType.UPDATE;
                                action.Content = oldNhanVien;
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


        //ham viet insert update reload delete save
        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int gridPos = bdsNhanVien.Position;

            bdsNhanVien.AddNew();

            pnInput.Enabled = true;
            txbBrandId.Text = Program.MACNHT;
            gcNhanVien.Enabled = false;

            cbGender.SelectedIndex = 0;
            edTrangThaiXoa.Text = Convert.ToString(0);
            txbId.Enabled = true;
            txbId.Focus();
            btnNhanVienMove.Enabled = btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            btnRedo.Enabled = false;

            btnSave.Tag = btnInsert;

            // Push cancel-editing event to undo stack
            undoStack.AddLast(new UserEventData(UserEventData.EventType.CANCEL_EDIT, null, gridPos));
            btnUndo.Enabled = true;
        }
       
        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int gridPos = bdsNhanVien.Position;
            pnInput.Enabled = true;
            gcNhanVien.Enabled = false;
            btnNhanVienMove.Enabled = btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            btnRedo.Enabled = false;
            btnSave.Tag = btnUpdate;

            undoStack.AddLast(new UserEventData(UserEventData.EventType.CANCEL_EDIT, null, gridPos));
            btnUndo.Enabled = true;
            ControlUtil.ResolveStackStorage(undoStack);
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                taNhanVien.Fill(this.DS.NhanVien);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog(ex.Message);
                throw;
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Xóa nhân viên là chỉ cần xóa sau khi kiểm tra ràng buộc
            // Còn chuyển nhân viên mới dùng tới trạng thái xóa

            // Không thể xóa nhân viên đang là user
            string NhanVienId = ((DataRowView)bdsNhanVien[bdsNhanVien.Position])[NhanVien.MANV_HEADER].ToString();
            if (NhanVienId.Equals(SecurityContext.User.Username))
            {
                MessageUtil.ShowErrorMsgDialog("Bạn chỉ được thay đổi thông tin của mình, không thể xóa.");
                return;
            }

            if (bdsGuiRut.Count > 0 || bdsChuyenTien.Count > 0)
            {
                MessageUtil.ShowErrorMsgDialog("Không thể xóa nhân viên đã thực hiện giao dịch cho khách hàng");
                return;
            }

            if (MessageUtil.ShowWarnConfirmDialog($"Xác nhận xóa nhân viên có mã số {NhanVienId}?") == DialogResult.OK)
            {
                NhanVien deletedNhanVien = null;
                try
                {
                    deletedNhanVien = new NhanVien((DataRowView)bdsNhanVien[bdsNhanVien.Position]);
                    // Xóa trên máy trước
                    bdsNhanVien.RemoveCurrent();
                    // Xóa trên server
                    taNhanVien.Update(this.DS.NhanVien);
                }
                catch (Exception ex)
                {
                    // Phục hồi nếu xóa không thành công
                    MessageUtil.ShowErrorMsgDialog($"Lỗi không thể xóa nhân viên. Thử thực hiện lại.\nChi tiết: {ex.Message}");
                    taNhanVien.Fill(this.DS.NhanVien);
                    bdsNhanVien.Position = bdsNhanVien.Find(NhanVien.MANV_HEADER, deletedNhanVien.MaNV);
                    return;
                }


               // string idNhanVien = deletedNhanVien.MaNV;

              //  string query = "EXEC usp_DeleteLogin @MaNV";
               // int res = Program.ExecuteNonQuery(query, new object[] { idNhanVien});
                

                btnDelete.Enabled = bdsNhanVien.Count != 0;

                // Ignore to save grid pos
                undoStack.AddLast(new UserEventData(UserEventData.EventType.INSERT, deletedNhanVien, -1));
                btnUndo.Enabled = true;
                ControlUtil.ResolveStackStorage(undoStack);
                redoStack.Clear();
                btnRedo.Enabled = false;
                btnNhanVienMove.Enabled = bdsNhanVien.Count != 0;
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Save old data for undoing if save for update
            NhanVien oldNhanVien = null;
            string NhanVienID = "";

            if (btnSave.Tag == btnUpdate)
            {
                oldNhanVien = new NhanVien((DataRowView)bdsNhanVien[bdsNhanVien.Position]);
            }
            else
            {
                // Kiểm tra các ràng buộc
                NhanVienID = txbId.Text.Trim();
                if (string.IsNullOrEmpty(NhanVienID))
                {
                    MessageUtil.ShowErrorMsgDialog("Mã nhân viên không được để trống.");
                    txbId.Focus();
                    return;
                }

                if (NhanVienID.Contains(" "))
                {
                    MessageUtil.ShowErrorMsgDialog("Mã nhân viên không hợp lệ");
                    txbId.Focus();
                    return;
                }

                if (NhanVienID.Length > 10)
                {
                    MessageUtil.ShowErrorMsgDialog("Mã nhân viên không được vượt quá 10 kí tự");
                    txbId.Focus();
                    return;
                }

                // Kiểm tra mã nhân viên tồn tại trên site chủ
                if (Program.kiemTraNhanVienTonTai(NhanVienID)==1)
                {
                    MessageUtil.ShowErrorMsgDialog("Mã nhân viên đã tồn tại. Vui lòng chọn mã khác");
                    txbId.Focus();
                    return;
                }

                NhanVienID = NhanVienID.ToUpper();
                txbId.Text = NhanVienID;
            }

            string lastName = txbLastName.Text.Trim();
            if (string.IsNullOrEmpty(lastName))
            {
                MessageUtil.ShowErrorMsgDialog("Họ tên nhân viên không được để trống");
                txbLastName.Focus();
                return;
            }

            lastName = ControlUtil.RemoveDuplicateSpace(lastName);
            lastName = ControlUtil.CapitalizeFirstLetter(lastName);
            txbLastName.Text = lastName;

            string firstName = txbFirstName.Text.Trim();
            if (string.IsNullOrEmpty(firstName))
            {
                MessageUtil.ShowErrorMsgDialog("Họ tên nhân viên không được để trống");
                txbFirstName.Focus();
                return;
            }

            if (firstName.Contains(" "))
            {
                MessageUtil.ShowErrorMsgDialog("Tên nhân viên không hợp lệ");
                txbFirstName.Focus();
                return;
            }

            firstName = ControlUtil.CapitalizeFirstLetter(firstName);
            txbFirstName.Text = firstName;

            string address = txbAddress.Text.Trim();
            if (string.IsNullOrEmpty(address))
            {
                MessageUtil.ShowErrorMsgDialog("Địa chỉ nhân viên không được để trống");
                txbAddress.Focus();
                return;
            }

            address = ControlUtil.RemoveDuplicateSpace(address);
            txbAddress.Text = address;

            string phoneNum = txbPhoneNum.Text.Trim();
            if (string.IsNullOrEmpty(phoneNum))
            {
                MessageUtil.ShowErrorMsgDialog("Số điện thoại nhân viên không được để trống");
                txbPhoneNum.Focus();
                return;
            }

            if (!phoneNum.All(Char.IsDigit))
            {
                MessageUtil.ShowErrorMsgDialog("Số điện thoại nhân viên không hợp lệ");
                txbPhoneNum.Focus();
                return;
            }

            if (phoneNum.Length != 10)
            {
                MessageUtil.ShowErrorMsgDialog("Số điện thoại nhân viên không đúng 10 chữ số");
                txbPhoneNum.Focus();
                return;
            }

            txbPhoneNum.Text = phoneNum;

            cbGender.DataBindings[0].WriteValue();

            try
            {
                // Lưu thông tin trên binding source
                bdsNhanVien.EndEdit();
                // Đặt thông tin nhân viên mới lên grid control
                bdsNhanVien.ResetCurrentItem();
                taNhanVien.Update(this.DS.NhanVien);


                MessageUtil.ShowInfoMsgDialog("Ghi thành công");
            }
            catch (Exception ex)
            {
                string msg = btnSave.Tag == btnInsert ? "Lỗi không thể thêm nhân viên mới" : "Lỗi không thể hiệu chỉnh nhân viên";
                MessageUtil.ShowErrorMsgDialog($"{msg}.\nChi tiết: {ex.Message}");
                return;
            }




            //bat su kien undo

            if (btnSave.Tag == btnInsert)
            {
                taNhanVien.Fill(this.DS.NhanVien);
                bdsNhanVien.Position = bdsNhanVien.Find(NhanVien.MANV_HEADER, NhanVienID);
            }

            // xoa su kien cancel trong stack
            UserEventData action = undoStack.Last();
            undoStack.RemoveLast();

            if (btnSave.Tag == btnInsert)
            {
                // Nếu INSERT, thêm vào undo stack DELETE action
                action.Type = UserEventData.EventType.DELETE;
                action.Content = new NhanVien((DataRowView)bdsNhanVien[bdsNhanVien.Position]);
                // Không cần lưu action.GridPos vì là DELETE action
            }
            else
            {
                // Nếu UPDATE, thêm vào undo stack UPDATE action
                action.Type = UserEventData.EventType.UPDATE;
                action.Content = oldNhanVien;
                // Không cần lưu action.GridPos vì không cần phục hồi gridPos khi UPDATE
            }

            undoStack.AddLast(action);
            ControlUtil.ResolveStackStorage(undoStack);






            btnUndo.Enabled = true;

            // Xóa redo stack
            redoStack.Clear();
            btnRedo.Enabled = false;

            gcNhanVien.Enabled = true;
            pnInput.Enabled = false;
            btnNhanVienMove.Enabled = btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = false;
            btnNhanVienMove.Enabled = (cbBrand.Items.Count > 1);
            txbId.Enabled = false;
            btnSave.Tag = null;

           
        }



        private void btnNhanVienMove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string NhanVienId = ((DataRowView)bdsNhanVien[bdsNhanVien.Position])[NhanVien.MANV_HEADER].ToString();

            // Không thể chuyển nhân viên đang là user
            if (NhanVienId.Equals(SecurityContext.User.Username))
            {
                MessageUtil.ShowErrorMsgDialog("Bạn chỉ được thay đổi thông tin của mình, không thể tự chuyển sang chi nhánh khác.");
                return;
            }
            formNhanVienMove = new fNhanVienMove(NhanVienId);

            formNhanVienMove.ShowDialog(this);

            this.taNhanVien.Fill(this.DS.NhanVien);
            formNhanVienMove.Close();
        }


        
        private void cbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {

           

        }

        private void cbBrand_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbBrand.SelectedValue.ToString().Equals("System.Data.RowView"))
                return;

            serverName = cbBrand.SelectedValue.ToString();
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
            else
            {
                taNhanVien.Connection.ConnectionString = Program.ConnectionStr;
                taNhanVien.Fill(this.DS.NhanVien);

                taChuyenTien.Connection.ConnectionString = Program.ConnectionStr;
                taChuyenTien.Fill(this.DS.GD_CHUYENTIEN);

                taGuiRut.Connection.ConnectionString = Program.ConnectionStr;
                taGuiRut.Fill(this.DS.GD_GOIRUT);
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}