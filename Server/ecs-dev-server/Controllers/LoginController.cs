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
        public void ReceiveSSOInfo()
        {
            // We need to complete the registration in-app after the user attempts to login.
            // return HttpResponse;
        }
    }
}