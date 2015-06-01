using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListNamespace;

namespace StackNamespace
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

    /// <summary>
    /// _List-based stack
    /// </summary>
    public class Stack : IStack
    {
        _List list = new _List();
        int lastAddedElementPosition = 0;

        /// <summary>
        /// Push element into stack
        /// </summary>
        /// <param name="element">Element</param>
        public void push(int element)
        {
            ++this.lastAddedElementPosition;

            this.list.AddElement(element);
        }

        /// <summary>
        /// Pop element from stack
        /// </summary>
        /// <returns>Top element from stack</returns>
        public int pop()
        {
            if (lastAddedElementPosition != 0)
            {
                int temp = this.list.CheckElement(lastAddedElementPosition);

                this.list.DeleteElement(lastAddedElementPosition);
                --this.lastAddedElementPosition;

                return temp;
            }
            else
            {
                throw new EmptyStackPopException();
            }
        }
    }
}
