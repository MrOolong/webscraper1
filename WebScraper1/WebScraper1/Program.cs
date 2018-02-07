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
            //var titles = chromeDriver.FindElementsByClassName("title");

            var artTitle = chromeDriver.FindElements(By.XPath("//a/h3"));
            //var artUrl = artTitle.FindElement(By.XPath(".//parent::a"));
            var mainTitle = chromeDriver.FindElement(By.XPath("//h1[@class = 'title']/parent::div/parent::div/parent::a"));

            // Count total articles
            Console.WriteLine();
            var totalTitles = artTitle.Count;
            Console.WriteLine("There are " + totalTitles + " article titles in total");

            Console.WriteLine();
            Console.WriteLine("Please hit enter to see all article titles");
            Console.ReadLine();

            List<ArticleDB> articleList = new List<ArticleDB>();

            //print mainTitle and mainTitle url

            Console.WriteLine(mainTitle.Text);
            Console.WriteLine(mainTitle.GetAttribute("href"));
            articleList.Add(new ArticleDB { ArticleTitle = mainTitle.Text , ArticleUrl = mainTitle.GetAttribute("href") });
            
            foreach (var title in artTitle)
            {
                

                //print the url associated with each title
                Console.WriteLine(title.Text);
                
                var currentUrl = title.FindElement(By.XPath(".//parent::a"));
                //var testElement = title.FindElement(By.XPath("/parent::a")).GetAttribute("href");
                Console.WriteLine(currentUrl.GetAttribute("href"));

                articleList.Add(new ArticleDB { ArticleTitle = title.Text, ArticleUrl = currentUrl.GetAttribute("href") });
            }

            chromeDriver.Quit();

           using (var ctx = new ArticleDBContext())
            {
                //ArticleDB article = new ArticleDB()
                //{ };

                //Source = "Progressive Grocer", SourceUrl = "https://www.progressivegrocer.com"

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
            public string ArticleUrl { get; set; }    
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