
namespace NganHangPhanTan.SimpleForm
{
    partial class fMoTaiKhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nGAYMOTKLabel;
            System.Windows.Forms.Label mACNLabel;
            System.Windows.Forms.Label sODULabel;
            System.Windows.Forms.Label cMNDLabel;
            System.Windows.Forms.Label sOTKLabel;
            System.Windows.Forms.Label mACNLabel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMoTaiKhoan));
            this.DS = new NganHangPhanTan.DS();
            this.tableAdapterManager = new NganHangPhanTan.DSTableAdapters.TableAdapterManager();
            this.gc1 = new DevExpress.XtraEditors.GroupControl();
            this.gcTaiKhoan = new DevExpress.XtraGrid.GridControl();
            this.bdsTaiKhoan = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gCInput = new DevExpress.XtraEditors.GroupControl();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.edNgayMoTK = new DevExpress.XtraEditors.DateEdit();
            this.edMaCn = new DevExpress.XtraEditors.TextEdit();
            this.edSoDu = new DevExpress.XtraEditors.TextEdit();
            this.edCMND = new DevExpress.XtraEditors.TextEdit();
            this.edSoTK = new DevExpress.XtraEditors.TextEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.taiKhoanTableAdapter = new NganHangPhanTan.DSTableAdapters.TaiKhoanTableAdapter();
            this.gD_GOIRUTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gD_GOIRUTTableAdapter = new NganHangPhanTan.DSTableAdapters.GD_GOIRUTTableAdapter();
            this.gD_CHUYENTIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gD_CHUYENTIENTableAdapter = new NganHangPhanTan.DSTableAdapters.GD_CHUYENTIENTableAdapter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnReload = new DevExpress.XtraEditors.SimpleButton();
            this.btnUndo = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnInsert = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cbBrand = new System.Windows.Forms.ComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            nGAYMOTKLabel = new System.Windows.Forms.Label();
            mACNLabel = new System.Windows.Forms.Label();
            sODULabel = new System.Windows.Forms.Label();
            cMNDLabel = new System.Windows.Forms.Label();
            sOTKLabel = new System.Windows.Forms.Label();
            mACNLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).BeginInit();
            this.gc1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCInput)).BeginInit();
            this.gCInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edNgayMoTK.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edNgayMoTK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edMaCn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edSoDu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edCMND.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edSoTK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD_GOIRUTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD_CHUYENTIENBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nGAYMOTKLabel
            // 
            nGAYMOTKLabel.AutoSize = true;
            nGAYMOTKLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nGAYMOTKLabel.Location = new System.Drawing.Point(873, 208);
            nGAYMOTKLabel.Name = "nGAYMOTKLabel";
            nGAYMOTKLabel.Size = new System.Drawing.Size(319, 33);
            nGAYMOTKLabel.TabIndex = 15;
            nGAYMOTKLabel.Text = "NGÀY MỞ TÀI KHOẢN:";
            // 
            // mACNLabel
            // 
            mACNLabel.AutoSize = true;
            mACNLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mACNLabel.Location = new System.Drawing.Point(969, 131);
            mACNLabel.Name = "mACNLabel";
            mACNLabel.Size = new System.Drawing.Size(234, 33);
            mACNLabel.TabIndex = 14;
            mACNLabel.Text = "MÃ CHI NHÁNH:";
            // 
            // sODULabel
            // 
            sODULabel.AutoSize = true;
            sODULabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sODULabel.Location = new System.Drawing.Point(226, 217);
            sODULabel.Name = "sODULabel";
            sODULabel.Size = new System.Drawing.Size(110, 33);
            sODULabel.TabIndex = 13;
            sODULabel.Text = "SỐ DƯ:";
            // 
            // cMNDLabel
            // 
            cMNDLabel.AutoSize = true;
            cMNDLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cMNDLabel.Location = new System.Drawing.Point(226, 159);
            cMNDLabel.Name = "cMNDLabel";
            cMNDLabel.Size = new System.Drawing.Size(110, 33);
            cMNDLabel.TabIndex = 12;
            cMNDLabel.Text = "CMND:";
            // 
            // sOTKLabel
            // 
            sOTKLabel.AutoSize = true;
            sOTKLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sOTKLabel.Location = new System.Drawing.Point(115, 94);
            sOTKLabel.Name = "sOTKLabel";
            sOTKLabel.Size = new System.Drawing.Size(221, 33);
            sOTKLabel.TabIndex = 11;
            sOTKLabel.Text = "SỐ TÀI KHOẢN:";
            // 
            // mACNLabel1
            // 
            mACNLabel1.AutoSize = true;
            mACNLabel1.Location = new System.Drawing.Point(1175, 141);
            mACNLabel1.Name = "mACNLabel1";
            mACNLabel1.Size = new System.Drawing.Size(0, 19);
            mACNLabel1.TabIndex = 18;
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.GD_CHUYENTIENTableAdapter = null;
            this.tableAdapterManager.GD_GOIRUTTableAdapter = null;
            this.tableAdapterManager.KhachHangTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.TaiKhoanTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = NganHangPhanTan.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // gc1
            // 
            this.gc1.Controls.Add(this.gcTaiKhoan);
            this.gc1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gc1.Location = new System.Drawing.Point(0, 74);
            this.gc1.Name = "gc1";
            this.gc1.Size = new System.Drawing.Size(1457, 356);
            this.gc1.TabIndex = 9;
            this.gc1.Text = "Danh sách tài khoản";
            // 
            // gcTaiKhoan
            // 
            this.gcTaiKhoan.DataSource = this.bdsTaiKhoan;
            this.gcTaiKhoan.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcTaiKhoan.Location = new System.Drawing.Point(2, 34);
            this.gcTaiKhoan.MainView = this.gridView1;
            this.gcTaiKhoan.Name = "gcTaiKhoan";
            this.gcTaiKhoan.Size = new System.Drawing.Size(1453, 320);
            this.gcTaiKhoan.TabIndex = 0;
            this.gcTaiKhoan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bdsTaiKhoan
            // 
            this.bdsTaiKhoan.DataMember = "TaiKhoan";
            this.bdsTaiKhoan.DataSource = this.DS;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gcTaiKhoan;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            // 
            // gCInput
            // 
            this.gCInput.Controls.Add(this.btnKiemTra);
            this.gCInput.Controls.Add(this.edNgayMoTK);
            this.gCInput.Controls.Add(mACNLabel1);
            this.gCInput.Controls.Add(this.edMaCn);
            this.gCInput.Controls.Add(this.edSoDu);
            this.gCInput.Controls.Add(this.edCMND);
            this.gCInput.Controls.Add(this.edSoTK);
            this.gCInput.Controls.Add(nGAYMOTKLabel);
            this.gCInput.Controls.Add(mACNLabel);
            this.gCInput.Controls.Add(sODULabel);
            this.gCInput.Controls.Add(cMNDLabel);
            this.gCInput.Controls.Add(sOTKLabel);
            this.gCInput.Controls.Add(this.panel1);
            this.gCInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCInput.Location = new System.Drawing.Point(0, 430);
            this.gCInput.Name = "gCInput";
            this.gCInput.Size = new System.Drawing.Size(1457, 301);
            this.gCInput.TabIndex = 10;
            this.gCInput.Text = "Danh sách tài khoản thuộc khách hàng";
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnKiemTra.Location = new System.Drawing.Point(586, 94);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(178, 38);
            this.btnKiemTra.TabIndex = 106;
            this.btnKiemTra.Text = "Kiểm tra";
            this.btnKiemTra.UseVisualStyleBackColor = true;
            this.btnKiemTra.Click += new System.EventHandler(this.kiemTraBtn_Click);
            // 
            // edNgayMoTK
            // 
            this.edNgayMoTK.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsTaiKhoan, "NGAYMOTK", true));
            this.edNgayMoTK.EditValue = null;
            this.edNgayMoTK.Location = new System.Drawing.Point(1223, 213);
            this.edNgayMoTK.Name = "edNgayMoTK";
            this.edNgayMoTK.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edNgayMoTK.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edNgayMoTK.Size = new System.Drawing.Size(150, 28);
            this.edNgayMoTK.TabIndex = 20;
            // 
            // edMaCn
            // 
            this.edMaCn.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsTaiKhoan, "MACN", true));
            this.edMaCn.Enabled = false;
            this.edMaCn.Location = new System.Drawing.Point(1223, 130);
            this.edMaCn.Name = "edMaCn";
            this.edMaCn.Size = new System.Drawing.Size(150, 28);
            this.edMaCn.TabIndex = 19;
            // 
            // edSoDu
            // 
            this.edSoDu.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsTaiKhoan, "SODU", true));
            this.edSoDu.Location = new System.Drawing.Point(381, 213);
            this.edSoDu.Name = "edSoDu";
            this.edSoDu.Properties.Mask.EditMask = "n0";
            this.edSoDu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.edSoDu.Size = new System.Drawing.Size(150, 28);
            this.edSoDu.TabIndex = 18;
            // 
            // edCMND
            // 
            this.edCMND.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsTaiKhoan, "CMND", true));
            this.edCMND.Location = new System.Drawing.Point(381, 155);
            this.edCMND.Name = "edCMND";
            this.edCMND.Size = new System.Drawing.Size(150, 28);
            this.edCMND.TabIndex = 17;
            // 
            // edSoTK
            // 
            this.edSoTK.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsTaiKhoan, "SOTK", true));
            this.edSoTK.Location = new System.Drawing.Point(381, 100);
            this.edSoTK.Name = "edSoTK";
            this.edSoTK.Size = new System.Drawing.Size(150, 28);
            this.edSoTK.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1453, 10);
            this.panel1.TabIndex = 10;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // taiKhoanTableAdapter
            // 
            this.taiKhoanTableAdapter.ClearBeforeFill = true;
            // 
            // gD_GOIRUTBindingSource
            // 
            this.gD_GOIRUTBindingSource.DataMember = "FK_GD_GOIRUT_TaiKhoan";
            this.gD_GOIRUTBindingSource.DataSource = this.bdsTaiKhoan;
            // 
            // gD_GOIRUTTableAdapter
            // 
            this.gD_GOIRUTTableAdapter.ClearBeforeFill = true;
            // 
            // gD_CHUYENTIENBindingSource
            // 
            this.gD_CHUYENTIENBindingSource.DataMember = "FK_SOTKCHUYEN_TAIKHOAN";
            this.gD_CHUYENTIENBindingSource.DataSource = this.bdsTaiKhoan;
            // 
            // gD_CHUYENTIENTableAdapter
            // 
            this.gD_CHUYENTIENTableAdapter.ClearBeforeFill = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnReload);
            this.panel2.Controls.Add(this.btnUndo);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnInsert);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 430);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1457, 43);
            this.panel2.TabIndex = 20;
            // 
            // btnReload
            // 
            this.btnReload.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReload.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.btnReload.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.ImageOptions.Image")));
            this.btnReload.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftBottom;
            this.btnReload.Location = new System.Drawing.Point(376, 0);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(94, 43);
            this.btnReload.TabIndex = 22;
            this.btnReload.Text = "Xem lại";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUndo.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.btnUndo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.ImageOptions.Image")));
            this.btnUndo.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftBottom;
            this.btnUndo.Location = new System.Drawing.Point(282, 0);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(94, 43);
            this.btnUndo.TabIndex = 20;
            this.btnUndo.Text = "Undo";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.btnSave.ImageOptions.Image = global::NganHangPhanTan.Properties.Resources.diskette;
            this.btnSave.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftBottom;
            this.btnSave.Location = new System.Drawing.Point(188, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 43);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDelete.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.btnDelete.ImageOptions.Image = global::NganHangPhanTan.Properties.Resources.delete;
            this.btnDelete.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftBottom;
            this.btnDelete.Location = new System.Drawing.Point(94, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 43);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnInsert.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.btnInsert.ImageOptions.Image = global::NganHangPhanTan.Properties.Resources.add;
            this.btnInsert.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftBottom;
            this.btnInsert.Location = new System.Drawing.Point(0, 0);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(94, 43);
            this.btnInsert.TabIndex = 23;
            this.btnInsert.Text = "Thêm";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi nhánh:";
            // 
            // cbBrand
            // 
            this.cbBrand.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBrand.FormattingEnabled = true;
            this.cbBrand.Location = new System.Drawing.Point(140, 24);
            this.cbBrand.Name = "cbBrand";
            this.cbBrand.Size = new System.Drawing.Size(391, 36);
            this.cbBrand.TabIndex = 1;
            this.cbBrand.SelectionChangeCommitted += new System.EventHandler(this.cbBrand_SelectionChangeCommitted);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cbBrand);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1457, 74);
            this.panelControl1.TabIndex = 6;
            // 
            // fMoTaiKhoan
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1457, 731);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gCInput);
            this.Controls.Add(this.gc1);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fMoTaiKhoan";
            this.Text = "Mở tài khoản khách hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fOpenKhachHangAccount_FormClosing);
            this.Load += new System.EventHandler(this.fOpenKhachHangAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).EndInit();
            this.gc1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCInput)).EndInit();
            this.gCInput.ResumeLayout(false);
            this.gCInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edNgayMoTK.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edNgayMoTK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edMaCn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edSoDu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edCMND.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edSoTK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD_GOIRUTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD_CHUYENTIENBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DS DS;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraEditors.GroupControl gc1;
        private DevExpress.XtraEditors.GroupControl gCInput;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraBars.Bar bar1;
        private System.Windows.Forms.BindingSource bdsTaiKhoan;
        private DSTableAdapters.TaiKhoanTableAdapter taiKhoanTableAdapter;
        private DevExpress.XtraEditors.TextEdit edCMND;
        private DevExpress.XtraEditors.TextEdit edSoTK;
        private DevExpress.XtraEditors.DateEdit edNgayMoTK;
        private DevExpress.XtraEditors.TextEdit edMaCn;
        private DevExpress.XtraEditors.TextEdit edSoDu;
        private DevExpress.XtraGrid.GridControl gcTaiKhoan;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource gD_GOIRUTBindingSource;
        private DSTableAdapters.GD_GOIRUTTableAdapter gD_GOIRUTTableAdapter;
        private System.Windows.Forms.BindingSource gD_CHUYENTIENBindingSource;
        private DSTableAdapters.GD_CHUYENTIENTableAdapter gD_CHUYENTIENTableAdapter;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnReload;
        private DevExpress.XtraEditors.SimpleButton btnUndo;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnInsert;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBrand;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}