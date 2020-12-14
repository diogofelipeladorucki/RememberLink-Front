using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hanssens.Net;

namespace RememberLink.localStorage
{
    class UserPersist
    {
        public LocalStorage storage = new LocalStorage();
        public string storageUserToken(string token)
        {
            var key = "tokenUser";
            var value = token;

            storage.Store(key, value);

            storage.Persist();

            return token; 
        }

        public string getTokenUser()
        {
            return storage.Get("tokenUser").ToString();
        }
    }
}
