using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace практика_ис1
{
    public class NamedPoint: Point
    {
        public string Name;

        public override string ToString()
        {
            return base.ToString() + $", name = {Name}";
        }

        public override string ToFile()
        {
            string x = X.ToString();
            string y = Y.ToString();
            return $"NamedPoint: X = {x}, Y = {y}, color = {Color}, name = {Name}";
        }
    }
}
