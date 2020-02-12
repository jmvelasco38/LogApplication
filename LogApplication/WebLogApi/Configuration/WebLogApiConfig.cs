using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebLogApi.Infrastructure;

namespace WebLogApi.Configuration
{
    public class WebLogApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.DependencyResolver = new NinjectResolver();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}