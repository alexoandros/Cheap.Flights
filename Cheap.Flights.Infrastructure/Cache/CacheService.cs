using Cheap.Flights.Infrastructure.Entities;
using System;
using System.Diagnostics;
using System.Runtime.Caching;

namespace Cheap.Flights.Infrastructure.Cache
{
    public class CacheService : ICacheService
    {
        public static MemoryCache Cache { get; set; }

        public CacheService()
        {
            Cache = new MemoryCache("BookingCache");
        }

        public BookingEntity RetrieveBooking(RetrieveBookingRqEntity retrieveBookingRq)
        {
            BookingEntity result = default(BookingEntity);
            try
            {
                var key = $"{retrieveBookingRq.BookingId}{retrieveBookingRq.ContactEmail}";
                CacheRepository.TryGet<BookingEntity>(Cache, key, out result);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
            }

            return result;
        }


        public void AddBooking(BookingEntity bookingRs)
        {
            try
            {
                var key = $"{bookingRs.BookingId}{bookingRs.Contact.Email}";
                CacheRepository.Add(Cache, key, bookingRs, new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTime.UtcNow.AddDays(1)
                });
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
            }

        }
    }
}
