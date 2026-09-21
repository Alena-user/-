using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.ExceptionServices;

namespace практика_ис1
{
    internal class Program
    {
        public Point F(List<Point> points)
        {
            double mini = Math.Sqrt((points[0].X) * (points[0].X) + (points[0].Y) * (points[0].Y));
            double a = 0;
            Point answer = null;
            foreach (Point point1 in points)
            {
                a = Math.Sqrt((point1.X) * (point1.X) + (point1.Y) * (point1.Y));
                if (a < mini)
                {
                    mini = a;
                    answer = point1;
                }
            }
            return (answer);
        }

        
        static void Main(string[] args)
        {

            Factory factory = new Factory();
            if (args.Length == 2 && args[0] == "-f")
            {
                string fileName = args[1];
                string[] lines = File.ReadAllLines(fileName);

                for (int i = 0; i < lines.Length; i++)
                {
                    Point point = factory.CreateObject(lines[i]);
                    factory.AddObject(point);
                    Console.WriteLine($"Добавлена точка с координатами x = {point.X}, y = {point.Y} и цветом - {point.Color}");
                }
                return;
            }
              
            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Добавить новый объект.");
                Console.WriteLine("2. Вывести список всех объектов.");
                Console.WriteLine("3. Выход.\n");

                Console.WriteLine("Введите номер выбора");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите объект и его свойства (координаты точки и цвет)");
                        string line = Console.ReadLine();
                        factory.AddObject(factory.CreateObject(line));
                        break;

                    case 2:
                        foreach (Point point1 in factory.points)
                        {
                            Console.WriteLine($"X = {point1.X}; Y = {point1.Y}; Color = {point1.Color}");
                        }
                        break;
                    case 3:
                        return;

                }
                
            }
        }
    }
}
