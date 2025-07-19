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
    public partial class ql_hoa_don : Form
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        public ql_hoa_don()
        {
            InitializeComponent();
            LoadSanPham();
            LoadMaHoaDon();
            SetupDataGridView();
        }

        private void info_con_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
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

        private void ql_hoa_don_Load(object sender, EventArgs e)
        {

        }
    }
}