using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace Project
{
    public partial class Balance : Form
    {
        public Balance()
        {
            InitializeComponent();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FRML8TL\sqlexpress;Initial Catalog=ATMmanagementSystem;Integrated Security=True");
        private void getbalance()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Balance from AccountTbl where Accnum='" + AccNumbertbl.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Balancetbl.Text = "Rs " +dt.Rows[0][0].ToString();
            con.Close();
        }
        private void Balance_Load(object sender, EventArgs e)
        {
            AccNumbertbl.Text = HOME.AccNumber;
            getbalance();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbl_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            this.Hide();
            home.Show();
        }
    }
}
