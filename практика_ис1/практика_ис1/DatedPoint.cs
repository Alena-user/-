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
        public DateTime Date;

        public override string ToString()
        {
            return base.ToString() + $", date = {Date}";
        }

        public override string ToFile()
        {
            string x = X.ToString();
            string y = Y.ToString();
            return $"DatededPoint: X = {x}, Y = {y}, color = {Color}, date = {Date}";
        }
    }
}
