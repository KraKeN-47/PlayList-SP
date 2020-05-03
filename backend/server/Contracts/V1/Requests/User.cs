using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Contracts.V1.Requests
{
    public class User
    {
        string Email { get; set; }
        public User(string EMAIL)
        {
            this.Email = EMAIL;
        }
    }
}
