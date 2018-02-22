using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebCrawler
{
    interface ICrawler
    {
        /// <summary>
        /// Starts the crawler asynchronously
        /// </summary>
        /// <returns> Completed Task </returns>
        Task CrawlingAsync();


        /// <summary>
        /// Crawls through the homepage of a site to aggregate article links
        /// </summary>
        /// <param name="url"> Url of site</param>
        /// <param name="attributes"> Attributes needed to traverse through site.</param>
        /// <returns> A List of Strings that consist of Article Links. </returns>
        Task<List<String>> HomeCrawler(string url, List<string> attributes);

        /// <summary>
        /// Crawls through the articles and checks to see if its a valid article for our site.
        /// </summary>
        /// <param name="links"> The list of url's of the articles. </param>
        /// <returns> A list of Article objects </returns>
        Task<List<Article>> ArticleCrawler(List<string[]> links);
    
    }
}
