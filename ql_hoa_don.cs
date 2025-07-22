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

        private void LoadChiTietHoaDon(int maHD)
        {
            dgvHoaDon.Rows.Clear();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT s.TenSanPham, ct.DonGia
                FROM ChiTietHoaDon ct
                JOIN SanPham s ON ct.MaSanPham = s.MaSanPham
                WHERE ct.MaHoaDon = @MaHoaDon";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHD);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string tenSP = reader["TenSanPham"].ToString();
                    decimal donGia = Convert.ToDecimal(reader["DonGia"]);
                    dgvHoaDon.Rows.Add(tenSP, donGia);
                }
                reader.Close();
            }

            TinhTongTien();
        }

        public ql_hoa_don()
        {
            InitializeComponent();
            LoadSanPham();
            LoadMaHoaDon();
            SetupDataGridView();
            cboMaHoaDon.SelectedIndexChanged += cboMaHoaDon_SelectedIndexChanged;
        }
        private void cboMaHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaHoaDon.SelectedValue == null)
                return;

            int maHD = Convert.ToInt32(cboMaHoaDon.SelectedValue);
            LoadChiTietHoaDon(maHD);
        }

        private void info_con_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

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
            SaveChiTietHoaDon();
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
                SaveChiTietHoaDon();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow != null)
            {
                dgvHoaDon.Rows.Remove(dgvHoaDon.CurrentRow);
                TinhTongTien();
                SaveChiTietHoaDon();
            }
        }

        // Hàm tự động lưu chi tiết hóa đơn hiện tại vào DB
        private void SaveChiTietHoaDon()
        {
            if (cboMaHoaDon.SelectedValue == null)
                return;

            int maHD = Convert.ToInt32(cboMaHoaDon.SelectedValue);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand deleteCmd = new SqlCommand("DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @MaHD", con);
                deleteCmd.Parameters.AddWithValue("@MaHD", maHD);
                deleteCmd.ExecuteNonQuery();

                foreach (DataGridViewRow row in dgvHoaDon.Rows)
                {
                    if (row.IsNewRow) continue;

                    string tenSP = row.Cells["TenSP"].Value.ToString();
                    decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value);

                    SqlCommand getMaSP = new SqlCommand("SELECT MaSanPham FROM SanPham WHERE TenSanPham = @TenSP", con);
                    getMaSP.Parameters.AddWithValue("@TenSP", tenSP);
                    int maSP = Convert.ToInt32(getMaSP.ExecuteScalar());

                    SqlCommand insertCmd = new SqlCommand(
                        "INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia) VALUES (@MaHD, @MaSP, @SoLuong, @DonGia)", con);
                    insertCmd.Parameters.AddWithValue("@MaHD", maHD);
                    insertCmd.Parameters.AddWithValue("@MaSP", maSP);
                    insertCmd.Parameters.AddWithValue("@SoLuong", 1);
                    insertCmd.Parameters.AddWithValue("@DonGia", donGia);

                    insertCmd.ExecuteNonQuery();
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (cboMaHoaDon.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để hủy!");
                return;
            }

            int maHD = Convert.ToInt32(cboMaHoaDon.SelectedValue);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE HoaDon SET TrangThai = N'Đã hủy' WHERE MaHoaDon = @MaHoaDon", con);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHD);
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Hóa đơn đã được hủy.");
                    dgvHoaDon.Rows.Clear();
                    lblTongTien.Text = "0 VND";
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn để hủy.");
                }
            }

            LoadMaHoaDon();
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

            lblTongTien.Text = tong.ToString("N0") + " VND";
        }

        private void ql_hoa_don_Load(object sender, EventArgs e)
        {

        }
    }
}