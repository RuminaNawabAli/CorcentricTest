using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using Corcentric.PageObjects;

namespace Corcentric
{
    [TestFixture]
    public class TestClass
    {
     public static IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            string path = System.IO.Path.GetFullPath(@"..\..\WinDriver\");
            driver = new ChromeDriver(path);
            driver.Manage().Window.Maximize();
           
        }
        [Test(Description = "Verify that form submitted successfully")]
        public void Case1()
        {
            var PracticeForm = new PracticeForm(driver);
            PracticeForm.GotoUrl("https://demoqa.com/");
            PracticeForm.NavigateToForm();
            PracticeForm.ClickPracticeForm();
            PracticeForm.SetFirstName("Rumina");
            PracticeForm.SetLastName("Merchant");
            PracticeForm.SetGender();
            PracticeForm.SetNumber("012344566787542");
            PracticeForm.SubmitForm();
            PracticeForm.CompareMessage("Thanks for submitting the form");
        }

        [Test(Description = "Verify First Name, Last Name, Gender are required fields")]
        public void Case2()
        {
            var PracticeForm = new PracticeForm(driver);
            PracticeForm.GotoUrl("https://demoqa.com/");
            PracticeForm.NavigateToForm();
            PracticeForm.ClickPracticeForm();
            PracticeForm.SubmitForm();
            PracticeForm.FieldValidation();
        }
        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }
       
    }
}