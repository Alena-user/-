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
        protected double z;
        protected bool isSelected;
        protected int id;

        public Point3D(double x, double y, PointColor color, double z, bool isSelected, int id) : base(x, y, color)
        {
            this.z = z;
            this.isSelected = isSelected;
            this.id = id;
        }
        public double Z { get { return z; } }
        public bool IsSelected { get { return isSelected; } }
        public int Id { get { return id; } }

        public override string ToString()
        {
            return base.ToString() + $", Z = {z}, IsSelected = {isSelected}, ID = {id}";
        }

        public override string ToFile()
        {
            string x_file = x.ToString();
            string y_file = y.ToString();
            string z_file = z.ToString();
            string id_file = id.ToString();
            string color_file = color.ToString();
            return $"Point3D: X = {x_file}, Y = {y_file}, Z = {z_file}, color = {color_file}, isSelected = {isSelected}, id = {id_file}";
        }
    }
}
