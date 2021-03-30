using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit;
using NUnit.Framework;
using Corcentric.PageObjects;
using SeleniumExtras.PageObjects;

namespace Corcentric
{
    [TestClass]
    public class TestClass
    {
     public static IWebDriver driver;
        [TestInitialize]
        public void Setup()
        {
            string path = System.IO.Path.GetFullPath(@"..\..\WinDriver\");
            driver = new ChromeDriver(path);
            driver.Manage().Window.Maximize();
           
        }
        [TestMethod]
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

        [TestMethod]
        public void Case2()
        {
            var PracticeForm = new PracticeForm(driver);
            PracticeForm.GotoUrl();
            PracticeForm.openForm();
            PracticeForm.openpractiseform();
            PracticeForm.Save();
            PracticeForm.FiledValidation();
        }
        [TestCleanup]
        public void QuitDriver()
        {
            driver.Quit();
        }
       
    }
}