using ATM_Maagement_System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Deposit : Form
    {
        public Deposit()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FRML8TL\sqlexpress;Initial Catalog=ATMmanagementSystem;Integrated Security=True");
        string Acc = Login.AccNumber;
        private void addtransaction()
        {
            string TrType = "Deposit";
            try
            {
                con.Open();
                string query = "insert into TransactionTbl values('" + Acc + "','" + TrType + "'," + DepoAmtTb.Text + ",'" + DateTime.Today.Date.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
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
        private void button1_Click(object sender, EventArgs e)
        {
            if(DepoAmtTb.Text == "" || Convert.ToInt32(DepoAmtTb.Text) <= 0)
            {
                MessageBox.Show("Enter the amount to deposit");
            }
            else
            {
                newBalance = oldbalance + Convert.ToInt32(DepoAmtTb.Text);
                try
                {
                    con.Open();
                    string query = "update AccountTbl set Balance = " + newBalance + " where Accnum ='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Deposit");
                    con.Close();
                    addtransaction();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            home.Show();
            this.Hide();
        }
        int oldbalance, newBalance;
        private void getbalance()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Balance from AccountTbl where Accnum='" + Acc + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            oldbalance = Convert.ToInt32( dt.Rows[0][0].ToString());
            con.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Deposit_Load(object sender, EventArgs e)
        {
            getbalance();
        }
    }
}
