using System;

namespace PolynomialInterpolationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Polynomial Interpolation Test");

                // Create an instance of PolyInter
                PolyInter polynomial = new PolyInter();

                // Input the x values
                Console.Write("Enter the number of data points: ");
                int n = int.Parse(Console.ReadLine());

                polynomial.X = new double[n];
                polynomial.Y = new double[n];

                Console.WriteLine("Enter the x values:");
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"x[{i}] = ");
                    polynomial.X[i] = double.Parse(Console.ReadLine());
                }

                // Input the y values
                Console.WriteLine("Enter the y values:");
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"y[{i}] = ");
                    polynomial.Y[i] = double.Parse(Console.ReadLine());
                }

                // Calculate the coefficients
                polynomial.Coef();

                if (!polynomial.IsPossible)
                {
                    Console.WriteLine("Interpolation is not possible.");
                }
                else
                {
                    // Display the polynomial in Newton's Form
                    Console.WriteLine("The polynomial in Newton's Form:");
                    Console.WriteLine(polynomial.Polynomial);

                    // Evaluate the polynomial at a given point
                    Console.Write("Enter a value of t to evaluate the polynomial: ");
                    double t = double.Parse(Console.ReadLine());

                    double result = polynomial.Eval(t);
                    Console.WriteLine($"P({t}) = {result}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}