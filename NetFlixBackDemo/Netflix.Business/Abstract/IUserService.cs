using Netflix.Entities;
using System;
using System.Collections.Generic;

namespace Netflix.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAllUser();
        User GetUserByID(Guid UserID);
        User AddUser(User u);
        User UpdateUser(User u);
        User CheckMailAndPassword(string mail, string password);
        void DeleteUser(Guid UserID);
    }
}
