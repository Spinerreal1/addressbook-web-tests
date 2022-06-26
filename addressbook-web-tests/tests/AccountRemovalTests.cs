using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class AccountRemovalTests : TestBase
    {

        [Test]
        public void AccountRemovalTest()
        {
            app.ContactHelper.Remove(1);
            app.LogoutHelper.Logout();
        }
    }
}
