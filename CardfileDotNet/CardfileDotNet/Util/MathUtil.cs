using System;
using System.ComponentModel;

namespace CardfileDotNet.Util
{
    public static class MathUtil
    {
        public static int Remainder(int a, int b)
        {
            return ((a % b) + b) % b;
        }

        public static int Clamp(int value, int minimum, int maximum)
        {
            if (maximum < minimum)
                throw new ArgumentException("maximum must be greater than or equal to minimum");
            return Math.Max(minimum, Math.Min(value, maximum));
        }

        public static double Clamp(double value, double minimum, double maximum)
        {
            if (maximum < minimum)
                throw new ArgumentException("maximum must be greater than or equal to minimum");
            return Math.Max(minimum, Math.Min(value, maximum));
        }
    }
}