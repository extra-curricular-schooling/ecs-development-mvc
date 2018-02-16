using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecs_dev_server.CORS;

namespace ecs_dev_server.Controllers
{
    public class RegistrationController : Controller
    {

        // This one doesn't work because it has problems sending a JSON object back.
        [HttpGet]
        public ActionResult GetJson()
        {
            return Json("Hello!");
        }

        // This is a adhoc way of getting around the Pre-flight.
        // Look here for better answer: https://stackoverflow.com/questions/13624386/handling-cors-preflight-requests-to-asp-net-mvc-actions
        [HttpGet]
        [AllowCORS]
        public ActionResult GetJsonNoPreflight()
        {
            // Bypassing the Preflight
            if (Request.HttpMethod == "OPTIONS")
            {
                return new ContentResult();
            }
            return new JsonResult
            {
                Data = "I am JSON!",
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpGet]
        public String SayHello()
        {
            return "WAAAZZZZUPPP";
        }
    }
}