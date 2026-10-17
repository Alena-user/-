using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace практика_ис1
{
    public class NamedPoint: Point
    {
        protected string name;

        public NamedPoint(double x, double y, PointColor color, string name) : base(x, y, color)
        {
            this.name = name;
        }

        public string Name {  get { return name; } }
        public override string ToString()
        {
            return base.ToString() + $", name = {name}";
        }

        public override string ToFile()
        {
            string x_file = x.ToString();
            string y_file = y.ToString();
            string color_file = color.ToString();
            return $"NamedPoint: X = {x_file}, Y = {y_file}, color = {color_file}, name = {name}";
        }
    }
}
