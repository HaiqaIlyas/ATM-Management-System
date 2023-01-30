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
using ATM_Maagement_System;

namespace Project
{
    public partial class ChangePin : Form
    {
        public ChangePin()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FRML8TL\sqlexpress;Initial Catalog=ATMmanagementSystem;Integrated Security=True");
        string Acc = Login.AccNumber;
        private void button1_Click(object sender, EventArgs e)
        {
            if (pin1Tb.Text == "" || pin2Tb.Text == "")
            {
                MessageBox.Show("Enter And Confirm TheNew Pin");
            }
            else if(pin2Tb.Text != pin1Tb.Text)
            {
                MessageBox.Show("Pin1 And Pin2 are Different");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update AccountTbl set Pin = " + pin1Tb.Text + " where Accnum ='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PIN Successfully Updated");
                    con.Close();
                    Login home = new Login();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            home.Show();
            this.Hide();
        }
    }
}
