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
            String code = "select email FROM TaiKhoan tk inner join NhanVien nv on tk.MaNhanVien = nv.MaNhanVien where tk.TenDangNhap = @Username";
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
                    } else
                    {
                        MessageBox.Show("Tên tài khoản không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        con.Close();
                        return;
                    }
                }
            }
            


            MessageBox.Show(email);
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
