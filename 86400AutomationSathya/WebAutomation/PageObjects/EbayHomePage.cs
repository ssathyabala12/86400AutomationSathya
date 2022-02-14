using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace _86400AutomationSathya.WebAutomation.PageObjects
{

    public class EbayHomePage
    {
        private readonly IWebDriver WebDriver;
        public EbayHomePage(IWebDriver webDriver)
        {
            this.WebDriver = webDriver;
        }
   
    public void InitialiseElements()
    {       
    }
        private IWebElement searchTextBox => WebDriver.FindElement(By.CssSelector("input[class='gh-tb ui-autocomplete-input']"));
        private IWebElement searchButton => WebDriver.FindElement(By.CssSelector("input[type='submit']"));
        private SelectElement categorySelectItem => new SelectElement(WebDriver.FindElement(By.CssSelector("select[aria-label='Select a category for search']")));
         private IWebElement resultsList => WebDriver.FindElement(By.CssSelector("a[class='gh-eb-li-a gh-rvi-menu']"));
         private IWebElement sellLink => WebDriver.FindElement(By.XPath("//a[text()='Sell']"));
        private IWebElement listAnItem => WebDriver.FindElement(By.XPath("//a[text()='List an item']"));
        public EbayHomePage searchByName(string productName)
        {
            searchTextBox.SendKeys(productName);
            searchButton.Click();
            return this;
        }
        public EbayHomePage searchByCategory(string productName, string CategoryType)
        {
            searchTextBox.Clear();
            searchTextBox.SendKeys(productName);
            categorySelectItem.SelectByText(CategoryType);
            searchButton.Click();
            return this;
         }
        public bool isFirstResult(string resultText)
        {
             return resultsList.Text.Contains(resultText);

        }
        public EbayHomePage withSellPage()
        {
            sellLink.Click();
            return this;
        }
    }
}

