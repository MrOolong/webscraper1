using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScraper1
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new ChromeOptions();
            //options.AddArguments("--disable-gpu");

            var chromeDriver = new ChromeDriver();
            chromeDriver.Navigate().GoToUrl("https://progressivegrocer.com");

            //var listOfTitles = new List<string>();
            //var test = chromeDriver.FindElementByXPath("//*[@id='block - homepageprimaryarticles']/div/div[1]/div/div[2]/a/h3").ToString();
            //Console.WriteLine(test);

            // Find article titles
            var titles = chromeDriver.FindElementsByClassName("title");

            // Find article descriptions
            var descriptions = chromeDriver.FindElementsByClassName("desc");

            // Count total articles
            var totalTitles = titles.Count;
            Console.WriteLine("There are " + totalTitles + " article titles in total");

            // Count total descriptions
            var totalDescriptions = descriptions.Count;
            Console.WriteLine("There are " + totalDescriptions + " descriptions in total");
            Console.WriteLine();
            Console.ReadLine();

            // Print each title found
            foreach (var title in titles)
            {
                Console.WriteLine(title.Text);
                //Console.ReadLine();
                //for (totalDescriptions = 0; totalDescriptions <= totalTitles; totalDescriptions++)
                //{
                //    Console.WriteLine(descriptions);
                //}
                //Console.WriteLine(descText);
                //foreach (var desc in descriptions)
                //{
                //    Console.WriteLine(descriptions.First());
                //}
            }
        }
    }
}
