using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ecs_dev_server.Models
{
    public enum Permissions
    {
        //Defined Permissions
        Create,
        Read,
        Update,
        Delete
    }
    public class AccountType
    {
        [Key, Required, Display(Name = "Role Name")]
        public string RoleName { get; set; }

        public Permissions? Permissions { get; set; }
        
    }
}