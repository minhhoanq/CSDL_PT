
namespace NganHangPhanTan.Report
{
    partial class fReportTaiKhoan
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this.cbBrand = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtBrandAll = new System.Windows.Forms.RadioButton();
            this.rbtChooseBrand = new System.Windows.Forms.RadioButton();
            this.dpDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.dpDateTo = new DevExpress.XtraEditors.DateEdit();
            this.btnSubmit = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dpDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpDateTo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(246, 242);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(105, 30);
            label3.TabIndex = 26;
            label3.Text = "Thời gian:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(627, 253);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(15, 19);
            label4.TabIndex = 27;
            label4.Text = "-";
            // 
            // cbBrand
            // 
            this.cbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBrand.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBrand.FormattingEnabled = true;
            this.cbBrand.Location = new System.Drawing.Point(240, 88);
            this.cbBrand.Margin = new System.Windows.Forms.Padding(4);
            this.cbBrand.Name = "cbBrand";
            this.cbBrand.Size = new System.Drawing.Size(502, 36);
            this.cbBrand.TabIndex = 24;
            this.cbBrand.SelectionChangeCommitted += new System.EventHandler(this.cbBrand_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 30);
            this.label1.TabIndex = 23;
            this.label1.Text = "Chi nhánh:";
            // 
            // rbtBrandAll
            // 
            this.rbtBrandAll.AutoSize = true;
            this.rbtBrandAll.Location = new System.Drawing.Point(942, 42);
            this.rbtBrandAll.Margin = new System.Windows.Forms.Padding(4);
            this.rbtBrandAll.Name = "rbtBrandAll";
            this.rbtBrandAll.Size = new System.Drawing.Size(188, 23);
            this.rbtBrandAll.TabIndex = 31;
            this.rbtBrandAll.TabStop = true;
            this.rbtBrandAll.Text = "Chọn tất cả chi nhánh";
            this.rbtBrandAll.UseVisualStyleBackColor = true;
            // 
            // rbtChooseBrand
            // 
            this.rbtChooseBrand.AutoSize = true;
            this.rbtChooseBrand.Location = new System.Drawing.Point(46, 42);
            this.rbtChooseBrand.Margin = new System.Windows.Forms.Padding(4);
            this.rbtChooseBrand.Name = "rbtChooseBrand";
            this.rbtChooseBrand.Size = new System.Drawing.Size(181, 23);
            this.rbtChooseBrand.TabIndex = 25;
            this.rbtChooseBrand.TabStop = true;
            this.rbtChooseBrand.Text = "Chọn theo chi nhánh";
            this.rbtChooseBrand.UseVisualStyleBackColor = true;
            this.rbtChooseBrand.CheckedChanged += new System.EventHandler(this.rbtChooseBrand_CheckedChanged);
            // 
            // dpDateFrom
            // 
            this.dpDateFrom.EditValue = new System.DateTime(2021, 12, 11, 19, 48, 25, 0);
            this.dpDateFrom.Location = new System.Drawing.Point(411, 242);
            this.dpDateFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dpDateFrom.Name = "dpDateFrom";
            this.dpDateFrom.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpDateFrom.Properties.Appearance.Options.UseFont = true;
            this.dpDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpDateFrom.Size = new System.Drawing.Size(161, 36);
            this.dpDateFrom.TabIndex = 28;
            // 
            // dpDateTo
            // 
            this.dpDateTo.EditValue = new System.DateTime(2021, 12, 11, 0, 0, 0, 0);
            this.dpDateTo.Location = new System.Drawing.Point(711, 242);
            this.dpDateTo.Margin = new System.Windows.Forms.Padding(4);
            this.dpDateTo.Name = "dpDateTo";
            this.dpDateTo.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpDateTo.Properties.Appearance.Options.UseFont = true;
            this.dpDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpDateTo.Size = new System.Drawing.Size(161, 36);
            this.dpDateTo.TabIndex = 29;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(963, 232);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(194, 46);
            this.btnSubmit.TabIndex = 30;
            this.btnSubmit.Text = "Xem";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // fReportTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 671);
            this.Controls.Add(this.cbBrand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbtBrandAll);
            this.Controls.Add(this.rbtChooseBrand);
            this.Controls.Add(label3);
            this.Controls.Add(this.dpDateFrom);
            this.Controls.Add(label4);
            this.Controls.Add(this.dpDateTo);
            this.Controls.Add(this.btnSubmit);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fReportTaiKhoan";
            this.Text = "Báo cáo tài khoản mở";
            this.Load += new System.EventHandler(this.fReportOpenedAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dpDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpDateTo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBrand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtBrandAll;
        private System.Windows.Forms.RadioButton rbtChooseBrand;
        private DevExpress.XtraEditors.DateEdit dpDateFrom;
        private DevExpress.XtraEditors.DateEdit dpDateTo;
        private System.Windows.Forms.Button btnSubmit;
    }
}