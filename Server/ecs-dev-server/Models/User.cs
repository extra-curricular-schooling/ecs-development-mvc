using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace ecs_dev_server.Models
{
    /// <summary>
    /// This model represents a given Account's personal information. 
    /// </summary>
    public class User
    {
        //The email a user submitted during registration
        [Key, Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //The first name a user submitted during registration
        [Required, Display(Name = "First Name"), StringLength(50)]
        public string FirstName { get; set; }

        //The last name a user submitted during registration
        [Required, Display(Name = "Last Name"), StringLength(50)]
        public string LastName { get; set; }

        //ForeignKey of ZipLocation class
        [Display(Name = "Zip Code"), StringLength(10, MinimumLength = 5, ErrorMessage = "Zipcode must be 5-10 characters")]
        public string ZipCode { get; set; }

        //navigation property of cookies class
        //a user can have many cookies
        public virtual ICollection<Cookies> Cookies { get; set; }

        //navigation property of zipLocation class
        //a user can have one zipcode/address
        public virtual ZipLocation ZipLocation { get; set; }
    }
}