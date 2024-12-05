using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Dashboard()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
