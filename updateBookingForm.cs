using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Bus_Sphere
{
    public partial class updateBookingForm : Form
    {
        string connectionString = "server=localhost;user=root;database=bussphere;port=3306;password=";
        public int routeId;
        public int busid;

        public updateBookingForm(int busid)
        {
            InitializeComponent();
            this.busid = busid;
            this.routeId = GetRouteId(busid);
            AddBookingForm addBookingForm = new AddBookingForm(this.routeId);
            LoadUserControl(addBookingForm);
        }

        public void LoadUserControl(UserControl userControl)
        {
            // Clear existing controls
            panel1.BringToFront();
            panel1.Controls.Clear();

            // Add the UserControl to the panel
            userControl.Dock = DockStyle.Fill;  // Dock to fill the panel
            userControl.BringToFront();
            panel1.Controls.Add(userControl);  // Add UserControl to the panel
        }

        public int GetRouteId(int busid)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT route_id FROM routing WHERE bus_id = @busid";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@busid", busid);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Convert.ToInt32(reader["route_id"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting route_id: " + ex.Message);
            }
            return -1; // Return -1 if no routeId is found or an error occurs
        }
    }
}
