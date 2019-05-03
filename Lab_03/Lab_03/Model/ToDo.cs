using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_03.Model
{
    class ToDo
    {
        public long Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
    }
}
