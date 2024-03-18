
namespace NganHangPhanTan.SimpleForm
{
    partial class fNhanVienMove
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
            this.btnMove = new System.Windows.Forms.Button();
            this.dS = new NganHangPhanTan.DS();
            this.tableAdapterManager = new NganHangPhanTan.DSTableAdapters.TableAdapterManager();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.usp_LayDsChiNhanhKhacGridControl = new DevExpress.XtraGrid.GridControl();
            this.bdsLayDsChiNhanhKhac = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txbId = new System.Windows.Forms.TextBox();
            this.usp_LayDsChiNhanhKhacTableAdapter = new NganHangPhanTan.DSTableAdapters.usp_LayDsChiNhanhKhacTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usp_LayDsChiNhanhKhacGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLayDsChiNhanhKhac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(722, 285);
            this.btnMove.Margin = new System.Windows.Forms.Padding(4);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(198, 45);
            this.btnMove.TabIndex = 1;
            this.btnMove.Text = "Chuyển";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.usp_LayDsChiNhanhKhacGridControl);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Controls.Add(this.txbId);
            this.groupControl2.Controls.Add(this.btnMove);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1221, 403);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "Chọn chi nhánh cần chuyển nhân viên:";
            // 
            // usp_LayDsChiNhanhKhacGridControl
            // 
            this.usp_LayDsChiNhanhKhacGridControl.DataSource = this.bdsLayDsChiNhanhKhac;
            this.usp_LayDsChiNhanhKhacGridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.usp_LayDsChiNhanhKhacGridControl.Location = new System.Drawing.Point(2, 34);
            this.usp_LayDsChiNhanhKhacGridControl.MainView = this.gridView1;
            this.usp_LayDsChiNhanhKhacGridControl.Name = "usp_LayDsChiNhanhKhacGridControl";
            this.usp_LayDsChiNhanhKhacGridControl.Size = new System.Drawing.Size(1217, 220);
            this.usp_LayDsChiNhanhKhacGridControl.TabIndex = 4;
            this.usp_LayDsChiNhanhKhacGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bdsLayDsChiNhanhKhac
            // 
            this.bdsLayDsChiNhanhKhac.DataMember = "usp_LayDsChiNhanhKhac";
            this.bdsLayDsChiNhanhKhac.DataSource = this.dS;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.usp_LayDsChiNhanhKhacGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(154, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 34);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã NV MỚI :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txbId
            // 
            this.txbId.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txbId.Location = new System.Drawing.Point(347, 296);
            this.txbId.Multiline = true;
            this.txbId.Name = "txbId";
            this.txbId.Size = new System.Drawing.Size(155, 34);
            this.txbId.TabIndex = 3;
            // 
            // usp_LayDsChiNhanhKhacTableAdapter
            // 
            this.usp_LayDsChiNhanhKhacTableAdapter.ClearBeforeFill = true;
            // 
            // fNhanVienMove
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 403);
            this.Controls.Add(this.groupControl2);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fNhanVienMove";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điều chuyển nhân viên sang chi nhánh";
            this.Load += new System.EventHandler(this.fNhanVienMove_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usp_LayDsChiNhanhKhacGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLayDsChiNhanhKhac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnMove;
        private DS dS;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bdsLayDsChiNhanhKhac;
        private DSTableAdapters.usp_LayDsChiNhanhKhacTableAdapter usp_LayDsChiNhanhKhacTableAdapter;
        private DevExpress.XtraGrid.GridControl usp_LayDsChiNhanhKhacGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}