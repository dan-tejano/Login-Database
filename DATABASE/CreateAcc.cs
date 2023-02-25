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
    public partial class CreateAcc : Form
    {
        string connStr = "server = localhost; database = dbsample; port = 3306; uid = root; pwd = rootAdmin123";
        MySqlConnection conn;

        public CreateAcc()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(btnCreate.Text) || string.IsNullOrWhiteSpace(cmbRole.Text) || string.IsNullOrWhiteSpace(txtPass.Text) || string.IsNullOrWhiteSpace(txtCPass.Text))
            {
                MessageBox.Show("Input User Name and Password.", "Input!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (txtPass.Text != txtCPass.Text)
                {
                    MessageBox.Show("Password Do Not Match.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn = new MySqlConnection(connStr);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO `dbsample`.`tbluser` (`username`, `role` ,`password`) VALUES ('" + txtUname.Text + "', '" +cmbRole.SelectedItem+ "' ,'" + txtPass.Text + "')";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Account Created Successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    Login login = new Login();
                    login.Show();
                    this.Close();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUname.Clear();
            txtPass.Clear();
            txtCPass.Clear();
            cmbRole.Items.Clear();
        }
    }
}
