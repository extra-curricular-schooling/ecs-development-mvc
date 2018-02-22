using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebCrawler
{
    interface IBaseCrawler
    {
        Task<List<String>> HomeCrawler(string url, List<string> attributes);

        Task<List<Article>> ArticleCrawler(List<string[]> links);

        Task CrawlingAsync();
    }
}
