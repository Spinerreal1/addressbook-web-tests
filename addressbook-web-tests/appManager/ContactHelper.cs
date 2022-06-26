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

        public ContactHelper Create(AccountCreationData group)
        {
            manager.Navigator.GoToGroupsPage();
            GoToAccountCreationTests();
            FillAccountForm(group);
            SubmitAccountCreation();
            ReturnToHomePage();
            return this;
        }
        public ContactHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();
            OpenHomePage();
            SelectContact(p);
            DeleteContact();
            CloseAllert();
            return this;
        }
        public ContactHelper Modify(int p, AccountCreationData newData)
        {
            manager.Navigator.GoToGroupsPage();
            OpenHomePage();
            SelectContact(p);
            EditContact();
            ChangeAccountForm(newData);
            SubmitAccountModify();
            return this;
        }

        public ContactHelper SubmitAccountCreation()
        {
            driver.FindElement(By.XPath("//input[21]")).Click();
            return this;
        }

        public ContactHelper FillAccountForm(AccountCreationData group)
        {
            Type(By.Name("firstname"), group.Firstname);
            Type(By.Name("middlename"), group.MIddlename);
            Type(By.Name("lastname"), group.Lastname);
            Type(By.Name("nickname"), group.Nickname);
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
        public ContactHelper ChangeAccountForm(AccountCreationData newData)
        {
            Type(By.Name("firstname"), newData.Firstname);
            Type(By.Name("middlename"), newData.MIddlename);
            Type(By.Name("lastname"), newData.Lastname);
            Type(By.Name("nickname"), newData.Nickname);
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("title")).Click();
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
        public ContactHelper OpenHomePage() 
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }
        public ContactHelper CloseAllert() 
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper SubmitAccountModify() 
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public ContactHelper EditContact()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }
    }
}
