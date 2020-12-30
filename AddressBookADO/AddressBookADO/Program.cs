using System;

namespace AddressBookADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome in Address Book ADO");
            AddressRepo Repo = new AddressRepo();
          //  Repo.CheckConnection();
            AddressBookModel Add = new AddressBookModel();
            Add.first_name = "Pratibha";
            Add.last_name = "Karande";
            Add.address = "Seawoods";
            Add.city = "Mumbai";
            Add.state = "Maharashtra";
            Add.zip = "400701";
            Add.phone_number = "9987936149";
            Add.addressBook_Name = "ABNameFriend";
            Add.addressBook_Type = "Friend";
         //  Repo.AddContacts(Add);
            Console.WriteLine("**********Inserted Record**********");
            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", Add.first_name, Add.last_name, Add.address, Add.city, Add.state, Add.zip, Add.phone_number, Add.addressBook_Name, Add.addressBook_Type);
            Repo.EditRecordUsingName(Add);
        }
    }
}
