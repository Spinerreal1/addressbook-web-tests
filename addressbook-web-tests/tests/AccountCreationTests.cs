using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;




namespace addressbook_web_tests
{
    [TestFixture]
    public class AccountCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    MIddleName = (GenerateRandomString(10)),
                    Address = (GenerateRandomString(50)),
                    Mobile = (GenerateRandomString(11)),
                    Home = (GenerateRandomString(11)),
                    Email = (GenerateRandomString(20)),
                    Title = (GenerateRandomString(10)),
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
            File.ReadAllText(@"contacts.json"));
        }
        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                    .Deserialize(new StreamReader(@"contacts.xml"));
        }

        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void AccountCreationTest(ContactData group)
        {
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
