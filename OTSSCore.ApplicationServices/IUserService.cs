using System.Collections.Generic;
using OTSSCore.Entities;

namespace OTSSCore.ApplicationServices
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUser(int id);
        User CreateUser(string UserName, string password, bool isAdmin);
        User UpdateUser(string UserName, string password, bool isAdmin);
        User DeleteUser(int id);
        List<User> GetFilteredUsers(Filter filter);
    }
}