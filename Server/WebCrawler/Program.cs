using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebCrawler
{

    class Program
    {
        static int Main(string[] args)
        {
           
            // Art & Design Sitess
            List<KeyValuePair<string, List<string>>> ArtSites = new List<KeyValuePair<string, List<string>>>() { };
            ArtSites.Add(new KeyValuePair<string, List<string>>("http://www.laweekly.com/arts", new List<string> { "div", "class", "img-box", "a", "href", "http://www.laweekly.com", "meta", "name", "keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content","Art & Design" }));
            ArtSites.Add(new KeyValuePair<string, List<string>>("http://www.cubanartnews.org/can/category/art", new List<string> { "div", "class", "artwork", "a", "href", "http://www.cubanartnews.org/", "meta", "name", "keywords", "content", "title", "", "", "", "meta", "name", "description", "content", "Art & Design" }));
            ArtSites.Add(new KeyValuePair<string, List<string>>("http://www.cubanartnews.org/can/category/art/P5", new List<string> { "div", "class", "artwork", "a", "href", "http://www.cubanartnews.org/", "meta", "name", "keywords", "content", "title", "", "", "", "meta", "name", "description", "content", "Art & Design" }));
            ArtSites.Add(new KeyValuePair<string, List<string>>("http://www.cubanartnews.org/can/category/art/P10", new List<string> { "div", "class", "artwork", "a", "href", "http://www.cubanartnews.org/", "meta", "name", "keywords", "content", "title", "", "", "", "meta", "name", "description", "content", "Art & Design" }));
            ArtSites.Add(new KeyValuePair<string, List<string>>("http://www.artcyclopedia.com/art-news.php", new List<string> { "font", "size", "+1", "a", "href", "", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Art & Design" }));
            ArtSites.Add(new KeyValuePair<string, List<string>>("https://theconversation.com/us/arts", new List<string> { "div", "class", "article--header", "a", "href", "https://theconversation.com", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Art & Design" }));
            ArtSites.Add(new KeyValuePair<string, List<string>>("https://www.huffingtonpost.com/section/arts", new List<string> { "div", "class", "card__content", "a", "href", "https://www.huffingtonpost.com", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Art & Design" }));

            // Art & Design Keyword/Tag List
            HashSet<string> ArtTags = new HashSet<string> { "art", "contemporary", "sculpture", "design", "architecture", "paint" };


            // Business Sites
            List<KeyValuePair<string, List<string>>> MoneySites = new List<KeyValuePair<string, List<string>>>() { };
            MoneySites.Add(new KeyValuePair<string, List<string>>("https://brokemillennial.com/", new List<string> { "div", "class", "featuredimg", "a", "href", "https://brokemillennial.com", "meta", "property", "og:description", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Business" }));
            MoneySites.Add(new KeyValuePair<string, List<string>>("https://www.huffingtonpost.com/section/business", new List<string> { "div", "class", "card__content", "a", "href", "https://www.huffingtonpost.com", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Business" }));

            // Business Keyword/Tag List
            HashSet<string> MoneyTags = new HashSet<string> { "credit", "economics", "business", "money", "finances" };


            // Environment Sites
            List<KeyValuePair<string, List<string>>> EarthSites = new List<KeyValuePair<string, List<string>>>() { };
            EarthSites.Add(new KeyValuePair<string, List<string>>("https://theconversation.com/us/environment", new List<string> { "div", "class", "article--header", "a", "href", "https://theconversation.com", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Environment" }));
            EarthSites.Add(new KeyValuePair<string, List<string>>("http://discovermagazine.com/topics/environment", new List<string> { "div", "class", "dataItem", "a", "href", "http://discovermagazine.com", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Environment" }));
            EarthSites.Add(new KeyValuePair<string, List<string>>("https://www.huffingtonpost.com/section/green", new List<string> { "div", "class", "card__content", "a", "href", "https://www.huffingtonpost.com", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Environment" }));


            // Environment Keyword/Tag List
            HashSet<string> EarthTags = new HashSet<string> { "environment", "environmental", "green", "organic" };

            // Education Sites
            List<KeyValuePair<string, List<string>>> SmartSites = new List<KeyValuePair<string, List<string>>>() { };
            SmartSites.Add(new KeyValuePair<string, List<string>>("https://theconversation.com/us/education", new List<string> { "div", "class", "article--header", "a", "href", "https://theconversation.com", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Education" }));
            SmartSites.Add(new KeyValuePair<string, List<string>>("http://www.bbc.com/news/education", new List<string> { "div", "class", "pigeon-item__body", "a", "href", "http://www.bbc.com", "meta", "name", "og:description", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Education" }));
            SmartSites.Add(new KeyValuePair<string, List<string>>("http://www.educationnews.org/", new List<string> { "article", "class", "article-popular ", "a", "href", "http://www.educationnews.org/", "meta", "property", "article:tag", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Education" }));
            SmartSites.Add(new KeyValuePair<string, List<string>>("http://www.educationnews.org/", new List<string> { "div", "class", "copy", "a", "href", "http://www.educationnews.org/", "meta", "property", "article:tag", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Education" }));

            // Education Keyword/Tag List
            HashSet<string> SmartTags = new HashSet<string> { "education", "school", "university", "college" };

            // History Sites
            List<KeyValuePair<string, List<string>>> AncientSites = new List<KeyValuePair<string, List<string>>>() { };
            AncientSites.Add(new KeyValuePair<string, List<string>>("http://historynewsnetwork.org/", new List<string> { "div", "class", "caption", "a", "href", "https://historynewsnetwork.org", "meta", "property", "og:title", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "History" }));
            AncientSites.Add(new KeyValuePair<string, List<string>>("https://www.newhistorian.com/", new List<string> { "div", "class", "news-summary has-feature-image", "a", "href", "https://www.newhistorian.com/", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "History" }));
            AncientSites.Add(new KeyValuePair<string, List<string>>("https://www.hoover.org/publications/military-history-news", new List<string> { "h2", "class", "field-title", "a", "href", "https://www.hoover.org", "meta", "name", "og:description", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "History" }));

            // History Keyword/Tag List
            HashSet<string> AncientTags = new HashSet<string> { "history", "ancient", "evolution", "prehistoric", "amazon", "dinosaur" };

            // Medical Sites
            List<KeyValuePair<string, List<string>>> MedicalSites = new List<KeyValuePair<string, List<string>>>() { };
            MedicalSites.Add(new KeyValuePair<string, List<string>>("https://www.medicalnewstoday.com/", new List<string> { "li", "class", "featured", "a", "href", "https://www.medicalnewstoday.com", "meta", "property", "og:description", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content","Medical" }));
            MedicalSites.Add(new KeyValuePair<string, List<string>>("https://www.medicalnewstoday.com/", new List<string> { "li", "class", "knowledge", "a", "href", "https://www.medicalnewstoday.com", "meta", "property", "og:description", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Medical" }));
            MedicalSites.Add(new KeyValuePair<string, List<string>>("https://www.medicalnewstoday.com/", new List<string> { "li", "class", "written", "a", "href", "https://www.medicalnewstoday.com", "meta", "property", "og:description", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Medical" }));

            // Medical Keyword/Tag List
            HashSet<string> MedicalTags = new HashSet<string> { "medicine", "cancer", "research", "health" };

            // Technology Sites
            List<KeyValuePair<string, List<string>>> TechSites = new List<KeyValuePair<string, List<string>>>() { };
            TechSites.Add(new KeyValuePair<string, List<string>>("http://news.mit.edu/topic/computers", new List<string> { "h3", "class", "title", "a", "href", "http://news.mit.edu", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Technology" }));
            TechSites.Add(new KeyValuePair<string, List<string>>("https://phys.org/technology-news/computer-sciences/", new List<string> { "div", "class", "article--header", "a", "href", "https://theconversation.com", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Technology" }));
            TechSites.Add(new KeyValuePair<string, List<string>>("https://theconversation.com/us/topics/computer-science-6612", new List<string> { "div", "class", "article--header", "a", "href", "https://theconversation.com", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Technology" }));
            TechSites.Add(new KeyValuePair<string, List<string>>("http://discovermagazine.com/topics/technology", new List<string> { "div", "class", "dataItem", "a", "href", "http://discovermagazine.com", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Technology" }));
            TechSites.Add(new KeyValuePair<string, List<string>>("https://techxplore.com/", new List<string> { "div", "class", "article--header", "a", "href", "https://theconversation.com", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Technology" }));
            TechSites.Add(new KeyValuePair<string, List<string>>("https://www.huffingtonpost.com/topic/computer-science", new List<string> { "div", "class", "card__content", "a", "href", "https://www.huffingtonpost.com", "meta", "name", "news_keywords", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Technology" }));
            TechSites.Add(new KeyValuePair<string, List<string>>("http://www.educationnews.org/", new List<string> { "article", "class", "article-popular ", "a", "href", "http://www.educationnews.org/", "meta", "property", "article:tag", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Technology" }));
            TechSites.Add(new KeyValuePair<string, List<string>>("http://www.educationnews.org/", new List<string> { "div", "class", "copy", "a", "href", "http://www.educationnews.org/", "meta", "property", "article:tag", "content", "meta", "property", "og:title", "content", "meta", "property", "og:description", "content", "Technology" }));


            // Technology Keyword/Tag List
            HashSet<string> TechTags = new HashSet<string> { "technologies", "technology", "computers", "google", "apps", "apple", "amazon", "microsoft", "ai", "elon musk", "spacex", "nasa" };

            // Art & Design Crawler
            BaseCrawler artie = new BaseCrawler(ArtSites, ArtTags);

            // Business Crawler
            BaseCrawler cachingie = new BaseCrawler(MoneySites, MoneyTags);

            // Environmental Crawler
            BaseCrawler earthie = new BaseCrawler(EarthSites, EarthTags);

            // Education Crawler
            BaseCrawler smartie = new BaseCrawler(SmartSites, SmartTags);

            // History Crawler
            BaseCrawler oldie = new BaseCrawler(AncientSites, AncientTags);

            // Medical Crawler
            BaseCrawler medie = new BaseCrawler(MedicalSites, MedicalTags);

            // Tech Crawler
            BaseCrawler techie = new BaseCrawler(TechSites, TechTags);

            // Run all crawlers asynchronously but waits until they are complete before moving on.
            Task.WaitAll(artie.CrawlingAsync(),cachingie.CrawlingAsync(),earthie.CrawlingAsync(), smartie.CrawlingAsync(), oldie.CrawlingAsync(),medie.CrawlingAsync(),techie.CrawlingAsync());

            Console.WriteLine(DateTime.Now + ": Crawler Ended");
            return 0;
        }
    }
}
