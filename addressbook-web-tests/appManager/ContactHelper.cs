using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper SubmitAccountCreation()
        {
            driver.FindElement(By.XPath("//input[21]")).Click();
            return this;
        }

        public ContactHelper FillAccountForm(AccountCreationData group)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(group.Firstname);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(group.MIddlename);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(group.Lastname);
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(group.Nickname);
            driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("home")).Click();
            driver.FindElement(By.Name("mobile")).Click();
            driver.FindElement(By.Name("work")).Click();
            driver.FindElement(By.Name("fax")).Click();
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email2")).Click();
            driver.FindElement(By.Name("email3")).Click();
            driver.FindElement(By.Name("homepage")).Click();
            driver.FindElement(By.Name("bday")).Click();
            driver.FindElement(By.Name("bmonth")).Click();
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("aday")).Click();
            driver.FindElement(By.Name("amonth")).Click();
            driver.FindElement(By.Name("ayear")).Click();
            driver.FindElement(By.Name("new_group")).Click();
            driver.FindElement(By.Name("address2")).Click();
            driver.FindElement(By.Name("phone2")).Click();
            driver.FindElement(By.Name("notes")).Click();
            return this;
        }

        public ContactHelper GoToAccountCreationTests()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
    }
}
