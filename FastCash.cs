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
    public partial class FastCash : Form
    {
        public FastCash()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            home.Show();
            this.Hide();
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
        private void FastCash_Load(object sender, EventArgs e)
        {
            getbalance();
        }
        private void addtransaction1()
        {
            string TrType = "WithDraw";
            try
            {
                con.Open();
                string query = "insert into TransactionTbl values('" + Acc + "','" + TrType + "'," + 100 + ",'" + DateTime.Today.Date.ToString() + "')";
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
        private void addtransaction2()
        {
            string TrType = "WithDraw";
            try
            {
                con.Open();
                string query = "insert into TransactionTbl values('" + Acc + "','" + TrType + "'," +500 + ",'" + DateTime.Today.Date.ToString() + "')";
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
        private void addtransaction3()
        {
            string TrType = "WithDraw";
            try
            {
                con.Open();
                string query = "insert into TransactionTbl values('" + Acc + "','" + TrType + "'," + 1000 + ",'" + DateTime.Today.Date.ToString() + "')";
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
        private void addtransaction4()
        {
            string TrType = "WithDraw";
            try
            {
                con.Open();
                string query = "insert into TransactionTbl values('" + Acc + "','" + TrType + "'," + 2000 + ",'" + DateTime.Today.Date.ToString() + "')";
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
        private void addtransaction5()
        {
            string TrType = "WithDraw";
            try
            {
                con.Open();
                string query = "insert into TransactionTbl values('" + Acc + "','" + TrType + "'," + 5000 + ",'" + DateTime.Today.Date.ToString() + "')";
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
        private void addtransaction6()
        {
            string TrType = "WithDraw";
            try
            {
                con.Open();
                string query = "insert into TransactionTbl values('" + Acc + "','" + TrType + "'," + 10000 + ",'" + DateTime.Today.Date.ToString() + "')";
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (bal < 100)
            {
                MessageBox.Show("Balance Can Not Be Negative");
            }
            else
            {
                int newBalance = bal - 100;
                try
                {
                    con.Open();
                    string query = "update AccountTbl set Balance = " + newBalance + " where Accnum ='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    con.Close();
                    addtransaction1();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bal < 500)
            {
                MessageBox.Show("Balance Can Not Be Negative");
            }
            else
            {
                int newBalance = bal - 500;
                try
                {
                    con.Open();
                    string query = "update AccountTbl set Balance = " + newBalance + " where Accnum ='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    con.Close();
                    addtransaction2();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bal < 1000)
            {
                MessageBox.Show("Balance Can Not Be Negative");
            }
            else
            {
                int newBalance = bal - 1000;
                try
                {
                    con.Open();
                    string query = "update AccountTbl set Balance = " + newBalance + " where Accnum ='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    con.Close();
                    addtransaction3();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bal < 2000)
            {
                MessageBox.Show("Balance Can Not Be Negative");
            }
            else
            {
                int newBalance = bal - 2000;
                try
                {
                    con.Open();
                    string query = "update AccountTbl set Balance = " + newBalance + " where Accnum ='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    con.Close();
                    addtransaction4();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bal < 5000)
            {
                MessageBox.Show("Balance Can Not Be Negative");
            }
            else
            {
                int newBalance = bal - 5000;
                try
                {
                    con.Open();
                    string query = "update AccountTbl set Balance = " + newBalance + " where Accnum ='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    con.Close();
                    addtransaction5();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (bal < 10000)
            {
                MessageBox.Show("Balance Can Not Be Negative");
            }
            else
            {
                int newBalance = bal - 10000;
                try
                {
                    con.Open();
                    string query = "update AccountTbl set Balance = " + newBalance + " where Accnum ='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    con.Close();
                    addtransaction6();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
