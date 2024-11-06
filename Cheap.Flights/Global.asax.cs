using System.Web.Http;
using Autofac.Integration.WebApi;
using Autofac;
using System.Reflection;
using Cheap.Flights.Infrastructure.Implementation;
using Cheap.Flights.Infrastructure.Contracts;
using Cheap.Flights.Infrastructure.Cache;
using System;
using Cheap.Flights.Business.Implementations;
using Cheap.Flights.Business.Contracts;

namespace Cheap.Flights.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var config = GlobalConfiguration.Configuration;

            RegisterDependencies(config);
        }

        private void RegisterDependencies(HttpConfiguration config)
        {
            var builder = new Autofac.ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            builder.RegisterType<BookingService>().As<IBookingService>();
            builder.RegisterType<AvailabilityService>().As<IAvailabilityService>();
            builder.RegisterType<CacheService>().As<ICacheService>().InstancePerDependency();
            builder.RegisterType<FlightsService>().As<IFlightsService>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        protected void Application_Error(Object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

        }
    }
}
