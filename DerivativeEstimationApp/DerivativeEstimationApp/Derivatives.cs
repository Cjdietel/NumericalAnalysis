using System;

namespace DerivativeEstimationApp
{
    public class Derivatives : IDerivatives
    {
        public double DerEstimate { get; set; }
        public double h { get; set; }
        public double Error { get; set; }

        public void Derivative(double x, Func<double, double> f, double epsilon, double maxFTriplePrime)
        {
            int n = (int)Math.Ceiling(Math.Log(Math.Sqrt((1.0 / 6.0) * maxFTriplePrime / epsilon), 2));

            h = 1.0 / Math.Pow(2, n);

            DerEstimate = (f(x + h) - f(x - h)) / (2 * h);

            Error = (1.0 / 6.0) * maxFTriplePrime * h * h;
        }
    }
}
