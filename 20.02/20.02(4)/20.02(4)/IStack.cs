using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackNamespace
{
    interface IStack
    {
        void push(int element);

        int pop();
    }
}
