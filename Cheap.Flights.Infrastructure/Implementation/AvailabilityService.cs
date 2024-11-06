using Cheap.Flights.Infrastructure.Contracts;
using Cheap.Flights.Infrastructure.Entities;
using Cheap.Flights.Infrastructure.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cheap.Flights.Infrastructure.Implementation
{
    public class AvailabilityService : IAvailabilityService
    {
        private List<FlightEntity> flights;
        public AvailabilityService()
        {
            LoadFlights();
        }
        public FlightEntity GetFlightByKey(string flightKey)
        {
            return flights.FirstOrDefault(w => w.FlightKey == flightKey);
        }

        public List<FlightEntity> GetFlights(FlightRqEntity flightRq)
        {

            var flig= flights.Where(w => w.FlightDate.Date == flightRq.FlightDate.Date && flightRq.Origin == w.Origin && w.Destination == flightRq.Destination).ToList();

            var hasADT = flightRq.PaxType.Any(a => a.Type == "ADT");
            var hasCHD = flightRq.PaxType.Any(a => a.Type == "CHD");

            if (!hasADT)
                flig.ForEach(f => f.PaxPrice = f.PaxPrice.Where(w => w.Type != "ADT").ToList());
            if (!hasCHD)
                flig.ForEach(f => f.PaxPrice = f.PaxPrice.Where(w => w.Type != "CHD").ToList());

            return flig;
        }

        private void LoadFlights()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var fileSettings = ".data.flights.json";

            var pathConfigfile = string.Concat(assembly.GetName().Name, fileSettings);
            flights = FlightsHelper.GetFlights(pathConfigfile);
                
        }
    }
}
