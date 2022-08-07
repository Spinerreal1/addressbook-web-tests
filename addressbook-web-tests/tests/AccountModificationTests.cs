using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;



namespace addressbook_web_tests
{
    [TestFixture]
    public class AccountModificationTests : ContactTestBase
    {
        [Test]
        public void AccountModificationTest()
        {
            ContactData newData = new ContactData("zzz", "xxxx");
            newData.LastName = "3333";
            newData.Nickname = "4444";

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldContactData = oldContacts[0];

            app.Contacts.CreateContactIfElementPresent();
            app.Contacts.Modify(0, newData);


            List<ContactData> newContacts = ContactData.GetAll();


            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
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
