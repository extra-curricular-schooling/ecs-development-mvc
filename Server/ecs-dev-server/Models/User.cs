using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ecs_dev_server.Models
{
    public class User
    {
        [Key]

        [Required(ErrorMessage="Email is requried")]
        [DataType(DataType.Email)]
        public string Email { get; set; }

        [Required(ErrorMessage="First name is requried")]
        [RegularExpression(@"^[a-zA-Z\s].{1,}$")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Last name is requried")]
        [RegularExpression(@"^[a-zA-Z].{1,}$")]
        public string LastName { get; set; }

        // [RegularExpression(@"[a-zA-Z0-9#.\s]$")]
        // Address Data
        public List<ZipLocation> ZipLocation { get; set; }
    }
}