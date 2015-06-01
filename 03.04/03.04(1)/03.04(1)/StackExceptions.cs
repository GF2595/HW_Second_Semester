using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStackNamespace
{
    public class EmptyStackPopException : ApplicationException
    {
        public EmptyStackPopException()
        {
        }

        public EmptyStackPopException(string message)
            : base(message)
        {
        }
    }
}
