using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class AccountCreationData : IEquatable<AccountCreationData>, IComparable<AccountCreationData>
    {

        public AccountCreationData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }


        public bool Equals(AccountCreationData other)
        {
            if (Object.ReferenceEquals(other, null))
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
            return $"firstname = {FirstName} and LastName = {LastName}";
        }
        public int CompareTo(AccountCreationData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;   
            }
            return this.ToString().CompareTo(other.ToString());
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
    }
    }

