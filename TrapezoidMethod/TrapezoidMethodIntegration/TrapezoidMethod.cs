using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrapezoidMethodIntegration
{
    public class TrapezoidMethod : ITrapezoid
    {
        public double Trapezoid(double a, double b, Func<double, double> f, double MaxError, double MaxSecondDerivative)
        {
            if (a >= b)
                throw new ArgumentException("Lower bound 'a' must be less than upper bound 'b'.");
            if (MaxError <= 0)
                throw new ArgumentException("MaxError must be greater than 0.");
            if (MaxSecondDerivative < 0)
                throw new ArgumentException("MaxSecondDerivative must be non-negative.");

            int n = (int)Math.Ceiling(Math.Sqrt((Math.Pow(b - a, 3) * MaxSecondDerivative) / (12 * MaxError)));

            n = Math.Max(n, 1);

            double h = (b - a) / n;

            double sum = 0.5 * (f(a) + f(b));
            for (int i = 1; i < n; i++)
            {
                double x = a + i * h;
                sum += f(x);
            }

            return sum * h;
        }
    }
}
