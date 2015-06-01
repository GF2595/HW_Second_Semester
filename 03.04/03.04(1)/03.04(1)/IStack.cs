using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStackNamespace
{
    /// <summary>
    /// IStack interface
    /// </summary>
    /// <typeparam name="T">Stack elements type</typeparam>
    public interface IStack<T>
    {
        void Push(T element);

        T Pop();
    }
}
