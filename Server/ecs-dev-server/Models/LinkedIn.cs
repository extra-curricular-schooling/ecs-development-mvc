using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ecs_dev_server.Models
{
    /// <summary>
    /// This model represents the LinkedIn access tokens used to create a LinkedIn post.  An account can only
    /// have one access token.
    /// </summary>
    public class LinkedIn
    {
        //Foreign Key of Account class
        [Required, Key, Column(Order = 0), Display(Name = "Username"), StringLength(20, MinimumLength = 5,
        ErrorMessage = "Username must be between 5-20 characters")]        
        public string UserName { get; set; }
        
        //The token produced as a string to create a LinkedIn post
        [Required, Key, Column(Order = 1),  StringLength(2000)]
        public string AccessToken { get; set; }

        //The date and time the token was created
        [Required, DataType(DataType.Date), Display(Name = "Token Creation")]
        public DateTime TokenCreation { get; set; }

        //navigation property of Account
        //token has one Account
        public Account Account { get; set; }
    }
}