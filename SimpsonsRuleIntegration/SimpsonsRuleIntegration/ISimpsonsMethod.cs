using System;
using System.Collections.Generic;
using System.Text;

namespace SimpsonsRuleIntegration
{
    public interface ISimpsonsMethod
    {
       /// <summary>
       /// Impelement the Composite Simpson's Rule. 
       /// Hard code the function. Then prompt the user 
       /// for a, b, the maximum allowable error, and the 
       /// maximum of the absolute value of the 
       /// fourth derivative. 
       /// </summary>
       /// <param name="a"></param>
       /// <param name="b"></param>
       /// <param name="f"></param>
       /// <param name="MaxError"></param>
       /// <param name="MaxFourthDerivative"></param>
       /// <returns></returns>
        double Simpsons(double a, double b, Func<double, double> f, double MaxError, double MaxFourthDerivative);
    }
}
