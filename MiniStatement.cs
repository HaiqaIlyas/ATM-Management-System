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
    public partial class MiniStatement : Form
    {
        public MiniStatement()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FRML8TL\sqlexpress;Initial Catalog=ATMmanagementSystem;Integrated Security=True");
        string Acc = Login.AccNumber;
        private void populate()
        {
            con.Open();
            string query = "Select * from TransactionTbl where AccNum='" + Acc + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ministatementDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void MiniStatement_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            this.Hide();
            home.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
