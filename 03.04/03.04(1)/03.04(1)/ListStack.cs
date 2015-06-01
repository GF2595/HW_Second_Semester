using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericListNamespace;

namespace GenericStackNamespace
{
    /// <summary>
    /// GenericList-based stack
    /// </summary>
    public class GenericStack<T> : IStack<T>
    {
        GenericList<T> list = new GenericList<T>();
        int lastAddedElementPosition = 0;

        /// <summary>
        /// Push element into stack
        /// </summary>
        /// <param name="element">Element</param>
        public void Push(T element)
        {
            ++this.lastAddedElementPosition;

            this.list.AddElement(element);
        }

        /// <summary>
        /// Pop element from stack
        /// </summary>
        /// <returns>Top element from stack</returns>
        public T Pop()
        {
            if (lastAddedElementPosition != 0)
            {
                T temp = this.list.CheckElement(lastAddedElementPosition);

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
