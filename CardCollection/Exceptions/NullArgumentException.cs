using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Exceptions
{
    public class NullArgumentException : Exception
    {
        public NullArgumentException(string msg) : base(msg)
        {

        }

        public NullArgumentException(string msg, Exception ex) : base(msg, ex)
        {

        }
    }
}
