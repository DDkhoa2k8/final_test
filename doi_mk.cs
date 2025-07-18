using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_test
{
    public partial class doi_mk : Form
    {
        public bool isQuen = false;
        public String veriCode;
        public String username;
        private string conStr;
        private SqlConnection con;

        public doi_mk()
        {
            InitializeComponent();
            conStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyDb"].ToString();
            con = new SqlConnection(conStr);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void doi_mk_Load(object sender, EventArgs e)
        {

        }

        private void mat_khau_old_gntb_TextChanged(object sender, EventArgs e)
        {

        }

        private void doi_mk_gnbtn_Click(object sender, EventArgs e)
        {
            if (isQuen)
            {
                if (this.mat_khau_old_gntb.Text != veriCode)
                {
                    MessageBox.Show("Mã xác thực không đúng!");
                    return;
                }

                if (this.mat_khau_gntb.Text != this.repeat_matKhau_gntb.Text)
                {
                    MessageBox.Show("Mật khẩu mới không khớp!");
                    return;
                }

                if (this.mat_khau_old_gntb.Text == this.mat_khau_gntb.Text)
                {
                    MessageBox.Show("Mật khẩu mới không được trùng với mật khẩu cũ!");
                    return;
                }

                con.Open();
                string updateQuery = "UPDATE TaiKhoan SET MatKhau = @newPass";
                SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                updateCmd.Parameters.AddWithValue("@newPass", this.mat_khau_gntb.Text);
                updateCmd.Parameters.AddWithValue("@user", username);

                int rowsAffected = updateCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    con.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại!");
                }
            } else
            {
                string checkQuery = "SELECT COUNT(*) FROM TaiKhoan WHERE MatKhau = @oldPass";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@oldPass", this.mat_khau_old_gntb.Text);

                con.Open();

                int count = (int)checkCmd.ExecuteScalar();

                if (count == 0)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!");
                    con.Close();
                    return;
                }

                if (this.mat_khau_gntb.Text != this.repeat_matKhau_gntb.Text)
                {
                    MessageBox.Show("Mật khẩu mới không khớp!");
                    con.Close();
                    return;
                }

                if (this.mat_khau_old_gntb.Text == this.mat_khau_gntb.Text)
                {
                    MessageBox.Show("Mật khẩu mới không được trùng với mật khẩu cũ!");
                    con.Close();
                    return;
                }

                string updateQuery = "UPDATE TaiKhoan SET MatKhau = @newPass";
                SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                updateCmd.Parameters.AddWithValue("@newPass", this.mat_khau_gntb.Text);
                updateCmd.Parameters.AddWithValue("@user", username);

                int rowsAffected = updateCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    con.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại!");
                }
            }

            con.Close();
        }
    }
}
