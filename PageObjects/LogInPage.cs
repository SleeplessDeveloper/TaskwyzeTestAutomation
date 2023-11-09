using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskwyzeTestAutomation.PageObjects
{
    public class LogInPage
    {
        IWebDriver _driver;
        public LogInPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement email;

        [FindsBy(How =How.Id, Using ="Password")]
        private IWebElement password;
    }
}
