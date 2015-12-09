using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Test_Rogue
{
    static class Player
    {
        private const char PLAYERCHAR = (char)1; // Replaced it with smiley, hehehehe.
        public static Point position;

        public static int life = 10;
        public static int strength = 5;
        public static int agility = 2;

        public static void SpawnPlayer(Point pos)
        {
            ConsoleHelper.WriteChar(PLAYERCHAR, pos.x, pos.y);
            GameManager.consoleContent[pos.x, pos.y] = '@';
            position = pos;
        }

        public static void MovePlayer(ConsoleKey c)
        {
            CollisionInfo col = CheckForCollision(position, c);
            if(col.Pass)
            {
                UpdatePlayerPos(col.pos);
            }
            else
            {
                switch (col.Type)
                {
                    case GameManager.TileType.Monster:
                        Attack(GameManager.FindMonster(col.pos));
                        break;
                    case GameManager.TileType.Wall:
                    default:
                        break;
                }
            }
            GameManager.Step();
        }
        private static Random rng = new Random();
        private static void Attack(Monster m)
        {
            Debug.WriteLine("Attacked monster");
            if (rng.Next(1, 7) < agility)
            {
                if (rng.Next(1, 7) > m.agility)
                {
                    int damage = (int)Math.Round((double)(strength / 2));
                    GameManager.eventLog = "You hit the monster for " + damage + " damages !";
                    Player.life -= damage;
                }
                else { GameManager.eventLog = "The monster dodges your punch !"; }
            }
            else { GameManager.eventLog = "You miss your punch !"; }
        }

        private struct CollisionInfo
        {
            public Point pos;
            public bool Pass;
            public GameManager.TileType Type;
        }

        private static void UpdatePlayerPos(Point newPos)
        {
            ConsoleHelper.WriteChar(' ', position.x, position.y);
            GameManager.consoleContent[position.x, position.y] = ' ';

            ConsoleHelper.WriteChar(PLAYERCHAR, newPos.x, newPos.y);
            GameManager.consoleContent[newPos.x, newPos.y] = '@';

            position = newPos;
        }

        private static CollisionInfo CheckForCollision(Point playerPos, ConsoleKey c)
        {
            CollisionInfo ret = new CollisionInfo();
            Point newPos = new Point(0, 0);
            switch (c)
            {
                case ConsoleKey.UpArrow:
                    newPos = new Point(playerPos.x, playerPos.y - 1);
                    break;
                case ConsoleKey.DownArrow:
                    newPos = new Point(playerPos.x, playerPos.y + 1);
                    break;
                case ConsoleKey.LeftArrow:
                    newPos = new Point(playerPos.x - 1, playerPos.y);
                    break;
                case ConsoleKey.RightArrow:
                    newPos = new Point(playerPos.x + 1, playerPos.y);
                    break;
            }
            ret.pos = newPos;
            switch(GameManager.consoleContent[newPos.x, newPos.y])
            {
                case ' ':
                    ret.Type = GameManager.TileType.Void;
                    ret.Pass = true;
                    break;
                case '#':
                    ret.Type = GameManager.TileType.Wall;
                    ret.Pass = false;
                    break;
                case 'm':
                    ret.Type = GameManager.TileType.Monster;
                    ret.Pass = false;
                    break;
            }

            return ret;
        }
    }
}