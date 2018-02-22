using System;
using System.Net.Http;
using System.Web.Mvc;
using ecs_dev_server.Services;
using ecs_dev_server.DTOs;
using ecs_dev_server.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace ecs_dev_server.Controllers
{
    [RoutePrefix("registration")]
    public class RegistrationController : Controller
    {
        // GET: Registration
        [HttpGet]
        [Route("SayHello")]
        public ActionResult SayHello()
        {
            return Json("Hello", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// This needs to send data from the App to SSO for notifying that a User has been made.
        /// </summary>
        /// <param name="accountDTO"></param>

        
        [NonAction]
        public ActionResult Index(SSOAccountDTO accountDTO)
        {
            // Would I use IHttpClient instead of HttpClientService for dependency injection?
            // This request needs to be called after the RegisterUser Action is called.
            // After we finish registration, we need to send the finished information to the SSO.
             
            // Convert to pass to SSO.
            String json = JsonConvert.SerializeObject(accountDTO);

            // Call request service to make a request to the SSO.
            // The request should handle all successes and errors, or pass it off.
            // Change parameter to the URI of the SSO base. (i.e. "https://www.sso.org/")
            
            // Double check this URI after setting up the SSO.
            using (HttpClientService client = HttpClientService.Instance)
            {
                client.PostAsJson("https://yourdomain.com/Registration/ReceiveAPPInfo", json);
            }

            // We then need to save the User to our database.
            //using (var dbContext = new ECSContext())

            // Everything should be functional at this point.
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}