using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corcentric.PageObjects
{
    class PracticeForm
    {
        IWebDriver driver;
        public PracticeForm(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void GotoUrl(String url)
        {
            driver.Navigate().GoToUrl(url);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,document.body.scrollHeight)");
        }

        [FindsBy(How = How.XPath, Using = "//h5[contains(text(),'Forms')]")]
        private IWebElement Form;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Practice Form')]")]
        private IWebElement Practice;
        [FindsBy(How = How.CssSelector, Using = "#firstName")]
        private IWebElement FirstName;
        [FindsBy(How = How.CssSelector, Using = "#lastName")]
        private IWebElement LastName;
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Female')]")]
        private IWebElement Gender;
        [FindsBy(How = How.CssSelector, Using = "#userNumber")]
        private IWebElement Number;
        [FindsBy(How = How.CssSelector, Using = "#submit")]
        private IWebElement Submit;
        [FindsBy(How = How.CssSelector, Using = "#example-modal-sizes-title-lg")]
        private IWebElement Text;
       
        public void NavigateToForm()
        {
            Form.Click();
        }
        public void ClickPracticeForm()
        {
            Practice.Click();
        }
        public void SetGender()
        {
            Gender.Click();
        }
        public void SetFirstName(string name)
        {
            FirstName.SendKeys(name);
        }
        public void SetLastName(string name)
        {
            LastName.SendKeys(name);
        }
        public void SetNumber(string number)
        {
            Number.SendKeys(number);
        }
        public void SubmitForm()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", Submit);

            Submit.Click();
        }

        public void CompareMessage(string expected)
        {
            String actual = Text.Text.Trim();
            Assert.AreEqual(expected, actual);
        }

        public void FieldValidation()
        {
         var result=   driver.FindElements(By.CssSelector(".form-control:invalid"));

            foreach (var v in result)
            {
                if (v.GetAttribute("id") != "firstName" && v.GetAttribute("id") != "lastName" && v.GetAttribute("id") != "userNumber")
                {
                    Assert.Fail(v.GetAttribute("id") + "not found");
                }
             
            }            
            
        }
 

    }
}
