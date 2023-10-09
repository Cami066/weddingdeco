namespace SharedClassesLibrary;

public class User
{
    public int UserID { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }
    public int UserRole { get; set; }

    public User(int userId, string email, string passwordHash, string salt, int userRole)
    {
        UserID = userId;
        Email = email;
        PasswordHash = passwordHash;
        Salt = salt;
        UserRole = userRole;
    }

    public User()
    {
    }
}

