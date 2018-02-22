using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebCrawler
{
    class ToStore : DbContext
    {
        public DbSet<Article> Articles { get; set; }

    }
}
