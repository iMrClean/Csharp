using Lab_02.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    class Program
    {
        /*
         * Лабораторная работа №2.
         * 
         * Написать примитивный парсер xml-файлов.
         * Программа должна уметь прочитать xml-файл и записать обратно на диск.
         * !Перед запуском указать путь.
         */

        static void Main(string[] args)
        {
            string FilenameIn = "text.xml";

            string FilenameOut ="textout.xml";

            IParser parser = new Parser();
            Console.WriteLine("Считывание файла {0}", FilenameIn);
            var result = parser.ReadFile(FilenameIn);

            Console.WriteLine("Запись в файл {0}", FilenameOut);
            parser.WriteFile(result, FilenameOut);
        }
    }
}
