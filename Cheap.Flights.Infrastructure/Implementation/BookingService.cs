using Cheap.Flights.Infrastructure.Cache;
using Cheap.Flights.Infrastructure.Contracts;
using Cheap.Flights.Infrastructure.Entities;
using System;
using System.Linq;

namespace Cheap.Flights.Infrastructure.Implementation
{

    public class BookingService : IBookingService
    { 
    private readonly ICacheService _cacheService;
    private readonly IAvailabilityService _availabilityService;

    public BookingService(ICacheService cacheService, IAvailabilityService availabilityService)
    {
        _cacheService = cacheService;
        _availabilityService = availabilityService;
    }

        public string RandomBookingId(int length)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public BookingEntity CreateBooking(BookingRqEntity bookingRq)
    {

        var flight = _availabilityService.GetFlightByKey(bookingRq.FlightKey);

        var booking = new BookingEntity
        {
            BookingDate = DateTime.UtcNow,
            BookingId = RandomBookingId(6).ToUpper(),
            Contact = bookingRq.Contact,
            DateOfBirthPax1 = bookingRq.DateOfBirthPax1,
            DateOfBirthPax2 = bookingRq.DateOfBirthPax2,
            DateOfBirthPax3 = bookingRq.DateOfBirthPax3,
            DateOfBirthPax4 = bookingRq.DateOfBirthPax4,
            DateOfBirthPax5 = bookingRq.DateOfBirthPax5,
            Destination = flight.Destination,
            FirstNamePax1 = bookingRq.FirstNamePax1,
            FirstNamePax2 = bookingRq.FirstNamePax2,
            FirstNamePax3 = bookingRq.FirstNamePax3,
            FirstNamePax4 = bookingRq.FirstNamePax4,
            FirstNamePax5 = bookingRq.FirstNamePax5,
            FlightDate = flight.FlightDate,
            FlightNumber = flight.FlightNumber,
            LastNamePax1 = bookingRq.LastNamePax1,
            LastNamePax2 = bookingRq.LastNamePax2,
            LastNamePax3 = bookingRq.LastNamePax3,
            LastNamePax4 = bookingRq.LastNamePax4,
            LastNamePax5 = bookingRq.LastNamePax5,
            Origin = flight.Origin,
         };

            booking.TotalPrice = flight.PaxPrice.Sum(s => s.Price);

        _cacheService.AddBooking(booking);

        return booking;

    }

    public BookingEntity RetrieveBooking(RetrieveBookingRqEntity retrieveBookingRq)
    {
        return _cacheService.RetrieveBooking(retrieveBookingRq);
    }
}
}
