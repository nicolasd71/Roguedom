using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Rogue
{
    struct Point
    {
        public int x { get; set; }
        public int y { get; set; }

        public Point normalized
        {
            get
            {
                return new Point(Mathf.Clamp(x, -1, 1), Mathf.Clamp(y, -1, 1));
            }
        }

        public Point(int x, int y) : this()
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return string.Format("[{0}-{1}]", x, y);
        }

        public static int Distance(Point p1, Point p2)
        {
            return (int)Math.Round(Math.Sqrt(Math.Pow(p1.x - p2.x, 2) + Math.Pow(p1.y - p2.y, 2)));
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.x + p2.x, p1.y + p2.y);
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.x - p2.x, p1.y - p2.y);
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return (p1.x == p2.x && p1.y == p2.y);
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return (p1.x != p2.x || p1.y != p2.y);
        }
    }
}
