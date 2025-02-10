using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Bus_Sphere.CustomControls;
using MySql.Data.MySqlClient;

namespace Bus_Sphere.CustomForm
{
    public partial class SeatSelection : UserControl
    {
        private List<CustomBtn> seatButtons = new List<CustomBtn>(); // Custom Button List
        private List<Seat> seats = new List<Seat>();
        public string busid;
        string connectionString = "server=localhost;user=root;database=bussphere;port=3306;password=";

        public SeatSelection(string busid)
        {
            InitializeComponent();
            this.busid = busid;
            InitializeSeatButtons();
            LoadSeatsFromDatabase(busid); // Load seats for the specified BusID
        }

        public void SeatBtnPressed(string seatNumber)
        {
            // Implement seat button pressed logic here
        }

        private void InitializeSeatButtons()
        {
            // Add manually created custom buttons to the list
            seatButtons.AddRange(new[]
            {
                customBtn1, customBtn2, customBtn3, customBtn4, customBtn5, customBtn6,
                customBtn7, customBtn8, customBtn9, customBtn10, customBtn11, customBtn12,
                customBtn13, customBtn14, customBtn15, customBtn16, customBtn17, customBtn18,
                customBtn19, customBtn20, customBtn21, customBtn22, customBtn23, customBtn24,
                customBtn25, customBtn26, customBtn27, customBtn28, customBtn29, customBtn30,
                customBtn31
            });

            foreach (var button in seatButtons)
            {
                button.Click += SeatButton_Click; // Assign click event
            }
        }

        private void LoadSeatsFromDatabase(string busId)
        {
            seats.Clear();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "SELECT seatNO, Status FROM Seats WHERE bus_id = @bus_id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@bus_id", busId);

                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string seatNumber = reader["seatNO"].ToString();
                        Seat.BookingStatus status = (Seat.BookingStatus)Enum.Parse(
                            typeof(Seat.BookingStatus),
                            reader["Status"].ToString()
                        );

                        seats.Add(new Seat(seatNumber, status));
                    }
                }

                // Assign seat objects to custom buttons
                for (int i = 0; i < seatButtons.Count && i < seats.Count; i++)
                {
                    seatButtons[i].Tag = seats[i]; // Store seat object inside button
                    seatButtons[i].BackColor = seats[i].GetSeatAvailabilityColor(); // Set color
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            CustomBtn clickedButton = sender as CustomBtn;
            Seat selectedSeat = (Seat)clickedButton.Tag;
            try
            {

                if (selectedSeat.Status == Seat.BookingStatus.Available)
                {
                    selectedSeat.Status = Seat.BookingStatus.Booked;
                    clickedButton.BackColor = selectedSeat.GetSeatAvailabilityColor();
                    UpdateSeatInDatabase(selectedSeat, busid); // Update status in DB
                    MessageBox.Show($"Seat {selectedSeat.SeatNumber} has been booked!");
                }
                else
                {
                    MessageBox.Show($"Seat {selectedSeat.SeatNumber} is already {selectedSeat.Status}!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

        }

        private void UpdateSeatInDatabase(Seat seat, string busId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "UPDATE Seats SET Status = @Status WHERE seatNO = @seatNO AND bus_id = @bus_id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", seat.Status.ToString());
                    cmd.Parameters.AddWithValue("@seatNO", seat.SeatNumber);
                    cmd.Parameters.AddWithValue("@bus_id", busId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void SeatPanel_Paint(object sender, PaintEventArgs e)
        {
            // Implement paint logic here
        }

        private void customBtn1_Click(object sender, EventArgs e)
        {
            // Implement custom button click logic here
        }

        public class Seat
        {
            public string SeatNumber { get; set; }
            public BookingStatus Status { get; set; }

            public Seat(string seatNumber, BookingStatus status)
            {
                this.SeatNumber = seatNumber;
                this.Status = status;
            }

            public enum BookingStatus
            {
                Available,
                Booked,
                Unavailable
            }

            public Color GetSeatAvailabilityColor()
            {
                return Status switch
                {
                    BookingStatus.Available => Color.Green,
                    BookingStatus.Booked => Color.Red,
                    BookingStatus.Unavailable => Color.Gray,
                    _ => Color.Gray
                };
            }
        }

        private void selectedSeatLbl_Click(object sender, EventArgs e)
        {
            // Implement label click logic here
        }
    }
}