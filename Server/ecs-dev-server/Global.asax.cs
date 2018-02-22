using ecs_dev_server.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ECS.Cors;

namespace ecs_dev_server
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AuthConfig.RegisterAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
    ///*
    //* Will execute after the Custom CORS module events execute.
    //* This is a great place for IN APP handling of events from the custom module.
    //* Method needs these 2 versions of the name to work (not case sensitive)
    //* {module}_onmyevent
    //* {module}_myevent
    //*/
    //protected void Cors_OnMyEvent(Object src, EventArgs e)
    //{
    //    // Context.Response.Write("Hello from Cors called in Globabl.asax.<br>");
    //}
}
