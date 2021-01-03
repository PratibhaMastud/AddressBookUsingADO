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
    }
}
