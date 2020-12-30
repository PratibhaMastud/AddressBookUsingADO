using System;
using System.Collections.Generic;
using System.Data;
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

        public bool AddContacts(AddressBookModel Model)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand CMD = new SqlCommand("SpAddAddressBook", this.sqlConnection);
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.Parameters.AddWithValue("@first_name", Model.first_name);
                    CMD.Parameters.AddWithValue("@last_name", Model.last_name);
                    CMD.Parameters.AddWithValue("@address", Model.address);
                    CMD.Parameters.AddWithValue("@city", Model.city);
                    CMD.Parameters.AddWithValue("@state", Model.state);
                    CMD.Parameters.AddWithValue("@zip", Model.zip);
                    CMD.Parameters.AddWithValue("@phone_number", Model.phone_number);
                    CMD.Parameters.AddWithValue("@addressBook_Name", Model.addressBook_Name);
                    CMD.Parameters.AddWithValue("@addressBook_Type", Model.addressBook_Type);
                    this.sqlConnection.Open();
                    var result = CMD.ExecuteNonQuery();
                    this.sqlConnection.Close();
                    if (result != 0)
                    {
                        return false;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
