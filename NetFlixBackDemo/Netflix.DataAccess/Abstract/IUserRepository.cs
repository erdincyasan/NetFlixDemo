using Netflix.Entities;
using System;
using System.Collections.Generic;

namespace Netflix.DataAccess.Abstract
{
    public interface IUserRepository
    {
        List<User> GetAllUser();
        User GetUserByID(Guid id);
        User CheckMailAndPassword(string mail, string password);
        User AddUser(User u);
        User UpdateUser(User u);
        void DeleteUser(Guid id);
    }
}
