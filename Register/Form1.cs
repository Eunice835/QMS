namespace Register
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
