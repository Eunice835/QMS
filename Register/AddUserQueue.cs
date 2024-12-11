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
    public partial class AddUserQueue : Form
    {

        MySqlConnection connection = connectionDB.GetConnection();
        string connectionString = connectionDB.connectionString;

        String queuetype = "";
        public AddUserQueue(String queue_type)
        {
            InitializeComponent();
            queuetype = queue_type;


            if (queuetype.Equals("proceeding") || queuetype.Equals("schedule"))
            {
                cbCounter.Enabled = false;
                cbCounter.Visible = false;
            }

          

            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"SELECT counter FROM live_queue WHERE queue_number IS NULL;";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Clear existing rows in the DataGridView
                    
                    // Loop through the data reader and populate the DataGridView
                    while (reader.Read())
                    {
                        cbCounter.Items.Add(reader["counter"].ToString());

                    }
                }
            }


        }

        public void add_user()
        {
            String name = tbName.Text;
            String queueNumber = tbQueueNumber.Text;
            String time = tbTime.Text;
            String contact = tbContact.Text;
            String counter = cbCounter.Text;

            if (queuetype.Equals("proceeding"))
            {
                string addQuery = $"INSERT INTO proceeding_queue (queue_number, name, time, contact, rescheduled) VALUES (@queueNumber, @name, @time, @contact, 'No')";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand addcmd = new MySqlCommand(addQuery, conn);
                    addcmd.Parameters.AddWithValue("@name", name);
                    addcmd.Parameters.AddWithValue("@queueNumber", queueNumber);
                    addcmd.Parameters.AddWithValue("@time", time);
                    addcmd.Parameters.AddWithValue("@contact", contact);
                    addcmd.ExecuteNonQuery();
                }


                MessageBox.Show("User added successfully!");
            }
            else if (queuetype.Equals("live"))
            {
                string addQuery = @"UPDATE live_queue SET name=@name, queue_number=@queueNUmber, time=@time, contact=@contact WHERE counter=@counter";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand addcmd = new MySqlCommand(addQuery, conn);
                    addcmd.Parameters.AddWithValue("@name", name);
                    addcmd.Parameters.AddWithValue("@queueNumber", queueNumber);
                    addcmd.Parameters.AddWithValue("@time", time);
                    addcmd.Parameters.AddWithValue("@contact", contact);
                    addcmd.Parameters.AddWithValue("@counter", counter);

                    addcmd.ExecuteNonQuery();
                }
                MessageBox.Show("User added successfully!");
            }
            else if (queuetype.Equals("schedule"))
            {
                string addQuery = $"INSERT INTO proceeding_queue (queue_number, name, time, contact, rescheduled) VALUES (@queueNumber, @name, @time, @contact, 'Yes')";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand addcmd = new MySqlCommand(addQuery, conn);
                    addcmd.Parameters.AddWithValue("@name", name);
                    addcmd.Parameters.AddWithValue("@queueNumber", queueNumber);
                    addcmd.Parameters.AddWithValue("@time", time);
                    addcmd.Parameters.AddWithValue("@contact", contact);

                    addcmd.ExecuteNonQuery();
                }
                MessageBox.Show("User added successfully!");
            }

        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tbName = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            label2 = new Label();
            tbQueueNumber = new Guna.UI2.WinForms.Guna2TextBox();
            label3 = new Label();
            tbTime = new Guna.UI2.WinForms.Guna2TextBox();
            label4 = new Label();
            tbContact = new Guna.UI2.WinForms.Guna2TextBox();
            label5 = new Label();
            cbCounter = new Guna.UI2.WinForms.Guna2ComboBox();
            label6 = new Label();
            btnSubmit = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // tbName
            // 
            tbName.CustomizableEdges = customizableEdges1;
            tbName.DefaultText = "";
            tbName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbName.Font = new Font("Segoe UI", 9F);
            tbName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbName.Location = new Point(268, 73);
            tbName.Margin = new Padding(3, 4, 3, 4);
            tbName.Name = "tbName";
            tbName.PasswordChar = '\0';
            tbName.PlaceholderText = "";
            tbName.SelectedText = "";
            tbName.ShadowDecoration.CustomizableEdges = customizableEdges2;
            tbName.Size = new Size(320, 36);
            tbName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(189, 79);
            label1.Name = "label1";
            label1.Size = new Size(62, 25);
            label1.TabIndex = 1;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(109, 126);
            label2.Name = "label2";
            label2.Size = new Size(142, 25);
            label2.TabIndex = 3;
            label2.Text = "Queue Number";
            // 
            // tbQueueNumber
            // 
            tbQueueNumber.CustomizableEdges = customizableEdges3;
            tbQueueNumber.DefaultText = "";
            tbQueueNumber.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbQueueNumber.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbQueueNumber.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbQueueNumber.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbQueueNumber.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbQueueNumber.Font = new Font("Segoe UI", 9F);
            tbQueueNumber.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbQueueNumber.Location = new Point(268, 117);
            tbQueueNumber.Margin = new Padding(3, 4, 3, 4);
            tbQueueNumber.Name = "tbQueueNumber";
            tbQueueNumber.PasswordChar = '\0';
            tbQueueNumber.PlaceholderText = "";
            tbQueueNumber.SelectedText = "";
            tbQueueNumber.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tbQueueNumber.Size = new Size(320, 36);
            tbQueueNumber.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(189, 167);
            label3.Name = "label3";
            label3.Size = new Size(54, 25);
            label3.TabIndex = 5;
            label3.Text = "Time";
            // 
            // tbTime
            // 
            tbTime.CustomizableEdges = customizableEdges5;
            tbTime.DefaultText = "";
            tbTime.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbTime.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbTime.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbTime.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbTime.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbTime.Font = new Font("Segoe UI", 9F);
            tbTime.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbTime.Location = new Point(268, 161);
            tbTime.Margin = new Padding(3, 4, 3, 4);
            tbTime.Name = "tbTime";
            tbTime.PasswordChar = '\0';
            tbTime.PlaceholderText = "";
            tbTime.SelectedText = "";
            tbTime.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tbTime.Size = new Size(320, 36);
            tbTime.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(165, 216);
            label4.Name = "label4";
            label4.Size = new Size(78, 25);
            label4.TabIndex = 7;
            label4.Text = "Contact";
            // 
            // tbContact
            // 
            tbContact.CustomizableEdges = customizableEdges7;
            tbContact.DefaultText = "";
            tbContact.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbContact.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbContact.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbContact.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbContact.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbContact.Font = new Font("Segoe UI", 9F);
            tbContact.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbContact.Location = new Point(268, 205);
            tbContact.Margin = new Padding(3, 4, 3, 4);
            tbContact.Name = "tbContact";
            tbContact.PasswordChar = '\0';
            tbContact.PlaceholderText = "";
            tbContact.SelectedText = "";
            tbContact.ShadowDecoration.CustomizableEdges = customizableEdges8;
            tbContact.Size = new Size(320, 36);
            tbContact.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(163, 259);
            label5.Name = "label5";
            label5.Size = new Size(80, 25);
            label5.TabIndex = 9;
            label5.Text = "Counter";
            // 
            // cbCounter
            // 
            cbCounter.BackColor = Color.Transparent;
            cbCounter.CustomizableEdges = customizableEdges9;
            cbCounter.DrawMode = DrawMode.OwnerDrawFixed;
            cbCounter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCounter.FocusedColor = Color.FromArgb(94, 148, 255);
            cbCounter.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbCounter.Font = new Font("Segoe UI", 10F);
            cbCounter.ForeColor = Color.FromArgb(68, 88, 112);
            cbCounter.ItemHeight = 30;
            cbCounter.Location = new Point(268, 248);
            cbCounter.Name = "cbCounter";
            cbCounter.ShadowDecoration.CustomizableEdges = customizableEdges10;
            cbCounter.Size = new Size(320, 36);
            cbCounter.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(203, 9);
            label6.Name = "label6";
            label6.Size = new Size(351, 50);
            label6.TabIndex = 11;
            label6.Text = "Add User to Queue";
            label6.Click += label6_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.CustomizableEdges = customizableEdges11;
            btnSubmit.DisabledState.BorderColor = Color.DarkGray;
            btnSubmit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSubmit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSubmit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSubmit.Font = new Font("Segoe UI", 9F);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(278, 307);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnSubmit.Size = new Size(225, 56);
            btnSubmit.TabIndex = 12;
            btnSubmit.Text = "Add";
            btnSubmit.Click += btnSubmit_Click;
            // 
            // AddUserQueue
            // 
            BackColor = Color.Navy;
            ClientSize = new Size(739, 401);
            Controls.Add(btnSubmit);
            Controls.Add(label6);
            Controls.Add(cbCounter);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(tbContact);
            Controls.Add(label3);
            Controls.Add(tbTime);
            Controls.Add(label2);
            Controls.Add(tbQueueNumber);
            Controls.Add(label1);
            Controls.Add(tbName);
            Name = "AddUserQueue";
            ResumeLayout(false);
            PerformLayout();
        }

        private Guna.UI2.WinForms.Guna2TextBox tbName;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox tbQueueNumber;
        private Label label3;
        private Guna.UI2.WinForms.Guna2TextBox tbTime;
        private Label label4;
        private Guna.UI2.WinForms.Guna2TextBox tbContact;
        private Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cbCounter;
        private Label label6;
        private Guna.UI2.WinForms.Guna2Button btnSubmit;
        private Label label1;

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            add_user();
            this.Close();
        }
    }
}
