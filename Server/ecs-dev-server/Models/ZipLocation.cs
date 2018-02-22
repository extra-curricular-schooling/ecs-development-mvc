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
        [Key]

        [RegularExpression(@"^[0-9].{5}$")]
        public int ZipCode { get; set; }
        
        [RegularExpression(@"^[a-zA-Z\s]$")]
        public string City { get; set; }

        [RegularExpression(@"^[A-Z]$")]
        public string State { get; set; }

        public int Latitude { get; set; }

        public int Longitude { get; set; }

        public List<User> Users { get; set; }
    }
}