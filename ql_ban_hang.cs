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
    public partial class ql_ban_hang : Form
    {
        private int slcRow = -1;
        private string conStr;
        public string username = "dev";
        private decimal tong = 0;
        private void loadSPCB()
        {
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT TenSanPham + '(' + CAST(MaSanPham AS VARCHAR) + ')' as 'TenSanPham' FROM SanPham", con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbsp.Items.Add(reader["TenSanPham"].ToString());
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải sản phẩm: " + ex.Message);
            }
        }

        private void calcTong()
        {
            try
            {
                decimal sum = 0;

                foreach (DataGridViewRow r in dtsp.Rows)
                {
                    // Skip header or empty rows
                    if (r.IsNewRow || r.Cells[2].Value == null || r.Cells[3].Value == null)
                        continue;

                    int soLuong;
                    decimal gia;

                    // TryParse to avoid format exceptions
                    if (int.TryParse(r.Cells[2].Value.ToString(), out soLuong) &&
                        decimal.TryParse(r.Cells[3].Value.ToString(), out gia))
                    {
                        sum += soLuong * gia;
                    }
                }

                tong = sum;

                tongTien.Text = $"Tổng tiền: {sum:N0} VND";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tổng tiền: " + ex.Message);
            }
        }

        public ql_ban_hang()
        {
            InitializeComponent();
            conStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyDb"].ToString();
            loadSPCB();

            // Add columns to dtsp DataGridView
            dtsp.Columns.Clear();
            dtsp.Columns.Add("TenSanPham", "Tên sản phẩm");
            dtsp.Columns.Add("MaSanPham", "Mã sản phẩm");
            dtsp.Columns.Add("SoLuong", "Số lượng");
            dtsp.Columns.Add("Gia", "Giá");
            dtsp.Columns.Add("DonViTinh", "Đơn vị tính");

             dtsp.Rows.Add("Tên sản phẩm", "Mã sản phẩm", "Số lượng", "Giá", "Đơn vị tính");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ql_ban_hang_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dtsp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (0 < e.RowIndex && e.RowIndex < dtsp.RowCount)
                {
                    int rowIndex = e.RowIndex;
                    slcRow = rowIndex;
                    this.soLuong.Value = Convert.ToInt32(dtsp.Rows[rowIndex].Cells[2].Value.ToString());
                } else
                    {
                        slcRow = -1;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn sản phẩm: " + ex.Message);
            }
        }

        private void them_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.soLuong.Value <= 0)
                {
                    MessageBox.Show("Số lượng sản phẩm phải lớn hơn 0!");
                    return;
                }

                if (cbsp.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm.");
                    return;
                }

                string tenSanPham = cbsp.SelectedItem?.ToString().Split('(')[0] ?? "";
                string maSanPham = cbsp.SelectedItem?.ToString().Split('(')[1].Replace(")", "").Trim();
                int soLuongMoi = (int)this.soLuong.Value;
                string donViTinh;
                decimal donGia;

                // Kiểm tra sản phẩm đã có trong danh sách chưa (bỏ qua dòng tiêu đề đầu tiên)
                bool found = false;
                for (int i = 1; i < dtsp.Rows.Count - 1; i++)
                {
                    var row = dtsp.Rows[i];
                    if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == maSanPham)
                    {
                        int soLuongCu = 0;
                        int.TryParse(row.Cells[2].Value?.ToString(), out soLuongCu);
                        row.Cells[2].Value = soLuongCu + soLuongMoi;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    using (SqlConnection con = new SqlConnection(conStr))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("select donViTinh, DonGia from sanPham where maSanPham = @maSP", con);
                        cmd.Parameters.AddWithValue("@maSP", Convert.ToInt32(maSanPham));
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            donViTinh = reader["DonViTinh"].ToString();
                            donGia = Convert.ToDecimal(reader["DonGia"]);
                            dtsp.Rows.Add(tenSanPham, maSanPham, soLuongMoi, donGia, donViTinh);
                        }
                        con.Close();
                    }
                }

                slcRow = dtsp.Rows.Count - 2;
                calcTong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message);
            }
        }

        private void sua_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (slcRow == -1)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!");
                    return;
                }

                if (this.soLuong.Value <= 0)
                {
                    MessageBox.Show("Số lượng sản phẩm phải lớn hơn 0!");
                    return;
                }

                dtsp.Rows[slcRow].Cells[2].Value = this.soLuong.Value;

                calcTong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa sản phẩm: " + ex.Message);
            }
        }

        private void xoa_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (slcRow == -1)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!");
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    dtsp.Rows.RemoveAt(slcRow);
                    slcRow = -1; // Reset selected row index
                }

                calcTong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message);
            }
        }

        private void thanh_toan_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtsp.Rows.Count <= 1)
                {
                    MessageBox.Show("Vui long them san pham");
                    return;
                }

                SqlConnection con = new SqlConnection(conStr);
                con.Open();

                int maNhanVien;

                SqlCommand cmd = new SqlCommand("SELECT nv.MaNhanVien FROM NhanVien nv inner join taiKhoan tk on nv.maNhanVien = tk.maNhanVien WHERE tk.TenDangNhap = @username", con);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    maNhanVien = Convert.ToInt32(reader["MaNhanVien"]);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên!");
                    con.Close();
                    return;
                }

                reader.Close();

                int maHoaDon;
                cmd = new SqlCommand("INSERT INTO HoaDon (TongTien, NgayLap, MaNhanVien, trangThai) VALUES (@tongTien, @ngayLap, @maNV, 'Đã thanh toán'); SELECT SCOPE_IDENTITY();", con);
                cmd.Parameters.AddWithValue("@tongTien", tong);
                cmd.Parameters.AddWithValue("@ngayLap", DateTime.Now);
                cmd.Parameters.AddWithValue("@maNV", maNhanVien);

                maHoaDon = Convert.ToInt32(cmd.ExecuteScalar());

                foreach (DataGridViewRow r in dtsp.Rows.Cast<DataGridViewRow>().Skip(1))
                {
                    cmd = new SqlCommand("INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia) VALUES (@MaHoaDon, @maSP, @SoLuong, @donGia);", con);
                    cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cmd.Parameters.AddWithValue("@maSP", Convert.ToInt32(r.Cells[1].Value));
                    cmd.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(r.Cells[2].Value));
                    cmd.Parameters.AddWithValue("@donGia", Convert.ToDecimal(r.Cells[3].Value));
                    cmd.ExecuteNonQuery();
                }

                con.Close();

                dtsp.Rows.Clear();
                dtsp.Rows.Add("Tên sản phẩm", "Mã sản phẩm", "Số lượng", "Giá", "Đơn vị tính");
                MessageBox.Show("Thanh toán thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thanh toán: " + ex.Message);
            }
        }
    }
}
