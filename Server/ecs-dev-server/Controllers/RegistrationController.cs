using System.Web.Mvc;
using ecs_dev_server.Services;
using ecs_dev_server.DTOs;
using System.Net;
using ecs_dev_server.Models;

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
            var userAccount = JsonConverterService.DeserializeObject<AccountRegistrationDTO>(json);

            // Proccess any other information.
            if (ModelState.IsValid)
            {
                // Check SSO DB for User.
                //PostRegistrationToSSO(userAccount.Username);

                // If successful, save user to app DB. If not successful, reject registration.
                using (ECSContext context = new ECSContext())
                {
                    context.Accounts.Add(new Account 
                    {
                        UserName = userAccount.Username,
                        Password = HashService.HashPasswordWithSalt(userAccount.Password, HashService.CreateSaltKey()), //ConfirmPassword = userAccount.ConfirmPassword
                        SecurityAnswers = new ICollection<SecurityQuestionAccount> 
                        {
                            new SecurityQuestionAccount 
                            {
                                Answer = userAccount.SecurityAnswers.ElementAt(0),
                                SecurityQuestion = userAccount.SecurityQuestions.ElementAt(0)
                            },
                            new SecurityQuestionAccount 
                            {
                                Answer = userAccount.SecurityAnswers.ElementAt(1),
                                SecurityQuestion = userAccount.SecurityQuestions.ElementAt(1)
                            },
                            new SecurityQuestionAccount 
                            {
                                Answer = userAccount.SecurityAnswers.ElementAt(2),
                                SecurityQuestion = userAccount.SecurityQuestions.ElementAt(2)
                            }
                        }
                    });
                    context.Users.Add(new User 
                    {
                        Email = userAccount.Email,
                        FirstName = userAccount.FirstName,
                        LastName = userAccount.LastName,
                        Address = userAccount.Address
                    });
                    context.ZipLocations.Add(new ZipLocation 
                    {
                        ZipCode = userAccount.ZipCode,
                        City = userAccount.City,
                        State = userAccount.State
                    });
                }
                context.SaveChanges();
                // return RedirectToAction();
            }
            // Return successful response
            // return View(userAccount);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        private void PostRegistrationToSSO(string username)
        {
            using(HttpClientService client = HttpClientService.Instance)
            {
                // Fix this up with a proper url.
                client.PostAsJson("*****", JsonConverterService.SerializeObject(username));
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult RequestSecurityQuestions()
        {
        }
    }
}