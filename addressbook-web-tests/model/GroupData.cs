using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class GroupData
    {
        private string name;
        private string header = "";
        private string footer = "";
        public GroupData(string name)
        {
            this.name = name;
        }

        public GroupData(string name, string v1, string v2) : this(name)
        {
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }


        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
            }

        }
        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                header = value;
            }

        }
    }
}
