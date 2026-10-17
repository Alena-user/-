using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace практика_ис1
{
    public class DatedPoint: Point
    {
        protected DateTime date;

        public DatedPoint(double x, double y, PointColor color, DateTime date) : base(x, y, color)
        {
            this.date = date;
        }

        public DateTime Date{  get{ return date; } }
        public override string ToString()
        {
            return base.ToString() + $", date = {date: yyyy.MM.dd}";
        }

        public override string ToFile()
        {
            string x_file = x.ToString();
            string y_file = y.ToString();
            string color_file = color.ToString();
            return $"DatedPoint: X = {x_file}, Y = {y_file}, color = {color_file}, date = {date: yyyy.MM.dd}";
        }
    }
}
