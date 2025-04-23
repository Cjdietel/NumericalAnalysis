using System;

namespace DifferentialEquationSolver
{
   public class Program
    {
        
        static void Main(string[] args)
        {

            double rkf(double t, double x)
            {
                return 2.0 + Math.Pow(x - t - 1, 2);
            }

            DEMethods DE = new DEMethods();

            int n = 72;
            double a = 1.0, b = 1.5625, x = 2.0;

            DE.RK(a, b, n,x, rkf);
        }
    }
}
