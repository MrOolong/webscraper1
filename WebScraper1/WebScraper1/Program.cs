using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Data.Entity;

namespace WebScraper1
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new ChromeOptions();
            //options.AddArguments("--disable-gpu");

            // open chrome and provide destination address
            var chromeDriver = new ChromeDriver();
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

            // Print each title found
            foreach (var title in titles)
            {
                Console.WriteLine(title.Text);
            }

            chromeDriver.Quit();

            ArticleDB DB1 = new ArticleDB();
        }

        public class ArticleDB
        {
            public ArticleDB()
            {

            }

            public int ArticleID { get; set; }
            public string ArticleTitle { get; set; }
            public string Source { get; set; }
            public string Url { get; set; }
        }

        //public class WebScraper
        //{
        //    public WebScraper()
        //    {

        //    }

        //    public void ScrapeMethod()
        //    {

        //    }
        //}
    }
}
