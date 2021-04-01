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
            PracticeForm.FillForm("Rumina", "Merchant", "012344566787542","Female");
            PracticeForm.SubmitForm();
            Assert.AreEqual("Thanks for submitting the form", PracticeForm.getTxt());
        }

        [Test(Description = "Verify First Name, Last Name, Gender are required fields")]
        public void Case2()
        {
            var PracticeForm = new PracticeForm(driver);
            PracticeForm.GotoUrl("https://demoqa.com/");
            PracticeForm.NavigateToForm();
            PracticeForm.ClickPracticeForm();
            PracticeForm.SubmitForm();
            Assert.True(PracticeForm.IsRequired(PracticeForm.FirstName, "required"));
            Assert.True(PracticeForm.IsRequired(PracticeForm.LastName, "required"));
            Assert.True(PracticeForm.IsRequired(PracticeForm.Number, "required"));
            Assert.True(PracticeForm.IsRequired(PracticeForm.Male, "required"));
            Assert.True(PracticeForm.IsRequired(PracticeForm.Female, "required"));
            Assert.True(PracticeForm.IsRequired(PracticeForm.Other, "required"));

        }
        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }
       
    }
}