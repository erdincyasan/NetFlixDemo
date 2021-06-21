using Netflix.DataAccess.Abstract;
using Netflix.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Netflix.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {

        private readonly NetflixDbContext dbContext;
        public UserRepository(NetflixDbContext db)
        {
            dbContext = db;
        }
        public User AddUser(User u)
        {
            dbContext.Users.Add(u);
            dbContext.SaveChanges();
            return u;

        }

        public User CheckMailAndPassword(string mail, string password)
        {
            User u = dbContext.Users.FirstOrDefault(U => U.UserMail == mail && U.UserPasswordHash == password);
            return u;
        }

        public void DeleteUser(Guid id)
        {

            User u = dbContext.Users.Find(id);
            dbContext.Users.Remove(u);
            dbContext.SaveChanges();

        }

        public List<User> GetAllUser()
        {
            return dbContext.Users.ToList();
        }

        public User GetUserByID(Guid id)
        {
            User u = dbContext.Users.Find(id);
            return u;

        }

        public User UpdateUser(User u)
        {

            dbContext.Users.Update(u);
            dbContext.SaveChanges();
            return u;

        }
    }
}
