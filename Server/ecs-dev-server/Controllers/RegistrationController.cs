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
        // GET: Registration
        [HttpGet]
        [AllowCrossSiteJson]
        public ActionResult SayHello()
        {
            return Json("Hello!");
        }
    }
}