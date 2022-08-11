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
            ContactData newContactData = new ContactData("zzz", "xxxx");
            newContactData.LastName = "3333";
            newContactData.Nickname = "4444";

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldContactData = oldContacts[0];

            app.Contacts.CreateContactIfElementPresent();
            app.Contacts.Modify(oldContactData, newContactData);


            List<ContactData> newContacts = ContactData.GetAll();


            oldContactData.FirstName = newContactData.FirstName;
            oldContactData.LastName = newContactData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldContactData.Id)
                {
                    Assert.AreEqual(newContactData.FirstName, contact.FirstName);
                    Assert.AreEqual(newContactData.LastName, contact.LastName);
                }
            }
        }

    }
}
