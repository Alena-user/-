using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace практика_ис1
{
    public class Point
    {
        protected double x;
        protected double y;
        protected PointColor color;

        public Point(double x, double y, PointColor color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }

        public double X { get{ return x; } }
        public double Y { get { return y; } }
        public PointColor Color { get { return color; } }

        public override string ToString()
        {
            return $"X = {x}, Y = {y}, color = {color}";
        }

        public virtual string ToFile() 
        {
            string x_file = x.ToString();
            string y_file = y.ToString();
            string color_file = color.ToString();
            return $"Point: X = {x_file}, Y = {y_file}, color = {color_file}";
        }
    }
}
