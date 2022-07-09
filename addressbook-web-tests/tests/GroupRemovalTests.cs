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
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();

            app.Navigator.GoToGroupsPage();
            app.GroupHelper.CreateGroupIfElementPresent();
            app.GroupHelper.Remove(0);


            List<GroupData> newGroups = app.GroupHelper.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
