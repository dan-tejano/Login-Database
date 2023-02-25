using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DATABASE
{
    public partial class Login : Form
    {
        string connStr = "server = localhost; database = dbsample; port = 3306; uid = root; pwd = rootAdmin123";
        MySqlConnection conn;
       
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // if textbox is empty
            if (string.IsNullOrWhiteSpace(txtUname.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Input User Name and Password.", "Input!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // if textbox has text 
            else
            {
                conn = new MySqlConnection(connStr);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from tbluser where username = '" + txtUname.Text + "' and password = '" + txtPass.Text + "'";
                MySqlDataReader rdr = cmd.ExecuteReader();

                // if user searched
                if (rdr.HasRows)
                {
                    rdr.Read();
                    MessageBox.Show("Login Successful!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    Search search = new Search();
                    search.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("User Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            }
        
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUname.Clear();
            txtPass.Clear();
        }

        private void lblCreate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateAcc create = new CreateAcc();
            create.Show();
            this.Hide();
        }

        
    }
}
