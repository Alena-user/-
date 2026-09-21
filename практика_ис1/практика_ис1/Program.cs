using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace практика_ис1
{
    internal class Program
    {
        public void Paint() 
        {

        }

        static void Main(string[] args)
        {
            

            string[] lines = File.ReadAllLines("C:\\Users\\USER\\-\\практика_ис1\\task3.txt");
            int count = lines.Length;
            int h = lines[0].Length;
            string str = string.Join("", lines);

            char[] mas = str.ToCharArray();
            char[,] m = new char[count, h];

            //int x1 = Convert.ToInt32(Console.ReadLine());
            //int y1 = Convert.ToInt32(Console.ReadLine());

            int ind = 0;
            for (int y = 0; y < count; y++)
            {
                for (int x = 0; x < h; x++) 
                {
                    if (ind < lines.Length)
                    {
                        m[y,x] = mas[ind];
                        ind++;
                        Console.WriteLine(m[y, x]);
                    }
                }
            }

        }
    }
}
