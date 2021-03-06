using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public string baseURL;
        public ContactHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }
        public ContactData GetContactInformationFromEditForm(int p)
        {
            manager.Navigator.GoToHomePage();
            EditContact(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string modilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string Fax = driver.FindElement(By.Name("fax")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Home = homePhone,
                Mobile = modilePhone,
                Work = workPhone,
                Fax = Fax
            };
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        private List<ContactData> contactCache = null;
        public List<ContactData> GetContactsList()
        {
            if (contactCache == null)
            { 
            contactCache = new List<ContactData>();

            manager.Navigator.GoToHomePage();
            Thread.Sleep(200);

            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name=\"entry\"]"));
            foreach (IWebElement element in elements)
            {
                var td = element.FindElements(By.CssSelector("td"));
                contactCache.Add(new ContactData(td[2].Text, td[1].Text)
                {
                    Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                });
            }
           }
            return new List<ContactData>(contactCache);
        }

        public ContactHelper Create(ContactData group)
        {
            manager.Navigator.GoToHomePage();
            GoToAccountCreationTests();
            FillAccountForm(group);
            SubmitAccountCreation();
            ReturnToHomePage();
            return this;
        }
        public ContactHelper Remove(int p)
        {
            {
                OpenHomePage();
                SelectContact(p);
                DeleteContact();
                return this;
            }
        }
        public ContactHelper Modify(int p, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            OpenHomePage();
            SelectContact(p);
            EditContact(p);
            ChangeAccountForm(newData);
            SubmitAccountModify();
            return this;
        }

        public ContactHelper SubmitAccountCreation()
        {
            driver.FindElement(By.XPath("//input[21]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper FillAccountForm(ContactData group)
        {
            Type(By.Name("firstname"), group.FirstName);
            Type(By.Name("middlename"), group.MIddleName);
            Type(By.Name("lastname"), group.LastName);
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
        public ContactHelper ChangeAccountForm(ContactData newData)
        {
            Type(By.Name("firstname"), newData.FirstName);
            Type(By.Name("middlename"), newData.MIddleName);
            Type(By.Name("lastname"), newData.LastName);
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
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }
        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.CssSelector("div.msgbox"));
            contactCache = null;
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
            contactCache = null;
            return this;
        }
        public ContactHelper EditContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index + 2) + "]/td[8]/a/img")).Click();
            return this;
        }
        public ContactHelper CreateContactIfElementPresent()
        {
            if (driver.Url == baseURL + "/addressbook/"
               && !IsElementPresent(By.Name("selected[]")))
            {
                Create(new AccountData("firstname", "lastname"));
            }
            return this;
        }

        private void Create(AccountData accountData)
        {
            throw new NotImplementedException();
        }
    }
}