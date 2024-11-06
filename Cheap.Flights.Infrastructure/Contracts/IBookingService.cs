using Cheap.Flights.Infrastructure.Entities;

namespace Cheap.Flights.Infrastructure.Contracts
{
    public interface IBookingService
    {
        BookingEntity CreateBooking(BookingRqEntity bookingRq);
        BookingEntity RetrieveBooking(RetrieveBookingRqEntity retrieveBookingRq);
    }
}
