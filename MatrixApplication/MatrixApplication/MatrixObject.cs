using System;

namespace MatrixApplication
{
    public class MatrixObject : IMatrixObject
    {
        public double[,] Add(double[,] A, double[,] B)
        {
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);

            if (rowsA != rowsB || colsA != colsB)
                throw new ArgumentException("Wrong sizes");

            double[,] result = new double[rowsA, colsA];
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    result[i, j] = A[i, j] + B[i, j];
                }
            }

            return result;
        }

        public double[,] Subtract(double[,] A, double[,] B)
        {
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);

            if (rowsA != rowsB || colsA != colsB)
                throw new ArgumentException("Wrong sizes");

            double[,] result = new double[rowsA, colsA];
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    result[i, j] = A[i, j] - B[i, j];
                }
            }

            return result;
        }

        public double[,] Multiply(double[,] A, double[,] B)
        {
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);

            if (colsA != rowsB)
                throw new ArgumentException("Wrong sizes");

            double[,] result = new double[rowsA, colsB];
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        result[i, j] += A[i, k] * B[k, j];
                    }
                }
            }

            return result;
        }

        public double[,] Multiply(double[,] A, double c)
        {
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);

            double[,] result = new double[rowsA, colsA];
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    result[i, j] = A[i, j] * c;
                }
            }

            return result;
        }

        public void Gauss(double[,] A, int[] l)
        {
            int n = A.GetLength(0);
            double[] s = new double[n];

            for (int i = 0; i < n; i++)
            {
                l[i] = i;
                s[i] = GetMaxRowScale(A, i);
            }

            for (int k = 0; k < n - 1; k++)
            {
                int pivotIndex = k;
                double maxRatio = 0;

                for (int i = k; i < n; i++)
                {
                    double ratio = Math.Abs(A[l[i], k]) / s[l[i]];
                    if (ratio > maxRatio)
                    {
                        maxRatio = ratio;
                        pivotIndex = i;
                    }
                }

                int temp = l[k];
                l[k] = l[pivotIndex];
                l[pivotIndex] = temp;

                for (int i = k + 1; i < n; i++)
                {
                    double xmult = A[l[i], k] / A[l[k], k];
                    A[l[i], k] = xmult;

                    for (int j = k + 1; j < n; j++)
                    {
                        A[l[i], j] -= xmult * A[l[k], j];
                    }
                }
            }
        }

        private double GetMaxRowScale(double[,] A, int row)
        {
            int cols = A.GetLength(1);
            double maxScale = 0;
            for (int j = 0; j < cols; j++)
            {
                maxScale = Math.Max(maxScale, Math.Abs(A[row, j]));
            }
            return maxScale;
        }
        public void GaussModifiedForwardEliminationRHS(double[,] A, int[] l, double[] b)
        {
            int n = A.GetLength(0);

            for (int k = 0; k < n - 1; k++)
            {
                for (int i = k + 1; i < n; i++)
                {
                    double factor = A[l[i], k];
                    b[l[i]] -= factor * b[l[k]];
                }
            }
        }

        public double[] Solve(double[,] A, int[] l, double[] b)
        {
            int n = A.GetLength(0);
            double[] x = new double[n];

            //GaussModifiedForwardEliminationRHS(A, l, b);

            x[n - 1] = b[l[n - 1]] / A[l[n - 1], n - 1];

            for (int i = n - 1; i >= 0; i--)
            {
                double sum = b[l[i]];
                for (int j = i + 1; j < n; j++)
                {
                    sum -= A[l[i], j] * x[j];
                }

                x[i] = sum / A[l[i], i];
            }
            return x;
        }

        public double[,] CalculateMatrixInverse(double[,] A)
        {
            int n = A.GetLength(0);
            double[,] inverse = new double[n, n];
            int[] l = new int[n];

            for (int i = 0; i < n; i++)
            {
                l[i] = i;
                for (int j = 0; j < n; j++)
                {
                    inverse[i, j] = (i == j) ? 1.0 : 0.0;
                }
            }

            Gauss(A, l);

            for (int i = 0; i < n; i++)
            {
                double[] column = new double[n];
                for (int j = 0; j < n; j++)
                {
                    column[j] = inverse[l[j], i];
                }
                double[] solution = Solve(A, l, column);
                for (int j = 0; j < n; j++)
                {
                    inverse[j, i] = solution[j];
                }
            }

            return inverse;
        }
    }
}
