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
using MySql.Data.MySqlClient;
using Bus_Sphere.packages;
namespace Bus_Sphere.CustomForm
{
    public partial class BusList : UserControl
    {
        const string connectionString = "server=localhost;user=root;database=bussphere;port=3306;password=";
        private Dictionary<int, Color> originalColors = new Dictionary<int, Color>();
        public BusList()
        {
            InitializeComponent();
            LoadBusData();
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Alternate row color

            dataGridView1.CellMouseEnter += dataGridView1_CellMouseEnter;
            dataGridView1.CellMouseLeave += dataGridView1_CellMouseLeave;
            dataGridView1.CellClick += dataGridView1_CellClick;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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

                    // Store original colors
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        originalColors[i] = dataGridView1.Rows[i].DefaultCellStyle.BackColor;
                    }
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
                //MessageBox.Show($"Selected Bus:\nID: {busID}\nNumber: {busNumber}\nName: {busName}\nType: {busType}\nSeats: {availableSeats}/{totalSeats}", "Bus Details");
                LoadUserControl(new SeatSelection(busID));
            }
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Store the original color before changing it
                if (!originalColors.ContainsKey(e.RowIndex))
                {
                    originalColors[e.RowIndex] = dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor;
                }
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            }
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && originalColors.ContainsKey(e.RowIndex))
            {
                // Restore the original color
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = originalColors[e.RowIndex];
            }
        }
        public void LoadUserControl(UserControl userControl)
        {
            // Clear existing controls
            panel1.BringToFront();
            panel1.Controls.Clear();

            // Add the UserControl to the panel
            userControl.Dock = DockStyle.Fill;  // Dock to fill the panel
            panel1.Controls.Add(userControl);  // Add UserControl to the panel
        }
    }
}
