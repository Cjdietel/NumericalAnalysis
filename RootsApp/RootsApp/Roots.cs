using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootsApp
{
    public class Roots : IRoots
    {
        public IRoot BisectionMethod(double a, double b, Func<double, double> f, double epsilon, int nmax)
        {
            double fa = f(a);
            double fb = f(b);

            if (double.IsNaN(fa) || double.IsNaN(fb) || fa * fb >= 0)
            {
                return new Root { root = double.NaN, error = (int)Errors.ROOT_ERRORS.SAME_SIGN };
            }

            int iterations = 0;
            double c = 0;

            while (iterations < nmax)
            {
                c = (a + b) / 2;
                double fc = f(c);

                if ((b - a) < epsilon)
                {
                    return new Root { root = c, error = (int)Errors.ROOT_ERRORS.NONE };
                }

                if (fa * fc < 0)
                {
                    b = c;
                }
                else
                {
                    a = c;
                    fa = fc;
                }

                iterations++;
            }


            return new Root { root = double.NaN, error = (int)Errors.ROOT_ERRORS.NONE };
        }

        public IRoot NewtonsMethod(double a, Func<double, double> f, Func<double, double> fPrime, double epsilon, int nmax)
        {
            int iterations = 0;
            double x = a;

            for (int i = 0; i < nmax; i++)
            {
                double fx = f(x);
                double fpx = fPrime(x);

                if (Math.Abs(fpx) < 1e-10)
                {
                    return new Root { root = double.NaN, error = (int)Errors.ROOT_ERRORS.DIVISION_BY_ZERO };
                }

                double xNew = x - fx / fpx;

                if (Math.Abs(xNew - x) < epsilon)
                {
                    return new Root { root = xNew, error = (int)Errors.ROOT_ERRORS.NONE };
                }

                x = xNew;
                iterations++;
            }

            return new Root { root = x, error = (int)Errors.ROOT_ERRORS.RUNAWAY };
        }
    }
}
