using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpsonsRuleIntegration
{
    public class SimpsonsMethod : ISimpsonsMethod
    {
        public double Simpsons(double a, double b, Func<double, double> f, double MaxError, double MaxFourthDerivative)
        {
            int n = 2;
            double error;

            do
            {
                error = Math.Pow(b - a, 5) / (180 * Math.Pow(n, 4)) * MaxFourthDerivative;
                if (error > MaxError) n += 2;
            } while (error > MaxError);

            double h = (b - a) / n;
            double sum = f(a) + f(b);

            for (int i = 1; i < n; i++)
            {
                double x = a + i * h;
                sum += (i % 2 == 0) ? 2 * f(x) : 4 * f(x);
            }

            return (h / 3) * sum;
        }
    }
}
