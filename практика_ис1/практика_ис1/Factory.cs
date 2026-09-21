using System;
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
            while (line.Contains("  "))
            {
                line = line.Replace("  ", " ");
            }
            string[] characteristic = line.Split(' ');
            Point point = new Point();
            point.X = double.Parse(characteristic[characteristic.Length - 3], CultureInfo.InvariantCulture);
            point.Y = double.Parse(characteristic[characteristic.Length - 2], CultureInfo.InvariantCulture);
            point.Color = characteristic[characteristic.Length - 1].Trim('"');

            return point;
        }
        
        public Line CreateLine(Point point1, Point point2)
        {
            Line line1 = new Line();
            
            line1.point1 = point1;
            line1.point2 = point2;
            return line1;
        }

        public Line S(List<Point> points)
        {
            double mini = 0;
            Line ans = null;
            for (int i = 0; i < points.Count; i++)
            {
                for (int i2 = 1; i2 < points.Count; i2++)
                {
                    double Leight = Math.Sqrt((points[i].X) * (points[i2].X) + (points[i].Y) * (points[i2].Y));
                    if (Leight > mini)
                    {
                        ans = new Line(); 
                        ans.point1 = points[i];
                        ans.point2 = points[i];
                    }
                }
            }
            return ans;
        }

        public void AddObject(Point point)
        {
            points.Add(point);
        }
    }
}
