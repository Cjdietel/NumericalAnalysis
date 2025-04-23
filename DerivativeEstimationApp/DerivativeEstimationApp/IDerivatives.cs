namespace DerivativeEstimationApp
{
    public interface IDerivatives
    {
        /// <summary>
        /// These are parts of the Derivative Estimate Object. Note that
        /// DerEstimate is the estimated derivative at the point given
        /// 
        /// h is the value used to specify the "half the length" of the interval.
        /// Note that the interval is (x-h,x+h). You will calculate this h 
        /// in your program. You should use the 
        /// value epsilon to calculate h by first solving the equation
        /// 
        /// ((1.0/6.0)*(maxFTriplePrime*(1/2^n)^2)<=epsilon
        /// 
        /// for n. Note that you will need to round up if you get a decimal
        /// value when trying to calculate n. Do this using the ceiling function.
        /// Use this integer n to calculate 
        /// 
        /// h = 1.0/(2.0^n)
        /// 
        /// Error is calculated using the error formula 
        /// for the central difference method along with the h
        /// calculated above, and the maxFTriplePrime specified
        /// by the user.
        /// 
        /// Don't change this part of the program.
        /// </summary>
        double DerEstimate { get; set; }
        double h { get; set; }
        double Error { get; set; }


        /// <summary>
        /// This should approximate the derivative of f using the 
        /// central difference formula. The Derivative object includes the 
        /// approximate derivative, the approximate error of that derivative, 
        /// and the value h used for this computation. 
        /// 
        /// Use this calculated h, the passed in value x, and the function f to 
        /// calculate the approximate derivative. Set the approximate derivative
        /// to the DerEstimate in the derivative object. 
        /// 
        /// </summary>
        /// <param name="x"> the x value that you wish to evaluate the derivative at</param>
        /// <param name="hInitial"> an initial guess for h for the Taylor approximation</param>
        /// <param name="epsilon">maximum allowable error determined by the user</param>
        /// <param name="maxFTriplePrime"> maximum of the third derivative on the interval - used
        /// in the error estimate. For sinx and cosx this is 1.</param>
        /// <returns></returns>

        void Derivative(double x, Func<double, double> f, double epsilon, double maxFTriplePrime);
    }
}
