using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace ecs_dev_server.Models
{
    public class User
    {
        [Key, Required, DataType(DataType.EmailAddress)]
        //[ForeignKey("ZipCode")]
        public string Email { get; set; }

        [Required, Display(Name = "First Name"), StringLength(50)]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name"), StringLength(50)]
        public string LastName { get; set; }

        //[Required, Display(Name = "Zip Location")]
        //public List<ZipLocation> ZipLocation { get; set; }
    }
}