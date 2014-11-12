namespace BullsAndCows.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Microsoft.Owin.Security.OAuth;
    using Newtonsoft.Json.Serialization;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "NextNotification",
                routeTemplate: "api/notifications/next",
                defaults: new
                {
                    controller = "Notifications",
                    action = "Next"
                }
            );

            config.Routes.MapHttpRoute(
                name: "Notifications",
                routeTemplate: "api/notifications",
                defaults: new
                {
                    controller = "Notifications",
                    action = "Get"
                }
            );

            config.Routes.MapHttpRoute(
                name: "Guesses",
                routeTemplate: "api/games/{id}/guess",
                defaults: new 
                {
                    controller = "Guesses"
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }
    }
}
