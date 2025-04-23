using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixApplication
{
    /// <summary>
    /// You may not add, remove, or change anything in this class or the Extensions class.
    /// </summary>
    interface IMatrixObject
    {

        /// <summary>
        /// Calculates A+B. Make sure to check for appropriate dimensions.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        double [,] Add(double[,] A, double[,] B);

        /// <summary>
        /// Calculates A-B. Make sure to check for appropriate dimensions.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        double[,] Subtract(double[,] A, double[,] B);

        /// <summary>
        /// Calculates A*B. Make sure to check for appropriate dimensions.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        double[,] Multiply(double[,] A, double[,] B);


        /// <summary>
        /// Calculates the scalar product c*A.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="c"></param>
        double[,] Multiply(double[,] A, double c);

        //Implement Gaussian Elimination with Scaled Partial Pivoting
        /// <summary>
        /// Gauss does the elimination on A and updates l and A. 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="l"></param>
        void Gauss(double[,] A, int[] l);

        /// <summary>
        /// Completes the forward elimination without 
        /// actually applying it to the b column.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="l"></param>
        /// <param name="b"></param>
        void GaussModifiedForwardEliminationRHS(double[,] A, int[] l, double[] b);

        /// <summary>
        /// Applies the forward elimination to the b column vector and returns 
        /// this as the solution. This is the last part of the Solve Procedure 
        /// Pseudocode in the book
        /// </summary>
        /// <param name="A"></param>
        /// <param name="l"></param>
        /// <param name="b"></param>
        /// <returns>the answer vector</returns>
        double[] Solve(double[,] A, int[] l, double[] b);

        //Implement the calculation of matrix inverses
        /// <summary>
        /// Calculates the inverse of a matrix using repeated Guassian
        /// Backsubstitution.
        /// </summary>
        /// <param name="A"></param>
        /// <returns>Inverse matrix</returns>
        double[,] CalculateMatrixInverse(double[,] A);

        

    }
}
