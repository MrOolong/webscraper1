﻿using System;
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

            var titles = chromeDriver.FindElementsByClassName("title");

            foreach (var title in titles)
            {
                Console.WriteLine(title.Text);
            }
        }
    }
}
