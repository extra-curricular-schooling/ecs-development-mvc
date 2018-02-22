using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ecs_dev_server.Models
{
    /// <summary>
    /// This model represents the Security Questions stored for accounts to use when registering.  Each question is 
    /// mapped to an ID for easy referencing.  Each account will have 3 security questions
    /// </summary>
    public class SecurityQuestion
    {
        //The ID for a specific security question
        [Key, Required, Display(Name = "Security Questions")]
        public int SecurityQuestionID { get; set; }

        //The security question
        public string SecurityQuestions { get; set; }
    }
}