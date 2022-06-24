﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
        public class ApplicationManager
     {

        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected LogoutHelper logoutHelper;

        public ApplicationManager() 
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
            loginHelper = new LoginHelper(driver);
            logoutHelper = new LogoutHelper(driver);
            navigator = new NavigationHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver);
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public LoginHelper Auth 
        {
            get 
            {
                return loginHelper;
            }
        }
        public NavigationHelper Navigator 
        {
            get
            {
                return navigator;
            }
        }
        public GroupHelper GroupHelper
        {
            get 
            {
                return groupHelper; 
            }
        }
        public LogoutHelper LogoutHelper 
        {
            get 
            {
                return logoutHelper;
            }
        }
    }
}
