using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {

        [Test]
        public void AccountCreationTest()
        {
            AccountCreationData group = new AccountCreationData("aaa", "bbb");
            group.Lastname = "bbb";
            group.Nickname = "ccc";

            app.ContactHelper.Create(group);
            app.LogoutHelper.Logout();
        }
        [Test]
        public void EmptyAccountCreationTest()
        {
            AccountCreationData group = new AccountCreationData("", "");
            group.Lastname = "";
            group.Nickname = "";

            app.ContactHelper.Create(group);
            app.LogoutHelper.Logout();
        }
    }
}
