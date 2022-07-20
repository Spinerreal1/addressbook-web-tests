using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;



namespace addressbook_web_tests
{
    [TestFixture]
    public class AccountRemovalTests : AuthTestBase
    {

        [Test]
        public void AccountRemovalTest()
        {
            app.Contacts.CreateContactIfElementPresent();

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            ContactData toBeRemoved = oldContacts[0];


            app.Contacts.Remove(0);

            List<ContactData> newContacts = app.Contacts.GetContactsList();

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
