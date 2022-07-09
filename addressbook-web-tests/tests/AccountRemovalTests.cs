using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;


namespace addressbook_web_tests
{
    [TestFixture]
    public class AccountRemovalTests : AuthTestBase
    {

        [Test]
        public void AccountRemovalTest()
        {

            List<AccountCreationData> oldContacts = app.ContactHelper.GetContactsList();

            AccountCreationData toBeRemoved = oldContacts[0];

            app.ContactHelper.CreateContactIfElementPresent();
            app.ContactHelper.Remove(0);

            List<AccountCreationData> newContacts = app.ContactHelper.GetContactsList();

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (AccountCreationData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
