using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class AccountModificationTests : AuthTestBase
    {
        [Test]
        public void AccountModificationTest()
        {
            AccountCreationData newData = new AccountCreationData("zzz", "xxxx");
            newData.Lastname = "3333";
            newData.Nickname = "4444";

            app.ContactHelper.CreateContactIfElementPresent();
            app.ContactHelper.Modify(1, newData);
        }

    }
}
