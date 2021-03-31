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
        [Test]
        public void Case1()
        {
            var PracticeForm = new PracticeForm(driver);
            PracticeForm.GotoUrl();
            PracticeForm.openForm();
            PracticeForm.openpractiseform();
            PracticeForm.SetFirstName("Rumina");
            PracticeForm.SetLastName("Merchant");
            PracticeForm.SetGender();
            PracticeForm.SetNumber("012344566787542");
            PracticeForm.Save();
            PracticeForm.Assertion("Thanks for submitting the form");
        }

        [Test]
        public void Case2()
        {
            var PracticeForm = new PracticeForm(driver);
            PracticeForm.GotoUrl();
            PracticeForm.openForm();
            PracticeForm.openpractiseform();
            PracticeForm.Save();
            PracticeForm.FiledValidation();
        }
        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }
       
    }
}