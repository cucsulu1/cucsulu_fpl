using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HopNguyenCms
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Control panel",
                url: "cpanel/{action}/{id}",
                defaults: new { controller = "Cpanel", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Index",
                url: "",
                defaults: new { controller = "Website", action = "Index" }
            );

            routes.MapRoute(
                name: "Send contact",
                url: "sendcontact",
                defaults: new { controller = "Website", action = "SendContact" }
            );

            routes.MapRoute(
                name: "Add cart",
                url: "addcart",
                defaults: new { controller = "Website", action = "AddCart" }
            );

            routes.MapRoute(
                name: "Update cart",
                url: "updatecart",
                defaults: new { controller = "Website", action = "UpdateCart" }
            );

            routes.MapRoute(
                name: "Delete cart",
                url: "deletecart/{id}",
                defaults: new { controller = "Website", action = "DeleteCart", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Checkout",
                url: "checkout",
                defaults: new { controller = "Website", action = "CheckOut" }
            );

            routes.MapRoute(
                name: "Page",
                url: "{page}.{slug}",
                defaults: new { controller = "Website", action = "Index", page = UrlParameter.Optional, slug = "html" }
            );

            routes.MapRoute(
                name: "Detail",
                url: "{page}/{alias}.{slug}",
                defaults: new { controller = "Website", action = "Index", page = UrlParameter.Optional, alias = UrlParameter.Optional, slug = "html" }
            );

        }
    }
}