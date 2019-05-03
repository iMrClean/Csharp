using Lab_02.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.Service
{
    interface IParser
    {
        List<XmlModel>ReadFile(string path);

        void WriteFile(List<XmlModel> result, string path);
    }
}
