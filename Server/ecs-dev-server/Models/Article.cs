using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ecs_dev_server.Models
{
    public class Article
    {
        [Key, Required, Display(Name = "Article Type")]
        //[ForeignKey("TagName")] 
        public string ArticleType { get; set; }
        
        [Key, Required, Display(Name = "Article Title")]
        public string ArticleTitle { get; set; }
        
        [Required, Display(Name = "Article Link")]
        public string ArticleLink { get; set; }

        [Required, Display(Name = "Article Description")]
        public string ArticleDescription { get; set; }

        //[Required, Display(Name = "Article Tag")]
        //public string articleTag { get; set; }
    }
}