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
    public partial class ql_nhan_vien : Form
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        public ql_nhan_vien()
        {
            InitializeComponent();
            this.Load += ql_nhan_vien_Load;
        }
        private void ql_nhan_vien_Load(object sender, EventArgs e)
        {
            cbGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" });
            cbChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadData();
            LoadChucVu();
        }
        void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT 
                nv.MaNhanVien AS MaNV,
                nv.HoTen AS TenNV,
                nv.GioiTinh,
                nv.NgaySinh,
                nv.SoDienThoai AS SoDienThoai,
                nv.ChucVu,
                tk.TenDangNhap AS TenTK,
                tk.MatKhau
            FROM NhanVien nv
            LEFT JOIN TaiKhoan tk ON nv.MaNhanVien = tk.MaNhanVien";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvNhanVien.DataSource = dt;
            }
        }
        void ClearInput()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSDT.Clear();
            cbGioiTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now;
            cbChucVu.SelectedIndex = -1;
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNV.Text) || cbGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO NhanVien (HoTen, GioiTinh, NgaySinh, SoDienThoai, ChucVu)
                         VALUES (@TenNV, @GioiTinh, @NgaySinh, @SoDienThoai, @ChucVu)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenNV", txtTenNV.Text);
                cmd.Parameters.AddWithValue("@GioiTinh", cbGioiTinh.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@SoDienThoai", txtSDT.Text);
                cmd.Parameters.AddWithValue("@ChucVu", cbChucVu.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                LoadData();
                ClearInput();
                MessageBox.Show("Đã thêm nhân viên.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                                 UPDATE NhanVien SET 
                                 HoTen = @TenNV, 
                                GioiTinh = @GioiTinh, 
                                SoDienThoai = @SoDienThoai, 
                                NgaySinh = @NgaySinh, 
                                ChucVu = @ChucVu 
                            WHERE MaNhanVien = @MaNV;

                            UPDATE TaiKhoan SET 
                                TenDangNhap = @TaiKhoan, 
                                MatKhau = @MatKhau 
                            WHERE MaNhanVien = @MaNV;";


                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@TenNV", txtTenNV.Text);
                cmd.Parameters.AddWithValue("@GioiTinh", cbGioiTinh.Text);
                cmd.Parameters.AddWithValue("@SoDienThoai", txtSDT.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@ChucVu", cbChucVu.Text);
                cmd.Parameters.AddWithValue("@TaiKhoan", txtTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                LoadData();
                ClearInput();
                MessageBox.Show("Đã cập nhật nhân viên.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận xoá nhân viên?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNV";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    LoadData();
                    ClearInput();
                    MessageBox.Show("Đã xoá nhân viên.");
                }
            }
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
                txtTenNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells["TenNV"].Value.ToString();
                cbGioiTinh.Text = dgvNhanVien.Rows[e.RowIndex].Cells["GioiTinh"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(dgvNhanVien.Rows[e.RowIndex].Cells["NgaySinh"].Value);
                txtSDT.Text = dgvNhanVien.Rows[e.RowIndex].Cells["SoDienThoai"].Value.ToString();
                cbChucVu.Text = dgvNhanVien.Rows[e.RowIndex].Cells["ChucVu"].Value.ToString();
                txtTaiKhoan.Text = dgvNhanVien.Rows[e.RowIndex].Cells["TenTK"].Value?.ToString() ?? "";
                txtMatKhau.Text = dgvNhanVien.Rows[e.RowIndex].Cells["MatKhau"].Value?.ToString() ?? "";
            }
        }
        void LoadChucVu()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT ChucVu FROM NhanVien", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                cbChucVu.Items.Clear();
                while (reader.Read())
                {
                    cbChucVu.Items.Add(reader["ChucVu"].ToString());
                }
            }
        }
    }
}
