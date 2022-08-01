using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string allPhones;
        public string allEmails;
        public String allData;
        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public ContactData(string allData)
        {
            this.allData = allData;
        }

        public bool Equals(ContactData other)
        {
            if (other is null)
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))

            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }
        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }
        public override string ToString()
        {
            return "Firstname = " + FirstName + ", Lastname = " + LastName;
        }
        public int CompareTo(ContactData other)
        {
            if (other.FirstName is null && other.LastName is null)
            {
                return 1;   
            }
            if (this.FirstName != other.FirstName)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            if (this.LastName != other.LastName)
            {
                return LastName.CompareTo(other.LastName);
            }
            return 0;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MIddleName { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; } 
        public string Work { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string Id { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work) + CleanUp(Fax)).Trim();
                }

            }
            set
            {
                allPhones = value;
            }
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (NewEmail(Email) + NewEmail(Email2) + NewEmail(Email3)).Trim();
                }

            }
            set
            {
                allEmails = value;
            }
        }
        private string NewEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }
        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ \\-()]", "") + "\r\n";
        }
        public string AllData
        {
            get
            {
                if (allData != null)
                {
                    return allData;
                }
                else
                {
                    string s = "";
                    string s1 = "";
                    string s2 = "";
                    string s3 = "";
                    string s4 = "";
                    string p1 = "";
                    string p2 = "";
                    string p3 = "";

                    if (FirstName != "")
                    {
                        s = FirstName;
                    }
                    if (LastName != "")
                    {
                        s1 = " " + LastName + "\r\n";
                    }
                    if (Address != "")
                    {
                        s2 = Address + "\r\n";
                    }
                    if (Home != "")
                    {
                        p1 = "H: " + Home + "\r\n";
                    }
                    if (Mobile != "")
                    {
                        p2 = "M: " + Mobile + "\r\n";
                    }
                    if (Work != "")
                    {
                        p3 = "W: " + Work;
                    }
                    if (AllPhones != "")
                    {
                        s3 = "\r\n" + p1 + p2 + p3 + "\r\n";
                    }
                    if (AllEmails != "")
                    {
                        s4 = AllEmails + " \r\n\r\n";
                    }
                    if (s + s1 + s2 + s3 + s4 == "")
                    {
                        return " \r\n\r\n";
                    }
                    else
                    {
                        if (AllEmails != "" && AllPhones != "")
                        {
                            return s + s1 + s2 + s3 + "\r\n" + s4;
                        }
                    }
                    return s + s1 + s2 + s3 + s4;
                }
            }
            set
            {
                allData = value;
            }
        }
    }
    }

