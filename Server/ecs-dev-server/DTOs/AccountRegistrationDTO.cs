using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecs_dev_server.DTOs
{
    /// <summary>
    /// User account information submitted during registration
    /// </summary>
    public class AccountRegistrationDTO
    {
        [Required(ErrorMessage="First name is requried")]
        [RegularExpression(@"^[a-zA-Z\s].{1,}$")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Last name is requried")]
        [RegularExpression(@"^[a-zA-Z].{1,}$")]
        public string LastName { get; set; }

        [Required(ErrorMessage="The username is requried")]
        [RegularExpression(@"^[a-zA-Z0-9~!@#$%^&*()_+].{8,120}$")]
        public string Username { get; set; }

        [Required(ErrorMessage="The email is requried")]
        [DataType(DataType.Email)]
        public string Email { get; set; }

        [Required(ErrorMessage="The password is requried")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,120}$")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [RegularExpression(@"[a-zA-Z0-9#.\s]$")]
        public string Address { get; set; }

        [RegularExpression(@"[a-zA-Z\s]$")]
        public string City { get; set; }

        [RegularExpression(@"[A-Z]$")]
        public string State { get; set; }

        [RegularExpression(@"^[0-9].{5}$")]
        public int ZipCode { get; set; }

        [Required]
        public List<String> SecurityQuestions { get; set; }

        [Required]
        public List<String> SecurityAnswers { get; set; }
    }
}