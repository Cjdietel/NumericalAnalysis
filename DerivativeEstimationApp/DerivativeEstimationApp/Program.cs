using System;

namespace DerivativeEstimationApp
{
    class Program
    {
        static void Main()
        {
            DerivativeEstimation derivative = new DerivativeEstimation();

            // Define the function f(x) = sin(x)
            Func<double, double> f = Math.Sin;

            // Set x value to evaluate derivative at
            double x = Math.PI / 4; // 45 degrees

            // Define error bound and max third derivative for sin(x)
            double epsilon = 1e-5;
            double maxFTriplePrime = 1; // For sin(x), max |f'''(x)| is 1

            // Compute derivative
            derivative.Derivative(x, f, epsilon, maxFTriplePrime);

            // Display results
            Console.WriteLine($"Estimated Derivative at x={x}: {derivative.DerEstimate}");
            Console.WriteLine($"Computed h: {derivative.h}");
            Console.WriteLine($"Estimated Error: {derivative.Error}");

            // Compare with the actual derivative (cos(x))
            double actualDerivative = Math.Cos(x);
            Console.WriteLine($"Actual Derivative: {actualDerivative}");
            Console.WriteLine($"Absolute Error: {Math.Abs(actualDerivative - derivative.DerEstimate)}");
        }
    }
}
