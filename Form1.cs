using Bus_Sphere.CustomControls;
using MySql.Data.MySqlClient;
using BCrypt.Net;
using static Bus_Sphere.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data;
namespace Bus_Sphere
{
    public partial class Form1 : Form
    {
        public class PasswordHasher
        {
            //Method to hash password
            public static string HashPassword(string password)
            {
                return BCrypt.Net.BCrypt.HashPassword(password);
            }
            //Method to validate password
            public static bool ValidatePassword(string password, string correctHash)
            {
                return BCrypt.Net.BCrypt.Verify(password, correctHash);
            }
        }
        string connectionString = "server=localhost;user=root;database=bussphere;port=3306;password=";
        public Form1()
        {
            InitializeComponent();
            ValidUserTxt.Visible = false;
            ValidUserTxt.Text = "Invalid Username or Password";
        }
        String username = "admin";
        String password = "admin";
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM UserPass WHERE username = @username";
            if (UsernameTxtBox.Text == "" || PasswordTxtBox.Text == "")
            {
                ValidUserTxt.Visible = true;
                ValidUserTxt.Text = "Please fill in all fields";
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {

                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@username", UsernameTxtBox.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (PasswordHasher.ValidatePassword(PasswordTxtBox.Text, $"{reader["passwordhash"]}"))
                        {
                            this.Hide();
                           // new BusSphere().Show();
                        }
                        else
                        {
                            ValidUserTxt.Visible = true;
                        }
                    }
                    else
                    {
                        ValidUserTxt.Visible = true;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "INSERT INTO UserPass(Username, PasswordHash, Role) VALUES(@Username, @PasswordHash, 'Admin')";
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@username", UsernameTxtBox.Text);
                    cmd.Parameters.AddWithValue("@passwordHash", PasswordHasher.HashPassword(PasswordTxtBox.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User registered successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void customTextBox3__TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ValidUserTxt_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ForgotPassLbl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please contact the admin For password reset");
        }

        private void ForgotPassLbl_MouseEnter(object sender, EventArgs e)
        {
            ForgotPassLbl.ForeColor = Color.Red;
        }

        private void ForgotPassLbl_MouseLeave(object sender, EventArgs e)
        {
            ForgotPassLbl.ForeColor = Color.Black;
        }
    }
}
