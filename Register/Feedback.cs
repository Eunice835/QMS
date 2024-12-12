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
    public partial class Feedback : Form
    {
        MySqlConnection connection = connectionDB.GetConnection();

        public Feedback()
        {
            InitializeComponent();
            load_data();
        }

        public void load_data()
        {
            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"SELECT * FROM feedback";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Clear existing rows in the DataGridView
                    dgFeedback.Rows.Clear();

                    // Loop through the data reader and populate the DataGridView
                    while (reader.Read())
                    {
                        // Assuming you have the columns in the DataGridView set up correctly
                        int rowIndex = dgFeedback.Rows.Add();
                        DataGridViewRow row = dgFeedback.Rows[rowIndex];

                        // Populate the row with data from the reader
                        row.Cells["Description"].Value = reader["description"];
                        row.Cells["Rating"].Value = reader["rating"];


                    }

                }
            }
        }

    }
}
