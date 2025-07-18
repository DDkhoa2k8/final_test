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
    public partial class ql_danh_muc : Form
    {
        public ql_danh_muc()
        {
            InitializeComponent();
        }

        private string conectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDb"].ToString();

        private void ql_danh_muc_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
        }
        private void LoadDanhMuc()
        {
            using (SqlConnection hienthi = new SqlConnection(conectionString))
            {
                hienthi.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM DanhMuc", hienthi);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvdanhmuc.DataSource = dt;
            }
        }


        private void them_btn_Click(object sender, EventArgs e)
        {
            using (SqlConnection them = new SqlConnection(conectionString))
            {
                them.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO DanhMuc (TenDanhMuc) VALUES (@TenDanhMuc)", them);
                cmd.Parameters.AddWithValue("@TenDanhMuc", ten_danh_muc_tb.Text);
            

                int them1 = cmd.ExecuteNonQuery();


                if (them1 > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadDanhMuc(); // Cập nhật lại danh sách danh mục
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.");
                }
            }
            LoadDanhMuc();
        }

        private void sua_btn_Click(object sender, EventArgs e)
        {
            using (SqlConnection sua = new SqlConnection(conectionString))
            {
                sua.Open();

                SqlCommand cmd = new SqlCommand("UPDATE DanhMuc SET TenDanhMuc = @tendanhmuc WHERE MaDanhMuc = @madanhmuc", sua);

                cmd.Parameters.AddWithValue("@tendanhmuc", ten_danh_muc_tb.Text); // textbox nhập tên danh mục mới
                cmd.Parameters.AddWithValue("@madanhmuc", ma_danh_muc_tb.Text);

                try
                {
                    int c = cmd.ExecuteNonQuery();

                    if (c > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy để cập nhật.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                }
                LoadDanhMuc();
            }
        }

        private void xoa_btn_Click(object sender, EventArgs e)
        {
            using (SqlConnection xoa = new SqlConnection(conectionString))
            {
                xoa.Open();
                string xoaQuery = "DELETE FROM DanhMuc WHERE MaDanhMuc = @madanhmuc";
                SqlCommand cmd = new SqlCommand(xoaQuery, xoa);
                cmd.Parameters.AddWithValue("@madanhmuc", ma_danh_muc_tb.Text);
                int c;

                try
                {
                    c = cmd.ExecuteNonQuery();
                    if (c > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                    }
                    else
                    {
                        MessageBox.Show("xóa thất bại");
                    }
                }
                catch { 
                    MessageBox.Show("Không thể xóa danh mục này vì nó đang được sử dụng trong các sản phẩm khác.");
                }
            }
            LoadDanhMuc();
        }

        private void dgvdanhmuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvdanhmuc.Rows.Count)
            {
                DataGridViewRow row = dgvdanhmuc.Rows[e.RowIndex];
                ten_danh_muc_tb.Text = row.Cells["TenDanhMuc"].Value.ToString();
                ma_danh_muc_tb.Text = row.Cells["Madanhmuc"].Value.ToString();
            }
        }

        private void tim_tb_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tim_tb.Text))
            {
                LoadDanhMuc();
                return;
            }

            using (SqlConnection hienthi = new SqlConnection(conectionString))
            {
                hienthi.Open();
                string keyword = tim_tb.Text;

                string query = "SELECT * FROM DanhMuc WHERE TenDanhMuc LIKE @keyword or Madanhmuc like @keyword";
                SqlCommand cmd = new SqlCommand(query, hienthi);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvdanhmuc.DataSource = dt;
            }
        }
    }
}
