using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Sphere.Models
{
    public class PassengerDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Seats { get; set; }
        public int noOfSeats { get; set; }
        public string Destination { get; set; }
        public string Source { get; set; }
        public string Date { get; set; }
        public string BusNo { get; set; }
        public string BusName { get; set; }
        public string BusType { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public decimal TicketPrice { get; set; }
        public string Through { get; set; }
        public enum PaymentMethod {paid,unpaid }

        //public PassengerDetail(int id, string name, string email, string phoneNumber, string address, string[] seats, string destination, string source, string date, string busNo, string busName, string busType, string departureTime, string arrivalTime, string ticketPrice)
        //{
        //    Id = id;
        //    Name = name;
        //    Email = email;
        //    PhoneNumber = phoneNumber;
        //    Address = address;
        //    Seats = seats;
        //    Destination = destination;
        //    Source = source;
        //    Date = date;
        //    BusNo = busNo;
        //    BusName = busName;
        //    BusType = busType;
        //    DepartureTime = departureTime;
        //    ArrivalTime = arrivalTime;
        //    TicketPrice = ticketPrice;
        //}
    }

}
