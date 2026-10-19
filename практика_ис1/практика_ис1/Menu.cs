using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;


namespace практика_ис1
{
    [ExcludeFromCodeCoverage]
    public class Menu
    {
        private Factory factory;
        private FileManager fileManager;
        private List<MenuItem> menuItems;
        public Menu(Factory factory, FileManager fileManager)
        {
            this.factory = factory;
            this.fileManager = fileManager;
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            
            menuItems = new List<MenuItem>
        {
            new MenuItem(1, "Добавление объекта через консоль", ReadFromConsole),
            new MenuItem(2, "Вывод списка всех объектов", factory.PrintAll), 
            new MenuItem(3, "Чтение из файла", LoadFromFile),
            new MenuItem(4, "Запись в файл", SaveToFile),
            new MenuItem(5, "Выход", ) 
        };
        }
        public void Run()
        {
            while (true)
            {
                PrintMenu();
                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Logger.Instance.LogError("Для выбора введите число от 1 до 5");
                    //Console.WriteLine("Для выбора введите число от 1 до 5");
                    continue;
                }
                MenuItem selectedItem = menuItems.Find(item => item.Id == choice);
                selectedItem.Method();
                //switch (choice)
                //{
                //    case 1:
                //        ReadFromConsole();
                //        break;
                //    case 2:
                //        factory.PrintAll();
                //        break;
                //    case 3:
                //        LoadFromFile();
                //        break;
                //    case 4:
                //        SaveToFile();
                //        break;
                //    case 5:
                //        return;
                //    default:
                //        Console.WriteLine("Такого пункта нет в меню");
                //        break;
                //}
            }
        }
        private void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Выберите пункт из меню:");
            foreach (MenuItem item in menuItems)
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
            Console.Write("Ваш выбор: ");
        }

        private void ReadFromConsole()
        {
            Console.Write("Введите данные через пробел в формате: тип точки(Point/ NamedPoint/ DatedPoint/ Point3D), x, y, color, name(для NamedPoint), date(для DatedPoint), (z, id, isSelected) - для Point3D: ");
            string description = Console.ReadLine();
            try
            {
                factory.AddObject(factory.CreateObject(description));
                Console.WriteLine("Объект успешно добавлен");
            }
            catch (FormatException e)
            {
                Logger.Instance.LogError("Ошибка формата: " + e.Message);
                //Console.WriteLine("Ошибка формата: " + e.Message);
            }
            catch (ArgumentException e)
            {
                Logger.Instance.LogError("Ошибка значения: " + e.Message);
                //Console.WriteLine("Ошибка значения: " + e.Message);
            }
            
        }

        private void LoadFromFile()
        {
            Console.Write("Введите путь к файлу: ");
            string path = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine("Путь не должен быть пустым");
                return;
            }
            try
            {
                string[] lines = fileManager.ReadLinesFromFile(path);
                int loaded = 0, skipped = 0;
                foreach (string line in lines)
                {
                    if (line.Trim() == "")
                        continue;
                    try
                    {
                        factory.AddObject(factory.CreateObject(line));
                        loaded++;
                    }
                    catch (FormatException e)
                    {
                        Logger.Instance.LogError("Строка пропущена, так как:" + e.Message);
                        //Console.WriteLine("Строка пропущена, так как: " + e.Message);
                        skipped++;
                    }
                    catch (ArgumentException e)
                    {
                        Logger.Instance.LogError("Строка пропущена, так как:" + e.Message);
                        //Console.WriteLine("Строка пропущена, так как: " + e.Message);
                        skipped++;
                    }
                }
                Console.WriteLine($"Удалось загрузить {loaded} строк, пропущено {skipped} строк");
            }
            catch (FileNotFoundException)
            {
                Logger.Instance.LogError("По этому пути файл не найден");
                //Console.WriteLine("По этому пути файл не найден");
            }
            catch (IOException e)
            {
                Logger.Instance.LogError("Ошибка чтения файла: " + e.Message);
                //Console.WriteLine("Ошибка чтения файла: " + e.Message);
            }
        }
        private void SaveToFile()
        {
            Console.Write("Введите путь к файлу: ");
            string path = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine("Путь не должен быть пустым");
                return;
            }
            try 
            {
                List<string> infomationForFile = new List<string>();

                foreach (Point p in factory.points)
                {
                    infomationForFile.Add(p.ToFile());
                }
                fileManager.WriteLinesToFile(path, infomationForFile);
                Console.WriteLine("Данные записаны в файл успешно");
            }
            catch (UnauthorizedAccessException e)
            {
                Logger.Instance.LogError("Нет прав на запись: " + e.Message);
                //Console.WriteLine("Нет прав на запись: " + e.Message);
            }
            catch (IOException e)
            {
                Logger.Instance.LogError("Ошибка записи в файл: " + e.Message);
                //Console.WriteLine("Ошибка записи в файл: " + e.Message);
            }
        }
        public static int GetSum([NotNull] List<int> nums)
        {
            throw new NotImplementedException();
        }

    }
}
