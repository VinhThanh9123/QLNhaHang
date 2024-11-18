using System;
using System.Collections;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection con = new SqlConnection(@"Data Source=VINHTHANH\SQLEXPRESS01;Initial Catalog=RM;Integrated Security=True");
        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            try
            {
                con.Open();
                string tk = txtUser.Text;
                string mk = txtPass.Text;
                string sql = "select *from users where username = '" + tk + "' and upass= '" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {
                    
                    this.Hide();
                    frmMain frm = new frmMain();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại tài khoản hoặc mật khẩu đăng nhập!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối" + ex.Message);
            }
            
        }

        //Create property for username
        public static string user;
        public static string USER
        {
            get { return user; }
            private set { user = value; }
        }
        public static int SQL(string qry, Hashtable ht)
        {
            //int res = 0;
            //try
            //{
            //    SqlConnection con = new SqlConnection(@"Data Source=VINHTHANH\SQLEXPRESS01;Initial Catalog=RM;Integrated Security=True"); //Thêm vào
            //    SqlCommand cmd = new SqlCommand(qry, con);
            //    cmd.CommandType = CommandType.Text;
            //    foreach (DictionaryEntry item in ht)
            //    {
            //        cmd.Parameters.AddWithValue(item);
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
            //return res;

            int res = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=VINHTHANH\SQLEXPRESS01;Initial Catalog=RM;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(qry, con))
                    {
                        cmd.CommandType = CommandType.Text;

                        // Duyệt qua các mục trong Hashtable
                        foreach (DictionaryEntry item in ht)
                        {
                            // AddWithValue yêu cầu tên tham số (key) và giá trị (value)
                            cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);

                        }
                        if(con.State == ConnectionState.Closed) { con.Open(); }
                        res = cmd.ExecuteNonQuery();
                        if(con.State == ConnectionState.Open) { con.Close(); }

                        // Mở kết nối và thực thi lệnh SQL
                        con.Open();
                        res = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //con.Close();
            }
            return res;
        }
        //For Loading data from database
        //public static string LoadingData(string qry, DataGridView gv, ListBox lb)
        //{
             
        //}
    }
}
