using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookADO
{
    public class AddressRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocaldb;Initial Catalog=AddressBook;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        public void CheckConnection()
        {
            try
            {
                this.sqlConnection.Open();
                Console.WriteLine("Connection Established");
                this.sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
