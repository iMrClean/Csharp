using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01.Service
{
    interface ICalculator
    {
        double Plus(double a, double b);

        double Minus(double a, double b);

        double Mult(double a, double b);

        double Div(double a, double b);

        double Incr(double a);

        double Decr(double a);

        double Sqrt(double a);
    }
}
