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
    public partial class Counter : Form
    {
        MySqlConnection connection = connectionDB.GetConnection();

        public Counter()
        {
            InitializeComponent();
            LoadTicketData();

            load_data();

        }

        private void LoadTicketData()
        {
            //throw new NotImplementedException();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void load_data()
        {
            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"SELECT * FROM live_queue";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Clear existing rows in the DataGridView
                    dgCounter.Rows.Clear();

                    // Loop through the data reader and populate the DataGridView
                    while (reader.Read())
                    {
                        // Assuming you have the columns in the DataGridView set up correctly
                        int rowIndex = dgCounter.Rows.Add();
                        DataGridViewRow row = dgCounter.Rows[rowIndex];

                        // Populate the row with data from the reader
                        row.Cells["CounterQ"].Value = reader["counter"];
                        row.Cells["NameQ"].Value = reader["name"];
                        row.Cells["TimeQ"].Value = reader["time"];
                    }
                }
            }


            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"SELECT COUNT(*) FROM live_queue WHERE queue_number IS NOT NULL;";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                int total_service = Convert.ToInt32(cmd.ExecuteScalar());
                countService.Text = total_service.ToString();

            }

            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"SELECT COUNT(*) FROM proceeding_queue";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                int total_proceeding = Convert.ToInt32(cmd.ExecuteScalar());
                countWaiting.Text = total_proceeding.ToString();

            }

            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"SELECT COUNT(*) FROM completed";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                int total_completed = Convert.ToInt32(cmd.ExecuteScalar());
                countCompleted.Text = total_completed.ToString();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button_add_new_Click(object sender, EventArgs e)
        {

        }

        private void Counters_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                //// Column headers styling
                //dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                //dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                //dataGridView2.EnableHeadersVisualStyles = false;

                //// Auto-size columns and rows
                //dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                //// Grid lines and borders
                //dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                //dataGridView2.GridColor = Color.DarkGray;

                //// Row styling
                //dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                //dataGridView2.DefaultCellStyle.BackColor = Color.White;
                //dataGridView2.DefaultCellStyle.SelectionBackColor = Color.LightBlue;

                //// Center cell content
                //dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //// Hide row headers
                //dataGridView2.RowHeadersVisible = false;

                //// Set read-only and selection mode
                //dataGridView2.ReadOnly = true;
                //dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //// Set cell padding
                //dataGridView2.DefaultCellStyle.Padding = new Padding(5);
            }
        }



        public class Ticket
        {
            public int TicketNumber { get; set; }
            public string AssignedCounter { get; set; } // Renamed to avoid conflict with the `Counter` class name
        }

        public partial class TicketCounter : Form
        {
            private List<Ticket> tickets;
            private BindingSource bindingSource;
            private DataGridView dataGridView2;

            public TicketCounter()
            {
                Counter counterForm = new Counter();
                counterForm.InitializeComponent();
                counterForm.LoadTicketData();

                SetupDataGridView();
            }

            private void LoadTicketData()
            {
                tickets = new List<Ticket>
        {
            new Ticket { TicketNumber = 101, AssignedCounter = "Counter 1" },
            new Ticket { TicketNumber = 102, AssignedCounter = "Counter 2" },
            new Ticket { TicketNumber = 103, AssignedCounter = "Counter 1" },
            new Ticket { TicketNumber = 104, AssignedCounter = "Counter 3" }
        };

                bindingSource = new BindingSource { DataSource = tickets };
            }

            private void SetupDataGridView()
            {
                // Bind data to DataGridView
                dataGridView2.DataSource = bindingSource;

                // Adjust headers
                dataGridView2.Columns[0].HeaderText = "Ticket Number";
                dataGridView2.Columns[1].HeaderText = "Assigned Counter";

                // Add delete button column
                var deleteButtonColumn = new DataGridViewButtonColumn
                {
                    Text = "Delete",
                    UseColumnTextForButtonValue = true,
                    HeaderText = "Actions"
                };
                dataGridView2.Columns.Add(deleteButtonColumn);

                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.CellValueChanged += DataGridView2_CellValueChanged;
                dataGridView2.CellClick += DataGridView2_CellClick;
            }

            private void DataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0)
                {
                    var ticket = tickets[e.RowIndex];
                    ticket.TicketNumber = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value);
                    ticket.AssignedCounter = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                }
            }

            private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView2.Columns["Actions"].Index)
                {
                    tickets.RemoveAt(e.RowIndex);
                    bindingSource.ResetBindings(false);
                }
            }
        }


        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}