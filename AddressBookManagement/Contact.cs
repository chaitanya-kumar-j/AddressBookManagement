using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookManagement
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
