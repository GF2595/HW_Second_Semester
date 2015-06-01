using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackNamespace
{
    /// <summary>
    /// Stack based on references.
    /// </summary>
    public class Stack
    {
        private class StackElement
        {
            public int Value { get; set; }

            public StackElement Next { get; set; }
        }

        private StackElement head = null;

        /// <summary>
        /// Push value to a stack.
        /// </summary>
        /// <param name="value">Value to be pushed.</param>
        public void Push(int value)
        {
            var newElement = new StackElement()
            {
                Next = head,
                Value = value
            };

            head = newElement;
        }

        /// <summary>
        /// Pop value from a stack
        /// </summary>
        /// <returns>Value</returns>
        public int Pop()
        {
            if (head == null)
            {
                return -1;
            }

            var temp = head.Value;
            head = head.Next;
            return temp;
        }

        /// <summary>
        /// Checks if stack is empty
        /// </summary>
        /// <returns>"true" if stack is empty, "false" otherwise</returns>
        public bool IsEmpty()
        {
            return head == null;
        }
    }
}
