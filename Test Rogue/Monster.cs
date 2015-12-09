using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Test_Rogue
{
    class Monster : Entity
    {
        public const char MONSTERCHAR = 'm';
        public Point position { get; set; }

        public int strength;
        public int agility;
        public int life;

        public Monster(Point pos, int level = 1)
        {
            this.position = pos;
            ConsoleHelper.WriteChar(MONSTERCHAR, position.x, position.y, ConsoleColor.Red);

            this.strength = Mathf.Clamp((int)Math.Floor(level * 0.5 * (rng.NextDouble() * 10)), 1, level * 5); // Change these to use the new Mathf.Random(), it will be overrall better.
            this.agility = Mathf.Clamp((int)Math.Floor(level * 2 * (rng.NextDouble() * 10)), 1, level * 5);
            this.life = (int)Math.Round(strength * level * 1.25);
        }

        Random rng = new Random();
        public void Step()
        {
            ConsoleHelper.WriteChar(' ', position.x, position.y, ConsoleColor.Gray);
            Point oldPos = position;
            while (true)
            {
                if (Point.Distance(position, Player.position) < 5)
                {
                    if (Point.Distance(position, Player.position) > 1)
                    {
                        Point direction = (Player.position - position).normalized;
                        position += direction;
                        GameManager.consoleContent[oldPos.x, oldPos.y] = ' ';
                        GameManager.consoleContent[position.x, position.y] = 'm';
                    }
                    if (Point.Distance(position, Player.position) == 1)
                    {
                        Attack();
                        break;
                    }
                    break;
                }
                else
                {
                    switch (rng.Next(0, 5))
                    {
                        case 0:
                            position = new Point(position.x + 1, position.y);
                            break;
                        case 1:
                            position = new Point(position.x, position.y + 1);
                            break;
                        case 2:
                            position = new Point(position.x - 1, position.y);
                            break;
                        case 3:
                            position = new Point(position.x, position.y - 1);
                            break;
                        case 5:
                            break;
                    }

                }
                if (GameManager.consoleContent[position.x, position.y] == ' ')
                {
                    GameManager.consoleContent[oldPos.x, oldPos.y] = ' ';
                    GameManager.consoleContent[position.x, position.y] = 'm';
                    break;
                }
                position = oldPos;
            }
            ConsoleHelper.WriteChar(MONSTERCHAR, position.x, position.y, ConsoleColor.Red);
        }

        private void Attack()
        {
            if (rng.Next(1, 7) < this.agility)
            {
                if (rng.Next(1, 7) > Player.agility)
                {
                    int damage = (int)Math.Round((double)(this.strength / 2));
                    GameManager.eventLog = "Monster hits you for " + damage + " damages !";
                    Player.life -= damage;
                }
                else { GameManager.eventLog = "You dodge the monster's punch !"; }
            }
            else { GameManager.eventLog = "The monster misses his punch !"; }
        }
    }
}