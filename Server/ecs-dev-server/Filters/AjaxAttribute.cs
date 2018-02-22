using System.Web.Mvc;

namespace ecs_dev_server.Filters
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Author: Scott Roberts</remarks>
    public class AjaxAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
                filterContext.HttpContext.Response.Redirect("/error/404");
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}