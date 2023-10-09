using System.Collections.Generic;

namespace SharedClassesLibrary
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int UserID { get; set; } 
        public List<RentalOrder> RentalOrders { get; set; }

        public Customer()
        {
            RentalOrders = new List<RentalOrder>();
        }

        public Customer(int customerId, string firstName, string lastName, string email, string address, string phoneNumber, int userId)
        {
            CustomerID = customerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            PhoneNumber = phoneNumber;
            UserID = userId; 
            RentalOrders = new List<RentalOrder>();
        }
    }
}

