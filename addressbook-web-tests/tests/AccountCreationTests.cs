using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

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
            app.AccountHelper
                .GoToAccountCreationTests()
                .FillAccountForm(group)
                .SubmitAccountCreation()
                .ReturnToHomePage();
            app.LogoutHelper.Logout();
        }
    }
}
