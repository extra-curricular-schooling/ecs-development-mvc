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
    }
    public class AccountType
    {
        [Key]
        public string TypeName { get; set; }
    }
}