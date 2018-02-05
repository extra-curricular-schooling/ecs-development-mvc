using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ecs_dev_server.Models
{
    public class Account
    {
        [Key]
        public string UserName { get; set; }

        public string Password { get; set; }

        public int Points { get; set; }

        public int AccountStatus { get; set; }

        public int SuspensionTime { get; set; } 

        public ICollection<SecurityQuestion> SecurityAnswers { get; set; }

        public ICollection<InterestTag> AccountTag { get; set; }
    }
}