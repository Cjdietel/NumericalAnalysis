using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductoryProject
{
    public class Calcs : ICalcs
    {
        public double Discriminent(double a, double b, double c)
        {
            return (Math.Pow(b, 2) - (4 * a * c));
        }

        public string[] Quadratic(double a, double b, double c)
        {
            string[] results = new string[2];

            double discriminent = Discriminent(a, b, c);
            
            if (discriminent < 0)
            {
                results[0] = "No Solution";
                results[1] = "No Solution";
                return results;
            }

            results[0] = ((-b + Math.Sqrt(discriminent)) / (2 * a)).ToString();
            results[1] = ((-b - Math.Sqrt(discriminent)) / (2 * a)).ToString();
            return results;
        }
    }
}
