using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using Bus_Sphere.Models;
using Bus_Sphere.CustomControls;
using Bus_Sphere.Services;
using System.Threading.Tasks;

namespace Bus_Sphere.CustomForm
{
    public partial class SeatLayout : UserControl
    {
        private readonly string connectionString =
            "server=localhost;user=root;database=bussphere;port=3306;password=";

        private readonly EmailService _emailService;
        private readonly PdfService _pdfService;

        public string BusId { get; set; }
        private List<Seat> seats = new List<Seat>();
        public PassengerDetail passengerDetail = new();

        public SeatLayout(string busId)
        {
            InitializeComponent();
            BusId = busId;
            _emailService = new EmailService();
            _pdfService = new PdfService();
            LoadSeatData();
            LoadRoutingData();
        }

        private void LoadRoutingData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            r.route_id,
                            r.bus_id,
                            r.departure_location,
                            r.arrival_location,
                            r.departure_time,
                            r.arrival_time,
                            r.ticket_price,
                            r.through_location,
                            b.bus_name,
                            b.bus_type,
                            b.bus_number
                        FROM 
                            routing r
                        JOIN 
                            bus b ON r.bus_id = b.bus_id
                        JOIN
                            seats s ON r.bus_id = s.bus_id
                             
                        WHERE 
                            r.bus_id = @BusId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BusId", BusId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string routeId = reader["route_id"]?.ToString()?.Trim() ?? "";
                                string busId = reader["bus_id"]?.ToString()?.Trim() ?? "";
                                string departureLocation = reader["departure_location"]?.ToString()?.Trim() ?? "";
                                string arrivalLocation = reader["arrival_location"]?.ToString()?.Trim() ?? "";
                                string departureTime = reader["departure_time"]?.ToString()?.Trim() ?? "";
                                string arrivalTime = reader["arrival_time"]?.ToString()?.Trim() ?? "";
                                string ticketPrice = reader["ticket_price"]?.ToString()?.Trim() ?? "";
                                string throughLocation = reader["through_location"]?.ToString()?.Trim() ?? "";
                                string busName = reader["bus_name"]?.ToString()?.Trim() ?? "";
                                string busType = reader["bus_type"]?.ToString()?.Trim() ?? "";
                                string busNumber = reader["bus_number"]?.ToString()?.Trim() ?? "";

                                // Use two lines (rows) for the label text, omitting route and bus IDs:
                                RoutingInfoLbl.Text =
                                    $"Bus Name: {busName} | Bus Type: {busType} | Bus Number: {busNumber}" +
                                    $"\n\nRoute : {departureLocation}  ->  {throughLocation}  ->  {arrivalLocation} | Ticket Price: {ticketPrice} " +
                                    $"\n\nTravel Duration: {departureTime}  ->  {arrivalTime}";

                                passengerDetail = new PassengerDetail
                                {
                                    BusNo = busNumber,
                                    BusName = busName,
                                    BusType = busType,
                                    Source = departureLocation,
                                    Destination = arrivalLocation,
                                    Through = throughLocation,
                                    Date = DateTime.Now.ToString(),
                                    ArrivalTime = arrivalTime,
                                    DepartureTime = departureTime,
                                    TicketPrice = Convert.ToDecimal(ticketPrice)
                                };

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading routing data: " + ex.Message);
            }
        }

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
            if (!ValidateInputs())
                return;

            CheckAndBookSeats();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CancelSeatTxtBox.Text))
            {
                MessageBox.Show("Please enter a seat number to cancel.");
                return;
            }

            CancelSeats();
        }

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

        private void CheckAndBookSeats()
        {
            if (string.IsNullOrWhiteSpace(seatLbl.Text))
            {
                MessageBox.Show("Please select a seat.");
                return;
            }

            string[] selectedSeats = seatsTxtBx.Text
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            if (selectedSeats.Length > 5)
            {
                MessageBox.Show("You can book up to 5 seats at a time.");
                return;
            }

            List<string> invalidOrUnavailable = new List<string>();
            foreach (string seatNo in selectedSeats)
            {
                var seatObj = seats.FirstOrDefault(s =>
                    s.SeatNumber.Equals(seatNo, StringComparison.OrdinalIgnoreCase));

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
            passengerDetail.Seats = seatsTxtBx.Text;
            passengerDetail.Email = emailTxt.Text;
            passengerDetail.noOfSeats = selectedSeats.Length;
            passengerDetail.Address = addressTxtBx.Text;
            passengerDetail.Name = nameTxt.Text;
            passengerDetail.PhoneNumber = phoneTxt.Text;

            PerformBooking(selectedSeats);
        }

        private bool IsSeatCurrentlyAvailable(Seat seatObj)
        {
            return seatObj.Status == Seat.BookingStatus.Available;
        }

        private async void PerformBooking(string[] seatNumbers)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    int passengerId = InsertOrGetPassengerId(nameTxt.Text.Trim(), phoneTxt.Text.Trim(), emailTxt.Text.Trim());
                    passengerDetail.Id = passengerId;

                    foreach (string seatNo in seatNumbers)
                    {
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

                        var seatObj = seats.FirstOrDefault(s =>
                            s.SeatNumber.Equals(seatNo, StringComparison.OrdinalIgnoreCase));
                        if (seatObj != null)
                        {
                            seatObj.Status = Seat.BookingStatus.Booked;
                        }
                    }

                    MessageBox.Show("Booking successful!");

                    await SendEmailAsync(passengerDetail);
                    ResetBookingForm();
                    UpdateSeatDisplay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error booking seats: " + ex.Message);
            }
        }

        private void CancelSeats()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string[] seatsToCancel = CancelSeatTxtBox.Text
                        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim())
                        .ToArray();

                    List<string> unavailableSeats = new List<string>();
                    List<string> cancelledSeats = new List<string>();

                    foreach (string seatNo in seatsToCancel)
                    {
                        var seatObj = seats.FirstOrDefault(s =>
                            s.SeatNumber.Equals(seatNo, StringComparison.OrdinalIgnoreCase));

                        if (seatObj == null || seatObj.Status == Seat.BookingStatus.Unavailable)
                        {
                            unavailableSeats.Add(seatNo);
                            continue;
                        }

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

                        string deleteBookingQuery = @"
                            DELETE FROM bookings
                            WHERE bus_id = @bus_id AND seatNo = @seatNo";

                        using (MySqlCommand deleteCmd = new MySqlCommand(deleteBookingQuery, conn))
                        {
                            deleteCmd.Parameters.AddWithValue("@bus_id", BusId);
                            deleteCmd.Parameters.AddWithValue("@seatNo", seatNo);
                            deleteCmd.ExecuteNonQuery();
                        }

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

        private int InsertOrGetPassengerId(string name, string phone, string email)
        {
            int passengerId = 0;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

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

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CancelSeatTxtBox.Text))
            {
                MessageBox.Show("Please enter a seat number to cancel.");
                return;
            }

            CancelSeats();

        }



        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        async Task SendEmailAsync(PassengerDetail passengerDetail)
        {
            try
            {
                string ticketPath = _pdfService.CreateTicket(passengerDetail);
                await _emailService.SendTicketEmailAsync(passengerDetail, ticketPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message);
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
