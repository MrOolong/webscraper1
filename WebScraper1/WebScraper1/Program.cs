using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Data.Entity;

namespace WebScraper_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();
            ChromeDriver chromeDriver = new ChromeDriver();
            chromeDriver.Navigate().GoToUrl("https://www.progressivegrocer.com");

            //var article = new ArticleDB() {ArticleTitle=" };

            // Find article titles
            var titles = chromeDriver.FindElementsByClassName("title");

            // Count total articles
            Console.WriteLine();
            var totalTitles = titles.Count;
            Console.WriteLine("There are " + totalTitles + " article titles in total");

            Console.WriteLine();
            Console.WriteLine("Please hit enter to see all article titles");
            Console.ReadLine();

            // Print each title found
            foreach (var title in titles)
            {
                Console.WriteLine(title.Text);
            }

            //var urlFinder = "//*[@id='block-homepageprimaryarticles']/div/div[1]/div/div[2]/a";

            //foreach (var url in urlFinder)
            //{
            //    Console.WriteLine(url.ToString());
            //}

            chromeDriver.Quit();

            ArticleDB DB1 = new ArticleDB();
            DB1.Source = "Progressive Grocer";
            DB1.SourceUrl = "https://www.progressivegrocer.com";
        }

        public class ArticleDB
        {
            public ArticleDB()
            {

            }

            //public int ArticleID { get; set; }
            public string ArticleTitle { get; set; }
            public string Source { get; set; }
            public string SourceUrl { get; set; }
        }

        public class ArticleDBContext : DbContext
        {
            public ArticleDBContext() : base()
            {

            }

            public DbSet<ArticleDB> ArticlesDB { get; set; }
        }

        //public class Navigation
        //{
        //    public Navigation()
        //    {

        //    }
        //}

        //public class Article_Finder
        //{
        //    public Article_Finder()
        //    {

        //    }
        //}
    }
}
