using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Register
{
    public partial class Login : Form
    {
        string connectionString = connectionDB.connectionString;

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            //User dashboard = new User();
            //dashboard.Show();
            //this.Close();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string load_queued_query = "SELECT COUNT(*) FROM `admin` WHERE `username` = @username AND `password` = @password";
                MySqlCommand commandSql = new MySqlCommand(load_queued_query, conn);

                commandSql.Parameters.AddWithValue("@username", username);
                commandSql.Parameters.AddWithValue("@password", password);

                int count = Convert.ToInt32(commandSql.ExecuteScalar());

                if (count > 0)
                {
                    User dashboard = new User();
                    dashboard.Show();
                    this.Close();
                }

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
