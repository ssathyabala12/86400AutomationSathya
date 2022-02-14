using _86400AutomationSathya.WebAutomation.CommonAttributes;
using _86400AutomationSathya.WebAutomation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _86400AutomationSathya.WebAutomation.WebTests
{
    public class EbayHomePageTests 
    {
        IWebDriver driver;
                
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "http://www.ebay.com.au";
        }

        [Test]
        public void SearchProduct()
        {         
            
            EbayHomePage ebayHomePage = new EbayHomePage(driver);
               ebayHomePage.searchByName("Iphone");
           
            ebayHomePage.searchByCategory("Iphone11", "Phones & Accessories");
            Assert.IsTrue(ebayHomePage.isFirstResult("My eBay"));
        }
        [Test]
        public void SellItem()
        {

            EbayHomePage ebayHomePage = new EbayHomePage(driver);
            ebayHomePage.withSellPage();
        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}