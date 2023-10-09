using System;
namespace SharedClassesLibrary
{

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }

        public Employee(int employeeId, string firstName, string lastName, string email, string jobTitle)
        {
            EmployeeID = employeeId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            JobTitle = jobTitle;
        }
    }
}
