using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace практика_ис1
{
    public class FileManager
    {
        public string[] ReadLinesFromFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            return lines;
        }

        public void WriteLinesToFile(string path, List<string> lines)
        {
            File.WriteAllLines(path, lines);
        }
    }
}
