using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public class UsersService : IUsersService
    {
        public string CreateUser(string username, string email, string password)
        {
            throw new NotImplementedException();
        }

        public string GetUserId(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool IsEmailAvailable(string email)
        {
            throw new NotImplementedException();
        }

        public bool IsUsernameAvailable(string username)
        {
            throw new NotImplementedException();
        }
    }
}
