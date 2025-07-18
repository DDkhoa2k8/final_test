namespace final_test
{
    partial class ql_ban_hang
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
            this.con = new System.Windows.Forms.TableLayoutPanel();
            this.info_con = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.them_btn = new Guna.UI2.WinForms.Guna2Button();
            this.sua_btn = new Guna.UI2.WinForms.Guna2Button();
            this.xoa_btn = new Guna.UI2.WinForms.Guna2Button();
            this.select_sp = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2NumericUpDown1 = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.danh_sach_sp_con = new Guna.UI2.WinForms.Guna2GroupBox();
            this.d = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.con.SuspendLayout();
            this.info_con.SuspendLayout();
            this.select_sp.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2NumericUpDown1)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // con
            // 
            this.con.ColumnCount = 1;
            this.con.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.con.Controls.Add(this.info_con, 0, 0);
            this.con.Controls.Add(this.guna2Panel1, 0, 1);
            this.con.Dock = System.Windows.Forms.DockStyle.Fill;
            this.con.Location = new System.Drawing.Point(0, 0);
            this.con.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.con.Name = "con";
            this.con.RowCount = 2;
            this.con.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.con.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.23653F));
            this.con.Size = new System.Drawing.Size(1003, 599);
            this.con.TabIndex = 0;
            this.con.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // info_con
            // 
            this.info_con.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.info_con.ColumnCount = 4;
            this.info_con.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.01F));
            this.info_con.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66333F));
            this.info_con.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66333F));
            this.info_con.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66333F));
            this.info_con.Controls.Add(this.label2, 0, 1);
            this.info_con.Controls.Add(this.them_btn, 1, 0);
            this.info_con.Controls.Add(this.sua_btn, 2, 0);
            this.info_con.Controls.Add(this.xoa_btn, 3, 0);
            this.info_con.Controls.Add(this.select_sp, 0, 0);
            this.info_con.Controls.Add(this.label3, 3, 1);
            this.info_con.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.info_con.Dock = System.Windows.Forms.DockStyle.Fill;
            this.info_con.Location = new System.Drawing.Point(20, 19);
            this.info_con.Margin = new System.Windows.Forms.Padding(20, 19, 20, 10);
            this.info_con.Name = "info_con";
            this.info_con.RowCount = 2;
            this.info_con.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.9604F));
            this.info_con.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.0396F));
            this.info_con.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.info_con.Size = new System.Drawing.Size(963, 129);
            this.info_con.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tổng tiền(VND):";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // them_btn
            // 
            this.them_btn.BorderRadius = 20;
            this.them_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.them_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.them_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.them_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.them_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.them_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.them_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.them_btn.ForeColor = System.Drawing.Color.White;
            this.them_btn.Location = new System.Drawing.Point(484, 19);
            this.them_btn.Margin = new System.Windows.Forms.Padding(3, 19, 3, 19);
            this.them_btn.Name = "them_btn";
            this.them_btn.Size = new System.Drawing.Size(154, 31);
            this.them_btn.TabIndex = 2;
            this.them_btn.Text = "Thêm";
            // 
            // sua_btn
            // 
            this.sua_btn.BorderRadius = 20;
            this.sua_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.sua_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.sua_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.sua_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.sua_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sua_btn.FillColor = System.Drawing.Color.Gold;
            this.sua_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sua_btn.ForeColor = System.Drawing.Color.White;
            this.sua_btn.Location = new System.Drawing.Point(644, 19);
            this.sua_btn.Margin = new System.Windows.Forms.Padding(3, 19, 3, 19);
            this.sua_btn.Name = "sua_btn";
            this.sua_btn.Size = new System.Drawing.Size(154, 31);
            this.sua_btn.TabIndex = 3;
            this.sua_btn.Text = "Sửa";
            // 
            // xoa_btn
            // 
            this.xoa_btn.BorderRadius = 20;
            this.xoa_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.xoa_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.xoa_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.xoa_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.xoa_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xoa_btn.FillColor = System.Drawing.Color.Red;
            this.xoa_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.xoa_btn.ForeColor = System.Drawing.Color.White;
            this.xoa_btn.Location = new System.Drawing.Point(804, 19);
            this.xoa_btn.Margin = new System.Windows.Forms.Padding(3, 19, 3, 19);
            this.xoa_btn.Name = "xoa_btn";
            this.xoa_btn.Size = new System.Drawing.Size(156, 31);
            this.xoa_btn.TabIndex = 4;
            this.xoa_btn.Text = "Xóa";
            // 
            // select_sp
            // 
            this.select_sp.ColumnCount = 2;
            this.select_sp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.select_sp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.48718F));
            this.select_sp.Controls.Add(this.label1, 0, 0);
            this.select_sp.Controls.Add(this.guna2ComboBox1, 1, 0);
            this.select_sp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.select_sp.Location = new System.Drawing.Point(2, 2);
            this.select_sp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.select_sp.Name = "select_sp";
            this.select_sp.RowCount = 1;
            this.select_sp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.select_sp.Size = new System.Drawing.Size(477, 65);
            this.select_sp.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sản phẩm:";
            // 
            // guna2ComboBox1
            // 
            this.guna2ComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBox1.BorderRadius = 10;
            this.guna2ComboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2ComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2ComboBox1.ForeColor = System.Drawing.Color.White;
            this.guna2ComboBox1.ItemHeight = 30;
            this.guna2ComboBox1.Location = new System.Drawing.Point(86, 22);
            this.guna2ComboBox1.Margin = new System.Windows.Forms.Padding(3, 22, 3, 22);
            this.guna2ComboBox1.Name = "guna2ComboBox1";
            this.guna2ComboBox1.Size = new System.Drawing.Size(388, 36);
            this.guna2ComboBox1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(808, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Khuyến mãi(%):";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.info_con.SetColumnSpan(this.tableLayoutPanel1, 2);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.20675F));
            this.tableLayoutPanel1.Controls.Add(this.guna2NumericUpDown1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(483, 71);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(316, 56);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // guna2NumericUpDown1
            // 
            this.guna2NumericUpDown1.BackColor = System.Drawing.Color.Transparent;
            this.guna2NumericUpDown1.BorderRadius = 10;
            this.guna2NumericUpDown1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2NumericUpDown1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2NumericUpDown1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2NumericUpDown1.Location = new System.Drawing.Point(89, 10);
            this.guna2NumericUpDown1.Margin = new System.Windows.Forms.Padding(4, 10, 4, 10);
            this.guna2NumericUpDown1.Name = "guna2NumericUpDown1";
            this.guna2NumericUpDown1.Size = new System.Drawing.Size(223, 36);
            this.guna2NumericUpDown1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(2, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Số lượng:";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.Controls.Add(this.danh_sach_sp_con);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel1.Location = new System.Drawing.Point(20, 168);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(20, 10, 20, 19);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(963, 412);
            this.guna2Panel1.TabIndex = 2;
            // 
            // danh_sach_sp_con
            // 
            this.danh_sach_sp_con.BackColor = System.Drawing.Color.Transparent;
            this.danh_sach_sp_con.BorderColor = System.Drawing.Color.Transparent;
            this.danh_sach_sp_con.BorderRadius = 20;
            this.danh_sach_sp_con.Dock = System.Windows.Forms.DockStyle.Fill;
            this.danh_sach_sp_con.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.danh_sach_sp_con.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.danh_sach_sp_con.Location = new System.Drawing.Point(0, 0);
            this.danh_sach_sp_con.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.danh_sach_sp_con.Name = "danh_sach_sp_con";
            this.danh_sach_sp_con.Size = new System.Drawing.Size(963, 412);
            this.danh_sach_sp_con.TabIndex = 0;
            this.danh_sach_sp_con.Text = "Danh sách sản phẩm";
            // 
            // ql_ban_hang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1003, 552);
            this.Controls.Add(this.con);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(887, 599);
            this.Name = "ql_ban_hang";
            this.Text = "bán hàng";
            this.Load += new System.EventHandler(this.ql_ban_hang_Load);
            this.con.ResumeLayout(false);
            this.info_con.ResumeLayout(false);
            this.info_con.PerformLayout();
            this.select_sp.ResumeLayout(false);
            this.select_sp.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2NumericUpDown1)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel con;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2AnimateWindow d;
        private Guna.UI2.WinForms.Guna2GroupBox danh_sach_sp_con;
        private System.Windows.Forms.TableLayoutPanel info_con;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button them_btn;
        private Guna.UI2.WinForms.Guna2Button sua_btn;
        private Guna.UI2.WinForms.Guna2Button xoa_btn;
        private System.Windows.Forms.TableLayoutPanel select_sp;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2NumericUpDown guna2NumericUpDown1;
    }
}