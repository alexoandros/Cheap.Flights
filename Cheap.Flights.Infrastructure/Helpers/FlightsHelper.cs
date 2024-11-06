using Cheap.Flights.Infrastructure.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cheap.Flights.Infrastructure.Helpers
{
    public static class FlightsHelper
    {


        public static List<FlightEntity> GetFlights(string assemblyFile)
        {
            return JsonConvert.DeserializeObject<List<FlightEntity>>(GetAssemblyFile(assemblyFile));
        }

        private static string GetAssemblyFile(string resource)
        {
            var _executingAssembly = Assembly.GetExecutingAssembly();
            using (var stream = _executingAssembly.GetManifestResourceStream(resource))
            {

                if (stream != null)
                {
                    var reader = new StreamReader(stream);
                    return reader.ReadToEnd();
                }
            }
            return null;
        }
    }
}
