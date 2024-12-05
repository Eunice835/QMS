using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Register
{
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //using MySql.Data.MySqlClient;
            //using System.Data;

            // Connection string
            //string connectionString = "server=yourserver;user=youruser;password=yourpassword;database=yourdatabase";
            //MySqlConnection connection = new MySqlConnection(connectionString);

            

        }

        // Method to load data
        //private void LoadData()
        //{
        //    string query = "SELECT * FROM your_table"; // Customize this query to fit your data

        //    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
        //    DataTable dataTable = new DataTable();
        //    adapter.Fill(dataTable);

        //    guna2DataGridView.DataSource = dataTable;
        //}

        //// Call LoadData() when the form loads
        //private void MainForm_Load(object sender, EventArgs e)
        //{
        //    LoadData();
        //}
    }
}
