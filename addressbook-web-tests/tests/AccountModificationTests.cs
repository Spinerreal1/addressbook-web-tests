using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;


namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class AccountModificationTests : AuthTestBase
    {
        [Test]
        public void AccountModificationTest()
        {
            AccountCreationData newData = new AccountCreationData("zzz", "xxxx");
            newData.Lastname = "3333";
            newData.Nickname = "4444";

            List<AccountCreationData> oldContacts = app.ContactHelper.GetContactsList();
            AccountCreationData oldContactData = oldContacts[0];

            app.ContactHelper.CreateContactIfElementPresent();
            app.ContactHelper.Modify(0, newData);

            app.GroupHelper.Modify(0, newData);

            List<AccountCreationData> newContacts = app.ContactHelper.GetContactsList();


            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (AccountCreationData contact in newContacts)
            {
                if (contact.Id == oldContactData.Id)
                {
                    Assert.AreEqual(newData.Firstname, contact.Firstname);
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                }
            }
        }

    }
}
