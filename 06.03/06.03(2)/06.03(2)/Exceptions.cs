using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListNamespace
{
    public class WrongElementPositionException : ApplicationException
    {
        public WrongElementPositionException()
        {
        }

        public WrongElementPositionException(string message)
            : base(message)
        {
        }
    }

    public class AlreadyAddedElementAddingException : ApplicationException
    {
        public AlreadyAddedElementAddingException()
        {
        }

        public AlreadyAddedElementAddingException(string message)
            : base(message)
        {
        }
    }
}
