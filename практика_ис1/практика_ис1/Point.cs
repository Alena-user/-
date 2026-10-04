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
        public double X;
        public double Y;
        public string Color;

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
