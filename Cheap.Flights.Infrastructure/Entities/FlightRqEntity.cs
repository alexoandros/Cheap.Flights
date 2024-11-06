using System;
using System.Collections.Generic;

namespace Cheap.Flights.Infrastructure.Entities
{
    public class FlightRqEntity
    {
        public DateTime FlightDate { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public List<PaxTypeEntity> PaxType { get; set; }

    }
}
