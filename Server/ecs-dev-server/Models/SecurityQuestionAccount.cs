using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ecs_dev_server.Models
{
    /// <summary>
    /// This model represents the answers to the security questions stored in the SecurityQuestion model.  Each answer is
    /// mapped to a specific security question through an ID, and a specific account through a username.  Each account
    /// will have 3 security questions.
    /// </summary>
    public class SecurityQuestionAccount
    {
        //The answer given to a specific Security Question
        [Required, StringLength(100, MinimumLength = 2)]
        public string Answer { get; set; }

        //Foreign Key of SecurityQuestion class, maps Security Questions
        [Key, Column(Order = 0)]
        public int SecurityQuestionID { get; set; }

        //Foreign Key of Account class, maps Accounts to answers
        [Key, Column(Order = 1), Display(Name = "Username"), StringLength(20, MinimumLength = 5,
        ErrorMessage = "Username must be between 5-20 characters")]
        public string Username { get; set; }
        
        //navigation property of accounts
        //answers to security questions has one account
        public virtual Account Accounts { get; set; }

        //navigation property of security questions
        //answers to security questions are mapped to one security question
        public virtual SecurityQuestion SecurityQuestion { get; set; }
    }
}