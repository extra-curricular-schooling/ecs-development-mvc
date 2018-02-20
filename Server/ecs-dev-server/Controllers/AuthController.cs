using ecs_dev_server.Services;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ecs_dev_server.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public HttpStatusCodeResult GenerateCookie()
        {
            string token = JwtManager.GenerateToken("luis");
            HttpCookie cookie = new HttpCookie("auth_token");
            cookie.Value = token;
            cookie.Domain = ".localhost";
            cookie.HttpOnly = true;
            cookie.Path = "/; SameSite=Lax";
            cookie.Expires = DateTime.Now.AddMinutes(20);
            Response.AppendCookie(cookie);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}