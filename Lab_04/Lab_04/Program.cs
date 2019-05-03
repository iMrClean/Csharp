using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab_04
{
    class Program
    {
        /*
         * Написать приложение, выполняющее конвертацию суммы из одной валюты в другую.
         * Курсы валют программа должна читать в момент конвертации из файла quotes.csv.
         * 
         * Date;RUB;USD;EUR
         * 11.03.2018;1;62.63;73.18
         * 12.03.2018;1;62.64;72.85
         * 
         * Программа должна работать в режиме утилиты: все необходимые аргументы принимать на вход при запуске и в стандартный поток вывода писать результат.
         * Если произошла ошибка, то код возврата программы должен быть отличным от 0.
         * 
         * Пример 1. Указаны сумма, валюта, в которой задана эта сумма, валюта, в которую выполняется конвертация, а также дата, на курс валют на которую требуется использовать для конвертации.
         * Если на указанную дату курс валют в файле не задан, то требуется использовать наиболее актуальный курс к этой дате, т.е. наиболее поздний из предшествующих.
         * Если предшествующих нет, то взять первый из последующих. Если ни на одну дату не заданы курсы валют – вывести ошибку.
         * > 1237 USD RUB 11.03.2018
         * 70262,96 RUB
         * 
         * Пример 2. Если не указана дата, то должен быть использован самый актуальный курс валют.
         * > 183 EUR RUB
         * 13503.86 RUB
         * 
         * Пример 3. Если не указана валюта, в которую выполняется конвертация, то необходимо распечатать значения для всех имеющихся валют – каждое значение с новой строки
         * > 183 EUR
         * 13503,86 RUB
         * 215,48 USD
         * 
         * Пример 4. Если не указана валюта, в которую выполняется конвертация, но указана дата, то результат должен быть аналогичным примеру 3, но для указанной даты.
         * > 183 EUR 11.03.2018
         * 12906.97 RUB
         * 227.23 USD
         * 
         * Запуск программы осуществляется с помощью аргументов 1) цена 2) дата 3) валюта в которой задана сумма 4) валюта которую требуется использовать для конвертации
         */
        private static double cost;
        private static string convertFrom;
        private static string convertTo;
        private static DateTime date = new DateTime();

        static void Main(string[] args)
        {
            try
            {
                string filename = @"K:\Ideal\New\C#\Lab_04\Lab_04\Resources\quotes.csv";
                double result;

                FileManager readfile = new FileManager();
                readfile.ReadFromFile(filename);
                FillArgs(args);

                if (convertTo != null)
                {
                    result = readfile.ConvertValute(date, convertFrom, convertTo, cost);
                    Console.WriteLine(result.ToString("F2") + " " + convertFrom);
                }

                else
                {
                    if (convertFrom != "RUB")
                    {
                        result = readfile.ConvertValute(date, convertFrom, "RUB", cost);
                        Console.WriteLine(result.ToString("F2") + " RUB");
                    }
                    if (convertFrom != "USD")
                    {
                        result = readfile.ConvertValute(date, convertFrom, "USD", cost);
                        Console.WriteLine(result.ToString("F2") + " USD");
                    }
                    if (convertFrom != "EUR")
                    {
                        result = readfile.ConvertValute(date, convertFrom, "EUR", cost);
                        Console.WriteLine(result.ToString("F2") + " EUR");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(-1);
            }

            Console.Read();
            Environment.Exit(0);
        }

        private static void FillArgs(string[] args)
        {
            cost = Double.Parse(args[0]);
            convertFrom = args[1].ToUpper();
            if (args.Length > 2)
            {
                bool success = DateTime.TryParse(args[2], out date);

                if (success)
                {
                    Console.WriteLine("Converted args'{0}' to {1}.", args[2], date);
                }
                else
                {
                    convertTo = args[2].ToUpper();
                    Console.WriteLine("Converted args'{0}' to '{1}' ", args[2], convertTo);
                    if (args.Length == 4)
                    {
                        date = DateTime.Parse(args[3]);
                    }
                    else
                    {
                        date = new DateTime();
                        Console.WriteLine("Date is n't present == '{0}'", date);
                    }
                }
            }
            else
            {
                Console.WriteLine("Converted args'{0}', {1}.", args[0], args[1]);
            }
        }
    }
}
