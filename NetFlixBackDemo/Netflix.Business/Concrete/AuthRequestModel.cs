using System;
using System.Collections.Generic;
using System.Text;

namespace Netflix.Business.Concrete
{
   public  class AuthRequestModel
    {
        public string UserMail { get; set; }
        public string UserPasswordHash { get; set; }
    }
}
