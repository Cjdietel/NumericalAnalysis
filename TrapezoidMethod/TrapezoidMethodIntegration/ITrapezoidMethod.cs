using System;
using System.Collections.Generic;
using System.Text;

namespace TrapezoidMethodIntegration
{
    /// <summary>
    /// Implement this interface
    /// </summary>
   public interface ITrapezoidMethod
    {
        /// <summary>
        /// Use the Trapezoid Method with uniform spacing to 
        /// return the double value of the integral of
        /// f from x=a to x=b.
        /// </summary>
        /// <param name="a">intial x0 value</param>
        /// <param name="b">terminal xn value</param>
        /// <param name="f">the function being integrated</param>
        /// <param name="MaxError">the maximum error specified by the user</param>
        /// <param name="MaxSecondDerivative">the maximum value of the second 
        /// derivative over the interval a to b specified by the user</param>
        /// <returns></returns>
        double Trapezoid(double a, double b, Func<double, double> f, double MaxError, double MaxSecondDerivative);
    }
}
