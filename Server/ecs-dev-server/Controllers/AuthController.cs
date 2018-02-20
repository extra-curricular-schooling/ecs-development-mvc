﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ecs_dev_server.Controllers
{
    public class AuthController : Controller
    {
        internal class JwtManager
        {
            /// <summary>
            /// Use the below code to generate symmetric Secret Key
            ///     var hmac = new HMACSHA256();
            ///     var key = Convert.ToBase64String(hmac.Key);
            /// </summary>
            private const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

            public static string GenerateToken(string username, int expireMinutes = 20)
            {
                var symmetricKey = Convert.FromBase64String(Secret);
                var tokenHandler = new JwtSecurityTokenHandler();

                var now = DateTime.UtcNow;
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                            {
                            new Claim(ClaimTypes.Name, username)
                        }),

                    Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),

                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
                };

                var stoken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(stoken);

                return token;
            }

            public static ClaimsPrincipal GetPrincipal(string token)
            {
                try
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                    if (jwtToken == null)
                        return null;

                    var symmetricKey = Convert.FromBase64String(Secret);

                    var validationParameters = new TokenValidationParameters()
                    {
                        RequireExpirationTime = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                    };

                    SecurityToken securityToken;
                    var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                    return principal;
                }

                catch (Exception)
                {
                    return null;
                }
            }
        }

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

        private static bool ValidateToken(string token, out string username)
        {
            username = null;
            var simplePrinciple = JwtManager.GetPrincipal(token);
            var identity = simplePrinciple.Identity as ClaimsIdentity;
            if (identity == null) return false;
            if (!identity.IsAuthenticated) return false;
            var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            username = usernameClaim?.Value;
            if (string.IsNullOrEmpty(username)) return false;
            // More validate to check whether username exists in system  
            return true;
        }

        protected Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            string username;
            if (ValidateToken(token, out username))
            {
                // based on username to get more information from database in order to build local identity  
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, username)  
                    // Add more claims if needed: Roles, ...  
                };
                var identity = new ClaimsIdentity(claims, "Jwt");
                IPrincipal user = new ClaimsPrincipal(identity);
                return Task.FromResult(user);
            }
            return Task.FromResult<IPrincipal>(null);
        }
    }
}