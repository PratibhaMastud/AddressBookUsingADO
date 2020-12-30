using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookADO
{
    public class AddressBookModel
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone_number { get; set; }
        public string addressBook_Name { get; set; }
        public string addressBook_Type { get; set; }
    }
}
