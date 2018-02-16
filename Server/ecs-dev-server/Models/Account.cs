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
        [Key, Required, Display(Name = "Username"), StringLength(20, MinimumLength = 5, 
        ErrorMessage = "Username must be between 5-20 characters")]
        public string UserName { get; set; }

        //[ForeignKey("Email")]
        //public string Email { get; set; }
        
        [Required] 
        //[Display(Name = "Password")]
        [RegularExpression(@"[A-Za-z0-9"), StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be between 6-20 characters")]
        public string Password { get; set; }

        //[Display(Name = "Points")]
        public int Points { get; set; }

        [Required, Display(Name = "Account Status")]
        public bool AccountStatus { get; set; }

        [DataType(DataType.Date), Display(Name = "Suspension Time")]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd", ApplyFormatInEditMode = true, NullDisplayText = "0")]
        public DateTime SuspensionTime { get; set; }

        [Required, Display(Name = "Security Answers"), StringLength(50)]
        public virtual ICollection<SecurityQuestion> SecurityAnswers { get; set; }

        [Required, Display(Name = "Account Tags"), StringLength(25)]
        public virtual ICollection<InterestTag> AccountTags { get; set; }
    }
}