using System.Collections.Generic;
using System.IO;
using OTSSCore.DomainServices;
using OTSSCore.Entities;

namespace OTSSCore.ApplicationServices.Impl
{
    public class UserService: IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers(null);
        }

        public User GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }

        public User CreateUser(UserLogin userLogin)
        {
            byte[] passwordSalt, passwordHash;
            CreatePasswordHash(userLogin.Password, out passwordHash, out passwordSalt);
            User user = new User()
            {
                IsAdmin = userLogin.IsAdmin,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Username = userLogin.Username
            };
            return _userRepository.CreateUser(user);

        }

        public User UpdateUser(UserLogin userLogin)
        {
            byte[] passwordSalt, passwordHash;
            CreatePasswordHash(userLogin.Password, out passwordHash, out passwordSalt);
            User user = new User()
            {
                Id = userLogin.Id,
                IsAdmin = userLogin.IsAdmin,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Username = userLogin.Username
            };
            return _userRepository.UpdateUser(user);

        }

        public User DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        public List<User> GetFilteredUsers(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("Current page and items pr page must be more than 0 or 0");
            }

            if ((filter.CurrentPage - 1) * filter.ItemsPrPage >= _userRepository.Count())
            {
                throw new InvalidDataException("Index out of bound to high page");
            }
            return _userRepository.GetAllUsers(filter);
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}