﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest() 
        {
            GroupData newData = new GroupData("zzz");
            newData.Header = "lll";
            newData.Footer = "www";
            app.GroupHelper.Modify(1, newData);
            app.LogoutHelper.Logout();
        }

    }
}
