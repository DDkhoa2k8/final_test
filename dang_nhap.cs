using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Data.SqlClient;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace final_test
{
    public partial class dang_nhap : Form
    {
        private string conStr;
        private SqlConnection con;
        public bool isQuen = false;

        public dang_nhap()
        {
            InitializeComponent();
            conStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyDb"].ToString();
            con = new SqlConnection(conStr);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dn_con_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void quen_mk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.ten_tai_khoan_gntb.Text))
            {
                MessageBox.Show("Nhập tên tài khoản trước khi đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            isQuen = true;

            //Lay sdt:
            String code = "select SoDienThoai FROM TaiKhoan tk inner join NhanVien nv on tk.MaNhanVien = nv.MaNhanVien where tk.TenDangNhap = @Username";
            con.Open();
            String sdt;

            using (SqlCommand cmd = new SqlCommand(code, con))
            {
                cmd.Parameters.AddWithValue("@Username", this.ten_tai_khoan_gntb.Text);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        sdt = reader["SoDienThoai"].ToString();
                    } else
                    {
                        MessageBox.Show("Tên tài khoản không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        con.Close();
                        return;
                    }
                }
            }

            const string accountSid = "AC98bd52441eb3282f5e32b08b69569490";
            const string authToken = "a18f02c1ccdbc3b9956ff6a838eed0ac";//Hmm, do not use this in production code, it's just for demo purposes.

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Chào bạn từ ứng dụng C#!",
                from: new PhoneNumber("+15715002540"),
                to: new PhoneNumber("+84563381372")
            );

            MessageBox.Show("Mã xác minh đã được gửi đến số điện thoại của bạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DN()
        {
            if (String.IsNullOrEmpty(this.ten_tai_khoan_gntb.Text) || String.IsNullOrEmpty(this.mat_khau_gntb.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            String code = "select count(*) FROM TaiKhoan where TenDangNhap = @Username and MatKhau = @Password";
            con.Open();

            using (SqlCommand cmd = new SqlCommand(code, con))
            {
                cmd.Parameters.AddWithValue("@Username", this.ten_tai_khoan_gntb.Text);
                cmd.Parameters.AddWithValue("@Password", this.mat_khau_gntb.Text);
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    menu mn = new menu();
                    mn.Show();
                    mn.isQuen = isQuen;
                    mn.FormClosed += (s, args) =>
                    {
                        this.Show();
                        this.ten_tai_khoan_gntb.Text = "";
                        this.mat_khau_gntb.Text = "";
                        isQuen = false;
                    };
                    this.Hide();
                    return;
                }
            }

            MessageBox.Show("Đăng nhập thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            con.Close();
        }

        private void DN_QMK()
        {
            
        }

        private void dang_nhap_gnbtn_Click(object sender, EventArgs e)
        {
            if (isQuen)
            {
                DN_QMK();
            } else
            {
                DN();
            }
        }

        private void mat_khau_gntb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
