using ecs_dev_server.DTOs;
using ecs_dev_server.Filters;
using ecs_dev_server.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;

namespace ecs_dev_server.Controllers
{
    [RoutePrefix("SSO")]
    public class SSOController : Controller
    {
        //[Ajax, Json]
        [HttpPost]
        [Route("Register")]
        public ActionResult Register()
        {
            // Read Json from POST body.
            var json = ParseHttpService.ReadHttpPostBody(Request);

            // Deserialize the Json String
            var partialUserAccount = JsonConvert.DeserializeObject<SSOAccountRegistrationDTO>(json);

            // Set some sort of flag up for the User in DB.
            // When they try and register in our app after SSO's registration, check the flag.

            // Return successful response
            return new HttpStatusCodeResult(HttpStatusCode.OK);

        }
        //[Ajax, Json]
        [HttpPost]
        [Route("ResetPassword")]
        public ActionResult ResetPassword() // I need the equivalent of [FromBody] to use for incoming JSON
        {
            // Read Json from POST body.
            var json = ParseHttpService.ReadHttpPostBody(Request);

            // Deserialize the Json String
            var partialUserAccount = JsonConvert.DeserializeObject<SSOAccountRegistrationDTO>(json);

            // We need to push this information to the database.
            //using(var context = new ECSContext())

            // Return successful response?
            return new HttpStatusCodeResult(HttpStatusCode.OK);

        }
    }
}