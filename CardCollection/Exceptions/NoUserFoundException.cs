using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Exceptions
{
    public class NoUserFoundException : Exception
    {

        public NoUserFoundException(string msg) : base(msg)
        {

        }

        public NoUserFoundException(string msg, Exception ex) : base(msg, ex)
        {

        }
    }
}
