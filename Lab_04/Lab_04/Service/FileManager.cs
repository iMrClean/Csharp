using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_04
{
    class FileManager
    {
        private Boolean header = true;

        private List<Course> courses = new List<Course>();

        public void ReadFromFile(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                if (!header)
                {
                    courses.Add(new Course(line));
                }
                else
                {
                    header = false;
                }
            }
        }

        public double ConvertValute(DateTime date, string from, string to, double value)
        {
            Course nearestPrev = null;
            Course nearestNext = null;
            Course useRow = null;
            bool wasFound = false;
            double result = value;

            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].Date < date)
                {
                    nearestPrev = courses[i];
                }
                else if (courses[i].Date > date)
                {
                    nearestNext = courses[i];
                }
                if (courses[i].Date == date)
                {
                    wasFound = true;
                    useRow = courses[i];
                    break;
                }
            }

            if (!wasFound)
            {
                if (nearestPrev != null)
                {
                    useRow = nearestPrev;
                }
                else if (nearestNext != null)
                {
                    useRow = nearestNext;
                }
            }

            if (from == "RUB")
            {
                result = result * useRow.RUB;
            }
            else if (from == "USD")
            {
                result = result * useRow.USD;
            }
            else if (from == "EUR")
            {
                result = result * useRow.EUR;
            }

            if (to == "RUB")
            {
                result = result / useRow.RUB;
            }
            else if (to == "USD")
            {
                result = result / useRow.USD;
            }
            else if (to == "EUR")
            {
                result = result / useRow.EUR;
            }

            return result;
        }
    }
}
