using System;
using System.Diagnostics;

namespace Test_Rogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            GameManager.Init();
            GameManager.GenerateRoom();
            GameManager.SpawnMonster(new Point(1, 3));
            Player.SpawnPlayer(new Point(5, 5));
            while(true)
            {
                //Console.SetWindowSize(84, 20);
                ConsoleKeyInfo c = Console.ReadKey(true);
                switch (c.Key)
                {
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.UpArrow: 
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.RightArrow:
                        Player.MovePlayer(c.Key);
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
