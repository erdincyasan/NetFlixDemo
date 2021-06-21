using System;
using System.Collections.Generic;

namespace Netflix.Entities
{
    public class User
    {


        public Guid UserID { get; set; }

        public string UserName { get; set; }

        public string UserSurName { get; set; }

        public string UserMail { get; set; }

        public string UserPhone { get; set; }

        public string UserPasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserToken { get; set; }
        public List<Category> Categories { get; set; }

    }
}
