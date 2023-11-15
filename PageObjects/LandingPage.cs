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
        [FindsBy(How = How.Id, Using = "login")]
        private readonly IWebElement signInButton;

        public SignUpPage SignUpPage()
        {
            signUpButton.Click();
            return new SignUpPage(_driver);
        }

        public LogInPage SignInPage()
        {
            signInButton.Click();
            return new LogInPage(_driver);
        }

    }
}
