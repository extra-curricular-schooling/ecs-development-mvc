
using ecs_dev_server.Filters;
using ecs_dev_server.Services;
using System.Net;
using System.Web.Mvc;

namespace ecs_dev_server.Controllers
{
    [RoutePrefix("resetpassword")]
    public class ResetPasswordController : Controller
    {
        /// <summary>
        /// This needs to send data from the App to SSO for notifying that a password has changed.
        /// </summary>
        
        [Ajax]
        [HttpPost]
        public ActionResult Index()
        {
            RedirectToAction("SendSSOInfo");
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        
        [NonAction]
        private void SendSSOInfo()
        {
            // After you finish the resetpassword action, we need to send the finished information to the SSO.

            // Call request service to make a request to the SSO.
            using (var client = HttpClientService.Instance)
            {
                // The request should talk to the SSO controller to talk to the database.
                // The request should handle all successes and errors, or pass it off.

            }

            // We then need to save the User to our database.
            //using(var context = new ECSContext())

            // The return should be a Json object to the SSO server.

            //return new HttpStatusCodeResult(HttpStatusCode.OK);
        }


        
    }
}