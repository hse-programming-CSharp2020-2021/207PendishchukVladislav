using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class UserInfo
    {
        public string UserName { get; set; }

        public string EMail { get; set; }

        public int ID { get; set; }

        public UserInfo(string userName, string eMail, int id)
        {
            UserName = userName;
            EMail = eMail;
            ID = id;
        }
    }
}
