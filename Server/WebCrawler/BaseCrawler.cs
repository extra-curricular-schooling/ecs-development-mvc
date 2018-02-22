using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebCrawler
{
    /// <summary>
    /// Crawls through a homepage to aggregrate articles, crawls through the articles to validate tags, stores valid articles to DB.
    /// Implements ICrawler
    /// </summary>
    class BaseCrawler : ICrawler
    {
        /// <summary>
        /// A List of KeyValuePair of (Strings and List of Strings)
        /// Key will be the URL String
        /// Value will be a list of strings consisting of attributes necessary to traverse through the html files.
        /// </summary>
        private List<KeyValuePair<string, List<string>>> Sites = new List<KeyValuePair<string, List<string>>>() { };

        /// <summary>
        /// A HashSet of Strings. Will be used validate articles.
        /// </summary>
        private HashSet<string> Tags = new HashSet<string> { };

        /// <summary>
        /// Two-Parameter Constructor.
        /// </summary>
        /// <param name="Sites"></param>
        /// <param name="Tags"></param>
        public BaseCrawler(List<KeyValuePair<string, List<string>>> Sites, HashSet<string> Tags)
        {
            this.Sites = Sites;
            this.Tags = Tags;
        }

        /// <summary>
        /// Starts the asynchronous crawler and stores to DB.
        /// </summary>
        /// <returns> Completed Task </returns>
        public async Task CrawlingAsync()
        {
            // Calls startCrawler with the given sites and stores valid articles to toStore.
            List<Article> toStore = await StartCrawler(Sites);

            // Instantiate new DBContext
            ArticleContext storer = new ArticleContext();

            // Go through each article and store if not already in DB.
            foreach (var article in toStore)
            {
                try
                {

                    if (!storer.Articles.Any(a => a.articleLink == article.articleLink))
                    {
                        storer.Articles.Add(article);
                        storer.SaveChanges();
                    }
                }
                // Catch if DBContext fails to save.
                catch (DbEntityValidationException e)
                {
                    Console.WriteLine(DateTime.Now + ": Site " + article.articleLink + " response: " + e.Message);
                }
            }
        }

        /// <summary>
        /// Starts the HomeCrawler and ArticleCrawler
        /// </summary>
        /// <param name="Sites"></param>
        /// <returns>Valid Articles</returns>
        private async Task<List<Article>> StartCrawler(List<KeyValuePair<string, List<string>>> Sites)
        {
      
            // Links will hold the links gathered from the homepage.
            List<string[]> links = new List<string[]>();

            // For each site from given Sites. Crawl through and gather article links.
            foreach (var site in Sites)
            {
                List<string> attributes = site.Value;
                List<string> link = (await HomeCrawler(site.Key, attributes));
                foreach (var urlLink in link)
                {
                    string[] linkInfo = { urlLink, site.Key };
                    links.Add(linkInfo);
                }

            }

            return await ArticleCrawler(links);
        }


        /// <summary>
        /// Crawls through given site for articles.
        /// </summary>
        /// <param name="url"> Site URL </param>
        /// <param name="attributes"> Attributes needed to traverse site </param>
        /// <returns> List of Strings of article links </returns>
        public async Task<List<string>> HomeCrawler(string url, List<string> attributes)
        {
            // Will hold the links for the articles.
            var links = new List<string>();
            try
            {
                // Initiate new HttpClient to request HTML.
                var httpClient = new HttpClient();
                // Gather the HTML data from the give url.
                var html = await httpClient.GetStringAsync(url);
                // Initiate new HtmlDocument object to load the HTMl.
                var htmlDoc = new HtmlDocument();
                // load gathered HTMl.
                htmlDoc.LoadHtml(html);
                try
                {
                    // Gather the blocks from each [attribute[0]] where [attribute[1]] = [attribute[2]]. ie. Gather the blocks from each "div" where "class"= "article--header"
                    var blocks = htmlDoc.DocumentNode.Descendants(attributes[0]).Where(node => node.GetAttributeValue(attributes[1], "").Equals(attributes[2])).ToList();

                    // For each block. Gather the [attribute[3]].[attribute[4]] and add to links. ie. From each block, gather the "a"."href"
                    foreach (var li in blocks)
                    {
                        var articleLink = li.Descendants(attributes[3]).FirstOrDefault().ChildAttributes(attributes[4]).FirstOrDefault().Value;
                        // If the gathered link is only a relative link without the full url. Append the url found in attribute[5]
                        if (articleLink.Substring(0, 4) != "http")
                        {
                            articleLink = attributes[5] + articleLink;
                        }

                        links.Add(articleLink);
                    }
                }
                // Catch NullReferenceException if it fails to locate a block via the attributes
                catch (NullReferenceException e)
                {
                    Console.WriteLine(DateTime.Now + ": Received an '" + e.Message + "' Error from " + url);
                }

            }
            // Catch HttpRequestException if it fails to get a response from requested site.
            catch (HttpRequestException e)
            {
                Console.WriteLine(DateTime.Now + ": Site " + url + " response: " + e.Message);
            }
            return links;
        }

        /// <summary>
        /// Crawl through aggregated links and check if its a valid article for the site.
        /// </summary>
        /// <param name="links"> List of gathered links</param>
        /// <returns> List of valid Articles </returns>
        public async Task<List<Article>> ArticleCrawler(List<string[]> links)
        {
            // Will hold the valid Articles.
            var list = new List<Article>();

            // Initiate new httpclient and htmlDocument to request and traverse html.
            var httpClient = new HttpClient();
            var htmlDoc = new HtmlDocument();

            // Will hold the article info.
            string tags = "";
            string title = "";
            string description = "";
            string tag = "";

            // Boolean to check if article matches a keyword/tag
            bool tagMatch = false;

            // For each article, check if valid
            foreach (var art in links)
            {
                try
                {
                    // Will hold the proper attributes for the site.
                    List<string> siteAttribute = null;
                    var html = await httpClient.GetStringAsync(art[0]);
                    htmlDoc.LoadHtml(html);

                    // Associate the proper attributes for the Site. 
                    foreach (var site in Sites)
                    {
                        if (site.Key == art[1])
                        {
                            siteAttribute = site.Value;
                            break;
                        }
                    }

                    // Gather the blocks where the keywords/tags are held in the article. 
                    var tagList = htmlDoc.DocumentNode.Descendants(siteAttribute[6]).Where(node => node.GetAttributeValue(siteAttribute[7], "").Equals(siteAttribute[8])).ToList();

                    // Gather each tag from the block.
                    foreach (var lt in tagList)
                    {
                        tags = lt.GetAttributeValue(siteAttribute[9], "");
                    }

                    // Lowercase the tags for easier comparison
                    tags = tags.ToLower();

                    // Reset tagMatch to false.
                    tagMatch = false;

                    // Replace any ',' if site stored tags as a CSV.
                    tags = tags.Replace(",", "");

                    // Split up tags 
                    string[] contentTags = tags.Split(' ');

                    // For each tag in list, check if it is contained in HashSet of valid tags. If so, tagMatch = true, assign hit tag to Article tag then break.
                    foreach (var t in contentTags)
                    {
                        if (Tags.Contains(t))
                        {
                            tagMatch = true;
                            tag = t;
                            break;
                        }
                    }

                    // If tagMatched, gather the rest of the necessary Article information.
                    if (tagMatch)
                    {
                        // Gather blocks that hold the Title information and store to title.
                        var titleHolder = htmlDoc.DocumentNode.Descendants(siteAttribute[10]).Where(node => node.GetAttributeValue(siteAttribute[11], "").Equals(siteAttribute[12]));
                        foreach (var titleName in titleHolder)
                        {
                            title = titleName.GetAttributeValue(siteAttribute[13], "");
                        }

                        // Gather blocks that hold the Description information and store to description.
                        var descriptionHolder = htmlDoc.DocumentNode.Descendants(siteAttribute[14]).Where(node => node.GetAttributeValue(siteAttribute[15], "").Equals(siteAttribute[16]));
                        foreach (var descriptionString in descriptionHolder)
                        {
                            description = descriptionString.GetAttributeValue(siteAttribute[17], "");
                        }

                        // Create new Article Object and assign the gathered variables.
                        var goodArticle = new Article
                        {
                            // Assigns articleType by attribute[18]. ie. Technology, Medical, etc.
                            articleType = siteAttribute[18],
                            articleTitle = title,
                            // Assigns the articleLink as the url from the article that is being crawled.
                            articleLink = art[0],
                            articleDescription = description,
                            articleTag = tag
                        };

                        // Ran into some articles that did not have a Title, decided to make the description the title.
                        if (goodArticle.articleTitle == "")
                        {
                            goodArticle.articleTitle = goodArticle.articleDescription;
                        }

                        // Add the valid article to the list of valid articles.
                        list.Add(goodArticle);
                    }
                }
                // Catch HttpRequestException if it fails to get a response from requested article.
                catch (HttpRequestException e)
                {
                    Console.WriteLine(DateTime.Now + ": Site " + art[0] + " response: " + e.Message);
                }
            }
            return list;
        }
    }
}
