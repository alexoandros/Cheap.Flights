using Cheap.Flights.Infrastructure.Entities;
using System.Collections.Generic;

namespace Cheap.Flights.Infrastructure.Contracts
{
    public interface IAvailabilityService
    {
        List<FlightEntity> GetFlights(FlightRqEntity flightRq);
        FlightEntity GetFlightByKey(string flightKey);
    }
}
