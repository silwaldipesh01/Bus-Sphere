using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Bus_Sphere
{
    public partial class AddBookingForm : UserControl
    {
        private const string connectionString = "server=localhost;user=root;database=bussphere;port=3306;password=";
        private int? currentRouteId;

        public AddBookingForm()
        {
            InitializeComponent();
            ApplyStyles();
            LoadBusData();
            InitializeDateTimePickers();
        }

        public AddBookingForm(int routeId) : this()
        {
            currentRouteId = routeId;
            LoadBookingDetails(routeId);
        }

        private void ApplyStyles()
        {
            // Apply styles to text boxes
            TxtBxSource.BackColor = Color.Beige;
            TxtBxDestination.BackColor = Color.Beige;
            TxtBxThrough.BackColor = Color.Beige;
            TxtBxTicketPrice.BackColor = Color.Beige;
            TxtBusNumber.BackColor = Color.Beige;

            TxtBxSource.ForeColor = Color.Black;
            TxtBxDestination.ForeColor = Color.Black;
            TxtBxThrough.ForeColor = Color.Black;
            TxtBxTicketPrice.ForeColor = Color.Black;
            TxtBusNumber.ForeColor = Color.Black;

            // Apply styles to buttons
            BtnAddRoute.BackColor = Color.FromArgb(30, 129, 176);
            BtnAddRoute.ForeColor = Color.White;

            BtnAddRoute.FlatAppearance.MouseOverBackColor = Color.FromArgb(36, 154, 211);
            BtnAddRoute.FlatAppearance.MouseDownBackColor = Color.FromArgb(36, 154, 211);

            // Apply styles to labels
            lblStart.ForeColor = Color.Black;
            lblthrough.ForeColor = Color.Black;
            label1.ForeColor = Color.Black;
            lblTicketPrice.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            lblStartDate.ForeColor = Color.Black;
            lblEndDate.ForeColor = Color.Black;

            // Apply styles to DataGridView
            BusNameGridView.BackgroundColor = Color.Beige;
            BusNameGridView.ForeColor = Color.Black;
            BusNameGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 140, 178);
            BusNameGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            BusNameGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            BusNameGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            BusNameGridView.ColumnHeadersHeight = 60; // Set header height
            BusNameGridView.DefaultCellStyle.BackColor = Color.Beige;
            BusNameGridView.DefaultCellStyle.ForeColor = Color.Black;
            BusNameGridView.DefaultCellStyle.Font = new Font("Arial", 12);
            BusNameGridView.RowTemplate.Height = 30; // Set row height
            BusNameGridView.EnableHeadersVisualStyles = false;

            BusNameGridView.CellClick += BusNameGridView_CellClick;
        }

        private void LoadBusData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // Query to get buses that are not assigned
                    string query = @"
                        SELECT bus_id, bus_name 
                        FROM bus 
                        WHERE bus_id NOT IN (SELECT bus_id FROM routing)";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    BusNameGridView.DataSource = dt;
                    BusNameGridView.Columns["bus_id"].HeaderText = "Bus ID";
                    BusNameGridView.Columns["bus_name"].HeaderText = "Bus Name";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bus data: {ex.Message}", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBookingDetails(int routeId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            r.departure_location, 
                            r.arrival_location, 
                            r.through_location, 
                            r.ticket_price, 
                            r.departure_time, 
                            r.arrival_time, 
                            b.bus_id 
                        FROM 
                            routing r 
                        JOIN 
                            bus b ON r.bus_id = b.bus_id 
                        WHERE 
                            r.route_id = @route_id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@route_id", routeId);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        try
                        {
                            TxtBxSource.Text = reader["departure_location"].ToString();
                            TxtBxDestination.Text = reader["arrival_location"].ToString();
                            TxtBxThrough.Text = reader["through_location"].ToString();
                            TxtBxTicketPrice.Text = reader["ticket_price"].ToString();

                            if (reader["departure_time"] != DBNull.Value)
                            {
                                StartDateTimePicker.Value = Convert.ToDateTime(reader["departure_time"]);
                            }
                            else
                            {
                                StartDateTimePicker.Value = DateTime.Now; // Or any default value
                            }

                            if (reader["arrival_time"] != DBNull.Value)
                            {
                                EndDateTimePicker.Value = Convert.ToDateTime(reader["arrival_time"]);
                            }
                            else
                            {
                                EndDateTimePicker.Value = DateTime.Now; // Or any default value
                            }

                            TxtBusNumber.Text = reader["bus_id"].ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error converting Date: " + ex.Message, "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                BtnAddRoute.Text = "Update Route";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading booking details: {ex.Message}", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsFormValid()
        {
            if (string.IsNullOrWhiteSpace(TxtBxSource.Text))
            {
                MessageBox.Show("Please enter the departure location.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtBxDestination.Text))
            {
                MessageBox.Show("Please enter the arrival location.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtBxThrough.Text))
            {
                MessageBox.Show("Please enter the through location.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtBxTicketPrice.Text) || !decimal.TryParse(TxtBxTicketPrice.Text, out _))
            {
                MessageBox.Show("Please enter a valid ticket price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtBusNumber.Text))
            {
                MessageBox.Show("Please select a bus from the table.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private int GetSelectedBusId()
        {
            if (BusNameGridView.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(BusNameGridView.SelectedRows[0].Cells["bus_id"].Value);
            }
            return -1;
        }

        private void BusNameGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow row = BusNameGridView.Rows[e.RowIndex];

                // Extract data from the selected row
                TxtBusNumber.Text = row.Cells["bus_id"].Value.ToString();
            }
        }

        private void BtnAddRoute_Click_1(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query;

                        if (currentRouteId.HasValue)
                        {
                            // Update existing booking
                            query = @"
                                UPDATE routing 
                                SET 
                                    departure_location = @departure_location, 
                                    arrival_location = @arrival_location, 
                                    through_location = @through_location, 
                                    ticket_price = @ticket_price, 
                                    departure_time = @departure_time, 
                                    arrival_time = @arrival_time, 
                                    bus_id = @bus_id 
                                WHERE 
                                    route_id = @route_id";
                        }
                        else
                        {
                            // Insert new booking
                            query = @"
                                INSERT INTO routing 
                                (departure_location, arrival_location, through_location, ticket_price, departure_time, arrival_time, bus_id)
                                VALUES (@departure_location, @arrival_location, @through_location, @ticket_price, @departure_time, @arrival_time, @bus_id)";
                        }

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@departure_location", TxtBxSource.Text);
                            cmd.Parameters.AddWithValue("@arrival_location", TxtBxDestination.Text);
                            cmd.Parameters.AddWithValue("@through_location", TxtBxThrough.Text);
                            cmd.Parameters.AddWithValue("@ticket_price", TxtBxTicketPrice.Text);
                            cmd.Parameters.AddWithValue("@departure_time", StartDateTimePicker.Value);
                            cmd.Parameters.AddWithValue("@arrival_time", EndDateTimePicker.Value);
                            cmd.Parameters.AddWithValue("@bus_id", Convert.ToInt32(TxtBusNumber.Text));

                            if (currentRouteId.HasValue)
                            {
                                cmd.Parameters.AddWithValue("@route_id", currentRouteId.Value);
                            }

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Booking saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving booking: {ex.Message}", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InitializeDateTimePickers()
        {
            // Ensure the DateTimePickers are initialized
            if (StartDateTimePicker == null)
            {
                StartDateTimePicker = new DateTimePicker();
                StartDateTimePicker.Format = DateTimePickerFormat.Custom;
                StartDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            }

            if (EndDateTimePicker == null)
            {
                EndDateTimePicker = new DateTimePicker();
                EndDateTimePicker.Format = DateTimePickerFormat.Custom;
                EndDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}