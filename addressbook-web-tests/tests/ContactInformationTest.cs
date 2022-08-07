using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ContactInformationTest : ContactTestBase
    {
        [Test]
        public void TestContactInformationFromTable()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
           
            //verification  
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }
        [Test]
        public void TestContactInformationFromCard()
        {
            ContactData fromCard = app.Contacts.GetContactInformationFromCard(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            Assert.AreEqual(fromCard.AllData, fromForm.AllData);
        }
    }
}
