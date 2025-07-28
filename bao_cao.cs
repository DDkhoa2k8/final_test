using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace final_test
{
    public partial class bao_cao : Form
    {
        public bao_cao()
        {
            InitializeComponent();
        }

        private void ThongKeHoaDon()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            DateTime tuNgay = hsd_dt.Value.Date;
            DateTime denNgay = hsd_dd.Value.Date;

            // Kiểm tra logic ngày tháng
            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày bắt đầu phải trước hoặc bằng ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT MaHoaDon, NgayLap, MaNhanVien, TongTien, Thue, ChietKhau, KhuyenMai, TrangThai
                             FROM HoaDon
                             WHERE NgayLap BETWEEN @TuNgay AND @DenNgay";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvBaoCao.DataSource = dt;

                    // Định dạng cột sau khi load
                    if (dgvBaoCao.Columns.Count > 0)
                    {
                        dgvBaoCao.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        dgvBaoCao.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                        dgvBaoCao.Columns["Thue"].DefaultCellStyle.Format = "P0";
                        dgvBaoCao.Columns["ChietKhau"].DefaultCellStyle.Format = "P0";
                        dgvBaoCao.Columns["KhuyenMai"].DefaultCellStyle.Format = "N0";

                        dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvBaoCao.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn dữ liệu:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThongKe_Click_1(object sender, EventArgs e)
        {
            ThongKeHoaDon();
            guna2ComboBox1_SelectedIndexChanged(null, null);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bao_cao_Load(object sender, EventArgs e)
        {
            hsd_dt.Value = DateTime.Today.AddDays(-7);
            hsd_dd.Value = DateTime.Today;

            guna2ComboBox1.Items.Add("Hóa đơn bán hàng");
            guna2ComboBox1.Items.Add("Khách hàng");
            guna2ComboBox1.Items.Add("Nhân viên");
            guna2ComboBox1.SelectedIndex = 0;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            DateTime tuNgay = hsd_dt.Value.Date;
            DateTime denNgay = hsd_dd.Value.Date;
            string luaChon = guna2ComboBox1.SelectedItem.ToString();
            string query = "";

            switch (luaChon)
            {
                case "Hóa đơn bán hàng":
                    query = @"SELECT hd.MaHoaDon AS [Mã HĐ],
                             hd.NgayLap AS [Ngày lập],
                             sp.TenSanPham AS [Sản phẩm],
                             ct.SoLuong AS [Số lượng],
                             (ct.SoLuong * ct.DonGia) AS [Thành tiền],
                             nv.HoTen AS [Nhân viên]
                      FROM HoaDon hd
                      JOIN ChiTietHoaDon ct ON hd.MaHoaDon = ct.MaHoaDon
                      JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                      JOIN NhanVien nv ON hd.MaNhanVien = nv.MaNhanVien
                      WHERE hd.NgayLap BETWEEN @TuNgay AND @DenNgay";
                    break;

                case "Nhân viên":
                    query = @"SELECT nv.HoTen AS [Nhân viên],
                             COUNT(DISTINCT hd.MaHoaDon) AS [Số hóa đơn],
                             SUM(ct.SoLuong) AS [Tổng sản phẩm bán],
                             SUM(ct.SoLuong * ct.DonGia) AS [Tổng doanh thu]
                      FROM NhanVien nv
                      JOIN HoaDon hd ON nv.MaNhanVien = hd.MaNhanVien
                      JOIN ChiTietHoaDon ct ON hd.MaHoaDon = ct.MaHoaDon
                      WHERE hd.NgayLap BETWEEN @TuNgay AND @DenNgay
                      GROUP BY nv.HoTen";
                    break;

                case "Khách hàng":
                    // Tạm thời lấy thông tin tổng chi tiêu giả định theo mã hóa đơn nếu chưa có bảng KhachHang
                    query = @"SELECT hd.MaHoaDon AS [Mã hóa đơn],
                             COUNT(ct.MaSanPham) AS [Lượt mua],
                             SUM(ct.SoLuong * ct.DonGia) AS [Tổng chi tiêu]
                      FROM HoaDon hd
                      JOIN ChiTietHoaDon ct ON hd.MaHoaDon = ct.MaHoaDon
                      WHERE hd.NgayLap BETWEEN @TuNgay AND @DenNgay
                      GROUP BY hd.MaHoaDon";
                    break;

                default:
                    MessageBox.Show("Lựa chọn không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvBaoCao.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn dữ liệu:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}