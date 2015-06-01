using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorNamespace
{
    public class Calculator
    {
        string firstMemoryCell = "";
        string secondMemoryCell = "";
        char operationMemoryCell = ' ';
        bool secondMemoryCellIsFilled = false;

        /// <summary>
        /// Adds digit to memory
        /// </summary>
        /// <param name="number">Digit</param>
        internal void AddDigitToMemory(int number)
        {            
            if (operationMemoryCell == ' ')
            {
                firstMemoryCell += number.ToString();
            }
            else
            {
                secondMemoryCell += number.ToString();

                secondMemoryCellIsFilled = true;
            }
        }

        /// <summary>
        /// Makes float number from string
        /// </summary>
        /// <param name="number">Number-representing string</param>
        /// <returns>Float number</returns>
        private float MakeNumber(string number)
        {
            float temp = Convert.ToSingle(number);

            return temp;
        }

        /// <summary>
        /// Commits recorded operation with two numbers
        /// </summary>
        /// <returns>Operation result represented in string</returns>
        internal string CommitOperation()
        {
            if (secondMemoryCellIsFilled)
            {
                float first = MakeNumber(firstMemoryCell);
                float second = MakeNumber(secondMemoryCell);

                switch (this.operationMemoryCell)
                {
                    case '+':
                        first += second;    
                        break;
                    case '-':
                        first -= second;
                        break;
                    case '*':
                        first *= second;
                        break;
                    case '/':
                        {
                            if (second == 0)
                            {
                                throw new DivisionByZeroException();
                            }
                            else
                            {
                                first /= second;
                            }
                        }
                        break;
                }

                secondMemoryCell = "";
                operationMemoryCell = ' ';
                secondMemoryCellIsFilled = false;

                firstMemoryCell = first.ToString();
            }

            return firstMemoryCell;
        }

        /// <summary>
        /// Records operation
        /// </summary>
        /// <param name="operation">Char-represented operation</param>
        internal void AddOperation(char operation)
        {
            operationMemoryCell = operation;
        }

        /// <summary>
        /// Cleans memory
        /// </summary>
        internal void CleanMemory()
        {
            firstMemoryCell = "";
            secondMemoryCell = "";
            operationMemoryCell = ' ';
            secondMemoryCellIsFilled = false;
            
        }

        /// <summary>
        /// Removes last recorded number from memory
        /// </summary>
        internal void DeleteLastRecordedNumber()
        {
            if (secondMemoryCellIsFilled)
            {                
                secondMemoryCell = "";
                secondMemoryCellIsFilled = false;
            }
            else
            {
                firstMemoryCell = "";
            }
        }

        /// <summary>
        /// Removes last symbol from string
        /// </summary>
        /// <returns>Reformed string</returns>
        internal string BackSpace()
        {
            if (!secondMemoryCellIsFilled)
            {
                string temp = firstMemoryCell;
                firstMemoryCell = "";

                for (int i = 0; i < temp.Length - 1; i++)
                {
                    firstMemoryCell += temp[i];
                }

                return firstMemoryCell;
            }
            else
            { 
                string temp = secondMemoryCell;
                secondMemoryCell = "";

                for (int i = 0; i < temp.Length - 1; i++)
                {
                    secondMemoryCell += temp[i];
                }

                return secondMemoryCell;
            }
        }

        /// <summary>
        /// Adds dot to number-representing string
        /// </summary>
        internal void ActivateDot()
        {
            if (operationMemoryCell != ' ')
            {
                secondMemoryCell += ',';
            }
            else
            {
                firstMemoryCell += ',';
            }
        }

        /// <summary>
        /// Changes string-represented number sign
        /// </summary>
        /// <returns>Reformed string</returns>
        internal string ChangeSign()
        {
            if (operationMemoryCell != ' ')
            {
                if (secondMemoryCell[0] != '-')
                {
                    secondMemoryCell = '-' + secondMemoryCell;
                }
                else
                {
                    string temp = "";

                    for (int i = 1; i < secondMemoryCell.Length; i++)
                    {
                        temp += secondMemoryCell[i];
                    }

                    secondMemoryCell = temp;
                }

                return secondMemoryCell;
            }
            else
            {
                if (firstMemoryCell[0] != '-')
                {
                    firstMemoryCell = '-' + firstMemoryCell;
                }
                else
                {
                    string temp = "";

                    for (int i = 1; i < firstMemoryCell.Length; i++)
                    {
                        temp += firstMemoryCell[i];
                    }

                    firstMemoryCell = temp;
                }

                return firstMemoryCell;
            }
        }

        /// <summary>
        /// Commits sqrt with last recorded number
        /// </summary>
        /// <returns>Reformed number-representing string</returns>
        internal string Sqrt()
        {
            if (operationMemoryCell == ' ')
            {
                float temp = MakeNumber(firstMemoryCell);
                temp = (float)Math.Sqrt(temp);

                firstMemoryCell = temp.ToString();

                return firstMemoryCell;
            }
            else
            {
                float temp = MakeNumber(secondMemoryCell);
                temp = (float)Math.Sqrt(temp);

                secondMemoryCell = temp.ToString();

                return secondMemoryCell;
            }
        }

        /// <summary>
        /// Inverses last-recorded number
        /// </summary>
        /// <returns>Reformed number-representing string</returns>
        internal string InvertNumber()
        {
            float temp = 0;
            bool firstNumberInverted = true;

            if (operationMemoryCell == ' ')
            {
                temp = MakeNumber(firstMemoryCell);
            }
            else
            {
                temp = MakeNumber(secondMemoryCell);

                firstNumberInverted = false;
            }

            if (temp != 0)
            {
                temp = 1 / temp;

                if (firstNumberInverted)
                {
                    firstMemoryCell = temp.ToString();

                    return firstMemoryCell;
                }
                else
                {
                    secondMemoryCell = temp.ToString();

                    return secondMemoryCell;
                }
            }
            else
            {
                throw new DivisionByZeroException();
            }
        }

        /// <summary>
        /// Calculates which part of first number is the second one, records it in second memory cell, clear memory if second number isn't recorded
        /// </summary>
        /// <returns>Reformed second string or empty string</returns>
        internal string Percent()
        {
            if (operationMemoryCell == ' ')
            {
                firstMemoryCell = "";

                return "";
            }
            else
            {
                float first = MakeNumber(firstMemoryCell);
                float second = MakeNumber(secondMemoryCell);

                float temp = second / first;

                secondMemoryCell = temp.ToString();

                return secondMemoryCell;
            }
        }
    }
}
