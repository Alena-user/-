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
        //static List<Point> Neib(int X, int Y)
        //{ 
        //    List<Point> neiborns = new List<Point>();
        //    Point point_up = new Point();
            
        //    //neiborns.Add();
        //}
        static void Paint(List<Point> pointss) 
        {
            while(pointss.Count>0)
            {
                //pointss.RemoveAt[0];
                
            }
        }

        static void Main(string[] args)
        {
            Point main_point = new Point();
            main_point.X = double.Parse(Console.ReadLine());
            main_point.Y = double.Parse(Console.ReadLine());
             
            List<Point> pointss = new List<Point>();
            pointss.Add(main_point);

            string[] lines = File.ReadAllLines("C:\\Users\\USER\\-\\практика_ис1\\task3.txt");
            int count = lines.Length;
            int h = lines[0].Length;
            string str = string.Join("", lines);

            char[] mas = str.ToCharArray();
            char[,] m = new char[count, h];

            

            int ind = 0;
            for (int y = 0; y < count; y++)
            {
                for (int x = 0; x < h; x++) 
                {
                    if (ind < lines.Length)
                    {
                        m[y,x] = mas[ind];
                        ind++;
                    }
                }
            }
        }
    }
}



