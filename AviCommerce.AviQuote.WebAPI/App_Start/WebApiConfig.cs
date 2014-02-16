using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AviCommerce.AviQuote.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();

            // Set the JSON serializer to produce camel case property names
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // http://www.asp.net/web-api/overview/security/enabling-cross-origin-requests-in-web-api
            // Global activation of CORS
            // If you are in MVC4 and picked up the Microsoft.AspNet.WebApi.Cors package from NuGet, you may hit a huge
            // type exception in the webApiConfig. You will need to also get the latest Microsoft.AspNet.WebApi as they 
            // should be in sync. 
            var corsAttrs = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttrs);
        }
    }
}
