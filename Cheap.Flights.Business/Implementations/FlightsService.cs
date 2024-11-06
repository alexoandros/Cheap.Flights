using Cheap.Flights.Business.Contracts;
using Cheap.Flights.Business.Models;
using Cheap.Flights.Infrastructure.Contracts;
using Cheap.Flights.Infrastructure.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Cheap.Flights.Business.Implementations
{
    public class FlightsService : IFlightsService
    {

        private readonly IAvailabilityService _availabilityService;
        private readonly IBookingService _bookingService;

        public FlightsService(IBookingService bookingService, IAvailabilityService availabilityService)
        {
            _availabilityService = availabilityService;
            _bookingService = bookingService;
        }

        public BookingRs CreateBooking(BookingRq bookingRq)
        {
            var bookingRqEntity = new BookingRqEntity
            {
                Contact = new ContactEntity
                {
                    Email = bookingRq.Contact.Email,
                    FirstName = bookingRq.Contact.LastName
                },
                DateOfBirthPax1 = bookingRq.DateOfBirthPax1,
                DateOfBirthPax2 = bookingRq.DateOfBirthPax2,
                DateOfBirthPax3 = bookingRq.DateOfBirthPax3,
                DateOfBirthPax4 = bookingRq.DateOfBirthPax4,
                DateOfBirthPax5 = bookingRq.DateOfBirthPax5,
                FirstNamePax1 = bookingRq.FirstNamePax1,
                FirstNamePax2 = bookingRq.FirstNamePax2,
                FirstNamePax3 = bookingRq.FirstNamePax3,
                FirstNamePax4 = bookingRq.FirstNamePax4,
                FirstNamePax5 = bookingRq.FirstNamePax5,
                FlightKey = bookingRq.FlightKey,
                LastNamePax1 = bookingRq.LastNamePax1,
                LastNamePax2 = bookingRq.LastNamePax2,
                LastNamePax3 = bookingRq.LastNamePax3,
                LastNamePax4 = bookingRq.LastNamePax4,
                LastNamePax5 = bookingRq.LastNamePax5,
            };

            var bookingResult= _bookingService.CreateBooking(bookingRqEntity);

            return new BookingRs
            {
                Contact = new Contact
                {
                    Email = bookingResult.Contact.Email,
                    FirstName = bookingResult.Contact.LastName
                },
                DateOfBirthPax1 = bookingResult.DateOfBirthPax1,
                DateOfBirthPax2 = bookingResult.DateOfBirthPax2,
                DateOfBirthPax3 = bookingResult.DateOfBirthPax3,
                DateOfBirthPax4 = bookingResult.DateOfBirthPax4,
                DateOfBirthPax5 = bookingResult.DateOfBirthPax5,
                FirstNamePax1 = bookingResult.FirstNamePax1,
                FirstNamePax2 = bookingResult.FirstNamePax2,
                FirstNamePax3 = bookingResult.FirstNamePax3,
                FirstNamePax4 = bookingResult.FirstNamePax4,
                FirstNamePax5 = bookingResult.FirstNamePax5,
                LastNamePax1 = bookingResult.LastNamePax1,
                LastNamePax2 = bookingResult.LastNamePax2,
                LastNamePax3 = bookingResult.LastNamePax3,
                LastNamePax4 = bookingResult.LastNamePax4,
                LastNamePax5 = bookingResult.LastNamePax5,
                BookingDate= bookingResult.BookingDate,
                BookingId= bookingResult.BookingId,
                Destination= bookingResult.Destination,
                FlightDate= bookingResult.FlightDate,
                FlightNumber= bookingResult.FlightNumber,
                Origin= bookingResult.Origin,
                TotalPrice= bookingResult.TotalPrice
            };
        }

        public List<FlightRs> GetFlights(FlightRq flightRq)
        {
            var flightRQEntity = new FlightRqEntity
            {
                Destination = flightRq.Destination,
                FlightDate = flightRq.FlightDate,
                Origin = flightRq.Origin,
                PaxType = flightRq.PaxType.Select(s=>new PaxTypeEntity {
                Quantity=s.Quantity,
                Type=s.Type}).ToList()
            };

            var flights= _availabilityService.GetFlights(flightRQEntity);

            return flights.Select(s => GetFlightRs(s)).ToList();
        }

        private FlightRs GetFlightRs(FlightEntity flight)
        {
            return new FlightRs
            {
                Destination = flight.Destination,
                FlightDate = flight.FlightDate,
                FlightKey = flight.FlightKey,
                Origin = flight.Origin,
                FlightNumber = flight.FlightNumber,
                PaxPrice = flight.PaxPrice.Select(s=> new PaxPrice {
                Type=s.Type,
                Price=s.Price
                }).ToList()
            };
        }

        public BookingRs RetrieveBooking(RetrieveBookingRq retrieveBookingRq)
        {
            var retrieveBookingEntity = new RetrieveBookingRqEntity
            {
                BookingId = retrieveBookingRq.BookingId,
                ContactEmail = retrieveBookingRq.ContactEmail
            };

            var bookingEntity=_bookingService.RetrieveBooking(retrieveBookingEntity);

            return new BookingRs
            {
                Contact = new Contact
                {
                    Email = bookingEntity.Contact.Email,
                    FirstName = bookingEntity.Contact.LastName
                },
                DateOfBirthPax1 = bookingEntity.DateOfBirthPax1,
                DateOfBirthPax2 = bookingEntity.DateOfBirthPax2,
                DateOfBirthPax3 = bookingEntity.DateOfBirthPax3,
                DateOfBirthPax4 = bookingEntity.DateOfBirthPax4,
                DateOfBirthPax5 = bookingEntity.DateOfBirthPax5,
                FirstNamePax1 = bookingEntity.FirstNamePax1,
                FirstNamePax2 = bookingEntity.FirstNamePax2,
                FirstNamePax3 = bookingEntity.FirstNamePax3,
                FirstNamePax4 = bookingEntity.FirstNamePax4,
                FirstNamePax5 = bookingEntity.FirstNamePax5,
                LastNamePax1 = bookingEntity.LastNamePax1,
                LastNamePax2 = bookingEntity.LastNamePax2,
                LastNamePax3 = bookingEntity.LastNamePax3,
                LastNamePax4 = bookingEntity.LastNamePax4,
                LastNamePax5 = bookingEntity.LastNamePax5,
                BookingDate = bookingEntity.BookingDate,
                BookingId = bookingEntity.BookingId,
                Destination = bookingEntity.Destination,
                FlightDate = bookingEntity.FlightDate,
                FlightNumber = bookingEntity.FlightNumber,
                Origin = bookingEntity.Origin,
                TotalPrice = bookingEntity.TotalPrice
            };
        }
    }
}
