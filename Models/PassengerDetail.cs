using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Sphere.Models
{
    public class PassengerDetail
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Drop { get; set; }
        public string Pickup { get; set; }
        public string Date { get; set; }
        public string[] Seats { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsRoundTrip { get; set; }
        public string Notes { get; set; }

        // Method to get booked seats
        public string[] GetBookedSeats()
        {
            return Seats;
        }

        // Method to check if multiple seats are booked
        public bool HasBookedMultipleSeats()
        {
            return Seats != null && Seats.Length > 1;
        }

        // Method to display passenger details
        public override string ToString()
        {
            return $"Name: {Name}, Email: {Email}, Phone: {Phone}, Address: {Address}, " +
                   $"Drop: {Drop}, Pickup: {Pickup}, Date: {Date}, Seats: {string.Join(", ", Seats)}, " +
                   $"Gender: {Gender}, Age: {Age}, PaymentMethod: {PaymentMethod}, IsRoundTrip: {IsRoundTrip}, Notes: {Notes}";
        }


    }
}
