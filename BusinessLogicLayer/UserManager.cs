using System.Security.Cryptography;
using System.Text;
using SharedClassesLibrary;
using DataAccessLayer;
using static SharedClassesLibrary.EnumUserRole;

namespace BusinessLogicLayer;

public class UserManager
{
    private readonly IUserRepository _userRepository;
    private readonly ICustomerRepository _customerRepository;

    public UserManager(IUserRepository userRepository, ICustomerRepository customerRepository)
    {
        _userRepository = userRepository;
        _customerRepository = customerRepository;
    }

    public string RegisterUser(string firstName, string lastName, string email, string plainTextPassword, string phoneNumber, string address)
    {
        if (_userRepository.DoesEmailExist(email))
        {
            return "Email is already registered.";
        }

        string salt = GenerateSalt();
        string passwordHash = HashPassword(plainTextPassword, salt);

        User newUser = new User
        {
            Email = email,
            PasswordHash = passwordHash,
            Salt = salt,
            UserRole = (int)UserRole.Customer
        };

        int userId = _userRepository.RegisterUser(newUser);

        if (userId > 0)
        {
            Customer newCustomer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address,
                UserID = userId
            };

            _customerRepository.RegisterCustomer(newCustomer);

            return "Registration successful!";
        }
        else
        {
            return "Registration failed. Please try again later.";
        }
    }




    public User AuthenticateUser(string email, string password)
    {
        User user = _userRepository.GetUserByEmail(email);

        if (user == null)
        {
            return null;
        }

        string hashedPassword = HashPassword(password, user.Salt);

        if (user.PasswordHash == hashedPassword)
        {
            return user;
        }

        return null;
    }



    private string GenerateSalt()
    {
        byte[] saltBytes = new byte[16];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(saltBytes);
        }
        return Convert.ToBase64String(saltBytes);
    }


    private string HashPassword(string password, string salt)
    {
        if (salt == null)
        {
            throw new ArgumentNullException(nameof(salt), "Salt cannot be null.");
        }

        using (var sha256 = SHA256.Create())
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] combinedBytes = new byte[saltBytes.Length + passwordBytes.Length];
            saltBytes.CopyTo(combinedBytes, 0);
            passwordBytes.CopyTo(combinedBytes, saltBytes.Length);

            byte[] hashBytes = sha256.ComputeHash(combinedBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }



    public void RegisterCustomerUser(string firstName, string lastName, string email, string plainTextPassword, string phoneNumber, string address)
    {
        string salt = GenerateSalt();
        string passwordHash = HashPassword(plainTextPassword, salt);

        User newUser = new User
        {
            Email = email,
            PasswordHash = passwordHash,
            Salt = salt,
            UserRole = (int)UserRole.Customer
        };

        int userId = _userRepository.RegisterUser(newUser);

        Customer newCustomer = new Customer
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber,
            Address = address,
            UserID = userId 
        };

        _customerRepository.RegisterCustomer(newCustomer);
    }
}