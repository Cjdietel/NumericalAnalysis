using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixApplication
{
    public static class Extensions
    {
        public static bool EpsilonEqual(this double[,] a, double[,] b, double epsilon)
        {
            int an = a.GetLength(0);
            int am = a.GetLength(1);
            int bn = b.GetLength(0);
            int bm = b.GetLength(1);

            bool rvalue = true;
            if (!(an == bn && am == bm))
            {
                return false;
            }
            for (int i = 0; i < an; i++)
            {
                for (int j = 0; j < am; j++)
                {
                    rvalue &= Math.Abs(a[i, j] - b[i, j]) < epsilon;
                }
            }
            return rvalue;
        }


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
