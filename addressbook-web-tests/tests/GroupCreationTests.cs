﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {

            GroupData group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "ccc";

            app.GroupHelper.Create(group);
            app.LogoutHelper.Logout();
        }
        [Test]
        public void EmptyGroupCreationTest()
        {

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.GroupHelper.Create(group);
            app.LogoutHelper.Logout();
        }
    }
}
