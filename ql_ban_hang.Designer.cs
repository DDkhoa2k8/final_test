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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.con = new System.Windows.Forms.TableLayoutPanel();
            this.info_con = new System.Windows.Forms.TableLayoutPanel();
            this.thanh_toan_btn = new Guna.UI2.WinForms.Guna2Button();
            this.tongTien = new System.Windows.Forms.Label();
            this.them_btn = new Guna.UI2.WinForms.Guna2Button();
            this.sua_btn = new Guna.UI2.WinForms.Guna2Button();
            this.xoa_btn = new Guna.UI2.WinForms.Guna2Button();
            this.select_sp = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbsp = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.soLuong = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.danh_sach_sp_con = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dtsp = new Guna.UI2.WinForms.Guna2DataGridView();
            this.d = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.con.SuspendLayout();
            this.info_con.SuspendLayout();
            this.select_sp.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soLuong)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.danh_sach_sp_con.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtsp)).BeginInit();
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
            this.con.Name = "con";
            this.con.RowCount = 2;
            this.con.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 247F));
            this.con.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.23653F));
            this.con.Size = new System.Drawing.Size(1505, 839);
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
            this.info_con.Controls.Add(this.thanh_toan_btn, 3, 1);
            this.info_con.Controls.Add(this.tongTien, 0, 1);
            this.info_con.Controls.Add(this.them_btn, 1, 0);
            this.info_con.Controls.Add(this.sua_btn, 2, 0);
            this.info_con.Controls.Add(this.xoa_btn, 3, 0);
            this.info_con.Controls.Add(this.select_sp, 0, 0);
            this.info_con.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.info_con.Dock = System.Windows.Forms.DockStyle.Fill;
            this.info_con.Location = new System.Drawing.Point(30, 30);
            this.info_con.Margin = new System.Windows.Forms.Padding(30, 30, 30, 15);
            this.info_con.Name = "info_con";
            this.info_con.RowCount = 2;
            this.info_con.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.9604F));
            this.info_con.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.0396F));
            this.info_con.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.info_con.Size = new System.Drawing.Size(1445, 202);
            this.info_con.TabIndex = 1;
            // 
            // thanh_toan_btn
            // 
            this.thanh_toan_btn.BorderRadius = 20;
            this.thanh_toan_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.thanh_toan_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.thanh_toan_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.thanh_toan_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.thanh_toan_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thanh_toan_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.thanh_toan_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.thanh_toan_btn.ForeColor = System.Drawing.Color.White;
            this.thanh_toan_btn.Location = new System.Drawing.Point(1207, 129);
            this.thanh_toan_btn.Margin = new System.Windows.Forms.Padding(5, 20, 5, 20);
            this.thanh_toan_btn.Name = "thanh_toan_btn";
            this.thanh_toan_btn.Size = new System.Drawing.Size(233, 53);
            this.thanh_toan_btn.TabIndex = 9;
            this.thanh_toan_btn.Text = "Thanh toán";
            this.thanh_toan_btn.Click += new System.EventHandler(this.thanh_toan_btn_Click);
            // 
            // tongTien
            // 
            this.tongTien.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tongTien.AutoSize = true;
            this.tongTien.BackColor = System.Drawing.Color.Transparent;
            this.tongTien.ForeColor = System.Drawing.Color.White;
            this.tongTien.Location = new System.Drawing.Point(10, 143);
            this.tongTien.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.tongTien.Name = "tongTien";
            this.tongTien.Size = new System.Drawing.Size(225, 25);
            this.tongTien.TabIndex = 5;
            this.tongTien.Text = "Tổng tiền(VND): 0 vnd";
            this.tongTien.Click += new System.EventHandler(this.label2_Click);
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
            this.them_btn.Location = new System.Drawing.Point(727, 30);
            this.them_btn.Margin = new System.Windows.Forms.Padding(5, 30, 5, 30);
            this.them_btn.Name = "them_btn";
            this.them_btn.Size = new System.Drawing.Size(230, 49);
            this.them_btn.TabIndex = 2;
            this.them_btn.Text = "Thêm";
            this.them_btn.Click += new System.EventHandler(this.them_btn_Click);
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
            this.sua_btn.Location = new System.Drawing.Point(967, 30);
            this.sua_btn.Margin = new System.Windows.Forms.Padding(5, 30, 5, 30);
            this.sua_btn.Name = "sua_btn";
            this.sua_btn.Size = new System.Drawing.Size(230, 49);
            this.sua_btn.TabIndex = 3;
            this.sua_btn.Text = "Sửa";
            this.sua_btn.Click += new System.EventHandler(this.sua_btn_Click);
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
            this.xoa_btn.Location = new System.Drawing.Point(1207, 30);
            this.xoa_btn.Margin = new System.Windows.Forms.Padding(5, 30, 5, 30);
            this.xoa_btn.Name = "xoa_btn";
            this.xoa_btn.Size = new System.Drawing.Size(233, 49);
            this.xoa_btn.TabIndex = 4;
            this.xoa_btn.Text = "Xóa";
            this.xoa_btn.Click += new System.EventHandler(this.xoa_btn_Click);
            // 
            // select_sp
            // 
            this.select_sp.ColumnCount = 2;
            this.select_sp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.select_sp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.48718F));
            this.select_sp.Controls.Add(this.label1, 0, 0);
            this.select_sp.Controls.Add(this.cbsp, 1, 0);
            this.select_sp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.select_sp.Location = new System.Drawing.Point(3, 3);
            this.select_sp.Name = "select_sp";
            this.select_sp.RowCount = 1;
            this.select_sp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.select_sp.Size = new System.Drawing.Size(716, 103);
            this.select_sp.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sản phẩm:";
            // 
            // cbsp
            // 
            this.cbsp.BackColor = System.Drawing.Color.Transparent;
            this.cbsp.BorderRadius = 10;
            this.cbsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbsp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbsp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsp.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbsp.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbsp.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbsp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbsp.ForeColor = System.Drawing.Color.White;
            this.cbsp.ItemHeight = 30;
            this.cbsp.Location = new System.Drawing.Point(130, 35);
            this.cbsp.Margin = new System.Windows.Forms.Padding(5, 35, 5, 35);
            this.cbsp.Name = "cbsp";
            this.cbsp.Size = new System.Drawing.Size(581, 36);
            this.cbsp.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.info_con.SetColumnSpan(this.tableLayoutPanel1, 2);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.20675F));
            this.tableLayoutPanel1.Controls.Add(this.soLuong, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(725, 112);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(474, 87);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // soLuong
            // 
            this.soLuong.BackColor = System.Drawing.Color.Transparent;
            this.soLuong.BorderRadius = 10;
            this.soLuong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.soLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.soLuong.Location = new System.Drawing.Point(133, 15);
            this.soLuong.Margin = new System.Windows.Forms.Padding(6, 15, 6, 15);
            this.soLuong.Name = "soLuong";
            this.soLuong.Size = new System.Drawing.Size(335, 57);
            this.soLuong.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Số lượng:";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.Controls.Add(this.danh_sach_sp_con);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel1.Location = new System.Drawing.Point(30, 262);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(30, 15, 30, 30);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1445, 547);
            this.guna2Panel1.TabIndex = 2;
            // 
            // danh_sach_sp_con
            // 
            this.danh_sach_sp_con.BackColor = System.Drawing.Color.Transparent;
            this.danh_sach_sp_con.BorderColor = System.Drawing.Color.Transparent;
            this.danh_sach_sp_con.BorderRadius = 20;
            this.danh_sach_sp_con.Controls.Add(this.dtsp);
            this.danh_sach_sp_con.Dock = System.Windows.Forms.DockStyle.Fill;
            this.danh_sach_sp_con.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.danh_sach_sp_con.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.danh_sach_sp_con.Location = new System.Drawing.Point(0, 0);
            this.danh_sach_sp_con.Name = "danh_sach_sp_con";
            this.danh_sach_sp_con.Size = new System.Drawing.Size(1445, 547);
            this.danh_sach_sp_con.TabIndex = 0;
            this.danh_sach_sp_con.Text = "Danh sách sản phẩm";
            // 
            // dtsp
            // 
            this.dtsp.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtsp.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtsp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtsp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtsp.ColumnHeadersHeight = 4;
            this.dtsp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtsp.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtsp.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtsp.Location = new System.Drawing.Point(0, 40);
            this.dtsp.Name = "dtsp";
            this.dtsp.RowHeadersVisible = false;
            this.dtsp.RowHeadersWidth = 82;
            this.dtsp.RowTemplate.Height = 33;
            this.dtsp.Size = new System.Drawing.Size(1445, 507);
            this.dtsp.TabIndex = 0;
            this.dtsp.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtsp.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtsp.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtsp.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtsp.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtsp.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtsp.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtsp.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtsp.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtsp.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtsp.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtsp.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtsp.ThemeStyle.HeaderStyle.Height = 4;
            this.dtsp.ThemeStyle.ReadOnly = false;
            this.dtsp.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtsp.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtsp.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtsp.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.dtsp.ThemeStyle.RowsStyle.Height = 33;
            this.dtsp.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtsp.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtsp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtsp_CellClick);
            // 
            // ql_ban_hang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1505, 839);
            this.Controls.Add(this.con);
            this.MinimumSize = new System.Drawing.Size(1322, 910);
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
            ((System.ComponentModel.ISupportInitialize)(this.soLuong)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.danh_sach_sp_con.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtsp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel con;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2AnimateWindow d;
        private Guna.UI2.WinForms.Guna2GroupBox danh_sach_sp_con;
        private System.Windows.Forms.TableLayoutPanel info_con;
        private System.Windows.Forms.Label tongTien;
        private Guna.UI2.WinForms.Guna2Button them_btn;
        private Guna.UI2.WinForms.Guna2Button sua_btn;
        private Guna.UI2.WinForms.Guna2Button xoa_btn;
        private System.Windows.Forms.TableLayoutPanel select_sp;
        private Guna.UI2.WinForms.Guna2ComboBox cbsp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2NumericUpDown soLuong;
        private Guna.UI2.WinForms.Guna2DataGridView dtsp;
        private Guna.UI2.WinForms.Guna2Button thanh_toan_btn;
    }
}