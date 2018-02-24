using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ecs_dev_server.Models
{
    /// <summary>
    /// The model represents the storage of article information from articles grabbed by our web crawler.
    /// Each account can have multiple articles attached to it.
    /// </summary>
    public class Article
    {
        //The type of article stored.
        [Required, Display(Name = "Article Type")] 
        public string ArticleType { get; set; }

        //The name of the article stored.
        [Required, Display(Name = "Article Title")]
        public string ArticleTitle { get; set; }
        
        //The full URL link of the article stored
        [Key,Required, Display(Name = "Article Link")]
        public string ArticleLink { get; set; }

        //A brief description that is attached to the article stored.
        [Display(Name = "Article Description")]
        public string ArticleDescription { get; set; }

        //Navigation Property of Account
        public virtual ICollection<Account> Account { get; set; }
        
        //Hugo says we don't need
        //[Required, Display(Name = "Article Tag")]
        //public string articleTag { get; set; }
    }
}