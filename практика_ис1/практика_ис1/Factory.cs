using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace практика_ис1
{
    public class Factory
    {
        public List<Point> points = new List<Point>();

        public Point CreateObject(string line)
        {
            line = CleanSpaces(line);
            string[] characteristic = line.Split(' ');

            string type = characteristic[0];

            if (type == "NamedPoint")
                return CreateNamedPoint(characteristic);
            if (type == "DatedPoint")
                return CreateDatedPoint(characteristic);
            if (type == "Point3D")
                return CreatePoint3D(characteristic);
            return CreatePoint(characteristic);
        }

        private (double x, double y, PointColor color) ParseBase(string[] characteristic)
        {
            double x = double.Parse(characteristic[1], CultureInfo.InvariantCulture);
            double y = double.Parse(characteristic[2], CultureInfo.InvariantCulture);
            PointColor color = (PointColor) Enum.Parse(typeof(PointColor),characteristic[3].Trim('"'), true);
            return (x, y, color);
        }
        //private void BasicProperties(Point point, string[] characteristic)
        //{
        //    point.X = double.Parse(characteristic[1], CultureInfo.InvariantCulture);
        //    point.Y = double.Parse(characteristic[2], CultureInfo.InvariantCulture);
        //    point.Color = characteristic[3].Trim('"');
        //}

        private Point CreatePoint(string[] characteristic)
        { 
            var (x, y, color) = ParseBase(characteristic);
            return new Point(x, y, color);
        }

        private NamedPoint CreateNamedPoint(string[] characteristic)
        {
            string name = characteristic[4].Trim('"');
            var (x, y, color) = ParseBase(characteristic);
            return new NamedPoint(x, y, color, name);
        }

        private DatedPoint CreateDatedPoint(string[] characteristic)
        {
            DateTime date = DateTime.ParseExact(characteristic[4], "yyyy.MM.dd", CultureInfo.InvariantCulture);
            var (x, y, color) = ParseBase(characteristic);
            return new DatedPoint(x, y, color, date);
        }

        private Point3D CreatePoint3D(string[] characteristic)
        {
            var (x, y, color) = ParseBase(characteristic);
            double z = double.Parse(characteristic[4], CultureInfo.InvariantCulture);
            int id = int.Parse(characteristic[5], CultureInfo.InvariantCulture);
            bool isSelected = bool.Parse(characteristic[6]);
            return new Point3D(x,y,color, z, isSelected, id);
        }

        public void PrintAll()
        {
            foreach (Point p in points)
            {
                Console.WriteLine(p.GetType().BaseType.Name + ":" + p.ToString());
            }
        }

        public void ReadFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                if (line.Trim() == "")
                    continue;
                AddObject(CreateObject(line));
            }
        }

        public void WriteFile(string path)
        {
            List<string> inform = new List<string>();
            foreach (Point p in points)
            {
                inform.Add(p.ToFile());
            }
            File.WriteAllLines(path, inform);
        }

        private string CleanSpaces(string line) 
        {
            while (line.Contains("  "))
            {
                line = line.Replace("  ", " ");
            }
            return line;
        }

        public void AddObject(Point point)
        {
            points.Add(point);
        }

        //public Line S(List<Point> points)
        //{
        //    double mini = 0;
        //    Line ans = null;
        //    for (int i = 0; i < points.Count; i++)
        //    {
        //        for (int i2 = 1; i2 < points.Count; i2++)
        //        {
        //            double Leight = Math.Sqrt((points[i].X) * (points[i2].X) + (points[i].Y) * (points[i2].Y));
        //            if (Leight > mini)
        //            {
        //                ans = new Line(); 
        //                ans.point1 = points[i];
        //                ans.point2 = points[i];
        //            }
        //        }
        //    }
        //    return ans;
        //}

        //public Line CreateLine(Point point1, Point point2)
        //{
        //    Line line1 = new Line();

        //    line1.point1 = point1;
        //    line1.point2 = point2;
        //    return line1;
        //}

    }
}
