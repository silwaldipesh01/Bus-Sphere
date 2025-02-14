using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.IO;
using Bus_Sphere.CustomControls;

using static Bus_Sphere.CustomForm.SeatSelection;

namespace Bus_Sphere.CustomForm
{
    public partial class SeatLayout : UserControl
    {
        private readonly string connectionString =
            "server=localhost;user=root;database=bussphere;port=3306;password=";

        public string BusId { get; set; }
        private List<Seat> seats = new List<Seat>();

        public SeatLayout(string busId)
        {
            InitializeComponent();
            BusId = busId;
            LoadSeatData();
        }

        /// <summary>
        /// Loads seat information from the database and populates the local list of seats.
        /// </summary>
        private void LoadSeatData()
        {
            try
            {
                seats.Clear();

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT seatNo, Status FROM seats WHERE bus_id = @BusId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BusId", BusId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string seatNumber = reader["seatNo"]?.ToString()?.Trim() ?? "";
                                string dbStatus = reader["Status"]?.ToString()?.Trim() ?? "";

                                if (string.IsNullOrEmpty(seatNumber))
                                    continue;

                                if (Enum.TryParse(dbStatus, true, out Seat.BookingStatus parsedStatus))
                                {
                                    seats.Add(new Seat(seatNumber, parsedStatus));
                                }
                            }
                        }
                    }
                }

                UpdateSeatDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading seats: " + ex.Message);
            }
        }

        /// <summary>
        /// Updates the visual display of seat buttons based on their current status.
        /// </summary>
        private void UpdateSeatDisplay()
        {
            foreach (var seat in seats)
            {
                CustomBtn button = this.Controls
                    .Find("customBtn" + seat.SeatNumber, true)
                    .FirstOrDefault() as CustomBtn;

                if (button != null)
                {
                    // Assign color based on status
                    button.BackColor = seat.GetSeatAvailabilityColor();
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 1. Validate user input (name, phone, email).
            if (!ValidateInputs())
                return;

            // 2. Apply seat booking logic if user inputs are valid.
            CheckAndBookSeats();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // 1. Validate seat input for cancellation.
            if (string.IsNullOrWhiteSpace(CancelSeatTxtBox.Text))
            {
                MessageBox.Show("Please enter a seat number to cancel.");
                return;
            }

            // 2. Apply seat cancellation logic.
            CancelSeats();
        }

        /// <summary>
        /// Verifies name, phone, and email fields.
        /// </summary>
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(nameTxt.Text) || !IsValidName(nameTxt.Text))
            {
                MessageBox.Show("Please enter a valid name.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(phoneTxt.Text) || !IsValidPhone(phoneTxt.Text))
            {
                MessageBox.Show("Please enter a valid phone number.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(emailTxt.Text) || !IsValidEmail(emailTxt.Text))
            {
                MessageBox.Show("Please enter a valid email.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Splits the seat selection input, checks each seat's availability, then books them if available.
        /// </summary>
        private void CheckAndBookSeats()
        {
            if (string.IsNullOrWhiteSpace(seatLbl.Text))
            {
                MessageBox.Show("Please select a seat.");
                return;
            }

            // Split comma-separated seat inputs
            string[] selectedSeats = seatsTxtBx.Text
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            if (selectedSeats.Length > 5)
            {
                MessageBox.Show("You can book up to 5 seats at a time.");
                return;
            }

            // Identify seats that are unavailable or not found
            List<string> invalidOrUnavailable = new List<string>();
            foreach (string seatNo in selectedSeats)
            {
                // Find the seat in the local seat list
                var seatObj = seats.FirstOrDefault(s =>
                    s.SeatNumber.Equals(seatNo, StringComparison.OrdinalIgnoreCase));

                // If seat does not exist, or is not 'Available', treat as unavailable
                if (seatObj == null || !IsSeatCurrentlyAvailable(seatObj))
                {
                    invalidOrUnavailable.Add(seatNo);
                }
            }

            if (invalidOrUnavailable.Any())
            {
                MessageBox.Show("Cannot book these seats (already booked/unavailable): "
                    + string.Join(", ", invalidOrUnavailable));
                seatsTxtBx.Text = "";
                return;
            }

            // If all seats are good, proceed to book them
            PerformBooking(selectedSeats);
        }

        /// <summary>
        /// Checks if a seat is marked "Available" in local memory.
        /// Additional checks or real-time re-queries could be added here if desired.
        /// </summary>
        private bool IsSeatCurrentlyAvailable(Seat seatObj)
        {
            return seatObj.Status == Seat.BookingStatus.Available;
        }

        /// <summary>
        /// Inserts bookings into the database, updates the seat statuses,
        /// and refreshes the seat display.
        /// </summary>
        private void PerformBooking(string[] seatNumbers)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Insert or get passenger ID
                    int passengerId = InsertOrGetPassengerId(nameTxt.Text.Trim(), phoneTxt.Text.Trim(), emailTxt.Text.Trim());

                    foreach (string seatNo in seatNumbers)
                    {
                        // Insert new booking record
                        string insertQuery = @"
                            INSERT INTO bookings (passenger_id, seatNo, bus_id)
                            VALUES (@passenger_id, @seatNo, @bus_id)";

                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@passenger_id", passengerId);
                            cmd.Parameters.AddWithValue("@seatNo", seatNo);
                            cmd.Parameters.AddWithValue("@bus_id", BusId);
                            cmd.ExecuteNonQuery();
                        }

                        // Update seat table to reflect the new 'Booked' status
                        string updateSeatQuery = @"
                            UPDATE seats
                            SET Status = 'Booked'
                            WHERE bus_id = @bus_id AND seatNo = @seatNo";

                        using (MySqlCommand updateCmd = new MySqlCommand(updateSeatQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@bus_id", BusId);
                            updateCmd.Parameters.AddWithValue("@seatNo", seatNo);
                            updateCmd.ExecuteNonQuery();
                        }

                        // Update local seat object as well
                        var seatObj = seats.FirstOrDefault(s =>
                            s.SeatNumber.Equals(seatNo, StringComparison.OrdinalIgnoreCase));
                        if (seatObj != null)
                        {
                            seatObj.Status = Seat.BookingStatus.Booked;
                        }
                    }

                    MessageBox.Show("Booking successful!");
                    ResetBookingForm();
                    UpdateSeatDisplay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error booking seats: " + ex.Message);
            }
        }

        /// <summary>
        /// Cancels the seats specified in the CancelSeatTxtBox.
        /// </summary>
        private void CancelSeats()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Split comma-separated seat inputs
                    string[] seatsToCancel = CancelSeatTxtBox.Text
                        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim())
                        .ToArray();

                    List<string> unavailableSeats = new List<string>();
                    List<string> cancelledSeats = new List<string>();

                    foreach (string seatNo in seatsToCancel)
                    {
                        // Find the seat in the local seat list
                        var seatObj = seats.FirstOrDefault(s =>
                            s.SeatNumber.Equals(seatNo, StringComparison.OrdinalIgnoreCase));

                        if (seatObj == null || seatObj.Status == Seat.BookingStatus.Unavailable)
                        {
                            unavailableSeats.Add(seatNo);
                            continue;
                        }

                        // Update seat table to reflect the new 'Available' status
                        string updateSeatQuery = @"
                            UPDATE seats
                            SET Status = 'Available'
                            WHERE bus_id = @bus_id AND seatNo = @seatNo";

                        using (MySqlCommand updateCmd = new MySqlCommand(updateSeatQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@bus_id", BusId);
                            updateCmd.Parameters.AddWithValue("@seatNo", seatNo);
                            updateCmd.ExecuteNonQuery();
                        }

                        // Remove booking record
                        string deleteBookingQuery = @"
                            DELETE FROM bookings
                            WHERE bus_id = @bus_id AND seatNo = @seatNo";

                        using (MySqlCommand deleteCmd = new MySqlCommand(deleteBookingQuery, conn))
                        {
                            deleteCmd.Parameters.AddWithValue("@bus_id", BusId);
                            deleteCmd.Parameters.AddWithValue("@seatNo", seatNo);
                            deleteCmd.ExecuteNonQuery();
                        }

                        // Update local seat object as well
                        if (seatObj != null)
                        {
                            seatObj.Status = Seat.BookingStatus.Available;
                            cancelledSeats.Add(seatNo);
                        }
                    }

                    if (unavailableSeats.Any())
                    {
                        MessageBox.Show("Cannot cancel these seats (unavailable/not found): "
                            + string.Join(", ", unavailableSeats));
                    }

                    if (cancelledSeats.Any())
                    {
                        MessageBox.Show("Seats cancelled successfully: "
                            + string.Join(", ", cancelledSeats));
                    }

                    ResetCancellationForm();
                    UpdateSeatDisplay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cancelling seats: " + ex.Message);
            }
        }

        /// <summary>
        /// Inserts a new passenger or retrieves the ID of an existing passenger
        /// based on phone and email.
        /// </summary>
        private int InsertOrGetPassengerId(string name, string phone, string email)
        {
            int passengerId = 0;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Check if the passenger already exists
                string selectQuery = @"
                    SELECT passenger_id 
                    FROM passengers 
                    WHERE phone = @phone AND email = @email 
                    LIMIT 1";
                using (var selectCmd = new MySqlCommand(selectQuery, conn))
                {
                    selectCmd.Parameters.AddWithValue("@phone", phone);
                    selectCmd.Parameters.AddWithValue("@email", email);

                    object result = selectCmd.ExecuteScalar();
                    if (result != null)
                    {
                        passengerId = Convert.ToInt32(result);
                        return passengerId;
                    }
                }

                // If passenger not found, insert a new record
                string insertQuery = @"
                    INSERT INTO passengers (name, phone, email)
                    VALUES (@name, @phone, @email);
                    SELECT LAST_INSERT_ID()";
                using (var insertCmd = new MySqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@name", name);
                    insertCmd.Parameters.AddWithValue("@phone", phone);
                    insertCmd.Parameters.AddWithValue("@email", email);

                    object newId = insertCmd.ExecuteScalar();
                    passengerId = Convert.ToInt32(newId);
                }
            }
            return passengerId;
        }

        private bool IsValidEmail(string email)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private bool IsValidPhone(string phone)
        {
            var pattern = @"^\d+$";
            return Regex.IsMatch(phone, pattern);
        }

        private bool IsValidName(string name)
        {
            var pattern = @"^[a-zA-Z\s]+$";
            return Regex.IsMatch(name, pattern);
        }

        private void ResetBookingForm()
        {
            nameTxt.Text = "";
            phoneTxt.Text = "";
            emailTxt.Text = "";
            seatsTxtBx.Text = "";
            addressTxtBx.Text = "";

        }

        private void ResetCancellationForm()
        {
            CancelSeatTxtBox.Text = "";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CancelSeatTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void customBtn32_Click(object sender, EventArgs e)
        {

        }

        private void CancelBtn_Click_1(object sender, EventArgs e)
        {
            // 1. Validate seat input for cancellation.
            if (string.IsNullOrWhiteSpace(CancelSeatTxtBox.Text))
            {
                MessageBox.Show("Please enter a seat number to cancel.");
                return;
            }

            // 2. Apply seat cancellation logic.
            CancelSeats();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}