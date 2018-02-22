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
        [HttpPost]
        [Route("RegisterUser")]
        public ActionResult RegisterUser()
        {
            // Read Json from POST body.
            var json = ParseHttpService.ReadHttpPostBody(Request);

            // Deserialize the Json String
            var userAccount = JsonConvert.DeserializeObject<AccountRegistrationDTO>(json);

            // Proccess any other information.

            // Check SSO DB for User.
            PostRegistrationToSSO(userAccount.Username);

            // If successful, save user to app DB. If not successful, reject registration.
            // using(ECSContext context = new ECSContext())

            // Return successful response
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        private void PostRegistrationToSSO(string username)
        {
            using(HttpClientService client = HttpClientService.Instance)
            {
                // Fix this up with a proper url.
                client.PostAsJson("*****", JsonConvert.SerializeObject(username));
            }
        }
    }
}