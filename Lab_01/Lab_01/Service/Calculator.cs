using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01.Service
{
    class Calculator : ICalculator
    {
        public double Plus(double a, double b)
        {
            return a + b;
        }

        public double Minus(double a, double b)
        {
            return a - b;
        }

        public double Mult(double a, double b)
        {
            return a * b;
        }

        public double Div(double a, double b)
        {
            return a / b;
        }

        public double Incr(double a)
        {
            return ++a;
        }

        public double Decr(double a)
        {
            return --a;
        }

        public double Sqrt(double a)
        {
            return Math.Sqrt(a);
        }
    }
}
