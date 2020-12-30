using System;

namespace AddressBookADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome in Address Book ADO");
            AddressRepo Repo = new AddressRepo();
            Repo.CheckConnection();
        }
    }
}
