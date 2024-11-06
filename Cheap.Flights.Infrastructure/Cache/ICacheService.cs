using Cheap.Flights.Infrastructure.Entities;

namespace Cheap.Flights.Infrastructure.Cache
{
    public interface ICacheService
    {
        BookingEntity RetrieveBooking(RetrieveBookingRqEntity retrieveBookingRq);
        void AddBooking(BookingEntity bookingRs);
    }
}
