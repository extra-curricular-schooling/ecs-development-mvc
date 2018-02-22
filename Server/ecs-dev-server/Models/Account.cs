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

        [Required(ErrorMessage="The username is requried")]
        [RegularExpression(@"^[a-zA-Z0-9~!@#$%^&*()_+].{8,120}$")]
        public string UserName { get; set; }

        [Required(ErrorMessage="The password is requried")]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,120}$")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int Points { get; set; }

        public int AccountStatus { get; set; }

        public int SuspensionTime { get; set; } 

        public ICollection<SecurityQuestion> SecurityAnswers { get; set; }

        public ICollection<InterestTag> AccountTag { get; set; }
    }
}