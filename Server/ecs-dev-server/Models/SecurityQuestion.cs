using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ecs_dev_server.Models
{
    public class SecurityQuestion
    {
        [Key, Required, Display(Name = "Security Questions"), StringLength(50)]
        public string SecurityQuestions { get; set; }

        [Display(Name = "Account Answering")]
        public virtual ICollection<Account> AccountAnswering { get; set; }
    }
}