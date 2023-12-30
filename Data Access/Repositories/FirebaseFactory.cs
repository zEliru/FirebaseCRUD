using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire.Data_Access.Repositories
{
    public class FirebaseFactory
    {
        public static IFirebaseRepository CreateFirebaseRepository()
        {
            return new FirebaseRepository();
        }
    }
}
