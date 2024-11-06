using System;
using System.Collections.Generic;

namespace Cheap.Flights.Infrastructure.Entities
{
    public class BookingEntity
    {
        public DateTime FlightDate { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string FlightNumber { get; set; }
        public string FirstNamePax1 { get; set; }
        public string LastNamePax1 { get; set; }
        public DateTime DateOfBirthPax1 { get; set; }
        public string FirstNamePax2 { get; set; }
        public string LastNamePax2 { get; set; }
        public DateTime DateOfBirthPax2 { get; set; }
        public string FirstNamePax3 { get; set; }
        public string LastNamePax3 { get; set; }
        public DateTime DateOfBirthPax3 { get; set; }
        public string FirstNamePax4 { get; set; }
        public string LastNamePax4 { get; set; }
        public DateTime DateOfBirthPax4 { get; set; }
        public string FirstNamePax5 { get; set; }
        public string LastNamePax5 { get; set; }
        public DateTime DateOfBirthPax5 { get; set; }
        public ContactEntity Contact { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
