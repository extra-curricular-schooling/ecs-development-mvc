using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecs_dev_server.Controllers
{
    public class ResetPasswordController : Controller
    {
        /// <summary>
        /// This needs to send data from the App to SSO for notifying that a password has changed.
        /// </summary>
        /// <returns>A Json object that sends the updated password.</returns>
        [HttpPost]
        public ActionResult SendSSOInfo()
        {
            // This needs to send data from the App to SSO for notifying that a User has been made.
            // We might need to use a JSON Serializer to convert from JSON to Models and vice-versa.
            // Newtonsoft is good for this use.

            return Json("");
        }


        //[HttpPost]
        //public ActionResult ReceiveSSOInfo()
        //{
        //    // This needs to receive data from SSO when registering an account in SSO.

        //    // We need to complete the registration in-app after the user attempts to login.

        //    return Json("");
        //}
    }
}