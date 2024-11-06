using Cheap.Flights.Business.Models;
using System.Collections.Generic;

namespace Cheap.Flights.Business.Contracts
{
    public interface IFlightsService
    {
        List<FlightRs> GetFlights(FlightRq flightRq);
        BookingRs CreateBooking(BookingRq bookingRq);
        BookingRs RetrieveBooking(RetrieveBookingRq retrieveBookingRq);
    }
}
