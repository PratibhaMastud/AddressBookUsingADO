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

        public void EditRecordUsingName(AddressBookModel Model)
        {
            try
            {
                using (this.sqlConnection)
                {
                    string editQuery = @"Update address_bookDB set last_name= @last_name, address = @address,city = @city, state = @state, zip=@zip, phone_number=@phone_number , addressBook_Name = @addressBook_Name, addressBook_Type = @addressBook_Type WHERE first_name = @first_name;";
                    SqlCommand CMD = new SqlCommand(editQuery, this.sqlConnection);
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
                    Console.WriteLine("Updated Success......");
                    this.sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteContact(AddressBookModel Model)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand CMD = new SqlCommand("sp_deleteRecord", this.sqlConnection);
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.Parameters.AddWithValue("@first_name", Model.first_name);
                    this.sqlConnection.Open();
                    CMD.ExecuteNonQuery();
                    Console.WriteLine("Contact Deleted Success...");
                    this.sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void RetriveRecord()
        {
            try
            {
                AddressBookModel model = new AddressBookModel();
                using (this.sqlConnection)
                {
                    using (SqlCommand fetch = new SqlCommand(@"Select * from address_bookDB ", this.sqlConnection))
                    {
                        this.sqlConnection.Open();
                        using (SqlDataReader reader = fetch.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.first_name = reader.GetString(0);
                                model.last_name = reader.GetString(1);
                                model.address = reader.GetString(2);
                                model.city = reader.GetString(3);
                                model.state = reader.GetString(4);
                                model.zip = reader.GetInt32(5);
                                model.phone_number = reader.GetString(6);
                                model.addressBook_Name = reader.GetString(7);
                                model.addressBook_Name = reader.GetString(8);
                                Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", model.first_name, model.last_name, model.address, model.city, model.state, model.zip, model.phone_number, model.addressBook_Name, model.addressBook_Type);
                                Console.WriteLine("\n");
                            }
                        }
                    }
                    this.sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void CountByCityState()
        {
            try
            {
                using (this.sqlConnection)
                {
                    using (SqlCommand CMD = new SqlCommand(@"select COUNT(first_name) from address_bookDB WHERE city='Mumbai' AND  state='maharashtra';", this.sqlConnection))
                    {
                        this.sqlConnection.Open();
                        using (SqlDataReader reader = CMD.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var counts = reader.GetInt32(0);
                                Console.WriteLine("Number of person belongs City'Mumbai' and state 'Maharashtra':{0} ", counts);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
