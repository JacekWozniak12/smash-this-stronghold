using System;

namespace SmashStronghold.Library
{
    public static class MathL
    {
        public static int Loop(int value, int min, int max)
        {
            if (value < min) value = max;
            else if (value > max) value = min;
            return value;
        }

        public static float Loop(float value, float min, float max)
        {
            if (value < min) value = max;
            else if (value > max) value = min;
            return value;
        }

        public static double Loop(double value, double min, double max)
        {
            if (value < min) value = max;
            else if (value > max) value = min;
            return value;
        }

        public static int LoopPositive(int value, int max) => Loop(value, 0, max);
        public static float LoopPositive(float value, float max) => Loop(value, 0, max);
    }
}
