
using ecs_dev_server.DTOs;
using ecs_dev_server.Filters;
using ecs_dev_server.Services;
using Newtonsoft.Json;
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
        public ActionResult SubmitUsername()
        {
            // Read Json from POST body.
            var json = ParseHttpService.ReadHttpPostBody(Request);

            // Deserialize the Json String
            var credentials = JsonConvert.DeserializeObject<AccountCredentialsDTO>(json);

            // Proccess any other information.

            // Check DB for username

            // Send User's security questions.
            using(HttpClientService client = HttpClientService.Instance)
            {
                // send to client.
            }

            // Return successful response
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        //[Ajax]
        [HttpPost]
        public ActionResult VerifySecurityAnswers()
        {
            // Read Json from POST body.
            var json = ParseHttpService.ReadHttpPostBody(Request);

            // Deserialize the Json String
            var securityQuestions = JsonConvert.DeserializeObject<AccountQuestionsDTO>(json);

            // Proccess any other information.

            // Verify User's answers.

            // Redirect User to Account reset password page??

            // Return successful response
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        //[Ajax]
        [HttpPost]
        public ActionResult ChangePassword()
        {
            // Read Json from POST body.
            var json = ParseHttpService.ReadHttpPostBody(Request);

            // Deserialize the Json String
            var credentials = JsonConvert.DeserializeObject<AccountCredentialsDTO>(json);

            // Proccess any other information.

            // Submit new password to app DB.

            // After you finish the resetpassword action, we need to send the finished information to the SSO.
            PostNewPasswordToSSO(credentials);

            // Redirect User to Account reset password page??

            // Return successful response
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        private void PostNewPasswordToSSO(AccountCredentialsDTO credentials)
        {
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