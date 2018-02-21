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
            // Read Json from Post Body

            Stream req = Request.InputStream;
            var json = RequestParseService.ReadHttpBody(req);

            SSOAccountDTO input = null;
            try
            {
                // assuming JSON.net/Newtonsoft library
                input = JsonConvert.DeserializeObject<SSOAccountDTO>(json);
            }

            catch (Exception ex)
            {
                // Try and handle malformed POST body
                return Content(ex.Source + "\n" + ex.Message + "\n" + ex.StackTrace);
            }

            // Set some sort of flag up for the User in DB.
            // When they try and register in our app after SSO's registration, check the flag.

            // Return a response to the caller.
            return new HttpStatusCodeResult(HttpStatusCode.OK);

        }
        //[Ajax, Json]
        [HttpPost]
        [Route("ResetPassword")]
        public ActionResult ResetPassword() // I need the equivalent of [FromBody] to use for incoming JSON
        {
            // Consume Json Incoming Requests

            // We need to push this information to the database.
            //using(var context = new ECSContext())
            //{

            //}

            // Return successful response?
            return new HttpStatusCodeResult(HttpStatusCode.OK);

        }
    }
}