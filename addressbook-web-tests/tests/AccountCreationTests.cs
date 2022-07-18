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
            AccountCreationData group = new AccountCreationData("aaa", "bbb");
            group.LastName = "bbb";
            group.Nickname = "ccc";

            List<AccountCreationData> oldContacts = app.ContactHelper.GetContactsList();

            app.ContactHelper.Create(group);


            List<AccountCreationData> newContacts = app.ContactHelper.GetContactsList();
            oldContacts.Add(group);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts.Count - 1, newContacts.Count);
        }
        [Test]
        public void EmptyAccountCreationTest()
        {
            AccountCreationData group = new AccountCreationData("", "");
            group.LastName = "";
            group.Nickname = "";

                        List<AccountCreationData> oldContacts = app.ContactHelper.GetContactsList();

            app.ContactHelper.Create(group);

            List<AccountCreationData> newContacts = app.ContactHelper.GetContactsList();
            oldContacts.Add(group);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts.Count - 1, newContacts.Count);
        }
    }
}
