﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    class AccountCreationData
    {
        private string firstname;
        private string middlename;
        private string lastname = "";
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string bday = "";
        private string bmonth = "";
        private string byear = "";
        private string aday = "";
        private string amonth = "";
        private string ayear = "";
        private string new_group = "";
        private string address2 = "";
        private string phone2 = "";
        private string notes = "";



        public AccountCreationData(string firstname, string middlename)
        { 
            this.firstname = firstname;
            this.middlename = middlename;
        }
        public string Firstname 
        {
            get 
            {
                return firstname;
            }
            set 
            {
                firstname = value;
            }
        }
        public string MIddlename 
        {
            get {
                return middlename;
            }
            set 
            {
                middlename = value;
            }
        }
        public string Lastname 
        {
            get 
            {
                return lastname;
            }
            set 
            {
                lastname = value;
            }
        }
        public string Nickname 
        {
            get 
            {
                return nickname;
            }
            set 
            {
                nickname = value;
            }
        }
        public string Title
        {
            get 
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string Company 
        {
            get 
            {
                return company;
            }
            set 
            {
                company = value;
            }
        }
        public string Address 
        {
            get 
            {
                return address;
            }
            set 
            {
                address = value;
            }
        }



    }
    }

