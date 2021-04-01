using Corcentric.ValueObject;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

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
        private IWebElement _FirstName;
        [FindsBy(How = How.CssSelector, Using = "#lastName")]
        private IWebElement _LastName;
        [FindsBy(How = How.CssSelector, Using = "#userNumber")]
        private IWebElement _Number;
        [FindsBy(How = How.CssSelector, Using = "#submit")]
        private IWebElement Submit;
        [FindsBy(How = How.CssSelector, Using = "#example-modal-sizes-title-lg")]
        private IWebElement Text;
        [FindsBy(How = How.CssSelector, Using = "#gender-radio-1")]
        private IWebElement _Male;
        [FindsBy(How = How.CssSelector, Using = "#gender-radio-2")]
        private IWebElement _Female;
        [FindsBy(How = How.CssSelector, Using = "#gender-radio-3")]
        private IWebElement _Other;

        public IWebElement FirstName { get { return _FirstName; }}
        public IWebElement LastName { get { return _LastName; }}
        public IWebElement Number { get { return _Number; }}
        public IWebElement Male { get { return _Male; } }
        public IWebElement Female { get { return _Female; } }
        public IWebElement Other { get { return _Other; } }

        public void NavigateToForm()
        {
            Form.Click();
        }
        public void ClickPracticeForm()
        {
            Practice.Click();
        }
        public void FillForm(string name, string lastname, string number, string gender)
        {
            Form form = new Form(name, lastname, number, gender);
            FirstName.SendKeys(form.Fistname);
            LastName.SendKeys(form.Lastname);
            Number.SendKeys(form.Usernumber);
            Gendervalue(form.Gender);
        }

        public void Gendervalue(string value)
        {
            var radios = driver.FindElements(By.Name("gender"));
            foreach (var radio in radios)
            {
                if (radio.GetAttribute("value") == value)
                {
                    var jse = (IJavaScriptExecutor)driver;
                    jse.ExecuteScript("arguments[0].click()", radio);
                }
            }

        }


        public void SubmitForm()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", Submit);

            Submit.Click();
        }

        public string getTxt()
        {
            return Text.Text.Trim();

        }

        public Boolean IsRequired(IWebElement element,string attribute)
        {
            var value = element.GetAttribute(attribute);
            if (value != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}