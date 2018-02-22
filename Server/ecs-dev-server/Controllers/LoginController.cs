using ecs_dev_server.DTOs;
using ecs_dev_server.Filters;
using ecs_dev_server.Models;
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
        /// 
        /// </summary>
        /// <remarks>Author: Scott Roberts</remarks>
        [Ajax]
        [HttpPost]
        public ActionResult Index()
        {
            // Read Json from POST body.
            var json = ParseHttpService.ReadHttpPostBody(Request);

            // Deserialize the Json String
            var credentials = JsonConverterService.DeserializeObject<AccountCredentialsDTO>(json);

            // Proccess any other information.

            // Check app DB for user.

            // Issue login information

            // Return successful response
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}