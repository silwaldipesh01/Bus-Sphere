using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using Bus_Sphere.Models;
using Bus_Sphere.CustomControls;


using System.Net.Mail;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Net;
using static Bus_Sphere.CustomForm.SeatSelection;
using Rectangle = iTextSharp.text.Rectangle;
using Font = iTextSharp.text.Font;

namespace Bus_Sphere.CustomForm
{
    public partial class SeatLayout : UserControl
    {
        private readonly string connectionString =
            "server=localhost;user=root;database=bussphere;port=3306;password=";

        public string BusId { get; set; }
        private List<Seat> seats = new List<Seat>();
       public PassengerDetail passengerDetail = new();

        public SeatLayout(string busId)
        {
            InitializeComponent();
            BusId = busId;
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

                                RoutingInfoLbl.Text = $"Route ID: {routeId}\n" +
                                    $"Bus ID: {busId}\n" +
                                    $"Bus Name: {busName}\n" +
                                    $"Bus Type: {busType}\n" +
                                    $"Departure: {departureLocation}\n" +
                                    $"Through: {throughLocation}\n" +
                                    $"Arrival: {arrivalLocation}\n" +
                                    $"Departure Time: {departureTime}\n" +
                                    $"Arrival Time: {arrivalTime}\n" +
                                    $"Ticket Price: {ticketPrice}" + "\n" +
                                    $"Bus Number: {busNumber}";
                                
                                passengerDetail.BusNo = busNumber;
                                passengerDetail.BusName = busName;
                                passengerDetail.BusType = busType;
                                passengerDetail.Source = departureLocation;
                                passengerDetail.Destination = arrivalLocation;
                                passengerDetail.Through = throughLocation;
                                passengerDetail.Date = DateTime.Now.ToString();
                                passengerDetail.ArrivalTime = arrivalTime;
                                passengerDetail.DepartureTime = departureTime;
                                passengerDetail.TicketPrice = Convert.ToDecimal(ticketPrice);

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

                   await  SendEmailAsync(passengerDetail);
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

        private void CancelBtn_Click_1(object sender, EventArgs e)
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
        static async Task SendEmailAsync(PassengerDetail passengerDetail)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("esp32alertdipesh@gmail.com");
            mail.To.Add(passengerDetail.Email);
            mail.Subject = "Ticket Confirmation for " + passengerDetail.Name;
            mail.Body = "Dear " + passengerDetail.Name + ",\n\nPlease find attached your ticket.\n\nBest regards,\nBus Sphere";

            string ticketPath = CreateTicket(passengerDetail);
            Attachment attachment = new Attachment(ticketPath);
            mail.Attachments.Add(attachment);

            try
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("esp32alertdipesh@gmail.com", "nouv lwqe ohkg menh");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                await smtpClient.SendMailAsync(mail);
                MessageBox.Show("Email sent successfully to " + passengerDetail.Email);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message);
            }
        }

        static string CreateTicket(PassengerDetail passengerDetail)
        {
            string outputPath = $"C:\\Users\\silwa\\source\\repos\\pdfGeneration\\ticket_{passengerDetail.Id}.pdf";

            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(outputPath, FileMode.Create));
            writer.PageEvent = new PdfPageEvents();

            try
            {
                doc.Open();
                doc.Add(new Paragraph("\n\n\n\n\n\n"));

                Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);
                Font regularFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                doc.Add(new Paragraph("Bus Sphere Ticket", titleFont) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph(" "));

                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 1, 2 });

                table.AddCell(new PdfPCell(new Phrase("Passenger Name:", regularFont)) { Border = Rectangle.NO_BORDER });
                table.AddCell(new PdfPCell(new Phrase(passengerDetail.Name, regularFont)) { Border = Rectangle.NO_BORDER });

                table.AddCell(new PdfPCell(new Phrase("Passenger Email:", regularFont)) { Border = Rectangle.NO_BORDER });
                table.AddCell(new PdfPCell(new Phrase(passengerDetail.Email, regularFont)) { Border = Rectangle.NO_BORDER });

                table.AddCell(new PdfPCell(new Phrase("Phone Number:", regularFont)) { Border = Rectangle.NO_BORDER });
                table.AddCell(new PdfPCell(new Phrase(passengerDetail.PhoneNumber, regularFont)) { Border = Rectangle.NO_BORDER });

                table.AddCell(new PdfPCell(new Phrase("Address:", regularFont)) { Border = Rectangle.NO_BORDER });
                table.AddCell(new PdfPCell(new Phrase(passengerDetail.Address, regularFont)) { Border = Rectangle.NO_BORDER });

                table.AddCell(new PdfPCell(new Phrase("Bus Number:", regularFont)) { Border = Rectangle.NO_BORDER });
                table.AddCell(new PdfPCell(new Phrase(passengerDetail.BusNo, regularFont)) { Border = Rectangle.NO_BORDER });

                table.AddCell(new PdfPCell(new Phrase("Bus Name:", regularFont)) { Border = Rectangle.NO_BORDER });
                table.AddCell(new PdfPCell(new Phrase(passengerDetail.BusName, regularFont)) { Border = Rectangle.NO_BORDER });

                table.AddCell(new PdfPCell(new Phrase("Bus Type:", regularFont)) { Border = Rectangle.NO_BORDER });
                table.AddCell(new PdfPCell(new Phrase(passengerDetail.BusType, regularFont)) { Border = Rectangle.NO_BORDER });

                table.AddCell(new PdfPCell(new Phrase("Seat Numbers:", regularFont)) { Border = Rectangle.NO_BORDER });
                table.AddCell(new PdfPCell(new Phrase(string.Join(", ", passengerDetail.Seats), regularFont)) { Border = Rectangle.NO_BORDER });

                table.AddCell(new PdfPCell(new Phrase("Departure Date:", regularFont)) { Border = Rectangle.NO_BORDER });
                table.AddCell(new PdfPCell(new Phrase(passengerDetail.Date, regularFont)) { Border = Rectangle.NO_BORDER });

                table.AddCell(new PdfPCell(new Phrase("Departure Time:", regularFont)) { Border = Rectangle.NO_BORDER });
                table.AddCell(new PdfPCell(new Phrase(passengerDetail.DepartureTime, regularFont)) { Border = Rectangle.NO_BORDER });

                table.AddCell(new PdfPCell(new Phrase("Departure Location:", regularFont)) { Border = Rectangle.NO_BORDER });
                table.AddCell(new PdfPCell(new Phrase(passengerDetail.Source, regularFont)) { Border = Rectangle.NO_BORDER });

                table.AddCell(new PdfPCell(new Phrase("Arrival Time:", regularFont)) { Border = Rectangle.NO_BORDER });
                table.AddCell(new PdfPCell(new Phrase(passengerDetail.ArrivalTime, regularFont)) { Border = Rectangle.NO_BORDER });

                table.AddCell(new PdfPCell(new Phrase("Arrival Location:", regularFont)) { Border = Rectangle.NO_BORDER });
                table.AddCell(new PdfPCell(new Phrase(passengerDetail.Destination, regularFont)) { Border = Rectangle.NO_BORDER });

                table.AddCell(new PdfPCell(new Phrase("Ticket Price:", regularFont)) { Border = Rectangle.NO_BORDER });
                string ticketPrice = Convert.ToInt32(passengerDetail.TicketPrice).ToString();
                table.AddCell(new PdfPCell(new Phrase(ticketPrice, regularFont)) { Border = Rectangle.NO_BORDER });

                table.AddCell(new PdfPCell(new Phrase("Total Price  :", regularFont)) { Border = Rectangle.NO_BORDER });
                string total = (Convert.ToInt32(passengerDetail.TicketPrice) * passengerDetail.Seats.Length).ToString();
                table.AddCell(new PdfPCell(new Phrase(total, regularFont)) { Border = Rectangle.NO_BORDER });




                doc.Add(table);

                doc.Add(new Paragraph("\n\n"));
                doc.Add(new Paragraph("Thank you for choosing Bus Sphere. We wish you a pleasant journey!", regularFont) { Alignment = Element.ALIGN_CENTER });

                doc.Close();
                MessageBox.Show("PDF created successfully at " + outputPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : "+ ex);
            }

            return outputPath;
        }

        public class PdfPageEvents : PdfPageEventHelper
        {
            public override void OnEndPage(PdfWriter writer, Document document)
            {
                PdfPTable headerTable = new PdfPTable(1);
                headerTable.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;

                headerTable.HorizontalAlignment = Element.ALIGN_CENTER;
                string imagePath = "C:\\Users\\silwa\\source\\repos\\Bus Sphere\\Images\\busLogo.png";
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagePath);
                image.ScaleToFit(474f, 87f);
                PdfPCell imageCell = new PdfPCell(image);
                imageCell.Border = Rectangle.NO_BORDER;
                imageCell.HorizontalAlignment = Element.ALIGN_CENTER;
                headerTable.AddCell(imageCell);

                Font font = FontFactory.GetFont(FontFactory.HELVETICA, 44, BaseColor.BLACK);
                PdfPCell headerCell = new PdfPCell(new Phrase("Bus Sphere", font));
                headerCell.Border = Rectangle.NO_BORDER;
                headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                headerTable.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - 15, writer.DirectContent);
            }
        }

    }
}
