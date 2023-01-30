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
using Project;

namespace ATM_Maagement_System
{
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }
SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FRML8TL\sqlexpress;Initial Catalog=ATMmanagementSystem;Integrated Security=True");

        private void label13_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int bal = 0;
            if (AccNametb.Text == "" || AccNumTb.Text == "" || FanameTb.Text == "" || Phonetb.Text == "" || Addresstb.Text == "" || occupationtb.Text == "" || pintb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into AccountTbl values('" + AccNumTb.Text + "','" + AccNametb.Text + "','" + FanameTb.Text + "','" + dobdate.Value.Date + "','" + Phonetb.Text + "','" + Addresstb.Text + "','" + educationcb.SelectedItem.ToString() + "','" + occupationtb.Text + "'," + pintb.Text + "," + bal + ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Created Successfully");
                    con.Close();
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
