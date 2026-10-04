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
            Factory factory = new Factory();

            while (true)
            {
                PrintMenu();
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ReadFromConsole(factory);
                        break;
                    case 2:
                        factory.PrintAll();
                        break;
                    case 3:
                        ReadFromFile(factory);
                        break;
                    case 4:
                        WriteToFile(factory);
                        break;
                    case 5:
                        return;
                }
            }
            
            //string[] file = File.ReadAllLines("C:\\Users\\USER\\Desktop\\граф.txt");

            //Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            //foreach (string line in file)
            //{
            //    string replace_line = line.Replace("=>", "*");
            //    string[] s = replace_line.Split('*');
            //    List<string> list = new List<string>();
            //    List<string> list_out = new List<string>();
            //    list.Add(s[1]);

            //    if (!dict.ContainsKey(s[0]))
            //    {
            //        dict.Add(s[0], list);
            //    }

            //    else if (!dict[s[0]].Contains(s[1]))
            //    {
            //        dict[s[0]].Add(s[1]);
            //    }
            //    if (!dict.ContainsKey(s[1]))
            //    {
            //        dict.Add(s[1], list_out);
            //    }
            //}

            

            //foreach (string key in dict.Keys)
            //{
            //    Console.Write($"{key}:");

            //    foreach (string value in dict[key])
            //    {
            //        Console.Write(value + " ");
            //    }
            //    Console.WriteLine();

            //}

        }

        static void PrintMenu()
        {
            Console.WriteLine("Выберите пункт из меню:");
            Console.WriteLine("1. Добавление объекта через консоль");
            Console.WriteLine("2. Вывод списка всех объектов");
            Console.WriteLine("3. Чтение из файла");
            Console.WriteLine("4. Запись в файл");
            Console.WriteLine("5. Выход");
            Console.Write("Ваш выбор: ");
        }

        static void ReadFromConsole(Factory factory)
        {
            Console.Write("Введите данные через пробел в формате: тип точки(Point/ NamedPoint/ DatedPoint), x, y, color, name(для NamedPoint), date(для DatedPoint)");
            string description = Console.ReadLine();
            factory.AddObject(factory.CreateObject(description));
        }

        static void ReadFromFile(Factory factory)
        {
            Console.Write("Введите путь к файлу:");
            string path = Console.ReadLine();
            factory.ReadFile(path);
        }
        static void WriteToFile(Factory factory)
        {
            Console.Write("Введите путь к файлу:");
            string path = Console.ReadLine();
            factory.WriteFile(path);
        }
    }
}



