using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupsPage();
            app.GroupHelper.CreateGroupIfElementPresent();
            app.GroupHelper.Remove(1);
        }
    }
}
