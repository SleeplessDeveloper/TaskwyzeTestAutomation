using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskwyzeTestAutomation.PageObjects
{
    public class SignUpPage
    {
        IWebDriver _driver;
        WebDriverWait _wait;
        public SignUpPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            _wait = wait;
        }

        

        [FindsBy(How = How.Id, Using = "Name")]
        private IWebElement name;

        [FindsBy(How = How.Id, Using = "Surname")]
        private IWebElement surname;
        [FindsBy(How = How.Id, Using = "mat-input-2")]
        private IWebElement phoneNumber;
        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement email;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement password;

        [FindsBy(How = How.Id, Using = "ChexkPassword")]
        private IWebElement checkPassword;
        [FindsBy(How = How.Id, Using = "submit")]
        private readonly IWebElement submitButton;
        public void FillInSignUpForm(string Fname, string Sname,  string UphoneNumber, string Uemail, string Upassword)
        {
            name.SendKeys(Fname);
            surname.SendKeys(Sname);
            email.SendKeys(Uemail);
            phoneNumber.SendKeys(UphoneNumber);
            password.SendKeys(Upassword);
            checkPassword.SendKeys(Upassword);
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(submitButton));
            submitButton.Click();
        }
        public OtpPage ViewOtpScreen()
        {
            return new OtpPage(_driver);
        }
    }
}
