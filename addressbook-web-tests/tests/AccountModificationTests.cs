using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;


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

            app.ContactHelper.CreateContactIfElementPresent();
            app.ContactHelper.Modify(1, newData);

            app.GroupHelper.Modify(0, newData);

            List<AccountCreationData> newContacts = app.ContactHelper.GetContactsList();


            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}
