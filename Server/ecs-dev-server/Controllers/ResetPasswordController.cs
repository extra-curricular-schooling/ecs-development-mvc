using ecs_dev_server.Services;
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
            // After you finish the resetpassword action, we need to send the finished information to the SSO.

            // Call request service to make a request to the SSO.
            using (var httpClient = new HttpClientService(""))
            {
                // The request should talk to the SSO controller to talk to the database.
                // The request should handle all successes and errors, or pass it off.

            }

            // We then need to save the User to our database.
            //using(var context = new ECSContext())
            //{

            //}

            // The return should be a success response to the client.
            return Json("Good to Go!");
        }


        [HttpPost]
        public ActionResult ReceiveSSOInfo()
        {
            // Call the ResponseService to handle the SSO registration request. Proccess any information.
            using (var httpClient = new HttpClientService(""))
            {
                // We need to push this information to the database.
                //using(var context = new ECSContext())
                //{

                //}

                // Return successful response?
                return Json("");
            }
        }
    }
}