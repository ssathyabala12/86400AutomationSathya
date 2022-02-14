using _86400AutomationSathya.WebAutomation.CommonAttributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _86400AutomationSathya.WebAutomation.PageObjects
{
    public class PageBrowser
    {
        public IWebDriver _driver;
        public readonly INavigation _navigator;
        public readonly IJavaScriptExecutor javaScriptExecutor;
        private DesiredCapabilities _capabilities;
        public string environmentURL { get; set; }
        public string Browser { get; set; }
        private static string baseUrl = "http://ebay.com.au"; 
        //private static IWebDriver webDriver = new ChromeDriver();

        public PageBrowser(IWebDriver webDriver)
        {
            environmentURL = ConfigurationManager.AppSettings[name: "EbayUrl"];
            _driver = webDriver;
        }
        public IWebDriver Create(BrowserType browser)
        {
            //A simple switch statement to determine which driver/service to create.
            switch (browser)
            {
                case BrowserType.Chrome:
                    _driver = new ChromeDriver();
                    break;

                //If a string isn't matched, it will default to FireFoxDriver
                default:
                    throw new Exception($"Webdriver not found for the BrowserType Passed {BrowserType.Chrome}");
                    break;
            }

            //Return the driver instance to the calling class.
            return _driver;
        }
        
        
    }
}
