using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecs_dev_server.Controllers
{
    public class AccountController : Controller
    {
        // To avoid merge conflicts, we are not going to put any account information in here right now.
        // Later, this will include Registration, Login, Logout.

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
    }
}