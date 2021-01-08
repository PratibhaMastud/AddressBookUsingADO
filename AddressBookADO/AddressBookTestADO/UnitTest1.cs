using AddressBookADO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AddressBookTestADO
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Retrieve Contacts from database and match number of counts of rows
        /// </summary>
        [TestMethod]
        public void GivenQuery_WhenRetrieve_ShouldReturnNumberOfRowsRetrieved()
        {
            int expectedResult = 5;
            AddressRepo addressRepo = new AddressRepo();
            int result = addressRepo.RetriveAllRecord();
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Givens the address book when enter last name then should update contact in address book.
        /// </summary>
        [TestMethod]
        public void GivenAddressBooks_WhenEnterLastName_ThenShouldUpdateContactInAddressBook()
        {
            string expectedResult = "Nilesh";
            AddressRepo addressRepo = new AddressRepo();
            AddressBookModel model = new AddressBookModel()
            {
                last_name = "rane",
                first_name = "Nilesh"
             };
            string firstName = addressRepo.UpdateContact(model);
            Assert.AreEqual(expectedResult, firstName);
        }

        /// <summary>
        /// Get count of employee from perticular range
        /// </summary>
        [TestMethod]
        public void GivenQuery_whenCount_ShouldReturnCount()
        {
            int expectedResult = 3;
            AddressRepo addressRepo = new AddressRepo();
            int result = addressRepo.getEmployeeDataWithGivenRange();
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Givens the address book when city or state then should return count address book data base.
        /// </summary>
        [TestMethod]
        public void GivenAddressBook_WhenCityOrState_ThenShouldReturnCountoFContactsInAddressBookDataBase()
        {
            int expected = 2;
            AddressRepo addressRepo = new AddressRepo();
            int numberofContacts = addressRepo.RetrivePersonsBelongingCityOrState();
            Assert.AreEqual(expected, numberofContacts);
        }

        /// <summary>
        /// Givens the add New Contact in address book.
        /// </summary>
        [TestMethod]
        public void GivenAddressBook_WhenAddNewContact_ThenShouldReturnTrueAddressBookDataBase()
        {
            bool expected = true;
            AddressRepo addressRepo = new AddressRepo();
            AddressBookModel Add = new AddressBookModel();
            Add.first_name = "Mahesheshwer";
            Add.last_name = "Ande";
            Add.address = "Seawoods";
            Add.city = "Mumbai";
            Add.state = "Maharashtra";
            Add.zip = 400701;
            Add.phone_number = "9744936149";
            Add.addressBook_Name = "ABNameFriend";
            Add.addressBook_Type = "Friend";
            Add.address_id = 106;
            bool result = addressRepo.AddNewContacts(Add);
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        ///Ability to Insert new Contact to the database and compute time required for insertion
        /// </summary>
        [TestMethod]
        public void GivenQuery_WhenInsert_ShouldAddNewContactToDBAndComputeTimeRequired()
        {
            AddressRepo database = new AddressRepo();
            AddressBookModel model = new AddressBookModel()
            {
                first_name = "esheshwer",
                last_name = "Ande",
                address = "Seawoods",
                city = "Mumbai",
                state = "Maharashtra",
                zip = 400701,
                phone_number = "9744936149",
                addressBook_Name = "ABNameFriend",
                addressBook_Type = "Friend",
                address_id = 105,
            };
            DateTime startTime = DateTime.Now;
            database.AddNewContacts(model);
            DateTime stopTime = DateTime.Now;
            Console.WriteLine("Duration taken for insertion is {0}", (stopTime - startTime));
        }
    }
}
