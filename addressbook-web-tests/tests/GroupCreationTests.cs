﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {

        [Test]
        public void GroupCreationTest()
        {

            GroupData group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "ccc";

            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();

            app.GroupHelper.Create(group);

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);

        }
        [Test]
        public void EmptyGroupCreationTest()
        {

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();

            app.GroupHelper.Create(group);

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {

            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();

            app.GroupHelper.Create(group);

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}
