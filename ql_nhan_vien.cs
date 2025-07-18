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
        string[] admin = { "Quản lý", "dev" };
        public ql_nhan_vien()
        {
            InitializeComponent();
            this.Load += ql_nhan_vien_Load;
            txtTimKiem.TextChanged += guna2TextBox1_TextChanged;
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
                        nv.Email,
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
            txtEmail.Clear();
            cbGioiTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now;
            cbChucVu.SelectedIndex = -1;
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNV.Text) ||
                cbGioiTinh.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                cbChucVu.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtTaiKhoan.Text) ||
                string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO NhanVien (HoTen, GioiTinh, NgaySinh, Email, ChucVu)
                                 VALUES (@TenNV, @GioiTinh, @NgaySinh, @Email, @ChucVu); SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenNV", txtTenNV.Text);
                cmd.Parameters.AddWithValue("@GioiTinh", cbGioiTinh.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@ChucVu", cbChucVu.Text);

                conn.Open();
                int maNV = Convert.ToInt32(cmd.ExecuteScalar());

                query = @"INSERT INTO TaiKhoan (MaNhanVien, TenDangNhap, MatKhau, vaitro)
                                 VALUES (@MaNV, @TaiKhoan, @MatKhau, @vaiTro);";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@TaiKhoan", txtTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                cmd.Parameters.AddWithValue("@vaiTro", (admin.Contains<String>(this.cbChucVu.Text) ? "Admin" : "Nhân viên"));

                cmd.ExecuteScalar();
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
                        Email = @Email, 
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
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
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
                    string query = "DELETE from TaiKhoan where MaNhanVien = @MaNV;DELETE FROM NhanVien WHERE MaNhanVien = @MaNV;";
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

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNhanVien.RowCount - 1)
            {
                txtMaNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
                txtTenNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells["TenNV"].Value.ToString();
                cbGioiTinh.Text = dgvNhanVien.Rows[e.RowIndex].Cells["GioiTinh"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(dgvNhanVien.Rows[e.RowIndex].Cells["NgaySinh"].Value);
                txtEmail.Text = dgvNhanVien.Rows[e.RowIndex].Cells["Email"].Value.ToString();
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

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            TimKiemNhanVien();
        }
        private void TimKiemNhanVien()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string keyword = txtTimKiem.Text.Trim();

                    string query = @"
                SELECT 
                    nv.MaNhanVien AS MaNV,
                    nv.HoTen AS TenNV,
                    nv.GioiTinh,
                    nv.NgaySinh,
                    nv.Email,
                    nv.ChucVu,
                    tk.TenDangNhap AS TenTK,
                    tk.MatKhau
                FROM NhanVien nv
                LEFT JOIN TaiKhoan tk ON nv.MaNhanVien = tk.MaNhanVien
                WHERE
                    nv.HoTen LIKE @TuKhoa OR
                    nv.Email LIKE @TuKhoa OR
                    nv.MaNhanVien LIKE @TuKhoa";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TuKhoa", "%" + keyword + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvNhanVien.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void ql_nhan_vien_Load_1(object sender, EventArgs e)
        {

        }
    }
}
