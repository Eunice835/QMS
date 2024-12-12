using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Register.Counter;

namespace Register
{
    public partial class Dashboard : Form
    {
        MySqlConnection connection = connectionDB.GetConnection();

        public Dashboard()
        {
            InitializeComponent();
            load_data();

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.Show();
            this.Hide();    
        }

        private void load_data()
        {
            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"SELECT * FROM live_queue WHERE queue_number IS NOT NULL";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Clear existing rows in the DataGridView
                    dgDashboard.Rows.Clear();

                    // Loop through the data reader and populate the DataGridView
                    while (reader.Read())
                    {
                        // Assuming you have the columns in the DataGridView set up correctly
                        int rowIndex = dgDashboard.Rows.Add();
                        DataGridViewRow row = dgDashboard.Rows[rowIndex];

                        // Populate the row with data from the reader
                        row.Cells["Counter"].Value = reader["counter"];
                        row.Cells["Ticket"].Value = reader["queue_number"];
                    }
                }
            }

            int total_service;
            int total_proceeding;
            int total_completed;

            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"SELECT COUNT(*) FROM live_queue WHERE queue_number IS NOT NULL;";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                total_service = Convert.ToInt32(cmd.ExecuteScalar());
                lblQueue.Text = total_service.ToString();

            }

            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"SELECT COUNT(*) FROM proceeding_queue";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                total_proceeding = Convert.ToInt32(cmd.ExecuteScalar());
                lblPending.Text = total_proceeding.ToString();

            }

            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"SELECT COUNT(*) FROM completed";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                total_completed = Convert.ToInt32(cmd.ExecuteScalar());
                lblCompleted.Text = total_completed.ToString();

            }

            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"SELECT COUNT(*) FROM live_queue";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                int total_counter = Convert.ToInt32(cmd.ExecuteScalar());
                lblCounter.Text = total_counter.ToString();
            }

            int total = total_completed + total_proceeding + total_service;
            pbCompleted.Value = total_completed;
            pbCompleted.Maximum = total;
            pbPending.Value = total_proceeding;
            pbPending.Maximum = total;
            pbQueue.Value = total_service;
            pbQueue.Maximum = total;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            QueueList queueList = new QueueList();
            queueList.Show();   
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Counter counter = new Counter();
            counter.Show();
            this.Hide();
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Feedback feedback = new Feedback();
            feedback.Show();
        }
    }
    //    namespace YourNamespace
    //{ 
    //    public partial class MainForm : Form
    //    {
    //        private List<Ticket> tickets;
    //        private Guna2DataGridView guna2DataGridView1; // The Guna DataGridView

    //        public MainForm()
    //        {
    //            InitializeComponent();
    //            LoadTicketData();
    //            SetupDataGridView();
    //        }

    //        private void LoadTicketData()
    //        {
    //            // Sample ticket data
    //            tickets = new List<Ticket>
    //        {
    //            new Ticket { TicketNumber = 101, Counter = "Counter 1" },
    //            new Ticket { TicketNumber = 102, Counter = "Counter 2" },
    //            new Ticket { TicketNumber = 103, Counter = "Counter 1" },
    //            new Ticket { TicketNumber = 104, Counter = "Counter 3" }
    //        };
    //        }

    //        private void SetupDataGridView()
    //        {
    //            // Initialize Guna2DataGridView
    //            guna2DataGridView1 = new Guna2DataGridView
    //            {
    //                // Set up grid properties
    //                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
    //                ColumnHeadersHeight = 40,
    //                EnableHeadersVisualStyles = false,
    //                AllowUserToAddRows = false, // Disable adding rows manually
    //                ReadOnly = true,  // Set read-only if you don't want users to modify it
    //                Location = new System.Drawing.Point(20, 20),  // Position of the DataGridView
    //                Size = new System.Drawing.Size(400, 300)  // Size of the DataGridView
    //            };

    //            // Add the DataGridView to the form's Controls
    //            this.Controls.Add(guna2DataGridView1);

    //            // Set up the columns for the DataGridView
    //            guna2DataGridView1.Columns.Add("TicketNumber", "Ticket Number");
    //            guna2DataGridView1.Columns.Add("Counter", "Assigned Counter");

    //            // Bind the list of tickets to the DataGridView
    //            guna2DataGridView1.DataSource = new BindingSource { DataSource = tickets };

    //            // Customize headers if needed
    //            guna2DataGridView1.Columns[0].HeaderText = "Ticket Number";
    //            guna2DataGridView1.Columns[1].HeaderText = "Assigned Counter";
    //        }
    //    }
    //}

}

public class Ticket
{
    public int TicketNumber { get; set; }
    public string Counter { get; set; }
}
