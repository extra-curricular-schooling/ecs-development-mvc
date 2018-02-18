using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace ecs_dev_server.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        [HttpGet]
        public ActionResult SayHello()
        {
            return Json("Hello", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// This needs to send data from the App to SSO for notifying that a User has been made.
        /// </summary>
        /// <returns>A Json object that sends the username, password, and security questions.</returns>
        [HttpPost]
        public ActionResult SendSSOInfo()
        {
            // We might need to use a JSON Serializer to convert from JSON to Models and vice-versa.
            // Newtonsoft is good for this use.

            return Json("");
        }

        /// <summary>
        /// This Action Method needs to receive data from SSO when registering an account in SSO.
        /// </summary>
        /// <returns>An HTTP Response</returns>
        [HttpPost]
        public void ReceiveSSOInfo()
        {
            // This needs to receive data from SSO when registering an account in SSO.

            // We need to complete the registration in-app after the user attempts to login.

            // return HttpResponse;
        }
    }
}