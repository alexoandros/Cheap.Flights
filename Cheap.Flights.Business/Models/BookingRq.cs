using System;

namespace Cheap.Flights.Business.Models
{
    public class BookingRq
    {
        public string FlightKey { get; set; }
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
        public Contact Contact { get; set; }
    }
}
