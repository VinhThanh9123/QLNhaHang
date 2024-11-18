using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
            Instance = this;
        }

        public frmMain Instance { get; }


        //Methood to add Controls in Main Form
        public void AddControls(Form f) //public static
        {
            ControlsPanel.Controls.Clear();  
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            ControlsPanel.Controls.Add(f);
            f.Show();
        }
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUser.Text = Form1.USER;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AddControls(new frmHome());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.Show();
        }
    }
}
