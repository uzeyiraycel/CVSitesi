using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mvc5Cv
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }
                //projenin hangisiyle başlamasını istiyorsak controller kısmına o controller ı action ise hangi sayfa ise o controller sayfasından başlamasını için view ini yazıyoruz.
            );
        }
    }
}
