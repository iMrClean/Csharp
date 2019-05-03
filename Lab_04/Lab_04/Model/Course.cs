using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_04
{
    class Course
    {
        public DateTime Date { get; set; }
        public double RUB { get; set; }
        public double USD { get; set; }
        public double EUR { get; set; }

        public Course(string line)
        {
            string[] elementInLine = line.Split(';');
            if (elementInLine.Count() != 4)
            {
                throw new Exception("Wrong file format");
            }
            Date = DateTime.Parse(elementInLine[0]);
            RUB = Double.Parse(elementInLine[1]);
            USD = Double.Parse(elementInLine[2]);
            EUR = Double.Parse(elementInLine[3]);
        }
    }
}
