using Fire.Data_Access.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire.Domain
{
    public class FirebaseDomainFactory
    {
        public static IFirebaseDomain CreateFirebaseDomain()
        {
            return new FirebaseDomain();
        }
    }
}
