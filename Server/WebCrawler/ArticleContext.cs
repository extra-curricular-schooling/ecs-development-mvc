using System.Data.Entity;

namespace WebCrawler
{
    /// <summary>
    /// EF Context to send/create a DB for the Article models.
    /// </summary>
    class ArticleContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

    }
}
