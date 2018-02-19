using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecs_dev_server.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // If we want to do any server side error handling, do it through the [HandleError] attribute.
            filters.Add(new HandleErrorAttribute());

            // Validation Filter

            // Think of other global filters we may need...
        }
    }
}