using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Drawing;
using TaskwyzeTestAutomation.PageObjects;
using TaskwyzeTestAutomation.Utilities;

namespace TaskwyzeTestAutomation.Tests
{
    public class Tests : Base
    {
        

        [Test, TestCaseSource(nameof(AddTestDataConfig))]
        
        public void E2E(string name, string surname, string phonenumber, string email, string password)
        {
            CertificatePage certificatePage = new CertificatePage(GetDriver());
            LandingPage landingPage = certificatePage.GoToLandingPage();
            SignUpPage signUpPage = landingPage.SignUpPage();
            signUpPage.FillInSignUpForm(name,surname, phonenumber, email, password);
            OtpPage otpPage = signUpPage.ViewOtpScreen();
            otpPage.ClickSubmitButton();
            LogInPage loginPage = otpPage.ClickLogInButton(email,password);

        }


      
        private static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            int counter = 0;
            List<string> User = new List<string>();
            User = MockData().GetDataFromCsv();
            string name ="", surname = "", phonenumber = "", email = "", password = "";
            foreach (var details in User)
            {
                switch (counter) 
                {
                    case 0:
                        name = details;
                        break;
                    case 1:
                         surname = details;
                        break;
                    case 2:
                        phonenumber = details;
                        break;
                    case 3:
                        email = details;
                        break;
                    case 4:
                        password = details;
                        break;
                }

                counter++;
            }

            yield return new TestCaseData(name, surname, phonenumber,
                email, password);
        }
    }
}