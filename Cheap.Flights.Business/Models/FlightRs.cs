using System;
using System.Collections.Generic;

namespace Cheap.Flights.Business.Models
{
    public class FlightRs
    {
        public string FlightKey { get; set; }
        public string FlightNumber { get; set; }
        public DateTime FlightDate { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public List<PaxPrice> PaxPrice { get; set; }
    }
}
