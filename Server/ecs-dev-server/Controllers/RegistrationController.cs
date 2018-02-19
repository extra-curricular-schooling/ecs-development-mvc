using System;
using System.Net.Http;
using System.Web.Mvc;
using ecs_dev_server.Services;
using ecs_dev_server.DTOs;

namespace ecs_dev_server.Controllers
{
    public class RegistrationController : Controller
    {
        // IHttpClient client;

        // GET: Registration
        [HttpGet]
        public ActionResult SayHello()
        {
            return Json("Hello", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// This needs to send data from the App to SSO for notifying that a User has been made.
        /// </summary>
        /// <param name="accountDTO"></param>
        [HttpPost]
        public void SendSSOInfo(SSOAccountDTO accountDTO)
        {
            // Would I use IHttpClient instead of HttpClientService for dependency injection?
            // This request needs to be called after the RegisterUser Action is called.
            // After we finish registration, we need to send the finished information to the SSO.

            // Convert to pass to SSO.
            String json = JsonConverterService.SerializeObject(accountDTO);

            // Call request service to make a request to the SSO.
            // The request should handle all successes and errors, or pass it off.
            // Change parameter to the URI of the SSO base. (i.e. "https://www.sso.org/")
            
            using (var httpClient = new HttpClientService(""))
            {
                // Double check this URI after setting up the SSO.
                ConsoleService.Print("Sending Request to SSO...");
                httpClient.Post("ReceiveAPPInfo", Json(json));
                ConsoleService.Print("Request Successful");
            }



            // We then need to save the User to our database.
            //using (var dbContext = new ECSContext())
            //{

            //}

            // Everything should be functional at this point.
            ConsoleService.Print("=== Saved User to Database ===");
        }

        /// <summary>
        /// This Action Method needs to receive data from SSO when registering an account in SSO.
        /// </summary>
        /// <returns>An HTTP Response</returns>
        [HttpPost]
        public ActionResult ReceiveSSOInfo()
        {
            // Call the ResponseService to handle the SSO registration request. Proccess any information.
            // Change parameter to the URI of the SSO base. (i.e. "https://www.sso.org/")
            using (var httpClient = new HttpClientService(""))
            {
                // Consume Request

                // Set some sort of flag up for the User in DB.
                // When they try and register in our app after SSO's registration, check the flag.

                // Return a response to the caller.
                return Json(Response.StatusCode);
            }
        }
    }
}