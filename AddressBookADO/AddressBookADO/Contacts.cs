using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookADO
{
    public class Contacts
    {
        public int contact_id { get; set; }
        public int address_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_number { get; set; }
        public string contact_name { get; set; }
    }
}
