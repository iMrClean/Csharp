using Lab_01.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01.Utils
{
    class Utils
    {
        public static double Calculate(string firstNumber, string sign)
        {
            ICalculator calc = new Calculator();
            double result = 0;

            if (sign.Equals("+") || sign.Equals("-") || sign.Equals("*") || sign.Equals("/"))
            {
                Console.WriteLine("Введите второе число");
                var secondNumber = Console.ReadLine();
                switch (sign)
                {
                    case "+":
                        result = calc.Plus(Convert.ToDouble(firstNumber), Convert.ToDouble(secondNumber));
                        break;
                    case "-":
                        result = calc.Minus(Convert.ToDouble(firstNumber), Convert.ToDouble(secondNumber));
                        break;
                    case ("*"):
                        result = calc.Mult(Convert.ToDouble(firstNumber), Convert.ToDouble(secondNumber));
                        break;
                    case ("/"):
                        result = calc.Div(Convert.ToDouble(firstNumber), Convert.ToDouble(secondNumber));
                        break;
                }
            }
            else if (sign.Equals("++") || sign.Equals("--") || sign.Equals("sqrt"))
            {
                switch (sign)
                {
                    case ("++"):
                        result = calc.Incr(Convert.ToDouble(firstNumber));
                        break;
                    case ("--"):
                        result = calc.Decr(Convert.ToDouble(firstNumber));
                        break;
                    case ("sqrt"):
                        result = calc.Sqrt(Convert.ToDouble(firstNumber));
                        break;
                }
            }

            return result;
        }
    }
}
