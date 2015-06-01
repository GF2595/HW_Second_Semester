using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorNamespace
{
    public class Calculator
    {
        int firstMemoryCellIntegerPart = 0;
        int firstMemoryCellFractionalPart = 0;
        int secondMemoryCellIntegerPart = 0;
        int secondMemoryCellFractionalPart = 0;
        char operationMemoryCell = ' ';
        bool firstMemoryCellDotActive = false;
        bool secondMemoryCellDotActive = false;
        bool secondMemoryCellIsFilled = false;

        internal void AddDigitToMemory(int number)
        {            
            if (operationMemoryCell == ' ')
            {
                if (firstMemoryCellDotActive)
                {
                    firstMemoryCellFractionalPart = firstMemoryCellFractionalPart * 10 + number;
                }
                else
                {
                    firstMemoryCellIntegerPart = firstMemoryCellIntegerPart * 10 + number;
                }
            }
            else
            {
                if (secondMemoryCellDotActive)
                {
                    secondMemoryCellFractionalPart = secondMemoryCellFractionalPart * 10 + number;
                }
                else
                {
                    secondMemoryCellIntegerPart = secondMemoryCellIntegerPart * 10 + number;
                }

                secondMemoryCellIsFilled = true;
            }
        }

        private float MakeNumber(int integer, int fractional)
        {
            float temp = fractional;

            while (Math.Abs(temp) > 1)
            {
                temp /= 10;
            }

            return integer + temp;
        }

        private void UnmakeNumber(ref int integer, ref int fractional, float number)
        {
            integer = (int)Math.Truncate(number);
            number -= integer;

            while (Math.Truncate(Math.Abs(number)) != Math.Abs(number))
            {
                number *= 10;
            }

            fractional = (int)number;
        }

        internal float CommitOperation()
        {
            float first = MakeNumber(firstMemoryCellIntegerPart, firstMemoryCellFractionalPart);;

            if (secondMemoryCellIsFilled)
            {
                float second = MakeNumber(secondMemoryCellIntegerPart, secondMemoryCellFractionalPart);

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

                secondMemoryCellIntegerPart = 0;
                secondMemoryCellFractionalPart = 0;
                operationMemoryCell = ' ';
                secondMemoryCellIsFilled = false;

                UnmakeNumber(ref firstMemoryCellIntegerPart, ref firstMemoryCellFractionalPart, first);
            }

            return first;
        }

        internal void AddOperation(char operation)
        {
            operationMemoryCell = operation;
        }

        internal void CleanMemory()
        {
            firstMemoryCellIntegerPart = 0;
            firstMemoryCellFractionalPart = 0;
            firstMemoryCellDotActive = false;
            operationMemoryCell = ' ';
            secondMemoryCellIntegerPart = 0;
            secondMemoryCellFractionalPart = 0;
            secondMemoryCellDotActive = false;
            secondMemoryCellIsFilled = false;
            
        }

        internal void DeleteLastRecordedNumber()
        {
            if (secondMemoryCellIsFilled)
            {                
                secondMemoryCellIntegerPart = 0;
                secondMemoryCellFractionalPart = 0;
                secondMemoryCellIsFilled = false;
            }
            else
            {
                firstMemoryCellIntegerPart = 0;
                firstMemoryCellFractionalPart = 0;
            }
        }

        internal void BackSpace()
        {
            if(!secondMemoryCellIsFilled)
            {
                if (firstMemoryCellDotActive)
                {
                    firstMemoryCellFractionalPart = firstMemoryCellFractionalPart / 10;
                }
                else
                {
                    firstMemoryCellIntegerPart = firstMemoryCellIntegerPart / 10;
                }
            }
            else
            { 
                if (secondMemoryCellDotActive)
                {
                    secondMemoryCellFractionalPart = secondMemoryCellFractionalPart / 10;
                }
                else
                {
                    secondMemoryCellIntegerPart = secondMemoryCellIntegerPart / 10;
                }
            }
        }

        internal void ActivateDot()
        {
            if (operationMemoryCell != ' ')
            {
                secondMemoryCellDotActive = true;
            }
            else
            {
                firstMemoryCellDotActive = true;
            }
        }

        internal void ChangeSign()
        {
            if (operationMemoryCell != ' ')
            {
                secondMemoryCellIntegerPart *= (-1);
                secondMemoryCellFractionalPart *= (-1);
            }
            else
            {
                firstMemoryCellIntegerPart *= (-1);
                firstMemoryCellFractionalPart *= (-1);
            }
        }

        internal float Sqrt()
        {
            if (operationMemoryCell == ' ')
            {
                float temp = MakeNumber(firstMemoryCellIntegerPart, firstMemoryCellFractionalPart);
                temp = (float)Math.Sqrt(temp);

                UnmakeNumber(ref firstMemoryCellIntegerPart, ref firstMemoryCellFractionalPart, temp);

                return temp;
            }
            else
            {
                float temp = MakeNumber(secondMemoryCellIntegerPart, secondMemoryCellFractionalPart);
                temp = (float)Math.Sqrt(temp);

                UnmakeNumber(ref secondMemoryCellIntegerPart, ref secondMemoryCellFractionalPart, temp);

                return temp;
            }
        }

        internal float InvertNumber()
        {
            float temp = 0;
            bool firstNumberInverted = true;

            if (operationMemoryCell == ' ')
            {
                temp = MakeNumber(firstMemoryCellIntegerPart, firstMemoryCellFractionalPart);
            }
            else
            {
                temp = MakeNumber(firstMemoryCellIntegerPart, firstMemoryCellFractionalPart);

                firstNumberInverted = false;
            }

            if (temp != 0)
            {
                temp = 1 / temp;
                bool dotShouldBeActivated = false;

                if (Math.Truncate(temp) != temp)
                {
                    dotShouldBeActivated = true;
                }

                if (firstNumberInverted)
                {
                    UnmakeNumber(ref firstMemoryCellIntegerPart, ref firstMemoryCellFractionalPart, temp);
                    firstMemoryCellDotActive = dotShouldBeActivated;
                }
                else
                {
                    UnmakeNumber(ref secondMemoryCellIntegerPart, ref secondMemoryCellFractionalPart, temp);
                    secondMemoryCellDotActive = dotShouldBeActivated;
                }

                return temp;
            }
            else
            {
                throw new DivisionByZeroException();
            }
        }

        internal float Percent()
        {
            if (operationMemoryCell == ' ')
            {
                firstMemoryCellIntegerPart = 0;
                firstMemoryCellFractionalPart = 0;
                firstMemoryCellDotActive = false;

                return 0;
            }
            else
            {
                float first = MakeNumber(firstMemoryCellIntegerPart, firstMemoryCellFractionalPart);
                float second = MakeNumber(secondMemoryCellIntegerPart, secondMemoryCellFractionalPart);

                float temp = second / first;

                UnmakeNumber(ref secondMemoryCellIntegerPart, ref secondMemoryCellFractionalPart, temp);

                return temp;
            }
        }
    }
}
