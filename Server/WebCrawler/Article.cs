using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler
{
    [Table("articleListing")]
    public class Article
    {
        
        public string articleType { get; set; }
        public string articleTitle { get; set; }
        [Key]
        public string articleLink { get; set; }
        public string articleDescription { get; set; }
        public string articleTag { get; set; }
    }
}
