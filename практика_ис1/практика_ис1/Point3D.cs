using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace практика_ис1
{
    public class Point3D: Point
    {
        public double Z;
        public bool IsSelected;
        public int ID;

        public override string ToString()
        {
            return base.ToString() + $", Z = {Z}, IsSelected = {IsSelected}, ID = {ID}";
        }

        public override string ToFile()
        {
            string x = X.ToString();
            string y = Y.ToString();
            return $"Point3D: X = {x}, Y = {y}, color = {Color}, Z = {Z}, IsSelected = {IsSelected}, ID = {ID}";
        }
    }
}
