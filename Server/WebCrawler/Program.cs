using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler
{

    class Program
    {
        static int Main(string[] args)
        {
            TechCrawler techie = new TechCrawler();
            ArtDesignCrawler artie = new ArtDesignCrawler();
            EducationCrawler smartie = new EducationCrawler();
            EarthCrawler earthie = new EarthCrawler();
            HistoryCrawler oldie = new HistoryCrawler();
            MedicalCrawler medie = new MedicalCrawler();
            BusinessCrawler cachingie = new BusinessCrawler();
            techie.CrawlingAsync().Wait();
            artie.CrawlingAsync().Wait();
            smartie.CrawlingAsync().Wait();
            earthie.CrawlingAsync().Wait();
            oldie.CrawlingAsync().Wait();
            medie.CrawlingAsync().Wait();
            cachingie.CrawlingAsync().Wait();
            Console.WriteLine("\n"+DateTime.Now + ": Crawler Ended");

            Console.ReadLine();
            return 0;
        }
    }
}
