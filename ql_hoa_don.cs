using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
<<<<<<< HEAD
=======
using System.Data.SqlTypes;
>>>>>>> 71159ac18c6e56ad175663b071c9e2727ec5bab2
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_test
{
    public partial class ql_hoa_don : Form
    {
<<<<<<< HEAD
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
=======
        // Connection string to your database
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        private DataTable dtSanPhamTrongHoaDon = new DataTable();
        private int selectedRowIndex = -1;

>>>>>>> 71159ac18c6e56ad175663b071c9e2727ec5bab2
        public ql_hoa_don()
        {
            InitializeComponent();
            LoadSanPham();
            LoadMaHoaDon();
            SetupDataGridView();
        }

        // In your Form's Load event handler, add:
        private void ql_hoa_don_Load(object sender, EventArgs e)
        {
            LoadMaHoaDon();
            LoadSanPham();
            //cboMaHoaDon.SelectedIndexChanged += cboMaHoaDon_SelectedIndexChanged;
            dgvHoaDon.CellClick += dgvHoaDon_CellClick;
            //btnThem.Click += btnThem_Click;
            //btnSua.Click += btnSua_Click;
            //btnXoa.Click += btnXoa_Click;
            btnHuy.Click += btnHuy_Click;
            cboSanPham.SelectedIndex = -1;
            cboMaHoaDon.SelectedIndex = -1;
        }

        // Load all MaHoaDon into cboMaHoaDon
        private void LoadMaHoaDon()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaHoaDon FROM HoaDon", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cboMaHoaDon.DataSource = dt;
                cboMaHoaDon.DisplayMember = "MaHoaDon";
                cboMaHoaDon.ValueMember = "MaHoaDon";
                cboMaHoaDon.SelectedIndex = -1;
            }
        }

        // When MaHoaDon is selected, load products in invoice
        private void cboMaHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaHoaDon.SelectedIndex >= 0)
            {
                string maHD = ((DataRowView)cboMaHoaDon.SelectedItem)["MaHoaDon"].ToString();
                LoadSanPhamTrongHoaDon(maHD);
                UpdateTongTien(maHD);
            }
            else
            {
                dgvHoaDon.DataSource = null;
                lblTongTien.Text = "Tổng tiền(VND):";
            }
        }

        // Load products in invoice into dgvHoaDon
        private void LoadSanPhamTrongHoaDon(string maHD)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT cthd.MaSanPham, sp.TenSanPham, cthd.SoLuong, cthd.DonGia, (cthd.SoLuong * cthd.DonGia) AS ThanhTien " +
                    "FROM ChiTietHoaDon cthd " +
                    "JOIN SanPham sp ON cthd.MaSanPham = sp.MaSanPham " +
                    "WHERE cthd.MaHoaDon = @MaHoaDon", con);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHD);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvHoaDon.DataSource = dt;
            }
        }

        // Helper: Update total amount label
        private void UpdateTongTien(string maHD)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT ISNULL(SUM(SoLuong * DonGia), 0) FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon", con);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHD);
                object result = cmd.ExecuteScalar();
                lblTongTien.Text = $"Tổng tiền(VND): {result:N0}";
            }
        }

        // Add product to invoice
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboMaHoaDon.SelectedIndex < 0 || cboSanPham.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn và sản phẩm.");
                return;
            }
            string maHD = cboMaHoaDon.SelectedValue.ToString();
            string maSP = cboSanPham.SelectedValue.ToString();
            int soLuong = (int)soLuongNum.Value;
            if (soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0.");
                return;
            }
            decimal donGia = LayDonGiaSanPham(maSP);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                // Check if product already exists in invoice
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon AND MaSanPham = @MaSanPham", con);
                checkCmd.Parameters.AddWithValue("@MaHoaDon", maHD);
                checkCmd.Parameters.AddWithValue("@MaSanPham", maSP);
                int exists = (int)checkCmd.ExecuteScalar();
                if (exists > 0)
                {
                    // Update quantity if exists
                    SqlCommand updateCmd = new SqlCommand(
                        "UPDATE ChiTietHoaDon SET SoLuong = SoLuong + @SoLuong WHERE MaHoaDon = @MaHoaDon AND MaSanPham = @MaSanPham", con);
                    updateCmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    updateCmd.Parameters.AddWithValue("@MaHoaDon", maHD);
                    updateCmd.Parameters.AddWithValue("@MaSanPham", maSP);
                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    // Insert new
                    SqlCommand insertCmd = new SqlCommand(
                        "INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia) VALUES (@MaHoaDon, @MaSanPham, @SoLuong, @DonGia)", con);
                    insertCmd.Parameters.AddWithValue("@MaHoaDon", maHD);
                    insertCmd.Parameters.AddWithValue("@MaSanPham", maSP);
                    insertCmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    insertCmd.Parameters.AddWithValue("@DonGia", donGia);
                    insertCmd.ExecuteNonQuery();
                }
            }
            LoadSanPhamTrongHoaDon(maHD);
            UpdateTongTien(maHD);
        }

        // Helper: Get DonGia for a product
        private decimal LayDonGiaSanPham(string maSP)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DonGia FROM SanPham WHERE MaSanPham = @MaSanPham", con);
                cmd.Parameters.AddWithValue("@MaSanPham", maSP);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToDecimal(result) : 0;
            }
        }

        // When a row is selected in dgvHoaDon, populate cboSanPham and soLuongNum
        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 || e.RowIndex < dgvHoaDon.RowCount - 1)
            {
                selectedRowIndex = e.RowIndex;
                var row = dgvHoaDon.Rows[e.RowIndex];
                string maSP = row.Cells["MaSanPham"].Value.ToString();
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                cboSanPham.SelectedValue = maSP;
                soLuongNum.Value = soLuong > soLuongNum.Maximum ? soLuongNum.Maximum : soLuong;
            }
        }

        // Edit selected product in invoice
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0 || cboMaHoaDon.SelectedIndex < 0 || cboSanPham.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để sửa.");
                return;
            }
            string maHD = cboMaHoaDon.SelectedValue.ToString();
            string maSP = cboSanPham.SelectedValue.ToString();
            int soLuong = (int)soLuongNum.Value;
            if (soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0.");
                return;
            }
            decimal donGia = LayDonGiaSanPham(maSP);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE ChiTietHoaDon SET SoLuong = @SoLuong, DonGia = @DonGia WHERE MaHoaDon = @MaHoaDon AND MaSanPham = @MaSanPham", con);
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                cmd.Parameters.AddWithValue("@DonGia", donGia);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHD);
                cmd.Parameters.AddWithValue("@MaSanPham", maSP);
                cmd.ExecuteNonQuery();
            }
            LoadSanPhamTrongHoaDon(maHD);
            UpdateTongTien(maHD);
        }

        // Delete selected product from invoice
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0 || cboMaHoaDon.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.");
                return;
            }
            string maHD = cboMaHoaDon.SelectedValue.ToString();
            string maSP = dgvHoaDon.Rows[selectedRowIndex].Cells["MaSanPham"].Value.ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon AND MaSanPham = @MaSanPham", con);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHD);
                cmd.Parameters.AddWithValue("@MaSanPham", maSP);
                cmd.ExecuteNonQuery();
            }
            LoadSanPhamTrongHoaDon(maHD);
            UpdateTongTien(maHD);
        }

        // Cancel invoice (set TrangThai = 'Đã hủy')
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (cboMaHoaDon.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để hủy.");
                return;
            }
            string maHD = cboMaHoaDon.SelectedValue.ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE HoaDon SET TrangThai = N'Đã hủy' WHERE MaHoaDon = @MaHoaDon", con);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHD);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Hóa đơn đã được hủy.");
            LoadMaHoaDon();
            dgvHoaDon.DataSource = null;
            lblTongTien.Text = "Tổng tiền(VND):";
        }

        // Load all SanPham into cboSanPham
        private void LoadSanPham()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaSanPham, TenSanPham FROM SanPham", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cboSanPham.DataSource = dt;
                cboSanPham.DisplayMember = "TenSanPham";
                cboSanPham.ValueMember = "MaSanPham";
                cboSanPham.SelectedIndex = -1;
            }
        }

        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm trong hóa đơn!");
                return;
            }

            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                tongTien += Convert.ToDecimal(row.Cells["DonGia"].Value);
            }

            decimal khuyenMai = 0;
            if (txtKhuyenMai.Text.Contains("%"))
                txtKhuyenMai.Text = txtKhuyenMai.Text.Replace("%", "");

            if (decimal.TryParse(txtKhuyenMai.Text, out decimal km))
            {
                khuyenMai = km;
            }

            decimal thanhTienSauKM = tongTien * (1 - (khuyenMai / 100));
            decimal thue = thanhTienSauKM * 0.1m; // 10% thuế
            decimal chietKhau = 0; // tuỳ ý

            int maHoaDonMoi = -1;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // 1. Thêm hóa đơn
                string queryHD = @"INSERT INTO HoaDon (NgayLap, TongTien, Thue, ChietKhau, KhuyenMai) 
                           VALUES (GETDATE(), @TongTien, @Thue, @ChietKhau, @KhuyenMai);
                           SELECT SCOPE_IDENTITY();";

                SqlCommand cmdHD = new SqlCommand(queryHD, con);
                cmdHD.Parameters.AddWithValue("@TongTien", thanhTienSauKM + thue);
                cmdHD.Parameters.AddWithValue("@Thue", thue);
                cmdHD.Parameters.AddWithValue("@ChietKhau", chietKhau);
                cmdHD.Parameters.AddWithValue("@KhuyenMai", khuyenMai);

                maHoaDonMoi = Convert.ToInt32(cmdHD.ExecuteScalar());

                // 2. Thêm chi tiết hóa đơn
                foreach (DataGridViewRow row in dgvHoaDon.Rows)
                {
                    int maSP = Convert.ToInt32(row.Cells["MaSP"].Value);
                    decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value);

                    string queryCT = @"INSERT INTO ChiTietHoaDon (MaHoaDon, TenSP, DonGia) 
                   VALUES (@MaHoaDon, @TenSP, @DonGia)";
                    SqlCommand cmdCT = new SqlCommand(queryCT, con);
                    cmdCT.Parameters.AddWithValue("@MaHoaDon", maHoaDonMoi);
                    cmdCT.Parameters.AddWithValue("@TenSP", row.Cells["TenSP"].Value);
                    cmdCT.Parameters.AddWithValue("@DonGia", row.Cells["DonGia"].Value);
                    cmdCT.ExecuteNonQuery();

                }

                MessageBox.Show($"Thanh toán thành công! Mã hóa đơn: {maHoaDonMoi}");
            }

            // Reset sau khi thanh toán
            dgvHoaDon.Rows.Clear();
            txtKhuyenMai.Text = "0%";
            lblTongTien.Text = "0 VND";
            LoadMaHoaDon(); // Cập nhật combobox mã hóa đơn
        }
        private void LoadSanPham()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT MaSanPham, TenSanPham FROM SanPham";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboSanPham.DataSource = dt;
                cboSanPham.DisplayMember = "TenSanPham";
                cboSanPham.ValueMember = "MaSanPham";
            }
        }


        private void LoadMaHoaDon()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT MaHoaDon FROM HoaDon";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboMaHoaDon.DataSource = dt;
                cboMaHoaDon.DisplayMember = "MaHoaDon";
                cboMaHoaDon.ValueMember = "MaHoaDon";
            }
        }
        private void SetupDataGridView()
        {
            dgvHoaDon.Columns.Clear();
            dgvHoaDon.Columns.Add("TenSP", "Tên SP");
            dgvHoaDon.Columns.Add("DonGia", "Đơn giá");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenSP = cboSanPham.Text;
            decimal donGia = LayDonGiaSanPham(Convert.ToInt32(cboSanPham.SelectedValue));

            dgvHoaDon.Rows.Add(tenSP, donGia);
            TinhTongTien();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow != null)
            {
                string tenSP = cboSanPham.Text;
                decimal donGia = LayDonGiaSanPham(Convert.ToInt32(cboSanPham.SelectedValue));

                dgvHoaDon.CurrentRow.Cells["TenSP"].Value = tenSP;
                dgvHoaDon.CurrentRow.Cells["DonGia"].Value = donGia;

                TinhTongTien();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow != null)
            {
                dgvHoaDon.Rows.Remove(dgvHoaDon.CurrentRow);
                TinhTongTien();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dgvHoaDon.Rows.Clear();
            lblTongTien.Text = "0 VND";
            txtKhuyenMai.Text = "0%";
        }
        private decimal LayDonGiaSanPham(int maSP)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DonGia FROM SanPham WHERE MaSP = @MaSP", con);
                cmd.Parameters.AddWithValue("@MaSP", maSP);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToDecimal(result) : 0;
            }
        }
        private void TinhTongTien()
        {
            decimal tong = 0;

            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.Cells["DonGia"].Value != null)
                {
                    tong += Convert.ToDecimal(row.Cells["DonGia"].Value);
                }
            }

            decimal khuyenMai = 1.0m;
            if (txtKhuyenMai.Text.Contains("%"))
                txtKhuyenMai.Text = txtKhuyenMai.Text.Replace("%", "");

            if (decimal.TryParse(txtKhuyenMai.Text, out decimal km))
            {
                khuyenMai = (100 - km) / 100;
            }

            decimal tongSauKM = tong * khuyenMai;
            lblTongTien.Text = tongSauKM.ToString("N0") + " VND";
        }
        private decimal ParseKhuyenMai()
        {
            string text = txtKhuyenMai.Text.Replace("%", "").Trim();
            if (decimal.TryParse(text, out decimal km))
                return km;
            return 0;
        }

        private void txtKhuyenMai_TextChanged(object sender, EventArgs e)
        {
            decimal khuyenMai = ParseKhuyenMai();
        }
    }
}