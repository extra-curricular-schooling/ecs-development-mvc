using ecs_dev_server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecs_dev_server.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// This Action Method needs to receive data from SSO when registering an account in SSO.
        /// </summary>
        /// <returns>An HTTP Response</returns>
        [HttpPost]
        public ActionResult ReceiveSSOInfo()
        {
            // Call the ResponseService to handle the SSO login request. 
            using (var httpClient = new HttpClientService(""))
            {
                // Proccess any information.
                // Take the processed information and call necessary login methods.

                // Return successful response?
                return Json("");
            }
        }


    }
}