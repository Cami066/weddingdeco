using System;
using SharedClassesLibrary;
using System.Data.SqlClient;
using static SharedClassesLibrary.EnumUserRole;
using System.Text;
using System.Security.Cryptography;


namespace DataAccessLayer
{
    public class UserRepository : DataAccess, IUserRepository
    {

        public int RegisterUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO [User] (Email, PasswordHash, UserRole) VALUES (@Email, @PasswordHash, @UserRole); SELECT SCOPE_IDENTITY()";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                command.Parameters.AddWithValue("@UserRole", user.UserRole);

                int newUserId = Convert.ToInt32(command.ExecuteScalar());

                return newUserId;
            }
        }

        public bool DoesEmailExist(string email)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM [User] WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }



        public User GetUserByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM [User] WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string salt = reader["Salt"] is DBNull ? null : (string)reader["Salt"];

                        return new User(
                            (int)reader["UserID"],
                            (string)reader["Email"],
                            (string)reader["PasswordHash"],
                            salt, 
                            (int)(UserRole)reader["UserRole"]
                        );
                    }
                }
            }

            return null;
        }
    }
}