using System;
using System.Collections.Generic;
using System.Text;

namespace PolynomialInterpolationApp
{
    public static class Extensions
    {
        public static bool EpsilonEqual(this double[] a, double[] b, double epsilon)
        {
            bool rvalue = true;
            if (a.Length != b.Length)
            {
                return false;
            }
            for (int i = 0; i < a.Length; i++)
            {
                rvalue &= Math.Abs(a[i] - b[i]) < epsilon;
            }
            return rvalue;
        }

        public static bool Equal(this int[] a, int[] b)
        {
            bool rvalue = true;
            if (a.Length != b.Length)
            {
                return false;
            }
            for (int i = 0; i < a.Length; i++)
            {
                rvalue &= a[i] == b[i];
            }
            return rvalue;
        }
    }
}
