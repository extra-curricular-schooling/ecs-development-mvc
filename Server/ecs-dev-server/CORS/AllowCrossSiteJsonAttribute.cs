using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecs_dev_server.CORS
{
    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // You can add multiple domains to the domains list if you want to accept communications.
            var domains = new List<string> { "http://localhost:8080/" };
  
            if (domains.Contains(filterContext.RequestContext.HttpContext.Request.UrlReferrer.Host))
            {
                filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}