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
        public enum Colors
        {
            Red,
            Green,
            Blue
        }

        protected double X;
        protected double Y;
        protected Colors Color;

        public Point(double x, double y, Colors color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        public override string ToString()
        {
            return $"X = {X}, Y = {Y}, color = {Color}";
        }

        public virtual string ToFile() 
        {
            string x = X.ToString();
            string y = Y.ToString();
            return $"Point: X = {x}, Y = {y}, color = {Color}";
        }
    }
}
