using SharedClassesLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RentalItemRepository : DataAccess, IRentalItemRepository
    {

        public List<RentalItemDTO> GetAllRentalItems(string category)
        {
            List<RentalItemDTO> rentalItems = new List<RentalItemDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM RentalItem";
                    if (!string.IsNullOrEmpty(category))
                    {
                        query += $" WHERE Category = @Category";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(category))
                        {
                            command.Parameters.AddWithValue("@Category", category);
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RentalItemDTO rentalItem = new RentalItemDTO
                                {
                                    ItemID = reader.GetInt32(reader.GetOrdinal("ItemID")),
                                    Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? null : reader.GetString(reader.GetOrdinal("Name")),
                                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                                    RentalPrice = reader.IsDBNull(reader.GetOrdinal("RentalPrice")) ? 0 : reader.GetDecimal(reader.GetOrdinal("RentalPrice")),
                                    Category = reader.IsDBNull(reader.GetOrdinal("Category")) ? null : reader.GetString(reader.GetOrdinal("Category")),
                                    Availability = reader.IsDBNull(reader.GetOrdinal("Availability")) ? false : reader.GetBoolean(reader.GetOrdinal("Availability")),
                                    ImageUrl = reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? null : reader.GetString(reader.GetOrdinal("ImageUrl")),
                                };

                                rentalItems.Add(rentalItem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving rental items: " + ex.Message);
            }

            return rentalItems;
        }



        public List<string> GetAllCategories()
        {
            List<string> categories = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT DISTINCT Category FROM RentalItem"; 

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string category = reader.IsDBNull(reader.GetOrdinal("Category")) ? null : reader.GetString(reader.GetOrdinal("Category"));
                                if (!string.IsNullOrEmpty(category))
                                {
                                    categories.Add(category);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving categories: " + ex.Message);
            }

            return categories;
        }

        public RentalItemDTO GetRentalItemById(int itemId)
        {
            RentalItemDTO rentalItem = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM RentalItem WHERE ItemID = @ItemID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemID", itemId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                rentalItem = new RentalItemDTO
                                {
                                    ItemID = reader.GetInt32(reader.GetOrdinal("ItemID")),
                                    Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? null : reader.GetString(reader.GetOrdinal("Name")),
                                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                                    RentalPrice = reader.IsDBNull(reader.GetOrdinal("RentalPrice")) ? 0 : reader.GetDecimal(reader.GetOrdinal("RentalPrice")),
                                    Category = reader.IsDBNull(reader.GetOrdinal("Category")) ? null : reader.GetString(reader.GetOrdinal("Category")),
                                    Availability = reader.IsDBNull(reader.GetOrdinal("Availability")) ? false : reader.GetBoolean(reader.GetOrdinal("Availability")),
                                    ImageUrl = reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? null : reader.GetString(reader.GetOrdinal("ImageUrl")),
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving rental item by ID: " + ex.Message);
            }

            return rentalItem;
        }

        public List<RentalOrder> GetRentalOrdersByItemId(int itemId)
        {
            List<RentalOrder> rentalOrders = new List<RentalOrder>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM RentalOrder WHERE ItemID = @ItemID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemID", itemId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RentalOrder rentalOrder = new RentalOrder
                                {
                                    RentalOrderID = reader.GetInt32(reader.GetOrdinal("RentalOrderID")),
                                    CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                                    RentalStartDate = reader.GetDateTime(reader.GetOrdinal("RentalStartDate")),
                                    RentalEndDate = reader.GetDateTime(reader.GetOrdinal("RentalEndDate")),
                                    TotalCost = reader.GetDecimal(reader.GetOrdinal("TotalCost")),
                                    Status = (OrderStatus)reader.GetInt32(reader.GetOrdinal("Status")),
                                    Payment = new Payment
                                    {
                                    },
                                    RentalItems = new List<RentalOrderItem>()
                                };

                                rentalOrders.Add(rentalOrder);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving rental orders by item ID: " + ex.Message);
            }

            return rentalOrders;
        }
    }
}