using Netflix.Business.Abstract;
using Netflix.DataAccess.Abstract;
using Netflix.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Netflix.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository rp)
        {
            _userRepository = rp;
        }
        public User AddUser(User u)
        {
            u.UserID = Guid.NewGuid();
            u.CreatedAt = DateTime.Now;



            SHA1 sh = new SHA1CryptoServiceProvider();

            string userPasswordHashed = Convert.ToBase64String(sh.ComputeHash(Encoding.UTF8.GetBytes(u.UserPasswordHash)));
            u.UserPasswordHash = userPasswordHashed;
            return _userRepository.AddUser(u);
        }

        public User CheckMailAndPassword(string mail, string password)
        {
            SHA1 sh = new SHA1CryptoServiceProvider();

            string userPasswordHashed = Convert.ToBase64String(sh.ComputeHash(Encoding.UTF8.GetBytes(password)));
            User u = _userRepository.CheckMailAndPassword(mail, userPasswordHashed);

            return u;

        }

        public void DeleteUser(Guid UserID)
        {
            _userRepository.DeleteUser(UserID);
        }

        public List<User> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }


        public User GetUserByID(Guid UserID)
        {
            return _userRepository.GetUserByID(UserID);
        }

        public User UpdateUser(User u)
        {
            return _userRepository.UpdateUser(u);
        }
    }
}
