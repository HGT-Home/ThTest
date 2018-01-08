using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThTest.Infrastructures
{
    public class WeekdayRouteConstraint : IRouteConstraint
    {
        private static readonly string[] Days = { "mon", "tue", "wed", "thu", "fri", "sat", "sun" };

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return WeekdayRouteConstraint.Days.Contains(values[routeKey]?.ToString().ToLowerInvariant());
        }
    }
}
