using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;



namespace addressbook_web_tests
{
    [TestFixture]
    public class AccountRemovalTests : ContactTestBase
    {

        [Test]
        public void AccountRemovalTest()
        {
            app.Contacts.CreateContactIfElementNotPresent();

            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeRemoved = oldContacts[0];


            app.Contacts.Remove(toBeRemoved);

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
