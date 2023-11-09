using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace TaskwyzeTestAutomation.PageObjects
{
    public class LandingPage
    {
        IWebDriver _driver;
        public LandingPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        
        [FindsBy(How = How.Id, Using = "signup")]
        private readonly IWebElement signUpButton;
        
        public SignUpPage SignUpPage()
        {
            signUpButton.Click();
            return new SignUpPage(_driver);
        }

    }
}
