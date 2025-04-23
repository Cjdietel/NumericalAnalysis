using System;
using System.Text;

namespace PolynomialInterpolationApp
{
    public class PolyInter : IPolyInter
    {
        public double[] A { get; set; }
        public double[] X { get; set; }
        public double[] Y { get; set; }
        public string Polynomial { get; set; }
        public bool IsPossible { get; set; }

        public void Coef()
        {
            if (X.Length != Y.Length || X.Length == 0)
            {
                IsPossible = false;
                return;
            }

            int n = X.Length;
            A = new double[n];
            double[,] table = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                table[i, 0] = Y[i];
            }

            for (int j = 1; j < n; j++)
            {
                for (int i = 0; i < n - j; i++)
                {
                    if (X[i + j] == X[i])
                    {
                        IsPossible = false;
                        return;
                    }
                    table[i, j] = (table[i + 1, j - 1] - table[i, j - 1]) / (X[i + j] - X[i]);
                }
            }

            for (int i = 0; i < n; i++)
            {
                A[i] = table[0, i];
            }

            IsPossible = true;
            Polynomial = GeneratePolynomialString();
        }

        public double Eval(double t)
        {
            if (!IsPossible)
            {
                return double.NaN;
            }

            double result = 0;
            double term = 1;

            for (int i = 0; i < A.Length; i++)
            {
                result += A[i] * term;
                term *= (t - X[i]);
            }

            return result;
        }

        private string GeneratePolynomialString()
        {
            if (!IsPossible)
            {
                return "Interpolation not possible.";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append($"{Math.Round(A[0], 5)}");

            for (int i = 1; i < A.Length; i++)
            {
                sb.Append($" + {Math.Round(A[i], 5)}");

                for (int j = 0; j < i; j++)
                {
                    sb.Append($"(x - {X[j]})");
                }
            }

            return sb.ToString();
        }
    }
}