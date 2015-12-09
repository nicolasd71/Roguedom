using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Rogue
{
    static class ConsoleHelper
    {
        public static void WriteChar(char c, int x, int y, ConsoleColor C = ConsoleColor.White)
        {
            Console.ForegroundColor = C;
            Console.SetCursorPosition(x, y);
            Console.Write(c);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    static class HUD
    {
        public static void WriteHUD(string l, int index = 0)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 20 + index);
            Console.Write(l);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void WriteLog(string l)
        {
            // Only one line showing at time, per step.
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 19);
            Console.Write(l);
            for (int i = Console.CursorLeft; i < Console.BufferWidth; i++)
            {
                Console.Write(" ");
            }
                Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}