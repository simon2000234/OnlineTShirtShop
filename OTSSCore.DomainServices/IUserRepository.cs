using System.Collections.Generic;
using OTSSCore.Entities;

namespace OTSSCore.DomainServices
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUser(int id);
        User CreateUser(User user);
        User UpdateUser(User user);
        User DeleteUser(int id);
    }
}