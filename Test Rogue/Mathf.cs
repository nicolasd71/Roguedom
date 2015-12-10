using System;

namespace Test_Rogue
{
    static class Mathf
    {
        private static Random _rnd = new Random();

        public static int Clamp(int val, int min, int max)
        {
            if (val < min)
                return min;
            else if (val > max)
                return max;
            return val;
        }

        public static float Random(float minimum, float maximum) // Yay random floats without hassle!
        {
            return (float)(_rnd.NextDouble() * (maximum - minimum) + minimum);
        }
    }
}
