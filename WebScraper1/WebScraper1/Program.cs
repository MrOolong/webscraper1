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
            ChromeDriver chromeDriver = new ChromeDriver();
            chromeDriver.Navigate().GoToUrl("https://www.progressivegrocer.com");

            // Find article titles
            var artTitle = chromeDriver.FindElements(By.XPath("//a/h3"));

            // Find article urls
            var mainTitle = chromeDriver.FindElement(By.XPath("//h1[@class = 'title']/parent::div/parent::div/parent::a"));

            // Count total articles by specified xpath in artTitle variable
            Console.WriteLine();
            var totalTitles = artTitle.Count;
            Console.WriteLine("There are " + totalTitles + " article titles in total");

            Console.WriteLine();
            Console.WriteLine("Please hit enter to see all article titles");
            Console.ReadLine();

            List<ArticleDB> articleList = new List<ArticleDB>();

            // print mainTitle and mainTitle url to console
            Console.WriteLine(mainTitle.Text);
            Console.WriteLine(mainTitle.GetAttribute("href"));
            articleList.Add(new ArticleDB { ArticleTitle = mainTitle.Text , ArticleUrl = mainTitle.GetAttribute("href") , Source = "Progressive Grocer" });
            

            // iterate through the articles displaying them in the console - alternating article title then article url
            foreach (var title in artTitle)
            {
                // print the text associated with each title
                Console.WriteLine(title.Text);
                
                var currentUrl = title.FindElement(By.XPath(".//parent::a"));
                Console.WriteLine(currentUrl.GetAttribute("href"));

                articleList.Add(new ArticleDB { ArticleTitle = title.Text, ArticleUrl = currentUrl.GetAttribute("href") , Source = "Progressive Grocer" });
            }

            chromeDriver.Quit();

           using (var ctx = new ArticleDBContext())
            {
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
            
            [Key]
            public int IDKey { get; set; }
            public string ArticleTitle { get; set; }
            public string ArticleUrl { get; set; }    
            public string Source { get; set; }
        }

        public class ArticleDBContext : DbContext
        {
            public ArticleDBContext() : base()
            {

            }

            public DbSet<ArticleDB> ArticleDBs { get; set; }
        }
 }