using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeNamespace
{
    [Serializable]
    public class DivisionByZeroException : ApplicationException
    {
        public DivisionByZeroException() 
        {
        }
        public DivisionByZeroException(string message) 
            : base(message)
        { 
        }
    }
}
