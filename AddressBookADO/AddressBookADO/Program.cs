﻿using System;

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
            /*Add.first_name = "Pratibha";
            Add.last_name = "Karande";
            Add.address = "Seawoods";
            Add.city = "Mumbai";
            Add.state = "Maharashtra";
            Add.zip = "400701";
            Add.phone_number = "9987936149";
            Add.addressBook_Name = "ABNameFriend";
            Add.addressBook_Type = "Friend";*/
            // Repo.AddContacts(Add);
            // Console.WriteLine("**********Inserted Record**********");
            // Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", Add.first_name, Add.last_name, Add.address, Add.city, Add.state, Add.zip, Add.phone_number, Add.addressBook_Name, Add.addressBook_Type);
            // Repo.EditRecordUsingName(Add);
            // Add.first_name = "Pratibha";
            // Repo.DeleteContact(Add);
            // Repo.RetriveRecord();
            //Repo.CountByCityState();
            //Repo.SortRecord();
            //Repo.CountByPerson();
            /* int count =  Repo.RetriveAllRecord();
             Console.WriteLine(count);
 */
            /*Add.last_name = "rane";
            Add.first_name = "Nilesh";
           string name = Repo.UpdateContact(Add);*/

            int count = Repo.getEmployeeDataWithGivenRange();
            Console.WriteLine(count);

            /*int count = Repo.RetrivePersonsBelongingCityOrState();
            Console.WriteLine(count);*/
            /*Add.addressBook_id = 103;
            Add.first_name = "Pratibha";
            Add.last_name = "Mastud";
            Add.address = "Seawoods";
            Add.city = "Mumbai";
            Add.state = "Maharashtra";
            Add.zip = 400701;
            Add.phone_number = "9676736149";
            Add.addressBook_Name = "ABNameFriend";
            Add.addressBook_Type = "Family";
            Add.address_id = 103;
            bool count = Repo.AddNewContacts(Add);
            Console.WriteLine(count);*/
        }
    }
}
