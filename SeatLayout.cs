using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Bus_Sphere.CustomControls;
using MySql.Data.MySqlClient;

namespace Bus_Sphere.CustomForm
{
    public partial class SeatLayout : UserControl
    {
        string connectionString = "server=localhost;user=root;database=bussphere;port=3306;password=";
        public string BusId { get; set; }
        private List<Seat> seats = new List<Seat>();

        public SeatLayout(string busId)
        {
            InitializeComponent();
            BusId = busId;
            LoadSeat(BusId);
        }

        public void LoadSeat(string busId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT seatNo, Status FROM seats WHERE bus_id = @BusId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BusId", busId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string seatNumber = reader["seatNo"].ToString();
                        if (Enum.TryParse(reader["Status"].ToString(), true, out Seat.BookingStatus status))
                        {
                            Seat seat = new Seat(seatNumber, status);
                            seats.Add(seat);
                        }
                        else
                        {
                            throw new Exception($"Invalid status value: {reader["Status"]}");
                        }
                    }
                }
                UpdateSeatColors();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void UpdateSeatColors()
        {
            foreach (Seat seat in seats)
            {
                CustomBtn button = this.Controls.Find("customBtn" + seat.SeatNumber, true).FirstOrDefault() as CustomBtn;
                if (button != null)
                {
                    button.BackColor = seat.GetSeatAvailabilityColor();
                }
            }
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
    }
}