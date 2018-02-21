using ecs_dev_server.DTOs;
using ecs_dev_server.Filters;
using ecs_dev_server.Services;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Web.Mvc;

namespace ecs_dev_server.Controllers
{
    [RoutePrefix("login")]
    public class LoginController : Controller
    {
        /// <summary>
        /// This Action Method needs to receive data from SSO when registering an account in SSO.
        /// </summary>
        /// <returns>An HTTP Response</returns>

        [Ajax]
        [HttpPost]
        public ActionResult Index(string Username, string Password)
        {
            // Read Json Body from Post.
            
            Stream req = Request.InputStream;
            var jsonString = RequestParseService.ReadHttpBody(req);

            SSOAccountDTO input = null;
            try
            {
                // assuming JSON.net/Newtonsoft library from http://json.codeplex.com/
                input = JsonConvert.DeserializeObject<SSOAccountDTO>(jsonString);
            }

            catch (Exception ex)
            {
                // Try to handle the misformed Post request...
                return Content(ex.Source + "\n" + ex.Message + "\n" + ex.StackTrace);
            }

            // Proccess any information.

            // Take the processed information and call necessary login methods.

            // Return successful response
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}