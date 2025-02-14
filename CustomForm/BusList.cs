using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bus_Sphere.CustomControls;

namespace Bus_Sphere.CustomForm
{
    public partial class BusList : UserControl
    {
        const string connectionString = "server=localhost;user=root;database=bussphere;port=3306;password=";
        private Dictionary<int, Color> originalColors = new Dictionary<int, Color>();

        public BusList()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadBusData();
        }

        private void InitializeDataGridView()
        {
            dataGridView1.Dock = DockStyle.Fill; // Ensure DataGridView fills the UserControl
            dataGridView1.BackgroundColor = Color.FromArgb(35, 140, 178);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 140, 178);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView1.ColumnHeadersHeight = 60; // Set header height
            dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridView1.RowTemplate.Height = 100; // Increase row height
            dataGridView1.GridColor = Color.White; // Set grid line color
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single; // Ensure single border style
            dataGridView1.BorderStyle = BorderStyle.FixedSingle; // Set border style of DataGridView
            dataGridView1.BackgroundColor = Color.LightGray; // Set background color
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView1.CellMouseEnter += dataGridView1_CellMouseEnter;
            dataGridView1.CellMouseLeave += dataGridView1_CellMouseLeave;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
        }

        private void LoadBusData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            b.bus_id AS 'Bus ID', 
                            b.bus_number AS 'Bus Number', 
                            b.bus_name AS 'Bus Name', 
                            b.bus_type AS 'Bus Type', 
                            b.total_seats AS 'Total Seats',
                            r.departure_location AS 'Start',
                            r.arrival_location AS 'Destination',
                            r.departure_time AS 'Departure Time',
                            r.arrival_time AS 'Reach Time',
                            r.ticket_price AS 'Ticket Price',
                            r.through_location AS 'Through'

                        FROM 
                            bus b
                        JOIN 
                            routing r ON b.bus_id = r.bus_id"; // Query to fetch bus data along with routing information and ticket price
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt; // Bind data to DataGridView

                    // Store original colors
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        originalColors[i] = dataGridView1.Rows[i].DefaultCellStyle.BackColor;
                    }

                    // Adjust the height of the DataGridView dynamically
                    AdjustDataGridViewHeight();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void AdjustDataGridViewHeight()
        {
            int totalRowHeight = dataGridView1.Rows.Cast<DataGridViewRow>().Sum(row => row.Height);
            int headerHeight = dataGridView1.ColumnHeadersHeight;
            int totalHeight = totalRowHeight + headerHeight + dataGridView1.Margin.Vertical;
            dataGridView1.Height = totalHeight;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell click event if needed
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
            panel2.BringToFront();
            panel2.Controls.Clear();

            // Add the UserControl to the panel
            userControl.Dock = DockStyle.None;  // Dock to fill the panel
            userControl.BringToFront();
            panel2.Controls.Add(userControl);  // Add UserControl to the panel
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure that a valid row is selected (ignore header row clicks)
            if (e.RowIndex >= 0)
            {
                // Select the entire row
                dataGridView1.Rows[e.RowIndex].Selected = true;

                // Get the selected row
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Extract data from the selected row
                string busID = row.Cells["Bus ID"].Value.ToString();
                string busNumber = row.Cells["Bus Number"].Value.ToString();
                string busName = row.Cells["Bus Name"].Value.ToString();
                string busType = row.Cells["Bus Type"].Value.ToString();
                string totalSeats = row.Cells["Total Seats"].Value.ToString();
                string departureLocation = row.Cells["Start"].Value.ToString();
                string throughLocation = row.Cells["Through"].Value.ToString();
                string arrivalLocation = row.Cells["Destination"].Value.ToString();
                string departureTime = row.Cells["Departure Time"].Value.ToString();
                string arrivalTime = row.Cells["Reach Time"].Value.ToString();
                string ticketPrice = row.Cells["Ticket Price"].Value.ToString();

                // Display selected bus details in a MessageBox (or TextBoxes)
                MessageBox.Show($"Selected Bus:\nID: {busID}\nNumber: {busNumber}\nName: {busName}\nType: {busType}\nSeats: {totalSeats}\nDeparture: {departureLocation} at {departureTime}\nArrival: {arrivalLocation} at {arrivalTime}\nTicket Price: {ticketPrice}", "Bus Details");

                GoBackbtn.Visible = true;
                LoadUserControl(new SeatLayout(busID));
            }
        }

        private void GoBackbtn_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(new BusList());
        }
    }
}