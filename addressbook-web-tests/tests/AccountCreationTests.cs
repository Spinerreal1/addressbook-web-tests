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
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.AccountHelper.GoToAccountCreationTests();
            AccountCreationData group = new AccountCreationData("aaa", "bbb");
            group.Lastname = "bbb";
            group.Nickname = "ccc";
            app.AccountHelper.FillAccountForm(group);
            app.AccountHelper.SubmitAccountCreation();
            app.AccountHelper.ReturnToHomePage();
            app.LogoutHelper.Logout();
        }
    }
}
