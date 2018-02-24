using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ecs_dev_server.Models
{
    /// <summary>
    /// This model represents the Interest Tags associated with Accounts.  They are unique names used to sort through
    /// different articles with similar or equal tags.
    /// </summary>
    public class InterestTag
    {
        //The name of the interest tag
        [Key, Required, Display(Name = "Tag Name")]
        public string TagName { get; set; }

        //Navigation Property
        public virtual ICollection<Account> AccountUsername { get; set; }
    }
}