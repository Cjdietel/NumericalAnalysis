using System;
using System.Collections.Generic;
using System.Text;

namespace DifferentialEquationSolver
{
    interface IDEMethods
    {
        /// <summary>
        /// This is where you store the solution of your differential equation.
        /// Note that I want to see the intermediate steps and the solution x(t) 
        /// for some user specified t. Store the intermediate steps in the 
        /// DESolutionVector as (t,x) pairs and the final answer in the DEAnswer
        /// </summary>
        double[,] DESolutionVector { get; set; }
        double DEAnswer { get; set; }


        /// <summary>
        /// Use the Euler Method to solve the differential equation.
        /// The user will specify a, b, n and x0=x(t0) at run time.
        /// </summary>
        /// <param name="t0">initial time t</param>
        /// <param name="tf">terminal time t</param>
        /// <param name="n">number of steps</param>
        /// <param name="x0">the y value of the intial conditions which occurs at the intial time t=a</param>
        /// f(t,x) is a runction which needs 
        /// double t and double x and returns a double. It is the 
        /// formula for the right hand side of your differential 
        /// equation.
        /// <returns></returns>

        void Euler(double t0, double tf, int n, double x0, Func<double, double, double> f);


        /// <summary>
        /// Use the Euler Method to solve the differential equation.
        /// The user will specify a, b, n and x0=x(t0) at run time.
        /// </summary>
        /// <param name="t0">initial time t</param>
        /// <param name="tf">terminal time t</param>
        /// <param name="n">number of steps</param>
        /// <param name="x0">a double representing the value x(t0) - the initial x value</param>
        /// <param name="f">the right hand side of the differential equation x'=f(t,x)</param>
        /// f(t,x) is a function which needs 
        /// double t and double x and returns a double. It is the 
        /// formula for the right hand side of your differential 
        /// equation and x''=fDP is the first derivative of f, x'''=fTP is the second
        /// derivative of f, x''''=fFP is the third derivative of f.
        /// <returns></returns>

        void Euler4(double t0, double tf, int n, double x0, Func<double, double, double> f,
            Func<double, double, double> fDP,
            Func<double, double, double> fTP, Func<double, double, double> fFP);

        /// <summary>
        /// The fourth order Runge Kutta method to solve an ordinary 
        /// differential equation. Do not change anything in this 
        /// interface class. Implement this interface for the Runge Kutta Method
        /// </summary>
        /// <param name="t0">a double representing the initial value of t</param>
        /// <param name="tf">a double representing the final value of t</param>
        /// <param name="n">n is the number of iterations</param>
        /// <param name="x0">a double representing the value x(t0) - the initial x value</param>
        /// <param name="f">the right hand side of the differential equation x'=f(t,x)</param>
        void RK(double t0, double tf, int n, double x0, Func<double, double, double> f);
    }
}
