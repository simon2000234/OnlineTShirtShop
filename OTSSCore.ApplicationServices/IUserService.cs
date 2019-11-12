using System.Collections.Generic;
using OTSSCore.Entities;

namespace OTSSCore.ApplicationServices
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUser(int id);
        User CreateUser(UserLogin userlogin);
        User UpdateUser(UserLogin userlogin);
        User DeleteUser(int id);
        List<User> GetFilteredUsers(Filter filter);
    }
}