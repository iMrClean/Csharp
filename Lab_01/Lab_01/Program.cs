using Lab_01.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01
{
    class Program
    {
        /*
         * Лабораторная работа №1
         * Написать консольный калькулятор, который умеет выполнять основные 4 арифметических действия
         * И ещё какие-нибудь унарные операции.
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Доступные операции:");
            Console.WriteLine("+, -, *, /, ++, --, sqr");
            Console.WriteLine("Введите первое число");
            var firstNumber = Console.ReadLine();
            Console.WriteLine("Введите знак операции");
            var sign = Console.ReadLine();
            var result = Utils.Utils.Calculate(firstNumber, sign);
            Console.WriteLine("Результат операции:" + result);
            Console.Read();
        }
    }
}
