﻿using MySql.Data.MySqlClient;
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
    public partial class QueueList : Form
    {
        MySqlConnection connection = connectionDB.GetConnection();
        string connectionString = connectionDB.connectionString;

        public QueueList()
        {
            InitializeComponent();
            fill_proceeding();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            //using MySql.Data.MySqlClient;
            //using System.Data;

            // MySQL connection string
            //string connectionString = "server=yourserver;user=youruser;password=yourpassword;database=yourdatabase";
            //MySqlConnection connection = new MySqlConnection(connectionString);

            //// Load queue data
            //private void LoadQueueData()
            //{
            //    string query = "SELECT * FROM queue_table"; // Adjust the query for your table

            //    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            //    DataTable dataTable = new DataTable();
            //    adapter.Fill(dataTable);

            //    foreach (DataRow row in dataTable.Rows)
            //    {
            //        // Use the queue data to create Guna2Panel items dynamically
            //        var queuePanel = new Guna.UI2.WinForms.Guna2Panel
            //        {
            //            BorderRadius = 10,
            //            FillColor = Color.White,
            //            Size = new Size(120, 80), // Adjust size as needed
            //        };

            //        // Add Labels for queue number, name, time, and status
            //        Label lblQueue = new Label { Text = row["queue_number"].ToString(), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };
            //        Label lblName = new Label { Text = row["name"].ToString(), AutoSize = true };
            //        Label lblTime = new Label { Text = row["time"].ToString(), AutoSize = true };

            //        // Position these Labels inside the queuePanel
            //        queuePanel.Controls.Add(lblQueue);
            //        queuePanel.Controls.Add(lblName);
            //        queuePanel.Controls.Add(lblTime);

            //        // Add this queuePanel to the main content area
            //        guna2PanelContent.Controls.Add(queuePanel); // Assuming guna2PanelContent is the main container
            //    }
            //}

            //// Call LoadQueueData() when the form loads
            //private void QueueForm_Load(object sender, EventArgs e)
            //{
            //    LoadQueueData();
            //}

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void fill_proceeding()
        {
            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"SELECT * FROM proceeding_queue";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Clear existing rows in the DataGridView
                    dgProceeding.Rows.Clear();

                    // Loop through the data reader and populate the DataGridView
                    while (reader.Read())
                    {
                        // Assuming you have the columns in the DataGridView set up correctly
                        int rowIndex = dgProceeding.Rows.Add();
                        DataGridViewRow row = dgProceeding.Rows[rowIndex];

                        // Populate the row with data from the reader
                        row.Cells["Name"].Value = reader["name"];
                        row.Cells["QueueNumber"].Value = reader["queue_number"];
                        row.Cells["Time"].Value = reader["time"];
                        row.Cells["Contact"].Value = reader["contact"];
                        row.Cells["RemoveP"].Value = "Remove";
                    }
                }
            }

            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"SELECT * FROM live_queue WHERE queue_number IS NOT NULL";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Clear existing rows in the DataGridView
                    dgLive.Rows.Clear();

                    // Loop through the data reader and populate the DataGridView
                    while (reader.Read())
                    {
                        // Assuming you have the columns in the DataGridView set up correctly
                        int rowIndex = dgLive.Rows.Add();
                        DataGridViewRow row = dgLive.Rows[rowIndex];

                        // Populate the row with data from the reader
                        row.Cells["NameL"].Value = reader["name"];
                        row.Cells["QueueNumberL"].Value = reader["queue_number"];
                        row.Cells["TimeL"].Value = reader["time"];
                        row.Cells["ContactL"].Value = reader["contact"];
                        row.Cells["Counter"].Value = reader["counter"];
                        row.Cells["WaitingTime"].Value = reader["waiting_time"];
                        row.Cells["Remove"].Value = "Remove";
                    }
                }
            }
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgLive_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgLive.Columns["Remove"].Index && e.RowIndex >= 0)
            {
                var queueNum = dgLive.Rows[e.RowIndex].Cells["QueueNumberL"].Value.ToString();
                var name = dgLive.Rows[e.RowIndex].Cells["NameL"].Value.ToString();
                var time = dgLive.Rows[e.RowIndex].Cells["TimeL"].Value.ToString();
                var contact = dgLive.Rows[e.RowIndex].Cells["ContactL"].Value.ToString();
                var counter = dgLive.Rows[e.RowIndex].Cells["Counter"].Value.ToString();
                var waitingTime = dgLive.Rows[e.RowIndex].Cells["WaitingTime"].Value.ToString(); // Assuming the waiting_time is available in the DataGrid

                // Calculate start_time as the difference between current time and waiting_time (assuming waiting_time is in TimeSpan format)
                TimeSpan startTime = TimeSpan.Parse(time) - TimeSpan.Parse(waitingTime);  // You might need to adjust this based on your time format

                var result = MessageBox.Show($"Are you sure you want to remove {name}?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Update live_queue table (removing the current record)
                    string deleteQuery = $"UPDATE live_queue SET queue_number=NULL, name=NULL, time=NULL, contact=NULL, waiting_time=NULL WHERE queue_number = '{queueNum}'";
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, conn);
                        deleteCommand.ExecuteNonQuery();
                    }

                    // Insert into completed table with waiting_time and calculated start_time
                    string completeQuery = @"INSERT INTO completed (queue_number, name, time, contact, counter, waiting_time, start_time) 
                                    VALUES (@queueNum, @name, @time, @contact, @counter, @waitingTime, @startTime)";
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        MySqlCommand completeCommand = new MySqlCommand(completeQuery, conn);
                        completeCommand.Parameters.AddWithValue("@queueNum", queueNum);
                        completeCommand.Parameters.AddWithValue("@name", name);
                        completeCommand.Parameters.AddWithValue("@time", DateTime.Now.TimeOfDay.ToString());
                        completeCommand.Parameters.AddWithValue("@contact", contact);
                        completeCommand.Parameters.AddWithValue("@counter", counter);
                        completeCommand.Parameters.AddWithValue("@waitingTime", waitingTime); // Store waiting_time in completed
                        completeCommand.Parameters.AddWithValue("@startTime", startTime.ToString()); // Store the calculated start_time

                        completeCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Record removed successfully!");
                    fill_proceeding(); // Refresh data after deletion
                }
            }
        }

        private void dgProceeding_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgProceeding.Columns["RemoveP"].Index && e.RowIndex >= 0)
            {
                var queueNum = dgProceeding.Rows[e.RowIndex].Cells["QueueNumber"].Value.ToString();
                var name = dgProceeding.Rows[e.RowIndex].Cells["Name"].Value.ToString();

                var result = MessageBox.Show($"Are you sure you want to remove {name}?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string deleteQuery = $"DELETE FROM proceeding_queue WHERE queue_number = '{queueNum}'";
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, conn);
                        deleteCommand.ExecuteNonQuery();
                    }
                    MessageBox.Show("Record removed successfully!");
                    fill_proceeding(); // Refresh data after deletion
                }
            }
        }
    }
}
