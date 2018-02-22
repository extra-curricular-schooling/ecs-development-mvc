using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler
{
    class BaseCrawler : ICrawler
    {
        private List<KeyValuePair<string, List<string>>> Sites = new List<KeyValuePair<string, List<string>>>() { };
        private HashSet<string> Tags = new HashSet<string> { };
        public BaseCrawler(List<KeyValuePair<string, List<string>>> Sites, HashSet<string> Tags)
        {
            this.Sites = Sites;
            this.Tags = Tags;
        }
        public async Task CrawlingAsync()
        {

            List<Article> toStore = await startCrawler(Sites);
            ArticleContext storer = new ArticleContext();

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
                catch (DbEntityValidationException e)
                {
                    Console.WriteLine(DateTime.Now + ": Site " + article.articleLink + " response: " + e.Message);
                }
            }
        }

        private async Task<List<Article>> startCrawler(List<KeyValuePair<string, List<string>>> Sites)
        {
      
            List<string[]> links = new List<string[]>();

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



        public async Task<List<string>> HomeCrawler(string url, List<string> attributes)
        {
            var links = new List<string>();
            try
            {
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(url);
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);
                try
                {
                    if (attributes[2] == "")
                    {
                        var blocks = htmlDoc.DocumentNode.Descendants(attributes[0]).ToList();
                        foreach (var li in blocks)
                        {
                            var articleLink = li.Descendants(attributes[3]).FirstOrDefault().ChildAttributes(attributes[4]).FirstOrDefault().Value;
                            links.Add(articleLink);
                        }
                    }
                    else
                    {
                        var blocks = htmlDoc.DocumentNode.Descendants(attributes[0]).Where(node => node.GetAttributeValue(attributes[1], "").Equals(attributes[2])).ToList();
                        foreach (var li in blocks)
                        {
                            var articleLink = li.Descendants(attributes[3]).FirstOrDefault().ChildAttributes(attributes[4]).FirstOrDefault().Value;
                            if (articleLink.Substring(0, 4) != "http")
                            {
                                articleLink = attributes[5] + articleLink;
                            }

                            links.Add(articleLink);
                        }
                    }
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(DateTime.Now + ": Received an '" + e.Message + "' Error from " + url);
                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(DateTime.Now + ": Site " + url + " response: " + e.Message);
            }
            return links;
        }


        public async Task<List<Article>> ArticleCrawler(List<string[]> links)
        {
            var list = new List<Article>();
            var httpClient = new HttpClient();
            var htmlDoc = new HtmlDocument();

            string tags = "";
            string title = "";
            string description = "";
            string tag = "";
            bool tagMatch = false;

            foreach (var art in links)
            {
                try
                {

                    List<string> siteAttribute = null;
                    var html = await httpClient.GetStringAsync(art[0]);
                    htmlDoc.LoadHtml(html);


                    foreach (var site in Sites)
                    {
                        if (site.Key == art[1])
                        {
                            siteAttribute = site.Value;
                            break;
                        }
                    }


                    var tagList = htmlDoc.DocumentNode.Descendants(siteAttribute[6]).Where(node => node.GetAttributeValue(siteAttribute[7], "").Equals(siteAttribute[8])).ToList();
                    foreach (var lt in tagList)
                    {
                        tags = lt.GetAttributeValue(siteAttribute[9], "");
                    }
                    tags = tags.ToLower();
                    //Console.WriteLine(tags); //for debugging
                    tagMatch = false;
                    tags = tags.Replace(",", "");
                    string[] contentTags = tags.Split(' ');
                    foreach (var t in contentTags)
                    {
                        if (Tags.Contains(t))
                        {
                            tagMatch = true;
                            tag = t;
                            break;
                        }
                    }

                    if (tagMatch)
                    {

                        var titleHolder = htmlDoc.DocumentNode.Descendants(siteAttribute[10]).Where(node => node.GetAttributeValue(siteAttribute[11], "").Equals(siteAttribute[12]));
                        foreach (var titleName in titleHolder)
                        {
                            title = titleName.GetAttributeValue(siteAttribute[13], "");
                        }
                        var descriptionHolder = htmlDoc.DocumentNode.Descendants(siteAttribute[14]).Where(node => node.GetAttributeValue(siteAttribute[15], "").Equals(siteAttribute[16]));
                        foreach (var descriptionString in descriptionHolder)
                        {
                            description = descriptionString.GetAttributeValue(siteAttribute[17], "");
                        }
                        var goodArticle = new Article
                        {
                            articleType = siteAttribute[18],
                            articleTitle = title,
                            articleLink = art[0],
                            articleDescription = description,
                            articleTag = tag
                        };
                        if (goodArticle.articleTitle == "")
                        {
                            goodArticle.articleTitle = goodArticle.articleDescription;
                        }
                        list.Add(goodArticle);
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine(DateTime.Now + ": Site " + art[0] + " response: " + e.Message);
                }
            }
            return list;
        }




    }
}
