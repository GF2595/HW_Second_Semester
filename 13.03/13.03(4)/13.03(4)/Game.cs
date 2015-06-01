using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLoopHomeworkNamespace
{
    public class Game
    {
        public void OnLeft(object sender, EventArgs args)
        {
            if (Console.CursorLeft > 0)
            {
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
        }

        public void OnRight(object sender, EventArgs args)
        {
            if (Console.CursorLeft == Console.BufferWidth - 1)
            {
                Console.SetCursorPosition(Console.CursorLeft = 0, Console.CursorTop + 1);
            }
            else
            {
                Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
            }
        }

        public void OnUp(object sender, EventArgs args)
        {
            if (Console.CursorTop > 0)
            {
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            }
        }

        public void OnDown(object sender, EventArgs args)
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
        }
    }
}
