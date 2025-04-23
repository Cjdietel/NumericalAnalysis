using System;


namespace RootsApp
{
    public interface IRoots
    {

        /// <summary>
        /// Implement the Bisection Method
        /// </summary>
        /// <param name="a">left hand endpoint of the starting interval</param>
        /// <param name="b">right hand endpoint of the starting interval</param>
        /// <param name="f">this is the function for which you want to find the root</param>
        /// <param name="epsilon">the accuracy desired</param>
        /// <param name="nmax">the maximum number of iterations you want the computer to attempt</param>
        RootObj BisectionMethod(double a, double b, Func<double, double> f, double epsilon, int nmax);


        /// <summary>
        /// Implement Newton's Method
        /// </summary>
        /// <param name="a">this is the initial condition</param>
        /// <param name="f">this is the function for which you want to find the root</param>
        /// <param name="fPrime">this is the derivative of the function for which you want to find the root</param>
        /// <param name="epsilon">the accuracy desired</param>
        /// <param name="nmax">the maximum number of iterations you want the computer to attempt</param>
        RootObj NewtonsMethod(double a, Func<double, double> f, Func<double, double> fPrime, double epsilon, int nmax);
    }
}
