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
    public partial class User : Form
    {

        string connectionString = "server=localhost;database=queue_db;uid=eunice;pwd=password123;";
        public User()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT name, contact FROM live_queue"; // Adjust column and table names
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);

                // Bind the DataTable to the DataGridView
                dataGridView1.DataSource = table;

                // Add Update button column
                DataGridViewButtonColumn updateColumn = new DataGridViewButtonColumn();
                updateColumn.Name = "Update";
                updateColumn.HeaderText = "Update";
                updateColumn.Text = "Update";
                updateColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(updateColumn);

                // Add Delete button column
                DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
                deleteColumn.Name = "Delete";
                deleteColumn.HeaderText = "Delete";
                deleteColumn.Text = "Delete";
                deleteColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(deleteColumn);
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadData();



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is a button cell
            if (e.RowIndex >= 0)
            {
                string customerName = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Update")
                {
                    // Update logic
                    MessageBox.Show($"Updating customer {customerName}");
                    // Add your update logic here (e.g., open an edit form)
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    // Delete logic
                    var result = MessageBox.Show($"Are you sure you want to delete {customerName}?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        string deleteQuery = $"DELETE FROM live_queue WHERE name = '{customerName}'";
                        using (MySqlConnection conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();
                            MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, conn);
                            deleteCommand.ExecuteNonQuery();
                        }
                        MessageBox.Show("Record deleted successfully!");
                        LoadData(); // Refresh data after deletion
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Counter counter = new Counter();
            counter.Show();
            this.Hide();
        }
    }
}
