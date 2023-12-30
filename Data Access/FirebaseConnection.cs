using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire.Data_Access
{
    static class FirebaseConnection
    {
        public static FirebaseClient GetFirebaseClient(string url, string secret = null)
        {
            //No s'utilitza secret xd
            return new FirebaseClient(url);
        }
    }
}
