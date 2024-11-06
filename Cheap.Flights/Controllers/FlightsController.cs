using Cheap.Flights.Business.Contracts;
using Cheap.Flights.Business.Models;
using Microsoft.Web.Http;
using System.Web.Http;

namespace Cheap.Flights.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/flights")]
    public class FlightsController : ApiController
    {
        private readonly IFlightsService _flightsService;

        public FlightsController(IFlightsService flightsService)
        {
            _flightsService = flightsService;
        }
        // GET: Flights
        [HttpPost]
        [Route("availability")]
        public IHttpActionResult Get(FlightRq flightRq)
        {
            return Ok(_flightsService.GetFlights(flightRq));
        }


        // POST: CreateBooking
        [HttpPost]
        [Route("booking")]
        public IHttpActionResult Post(BookingRq bookingRq)
        {
            return Ok(_flightsService.CreateBooking(bookingRq));
        }


        // Get: RetrieveBooking
        [HttpGet]
        [Route("retrieve({bookingId}/{contactEmail}")]
        public IHttpActionResult Post(string bookingId, string contactEmail)
        {

            return Ok(_flightsService.RetrieveBooking(new RetrieveBookingRq
            {
                BookingId = bookingId,
                ContactEmail = contactEmail
            }));
        }
    }
}