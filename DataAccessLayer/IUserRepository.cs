using System;
using SharedClassesLibrary;

namespace DataAccessLayer
{
	public interface IUserRepository
	{
        int RegisterUser(User user);
        User GetUserByEmail(string email);
        bool DoesEmailExist(string email);

    }
}

