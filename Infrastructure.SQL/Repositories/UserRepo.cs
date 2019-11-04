using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OTSSCore.DomainServices;
using OTSSCore.Entities;

namespace Infrastructure.SQL.Repositories
{
    public class UserRepo : IUserRepository
    {
        private OTSSContext _context;

        public UserRepo(OTSSContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUser(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User CreateUser(User user)
        {
            _context.Attach(user).State = EntityState.Added;
            _context.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            _context.Attach(user).State = EntityState.Modified;
            _context.SaveChanges();
            return user;
        }

        public User DeleteUser(int id)
        {
            var user = _context.Remove(new User { Id = id }).Entity;
            _context.SaveChanges();
            return user;
        }
    }
}