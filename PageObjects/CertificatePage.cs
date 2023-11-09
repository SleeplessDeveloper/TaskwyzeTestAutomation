using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskwyzeTestAutomation.PageObjects
{
    public class CertificatePage
    {
        IWebDriver _driver;
        public CertificatePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "details-button")]
        private readonly IWebElement advanced;
        [FindsBy(How = How.Id, Using = "proceed-link")]
        private readonly IWebElement proceed;

        public LandingPage GoToLandingPage()
        {
            advanced.Click();
            proceed.Click();
            return new LandingPage(_driver);
        }
    }
}
