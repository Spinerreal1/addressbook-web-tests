using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace addressbook_web_tests
{
    [TestFixture]
    public class AccountCreationTests : AuthTestBase
    {

        [Test]
        public void AccountCreationTest()
        {
            ContactData group = new ContactData("aaa", "bbb")
            {
                LastName = "abzr",
                Nickname = "abzrq"
            };

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.Create(group);


            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts.Add(group);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts.Count, newContacts.Count);
            Assert.AreEqual(oldContacts, newContacts);
        }
        [Test]
        public void EmptyAccountCreationTest()
        {
            ContactData group = new ContactData("", "")
            {
                LastName = "",
                Nickname = ""
            };

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.Create(group);

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts.Add(group);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts.Count, newContacts.Count);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
