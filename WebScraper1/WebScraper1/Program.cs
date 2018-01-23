using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebScraper_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArticleDB DB1 = new ArticleDB();
            //DB1.Source = "Progressive Grocer";
            //DB1.SourceUrl = "https://www.progressivegrocer.com";

            ChromeOptions options = new ChromeOptions();
            ChromeDriver chromeDriver = new ChromeDriver();
            chromeDriver.Navigate().GoToUrl("https://www.progressivegrocer.com");

            // Find article titles
            var titles = chromeDriver.FindElementsByClassName("title");

            // Count total articles
            Console.WriteLine();
            var totalTitles = titles.Count;
            Console.WriteLine("There are " + totalTitles + " article titles in total");

            Console.WriteLine();
            Console.WriteLine("Please hit enter to see all article titles");
            Console.ReadLine();

            List<ArticleDB> articleList = new List<ArticleDB>();

            // Print each title found
            foreach (var title in titles)
            {
                articleList.Add(new ArticleDB { ArticleTitle = title.Text});
                Console.WriteLine(title.Text);
            }


            //var urlFinder = chromeDriver.FindElementsByXPath("//*[@class='category']//*[@href]");
            //*[@id="block-homepageprimaryarticles"]/div/div[1]/div/div[2]/a
            //a[text()='text_i_want_to_find']/@href
            //Console.WriteLine(urlFinder);

            //foreach (var url in urlFinder)
            //{
            //    Console.WriteLine(url.Text);
            //}

            chromeDriver.Quit();

           using (var ctx = new ArticleDBContext())
            {
                ArticleDB article = new ArticleDB()
                {
                };

                foreach (var i in articleList)
                {

                    ctx.ArticleDBs.Add(i);
                };

                ctx.SaveChanges();
            }


            }
        }

        public class ArticleDB
        {
            public ArticleDB()
            {

            }
            
            //public int ArticleID { get; set; }
            [Key]
            public int IDKey { get; set; }
            public string ArticleTitle { get; set; }
            //public string ArticleUrl { get; set; }    
            //public string Source { get; set; }
            //public string SourceUrl { get; set; }
        }

        public class ArticleDBContext : DbContext
        {
            public ArticleDBContext() : base()
            {

            }

            public DbSet<ArticleDB> ArticleDBs { get; set; }
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


