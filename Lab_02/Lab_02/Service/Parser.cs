using Lab_02.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_02.Service
{
    class Parser : IParser
    {
        private readonly string _patternTag = @"(<\/?[a-z][a-z0-9]*>)";

        public List<XmlModel> ReadFile(string path)
        {
            try
            {
                var streamReader = new StreamReader(path);
                var file = streamReader.ReadToEnd();
                streamReader.Close();

                return ParseFile(file);

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        private List<XmlModel> ParseFile(string file)
        {
            if (file == null)
            {
                throw new ArgumentException(file);
            }
            var regexTag = new Regex(_patternTag);
            var matchTag = regexTag.Match(file);

            var resultModel = new List<XmlModel>();
            while (matchTag.Success)
            {
                var result = new XmlModel();
                result.Name = matchTag.Groups[1].Value;
                matchTag = matchTag.NextMatch();
                resultModel.Add(result);
            }

            return resultModel;
        }

        public void WriteFile(List<XmlModel> result, string path)
        {
            var streamWriter = new StreamWriter(path);
            foreach (var item in result)
            {
                streamWriter.WriteLine(item.Name);
            }
            streamWriter.Close();
        }
    }
}
