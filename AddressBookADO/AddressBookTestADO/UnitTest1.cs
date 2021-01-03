using AddressBookADO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
