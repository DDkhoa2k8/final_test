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
using System.Net;
using System.Net.Mail;

namespace final_test
{
    public partial class dang_nhap : Form
    {
        private string conStr;
        private SqlConnection con;
        public bool isQuen = false;
        public String veriCode;
        private String username_khi_quen;
        private string username;
        private String vaitro;

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

        private void openMenu(String input_vaitro)
        {
            menu mn = new menu();
            mn.Show();
            mn.isQuen = isQuen;
            mn.veriCode = veriCode;
            mn.vaitro = input_vaitro;
            mn.username = username;
            mn.FormClosed += (s, args) =>
            {
                this.Show();
                this.ten_tai_khoan_gntb.Text = "";
                this.mat_khau_gntb.Text = "";
                isQuen = false;
                veriCode = null;
                this.mat_khau_lable.Text = "Mật khẩu:";
                username_khi_quen = null;
            };
            this.Hide();
        }

        private void quen_mk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.ten_tai_khoan_gntb.Text))
            {
                MessageBox.Show("Nhập tên tài khoản trước khi đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            isQuen = true;
            username_khi_quen = this.ten_tai_khoan_gntb.Text;
            this.mat_khau_lable.Text = "Mã xác minh:";

            //Lay sdt:
            String code = "select email, vaitro, tenDangNhap FROM TaiKhoan tk inner join NhanVien nv on tk.MaNhanVien = nv.MaNhanVien where tk.TenDangNhap = @Username";
            con.Open();
            String email;

            using (SqlCommand cmd = new SqlCommand(code, con))
            {
                cmd.Parameters.AddWithValue("@Username", this.ten_tai_khoan_gntb.Text);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        email = reader["email"].ToString();
                        vaitro = reader["vaitro"].ToString();
                        username = reader["tenDangNhap"].ToString();
                    } else
                    {
                        MessageBox.Show("Tên tài khoản không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        con.Close();
                        return;
                    }
                }
            }

            var fromAddress = new MailAddress("ddkmgb999@gmail.com", "Dinh Dang Khoa");
            var toAddress = new MailAddress(email, "");
            const string fromPassword = "inwj tuna xvqq bhwe";
            const string subject = "Mã xác minh.";
            veriCode = Math.Abs(Guid.NewGuid().GetHashCode()).ToString("X").Substring(0, 6);
            string body = "Mã xác minh là: " + veriCode;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

            MessageBox.Show("Mã xác minh đã được gửi đến email của bạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
        }

        private void DN()
        {
            if (String.IsNullOrEmpty(this.ten_tai_khoan_gntb.Text) || String.IsNullOrEmpty(this.mat_khau_gntb.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            String code = "select vaitro, tenDangNhap FROM TaiKhoan where TenDangNhap = @Username and MatKhau = @Password";
            con.Open();

            using (SqlCommand cmd = new SqlCommand(code, con))
            {
                cmd.Parameters.AddWithValue("@Username", this.ten_tai_khoan_gntb.Text);
                cmd.Parameters.AddWithValue("@Password", this.mat_khau_gntb.Text);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) {
                        username = reader["tenDangNhap"].ToString();
                        openMenu(reader["vaitro"].ToString());
                        con.Close();
                        return;
                    }
                }
            }

            MessageBox.Show("Đăng nhập thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            con.Close();
        }

        private void DN_QMK()
        {
            if (String.IsNullOrEmpty(this.ten_tai_khoan_gntb.Text) || String.IsNullOrEmpty(this.mat_khau_gntb.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.ten_tai_khoan_gntb.Text != username_khi_quen)
            {
                MessageBox.Show($"Tên tài khoản được dùng khác với tên tài khoản khi nhấn nút quên mật khẩu là {username_khi_quen}, hãy khởi động lại nếu muốn dùng tài khoản {this.ten_tai_khoan_gntb.Text}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.mat_khau_gntb.Text == veriCode)
            {
                openMenu(vaitro);
            }
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

        private void mat_khau_lable_Click(object sender, EventArgs e)
        {

        }
    }
}