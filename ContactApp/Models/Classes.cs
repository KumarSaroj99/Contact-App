using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace ContactApp.Models
{

    class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; } = true;
        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }

    class Contact
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; } = true;
        public List<ContactDetails> ContactDetails { get; set; } = new List<ContactDetails>();
    }

    class ContactDetails
    {
        public int ContactDetailsID { get; set; }
        public string Type { get; set; } // e.g., "Phone", "Email"
        public string Number { get; set; }
        public bool IsActive { get; set; } = true;
    }

}
