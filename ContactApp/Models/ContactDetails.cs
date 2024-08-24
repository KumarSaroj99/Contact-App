using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    internal class ContactDetails
    {
        public int ContactDetailsID { get; set; }
        public string Type { get; set; } // e.g., "Phone", "Email"
        public string Number { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
