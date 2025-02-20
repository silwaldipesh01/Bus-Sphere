using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Sphere.Models
{
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
                BookingStatus.Available => Color.FromArgb(0, 192, 192),
                BookingStatus.Booked => Color.Red,
                BookingStatus.Unavailable => Color.Gray,
                _ => Color.Gray
            };
        }
    }
}
