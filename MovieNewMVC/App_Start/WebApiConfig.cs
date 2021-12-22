using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MovieNewMVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // the properties of this JSON objects are named using Pascal notation in our API return result
            // but in javascript we use camel notation for variable and in our api it returns Pascal case ,so convert variable name 
            // from pascal case to camel case use this three line code
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
