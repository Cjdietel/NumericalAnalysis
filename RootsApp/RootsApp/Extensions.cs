using System;

namespace RootsApp
{
    public static class Extensions
    {
        public static bool EpsilonEqual(this double a, double b, double epsilon)
        {
            bool rvalue = true;

            rvalue &= (Math.Abs(a - b) < epsilon);
            return rvalue;
        }
    }
}
