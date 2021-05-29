using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class CreateUserRequest
    {
        public string UserName { get; set; }

        public string EMail { get; set; }
    }
}
