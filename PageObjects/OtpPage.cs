using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskwyzeTestAutomation.PageObjects
{
    public class OtpPage
    {
        IWebDriver _driver;
        WebDriverWait _wait;
        public OtpPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(2));
            _wait = wait;
        }

        [FindsBy(How = How.Id, Using ="btn-submit")]
        private readonly IWebElement submitButton;
        [FindsBy(How =How.Id, Using = "email")]
        private readonly IWebElement email;
        [FindsBy(How = How.Id, Using ="Password")]
        private readonly IWebElement password;
        [FindsBy(How = How.Id, Using = "submit")]
        private IWebElement logInButton;
       
        public void ClickSubmitButton()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(submitButton));
            submitButton.Click();
        }
        public LogInPage ClickLogInButton(string Uemail, string Upassword)
        {
            email.SendKeys(Uemail);
            password.SendKeys(Upassword);
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(logInButton));
            logInButton.Click();
            return new LogInPage(_driver);
        }
    }

}
