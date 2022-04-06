using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WATalycapLibrero
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Visualiza el resultado en Json
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
