using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;



namespace addressbook_web_tests
{
    [TestFixture]
    public class AccountModificationTests : AuthTestBase
    {
        [Test]
        public void AccountModificationTest()
        {
            AccountCreationData newData = new AccountCreationData("zzz", "xxxx");
            newData.LastName = "3333";
            newData.Nickname = "4444";

            List<AccountCreationData> oldContacts = app.ContactHelper.GetContactsList();
            AccountCreationData oldContactData = oldContacts[0];

            app.ContactHelper.CreateContactIfElementPresent();
            app.ContactHelper.Modify(0, newData);

            app.GroupHelper.Modify(0, newData);

            List<AccountCreationData> newContacts = app.ContactHelper.GetContactsList();


            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (AccountCreationData contact in newContacts)
            {
                if (contact.Id == oldContactData.Id)
                {
                    Assert.AreEqual(newData.FirstName, contact.FirstName);
                    Assert.AreEqual(newData.LastName, contact.LastName);
                }
            }
        }

    }
}
