using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RememberLink.Models
{
    class requestCreateAccount
    {
        public string nameclient { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }

    class responseCreateAccount
    {
        public string msg { get; set; }
        public string code { get; set; }

    }
}
