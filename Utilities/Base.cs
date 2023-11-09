using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace TaskwyzeTestAutomation.Utilities
{
    public class Base
    {
        IWebDriver driver;
        string browserName;
        string url;
        
        [SetUp] 
        public void SetUp() 
        {

            browserName = ConfigurationManager.AppSettings["browser"]!;
            url = ConfigurationManager.AppSettings["url"]!;
            InitBrowser(browserName);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = url;   

        }
        public IWebDriver GetDriver()
        {
            return driver;
        }

        public static RegistrationCsvReader MockData()
        {
            string csvFile = ConfigurationManager.AppSettings["Registrationfile"]!;
            return new RegistrationCsvReader(csvFile);
        }
        public void InitBrowser(string browserName)
        {
            switch(browserName)
            {
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
            }
        }
        [TearDown]
        public void TearDown() 
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
