using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace panictheorem.App_Start.RouteConstraints
{
    public class BlogArchiveConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if(values["urlSegment"] != null)
            {
                return values["urlSegment"].ToString() != "Archive";
            }
            return (values["action"].ToString() != "Archive");
        }
    }
}