using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
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
        MySqlConnection connection = connectionDB.GetConnection();

        string connectionString = connectionDB.connectionString;
        //string connectionString = "server=localhost;database=queue_db;uid=eunice;pwd=password123;";
        public User()
        {
            InitializeComponent();


        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"SELECT * FROM user";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Clear existing rows in the DataGridView
                    dgUsers.Rows.Clear();

                    // Loop through the data reader and populate the DataGridView
                    while (reader.Read())
                    {
                        // Assuming you have the columns in the DataGridView set up correctly
                        int rowIndex = dgUsers.Rows.Add();
                        DataGridViewRow row = dgUsers.Rows[rowIndex];

                        // Populate the row with data from the reader
                        row.Cells["FirstName"].Value = reader["first_name"];
                        row.Cells["LastName"].Value = reader["last_name"];

                        row.Cells["Email"].Value = reader["email"];
                        row.Cells["Contact"].Value = reader["contact"];
                        row.Cells["Delete"].Value = "Delete User";

                    }

                    foreach (DataGridViewRow row in dgUsers.Rows)
                    {
                        row.Cells["OriginalEmail"].Value = row.Cells["Email"].Value;
                    }

                }
            }
        }

        private void dgUsers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ensure it's not a header row or an invalid cell
                if (e.RowIndex >= 0 && e.RowIndex < dgUsers.Rows.Count)
                {
                    var row = dgUsers.Rows[e.RowIndex];

                    // Skip if the row is a new row or the cell is null
                    if (row.IsNewRow) return;

                    var originalEmailCell = row.Cells["OriginalEmail"].Value; // Hidden or tracked original email
                    var emailCell = row.Cells["Email"].Value;
                    var firstnameCell = row.Cells["FirstName"].Value;
                    var lastnameCell = row.Cells["LastName"].Value;
                    var contactCell = row.Cells["Contact"].Value;

                    // Ensure none of the values are null
                    if (originalEmailCell == null || string.IsNullOrWhiteSpace(originalEmailCell.ToString()) ||
                        emailCell == null || string.IsNullOrWhiteSpace(emailCell.ToString()) ||
                        firstnameCell == null || string.IsNullOrWhiteSpace(firstnameCell.ToString()) ||
                        lastnameCell == null || string.IsNullOrWhiteSpace(lastnameCell.ToString()) ||
                        contactCell == null || string.IsNullOrWhiteSpace(contactCell.ToString()))
                    {
                        //MessageBox.Show("One or more required fields are empty. Update aborted.");
                        return;
                    }

                    var originalEmail = originalEmailCell.ToString();
                    var email = emailCell.ToString();
                    var first_name = firstnameCell.ToString();
                    var last_name = lastnameCell.ToString();
                    var contact = contactCell.ToString();

                    // Update query that also updates the primary key (email)
                    string updateQuery = @"UPDATE user 
                               SET email=@newEmail, first_name=@first_name, last_name=@last_name, contact=@contact 
                               WHERE email=@originalEmail";
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        MySqlCommand updateCommand = new MySqlCommand(updateQuery, conn);
                        updateCommand.Parameters.AddWithValue("@originalEmail", originalEmail);
                        updateCommand.Parameters.AddWithValue("@newEmail", email);
                        updateCommand.Parameters.AddWithValue("@first_name", first_name);
                        updateCommand.Parameters.AddWithValue("@last_name", last_name);
                        updateCommand.Parameters.AddWithValue("@contact", contact);
                        updateCommand.ExecuteNonQuery();
                    }

                    // Update the OriginalEmail column to match the new email
                    row.Cells["OriginalEmail"].Value = email;

                    MessageBox.Show("User updated successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }


        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadData();


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

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            QueueList queueList = new QueueList();
            queueList.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void dgUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgUsers.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                var email = dgUsers.Rows[e.RowIndex].Cells["Email"].Value.ToString();

                DialogResult dialogResult = MessageBox.Show($"Delete this user with email {email}?", "Delete User", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string deleteQuery = $"DELETE FROM user WHERE email=@email";
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, conn);
                        deleteCommand.Parameters.AddWithValue("@email", email);
                        deleteCommand.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("User deleted");

                LoadData();

            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.Show();
        }
    }
}
