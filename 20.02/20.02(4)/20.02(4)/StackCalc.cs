using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackNamespace;

namespace StackCalcNamespace
{
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

    public class StackCalc
    {
        IStack stack = new Stack();

        /// <summary>
        /// Push element in calculator's stack
        /// </summary>
        /// <param name="number">Element to be pushed</param>
        public void Push(int number)
        {
            this.stack.push(number);
        }

        /// <summary>
        /// Pop element from calculator's stack
        /// </summary>
        /// <returns>Element value</returns>
        public int Pop()
        {
            return this.stack.pop();
        }

        /// <summary>
        /// Commit specified operation with two elements on top of stack and pushes the result into stack
        /// </summary>
        /// <param name="operation">Operation sign</param>
        public void Operation(char operation)
        {
            int firstElement = 0;
            int secondElement = 0;

            try
            {
                firstElement = this.stack.pop();
            }
            catch(EmptyStackPopException)
            {
                Console.WriteLine("Недостаточно чисел в стеке для совершения операции");

                return;
            }

            try
            {
                secondElement = this.stack.pop();
            }
            catch (EmptyStackPopException)
            {
                Console.WriteLine("Недостаточно чисел в стеке для совершения операции");

                this.stack.push(firstElement);
                return;
            }

            switch (operation)
            {
                case '+':
                    {
                        firstElement += secondElement;

                        this.stack.push(firstElement);
                    }
                    break;
                case '-':
                    {
                        firstElement -= secondElement;

                        this.stack.push(firstElement);

                    }
                    break;
                case '*':
                    {
                        firstElement *= secondElement;

                        this.stack.push(firstElement);

                    }
                    break;
                case '/':
                    {
                        if (secondElement != 0)
                        {
                            firstElement /= secondElement;

                            this.stack.push(firstElement);
                        }
                        else
                        {
                            throw new DivisionByZeroException();
                        }
                    }
                    break;
            }
        }
    }
}
