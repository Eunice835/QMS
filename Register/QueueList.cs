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
    public partial class QueueList : Form
    {
        public QueueList()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            using MySql.Data.MySqlClient;
            using System.Data;

            // MySQL connection string
            string connectionString = "server=yourserver;user=youruser;password=yourpassword;database=yourdatabase";
            MySqlConnection connection = new MySqlConnection(connectionString);

            // Load queue data
            private void LoadQueueData()
            {
                string query = "SELECT * FROM queue_table"; // Adjust the query for your table

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    // Use the queue data to create Guna2Panel items dynamically
                    var queuePanel = new Guna.UI2.WinForms.Guna2Panel
                    {
                        BorderRadius = 10,
                        FillColor = Color.White,
                        Size = new Size(120, 80), // Adjust size as needed
                    };

                    // Add Labels for queue number, name, time, and status
                    Label lblQueue = new Label { Text = row["queue_number"].ToString(), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };
                    Label lblName = new Label { Text = row["name"].ToString(), AutoSize = true };
                    Label lblTime = new Label { Text = row["time"].ToString(), AutoSize = true };

                    // Position these Labels inside the queuePanel
                    queuePanel.Controls.Add(lblQueue);
                    queuePanel.Controls.Add(lblName);
                    queuePanel.Controls.Add(lblTime);

                    // Add this queuePanel to the main content area
                    guna2PanelContent.Controls.Add(queuePanel); // Assuming guna2PanelContent is the main container
                }
            }

            // Call LoadQueueData() when the form loads
            private void QueueForm_Load(object sender, EventArgs e)
            {
                LoadQueueData();
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
