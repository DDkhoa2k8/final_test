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
    public partial class ql_ncc : Form
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        public ql_ncc()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.ql_ncc_Load);

        }
        private void ql_ncc_Load(object sender, EventArgs e)
        {
            LoadNhaCungCap();
        }
        private void LoadNhaCungCap()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM NhaCungCap";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvNCC.DataSource = dt;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL khi tải dữ liệu: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khác: " + ex.Message);
            }
        }

        private void them_btn_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO NhaCungCap (TenNhaCungCap, DiaChi, SoDienThoai, Email) 
                                     VALUES (@Ten, @DiaChi, @SDT, @Email)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        AddParameters(cmd);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("✅ Thêm nhà cung cấp thành công!");
                        LoadNhaCungCap();
                        ClearFields();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Lỗi SQL khi thêm: " + ex.Message);
            }
        }
        private void sua_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa.");
                return;
            }

            if (!ValidateInput()) return;

            if (MessageBox.Show("Bạn có chắc muốn cập nhật nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE NhaCungCap SET 
                                     TenNhaCungCap = @Ten, DiaChi = @DiaChi, 
                                     SoDienThoai = @SDT, Email = @Email 
                                     WHERE MaNhaCungCap = @Ma";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ma", txtMa.Text.Trim());
                        AddParameters(cmd);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("✅ Cập nhật thành công!");
                        LoadNhaCungCap();
                        ClearFields();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Lỗi SQL khi sửa: " + ex.Message);
            }
        }

        private void xoa_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text))
            {
                MessageBox.Show("⚠️ Vui lòng chọn nhà cung cấp cần xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa nhà cung cấp này cùng với dữ liệu liên quan?",
                                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Bước 1: Xóa dữ liệu liên quan trong bảng ChiTietNhap
                    string queryChild = "DELETE FROM ChiTietNhap WHERE MaNhaCungCap = @Ma";
                    using (SqlCommand cmdChild = new SqlCommand(queryChild, conn))
                    {
                        cmdChild.Parameters.AddWithValue("@Ma", txtMa.Text.Trim());
                        cmdChild.ExecuteNonQuery();
                    }

                    // Bước 2: Xóa nhà cung cấp trong bảng NhaCungCap
                    string queryParent = "DELETE FROM NhaCungCap WHERE MaNhaCungCap = @Ma";
                    using (SqlCommand cmdParent = new SqlCommand(queryParent, conn))
                    {
                        cmdParent.Parameters.AddWithValue("@Ma", txtMa.Text.Trim());
                        cmdParent.ExecuteNonQuery();
                    }

                    MessageBox.Show("✅ Đã xóa nhà cung cấp và dữ liệu liên quan thành công!");
                    LoadNhaCungCap();
                    ClearFields();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Lỗi SQL khi xóa: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khác: " + ex.Message);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string keyword = txtTimKiem.Text.Trim().ToLower();
                    string query = "SELECT * FROM NhaCungCap WHERE LOWER(TenNhaCungCap) LIKE @TuKhoa";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TuKhoa", "%" + keyword + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvNCC.DataSource = dt;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Lỗi SQL khi tìm kiếm: " + ex.Message);
            }
        }

        private void dgvNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvNCC.Rows[e.RowIndex].Cells["MaNhaCungCap"].Value != null)
            {
                DataGridViewRow row = dgvNCC.Rows[e.RowIndex];
                txtMa.Text = row.Cells["MaNhaCungCap"].Value.ToString();
                txtTen.Text = row.Cells["TenNhaCungCap"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
            }
        }
        private void ClearFields()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtTen.Focus();
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text) ||
                            string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                            string.IsNullOrWhiteSpace(txtSDT.Text) ||
                            string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("⚠️ Vui lòng điền đầy đủ thông tin.");
                return false;
            }

            if (!long.TryParse(txtSDT.Text, out _) || txtSDT.Text.Length < 8)
            {
                MessageBox.Show("⚠️ Số điện thoại không hợp lệ.");
                return false;
            }

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("⚠️ Email không hợp lệ.");
                return false;
            }

            return true;
        }
        private void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Ten", txtTen.Text.Trim());
            cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
            cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
        }

        private void ql_ncc_Load_1(object sender, EventArgs e)
        {

        }
    }
}
