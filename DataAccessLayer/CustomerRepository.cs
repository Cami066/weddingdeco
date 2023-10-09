using System;
using SharedClassesLibrary;
using System.Data.SqlClient;

namespace DataAccessLayer
{

    public class CustomerRepository : DataAccess, ICustomerRepository
    {
        public void RegisterCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO [Customer] (FirstName, LastName, Email, Address, PhoneNumber, UserID) " +
                               "VALUES (@FirstName, @LastName, @Email, @Address, @PhoneNumber, @UserID)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                command.Parameters.AddWithValue("@LastName", customer.LastName);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.Parameters.AddWithValue("@Address", customer.Address);
                command.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                command.Parameters.AddWithValue("@UserID", customer.UserID);

                command.ExecuteNonQuery(); 
            }
        }
    }
}