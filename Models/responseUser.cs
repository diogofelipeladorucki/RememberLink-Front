using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RememberLink.Models
{
    public class User
    {
        public int erased { get; set; }
        public string _id { get; set; }
        public string nameclient { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int __v { get; set; }
    }

    public class DataUser
    {
        public string userId { get; set; }
        public User user { get; set; }
    }

    public class UserResponse
    {
        public string token { get; set; }
        public DataUser dataUser { get; set; }
    }


}
