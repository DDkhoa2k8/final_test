﻿namespace final_test
{
    partial class dang_nhap
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
            this.dn_con = new System.Windows.Forms.TableLayoutPanel();
            this.dn = new Guna.UI2.WinForms.Guna2Panel();
            this.quen_mk = new System.Windows.Forms.Label();
            this.mat_khau_lable = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dang_nhap_gnbtn = new Guna.UI2.WinForms.Guna2Button();
            this.mat_khau_gntb = new Guna.UI2.WinForms.Guna2TextBox();
            this.ten_tai_khoan_gntb = new Guna.UI2.WinForms.Guna2TextBox();
            this.tieu_de = new System.Windows.Forms.Label();
            this.dn_con.SuspendLayout();
            this.dn.SuspendLayout();
            this.SuspendLayout();
            // 
            // dn_con
            // 
            this.dn_con.ColumnCount = 3;
            this.dn_con.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.dn_con.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.dn_con.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.dn_con.Controls.Add(this.dn, 1, 1);
            this.dn_con.Controls.Add(this.tieu_de, 1, 0);
            this.dn_con.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dn_con.Location = new System.Drawing.Point(0, 0);
            this.dn_con.Name = "dn_con";
            this.dn_con.RowCount = 3;
            this.dn_con.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.24324F));
            this.dn_con.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.62162F));
            this.dn_con.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.dn_con.Size = new System.Drawing.Size(828, 669);
            this.dn_con.TabIndex = 1;
            this.dn_con.Paint += new System.Windows.Forms.PaintEventHandler(this.dn_con_Paint);
            // 
            // dn
            // 
            this.dn.BackColor = System.Drawing.Color.Transparent;
            this.dn.BorderColor = System.Drawing.Color.AliceBlue;
            this.dn.BorderRadius = 10;
            this.dn.Controls.Add(this.quen_mk);
            this.dn.Controls.Add(this.mat_khau_lable);
            this.dn.Controls.Add(this.label2);
            this.dn.Controls.Add(this.dang_nhap_gnbtn);
            this.dn.Controls.Add(this.mat_khau_gntb);
            this.dn.Controls.Add(this.ten_tai_khoan_gntb);
            this.dn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.dn.ForeColor = System.Drawing.Color.White;
            this.dn.Location = new System.Drawing.Point(85, 125);
            this.dn.Name = "dn";
            this.dn.Size = new System.Drawing.Size(656, 473);
            this.dn.TabIndex = 0;
            this.dn.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // quen_mk
            // 
            this.quen_mk.AutoSize = true;
            this.quen_mk.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quen_mk.ForeColor = System.Drawing.Color.White;
            this.quen_mk.Location = new System.Drawing.Point(461, 411);
            this.quen_mk.Name = "quen_mk";
            this.quen_mk.Size = new System.Drawing.Size(158, 25);
            this.quen_mk.TabIndex = 5;
            this.quen_mk.Text = "Quên mật khẩu";
            this.quen_mk.Click += new System.EventHandler(this.quen_mk_Click);
            // 
            // mat_khau_lable
            // 
            this.mat_khau_lable.AutoSize = true;
            this.mat_khau_lable.ForeColor = System.Drawing.Color.White;
            this.mat_khau_lable.Location = new System.Drawing.Point(53, 158);
            this.mat_khau_lable.Name = "mat_khau_lable";
            this.mat_khau_lable.Size = new System.Drawing.Size(101, 25);
            this.mat_khau_lable.TabIndex = 4;
            this.mat_khau_lable.Text = "Mật khẩu";
            this.mat_khau_lable.Click += new System.EventHandler(this.mat_khau_lable_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(53, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên tài khoản";
            // 
            // dang_nhap_gnbtn
            // 
            this.dang_nhap_gnbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dang_nhap_gnbtn.BorderRadius = 10;
            this.dang_nhap_gnbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.dang_nhap_gnbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.dang_nhap_gnbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.dang_nhap_gnbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dang_nhap_gnbtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dang_nhap_gnbtn.ForeColor = System.Drawing.Color.White;
            this.dang_nhap_gnbtn.Location = new System.Drawing.Point(53, 303);
            this.dang_nhap_gnbtn.Name = "dang_nhap_gnbtn";
            this.dang_nhap_gnbtn.Size = new System.Drawing.Size(556, 78);
            this.dang_nhap_gnbtn.TabIndex = 2;
            this.dang_nhap_gnbtn.Text = "Đăng Nhập";
            this.dang_nhap_gnbtn.Click += new System.EventHandler(this.dang_nhap_gnbtn_Click);
            // 
            // mat_khau_gntb
            // 
            this.mat_khau_gntb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mat_khau_gntb.BorderRadius = 10;
            this.mat_khau_gntb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mat_khau_gntb.DefaultText = "";
            this.mat_khau_gntb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.mat_khau_gntb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.mat_khau_gntb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.mat_khau_gntb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.mat_khau_gntb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.mat_khau_gntb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mat_khau_gntb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.mat_khau_gntb.Location = new System.Drawing.Point(53, 204);
            this.mat_khau_gntb.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.mat_khau_gntb.Name = "mat_khau_gntb";
            this.mat_khau_gntb.PlaceholderText = "";
            this.mat_khau_gntb.SelectedText = "";
            this.mat_khau_gntb.Size = new System.Drawing.Size(556, 59);
            this.mat_khau_gntb.TabIndex = 1;
            this.mat_khau_gntb.TextChanged += new System.EventHandler(this.mat_khau_gntb_TextChanged);
            // 
            // ten_tai_khoan_gntb
            // 
            this.ten_tai_khoan_gntb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ten_tai_khoan_gntb.BorderRadius = 10;
            this.ten_tai_khoan_gntb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ten_tai_khoan_gntb.DefaultText = "";
            this.ten_tai_khoan_gntb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ten_tai_khoan_gntb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ten_tai_khoan_gntb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ten_tai_khoan_gntb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ten_tai_khoan_gntb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ten_tai_khoan_gntb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ten_tai_khoan_gntb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ten_tai_khoan_gntb.Location = new System.Drawing.Point(53, 79);
            this.ten_tai_khoan_gntb.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ten_tai_khoan_gntb.Name = "ten_tai_khoan_gntb";
            this.ten_tai_khoan_gntb.PlaceholderText = "";
            this.ten_tai_khoan_gntb.SelectedText = "";
            this.ten_tai_khoan_gntb.Size = new System.Drawing.Size(556, 58);
            this.ten_tai_khoan_gntb.TabIndex = 0;
            // 
            // tieu_de
            // 
            this.tieu_de.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tieu_de.AutoSize = true;
            this.tieu_de.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tieu_de.ForeColor = System.Drawing.Color.White;
            this.tieu_de.Location = new System.Drawing.Point(131, 40);
            this.tieu_de.Name = "tieu_de";
            this.tieu_de.Size = new System.Drawing.Size(563, 42);
            this.tieu_de.TabIndex = 2;
            this.tieu_de.Text = "Phần mềm quản lý siêu thị mini";
            this.tieu_de.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dang_nhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(828, 669);
            this.Controls.Add(this.dn_con);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(774, 453);
            this.Name = "dang_nhap";
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.dn_con.ResumeLayout(false);
            this.dn_con.PerformLayout();
            this.dn.ResumeLayout(false);
            this.dn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel dn_con;
        private Guna.UI2.WinForms.Guna2Panel dn;
        private Guna.UI2.WinForms.Guna2Button dang_nhap_gnbtn;
        private Guna.UI2.WinForms.Guna2TextBox mat_khau_gntb;
        private Guna.UI2.WinForms.Guna2TextBox ten_tai_khoan_gntb;
        private System.Windows.Forms.Label quen_mk;
        private System.Windows.Forms.Label mat_khau_lable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label tieu_de;
    }
}

