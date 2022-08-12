using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];

            app.GroupHelper.Remove(toBeRemoved);

            app.Navigator.GoToGroupsPage();
            app.GroupHelper.CreateGroupIfElementNotPresent();
            
            List<GroupData> newGroups = GroupData.GetAll();
           
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {   
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
