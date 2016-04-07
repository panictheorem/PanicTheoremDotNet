using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using panictheorem.App_Start.RouteConstraints;
namespace panictheorem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "DefaultElmahUrlBlock",
                url: "Elmah",
                defaults: new { controller = "Error", action = "NotFound" }
            );

            routes.MapRoute(
                name: "Projects",
                url: "Portfolio/{urlSegment}",
                defaults: new { controller = "Portfolio", action = "Projects" },
                namespaces: new[] { "panictheorem.Controllers" }
            );
            routes.MapRoute(
                name: "BlogPostArchive",
                url: "Blog/Archive/{pageNumber}",
                defaults: new { controller = "Blog", action = "Archive", pageNumber = UrlParameter.Optional },
                namespaces: new[] { "panictheorem.Controllers" }
            );
            routes.MapRoute(
                name: "BlogLabel",
                url: "Blog/Label/{urlSegment}/{pageNumber}",
                defaults: new { controller = "Blog", action = "Labels", pageNumber = UrlParameter.Optional},
                namespaces: new[] { "panictheorem.Controllers" }
            );
            routes.MapRoute(
                name: "BlogPost",
                url: "Blog/{urlSegment}",
                defaults: new { controller = "Blog", action = "BlogPost" },
                namespaces: new[] { "panictheorem.Controllers" }
            );
            routes.MapRoute(
                name: "Blog",
                url: "Blog/{action}",
                defaults: new { controller = "Blog", action = "Index" },
                namespaces: new[] { "panictheorem.Controllers" }
            );
            routes.MapRoute(
                name: "UrlSegment",
                url: "{controller}/{action}/{urlSegment}",
                defaults: new { controller = "Home", action = "Index"},
                namespaces: new[] { "panictheorem.Controllers" }
            );

            routes.MapRoute(
                name: "NoId",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                namespaces: new[] { "panictheorem.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "panictheorem.Controllers" }
            );

            routes.MapRoute(
                name: "AdminArea",
                url: "Admin/{controller}/{action}/{urlSegment}",
                defaults: new { controller = "Account", action = "Home", urlSegment = UrlParameter.Optional },
                namespaces: new[] { "panictheorem.Controllers.Areas.Admin.Controllers" }
            );

            routes.MapRoute(
                name: "404-Error",
                url: "{*url}",
                defaults: new { controller = "Error", action = "NotFound" }
            );
        }
    }
}
