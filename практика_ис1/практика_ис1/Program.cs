using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace практика_ис1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string[] file = File.ReadAllLines("C:\\Users\\USER\\Desktop\\граф.txt");

            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            foreach (string line in file)
            {
                string replace_line = line.Replace("=>", "*");
                string[] s = replace_line.Split('*');
                List<string> list = new List<string>();
                List<string> list_out = new List<string>();
                list.Add(s[1]);

                if (!dict.ContainsKey(s[0]))
                {
                    dict.Add(s[0], list);
                }

                else if (!dict[s[0]].Contains(s[1]))
                {
                    dict[s[0]].Add(s[1]);
                }
                if (!dict.ContainsKey(s[1]))
                {
                    dict.Add(s[1], list_out);
                }
            }

            

            foreach (string key in dict.Keys)
            {
                Console.Write($"{key}:");

                foreach (string value in dict[key])
                {
                    Console.Write(value + " ");
                }
                Console.WriteLine();

            }

        }
    }
}



