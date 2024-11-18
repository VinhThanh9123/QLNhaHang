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

namespace Restaurant
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=VINHTHANH\SQLEXPRESS01;Initial Catalog=RM;Integrated Security=True");

        private void btnThem_Click(object sender, EventArgs e)
        {
            string qry = "insert into NHANVIEN ('Mã nhân viên','Tên nhân viên','Mật khẩu',SDT,'Ngày Sinh','Chức vụ',Địa chỉ') values (@MaNV, @TenNV, @MatKhau,@SDT,@NgaySinh, @BoPhan,@DiaChi) ";
            using (con)
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@MaNV", txtMa.Text);
                cmd.Parameters.AddWithValue("@TenNV", txtTen.Text);
                cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Text);
                cmd.Parameters.AddWithValue("@BoPhan", txtChucVu.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm nhân viên thành công!");
                LoadEmployeeData();
                
            }
        }

        private void LoadEmployeeData()
        {
            string qry = "SELECT * FROM Employees";
            using (SqlConnection con = new SqlConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(qry, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dtgv.DataSource = dt;
            }
        }
        #region
        private void txtMa_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtChucVu_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string qry = "delete from NHANVIEN where MaNV=@MaNV";
            using (con)
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@MaNV", txtMa.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa nhân viên thành công!");
                LoadEmployeeData();
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string qry = "update into NHANVIEN ('Mã nhân viên','Tên nhân viên','Mật khẩu',SDT,'Ngày Sinh','Chức vụ',Địa chỉ') values (@MaNV, @TenNV, @MatKhau,@SDT,@NgaySinh, @BoPhan,@DiaChi) ";
            using (con)
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@MaNV", txtMa.Text);
                cmd.Parameters.AddWithValue("@TenNV", txtTen.Text);
                cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Text);
                cmd.Parameters.AddWithValue("@BoPhan", txtChucVu.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm nhân viên thành công!");
                LoadEmployeeData();

            }
        }

        #region
        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
