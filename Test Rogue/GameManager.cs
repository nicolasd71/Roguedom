using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Test_Rogue
{
    static class GameManager
    {
        public static List<Entity> spawnedEntities = new List<Entity>();
        public static char[,] consoleContent = new char[Console.BufferWidth, Console.BufferHeight];

        public enum TileType
        {
            Void,
            Wall,
            Monster
        }

        public static void Init()
        {
            for (int x = 0; x < Console.BufferWidth; x++)
            {
                for (int y = 0; y < Console.BufferHeight; y++)
                {
                    consoleContent[x, y] = ' ';
                }
            }
        }

        public static void SpawnMonster(Point pos)
        {
            Monster m = new Monster(pos);
            spawnedEntities.Add(m);
        }

        public static void Step()
        {
            foreach (Entity t in spawnedEntities)
            {
                t.Step();
            }
            UpdateHUD();
        }

        // todo: actual procedural generation. Not clue about how any of this shit works though
        public static void GenerateRoom()
        {
            for (int i = 0; i <= 10; i++)
            {
                ConsoleHelper.WriteChar('#', i, 0);
                consoleContent[i, 0] = '#';
            }
            for (int i = 0; i <= 10; i++)
            {
                ConsoleHelper.WriteChar('#', i, 10);
                consoleContent[i, 10] = '#';
            }
            for (int i = 0; i <= 10; i++)
            {
                ConsoleHelper.WriteChar('#', 0, i);
                consoleContent[0, i] = '#';
            }
            for (int i = 0; i <= 10; i++)
            {
                ConsoleHelper.WriteChar('#', 10, i);
                consoleContent[10, i] = '#';
            }
        }
        // todo: a real UpdateLog method
        // Bug: Monster's turn resolved after Player's, so Player's event log not displayed/overwritten
        private static string oldLog = "";
        public static string eventLog = "";
        public static void UpdateHUD()
        {
            HUD.WriteHUD(string.Format("HP:{0} Str:{1} Agi:{2} Wis:N/A", Player.life, Player.strength, Player.agility));
            HUD.WriteHUD("Yui the Great - Lvl N/A (N/A class)", 1);
            HUD.WriteLog(eventLog);
            if (eventLog == oldLog)
            {
                eventLog = "";
                oldLog = "";
            }
            else
            {
                oldLog = eventLog;
            }
        }

        public static Monster FindMonster(Point p)
        {
            foreach(Entity e in spawnedEntities)
            {
                if (e.position == p)
                    return (Monster)e;
            }
            return null;
        }
    }
}