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
    public partial class Search : Form
    {
        string connStr = "server = localhost; database = dbsample; port = 3306; uid = root; pwd = rootAdmin123";
        MySqlConnection conn;

        public Search()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Input User Name to be Searched.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                conn = new MySqlConnection(connStr);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from tbluser where username = '"+txtSearch.Text+"'";
                MySqlDataReader rdr= cmd.ExecuteReader();
                
                if(rdr.Read())
                {
                    conn.Close();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvOutput.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("User Name Not Found.", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
    }
}
