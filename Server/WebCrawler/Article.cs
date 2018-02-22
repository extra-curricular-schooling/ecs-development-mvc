using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebCrawler
{
    /// <summary>
    /// Model for Articles
    /// </summary>
    [Table("articleListing")]
    public class Article
    {
        /// <summary>
        /// Will hold the URL for the article. Used as the Primary Key for the DB.
        /// </summary>
        [Key]
        public string articleLink { get; set; }

        /// <summary>
        /// Will hold the Type of Article it is. ie. Technology, Medical, Business, etc.
        /// </summary>
        public string articleType { get; set; }

        /// <summary>
        /// Will hold the Title of the Article.
        /// </summary>
        public string articleTitle { get; set; }

        /// <summary>
        /// Will hold the article description
        /// </summary>
        public string articleDescription { get; set; }

        /// <summary>
        /// Will hold the keyword/tag that the article hit in order to be classified as a valid article.
        /// </summary>
        public string articleTag { get; set; }
    }
}
