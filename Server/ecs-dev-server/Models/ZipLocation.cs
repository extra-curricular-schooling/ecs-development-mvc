using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ecs_dev_server.Models
{
    public class ZipLocation
    {
        //[Required]
        [Key, Display(Name = "Zip Code"), StringLength(10, MinimumLength = 5, ErrorMessage = "Zipcode must be 5-10 characters")] 
        public string ZipCode { get; set; }
        
        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        public int Latitude { get; set; }

        public int Longitude { get; set; }

        //public List<User> Users { get; set; }
    }
}