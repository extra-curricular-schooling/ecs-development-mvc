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
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<ZipLocation> ZipLocation { get; set; }
    }
}