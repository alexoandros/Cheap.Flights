using System;
using System.Collections.Generic;

namespace Cheap.Flights.Business.Models
{
    public class FlightRq
    {
        public DateTime FlightDate { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public List<PaxType> PaxType { get; set; }

    }
}
