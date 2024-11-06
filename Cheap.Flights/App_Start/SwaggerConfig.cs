using System.Web.Http;
using WebActivatorEx;
using Cheap.Flights.WebApi;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Cheap.Flights.WebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Cheap.Flights.WebApi");
                    })
                .EnableSwaggerUi();
        }
    }
}
