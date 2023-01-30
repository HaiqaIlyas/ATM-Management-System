using ATM_Maagement_System;
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

namespace Project
{
    public partial class Withdraw : Form
    {
        public Withdraw()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FRML8TL\sqlexpress;Initial Catalog=ATMmanagementSystem;Integrated Security=True");
        string Acc = Login.AccNumber;

        int bal;
        private void getbalance()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Balance from AccountTbl where Accnum='" + Acc + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            balancelbl.Text = "Balance Rs " + dt.Rows[0][0].ToString();
            bal = Convert.ToInt32(dt.Rows[0][0].ToString()); 
            con.Close();
        }
        private void addtransaction()
        {
            string TrType = "WithDraw";
            try
            {
                con.Open();
                string query = "insert into TransactionTbl values('" + Acc + "','" + TrType + "'," + wdamtTb.Text + ",'" + DateTime.Today.Date.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Account Created Successfully");
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
        private void Withdraw_Load(object sender, EventArgs e)
        {
            getbalance();
        }
        int newBalance;
        private void button1_Click(object sender, EventArgs e)
        {
            if(wdamtTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else if(Convert.ToInt32(wdamtTb.Text) <= 0)
            {
                MessageBox.Show("Enter a Valid Amount");
            }
            else if (Convert.ToInt32(wdamtTb.Text) > bal)
            {
                MessageBox.Show("Balance can not be negative");
            }
            else
            {
                try
                {
                    newBalance = bal - Convert.ToInt32(wdamtTb.Text);
                    try
                    {
                        con.Open();
                        string query = "update AccountTbl set Balance = " + newBalance + " where Accnum ='" + Acc + "'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Success Withdraw");
                        con.Close();
                        addtransaction();
                        HOME home = new HOME();
                        home.Show();
                        this.Hide();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            HOME home =new HOME();
            home.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
