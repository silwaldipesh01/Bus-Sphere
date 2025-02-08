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
    public partial class LoadBuses : Form
    {
        const string connectionString = "server=localhost;user=root;database=bussphere;port=3306;password=";
        public LoadBuses()
        {
            InitializeComponent();
        }

        private void DataGridPractice_Load(object sender, EventArgs e)
        {
            LoadBusData();

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Alternate row color
        }




        private void LoadBusData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Bus"; // Query to fetch bus data
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt; // Bind data to DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure that a valid row is selected (ignore header row clicks)
            if (e.RowIndex >= 0)
            {
                // Select the entire row
                dataGridView1.Rows[e.RowIndex].Selected = true;

                // Get the selected row
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Extract data from the selected row
                string busID = row.Cells["bus_id"].Value.ToString();
                string busNumber = row.Cells["bus_number"].Value.ToString();
                string busName = row.Cells["bus_name"].Value.ToString();
                string busType = row.Cells["bus_type"].Value.ToString();
                string totalSeats = row.Cells["total_seats"].Value.ToString();
                string availableSeats = row.Cells["available_seats"].Value.ToString();

                // Display selected bus details in a MessageBox (or TextBoxes)
                MessageBox.Show($"Selected Bus:\nID: {busID}\nNumber: {busNumber}\nName: {busName}\nType: {busType}\nSeats: {availableSeats}/{totalSeats}", "Bus Details");
            }
        }

    }
}
