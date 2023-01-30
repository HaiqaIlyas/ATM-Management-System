using ATM_Maagement_System;
using Project;
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

namespace ATM_Maagement_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void label5_Click(object sender, EventArgs e)
        {
            Account acc = new Account();
            acc.Show();
            this.Hide();
        }
        public static string AccNumber;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FRML8TL\sqlexpress;Initial Catalog=ATMmanagementSystem;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from AccountTbl where Accnum='"+AccNumTb.Text+"' and PIN="+pinTb.Text+"",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                AccNumber = AccNumTb.Text;
                HOME home = new HOME();
                home.Show();
                this.Hide();
                con.Close();
            }
            else
            {
                MessageBox.Show("Wrong Account Number or PIN Code");
            }
            con.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
