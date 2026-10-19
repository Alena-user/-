using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using практика_ис1;

namespace ProjectTests
{
    public class TestPoint3D
    {
        [Fact]
        public void ToString_ValidPoint3D_ReturnRightString()
        {
            Point3D p = new Point3D(5.0, 9.2, PointColor.Red, 4.6, true, 123);
            string result = p.ToString();
            string expected = "X = 5, Y = 9,2, color = Red, Z = 4,6, IsSelected = True, ID = 123";
            Assert.Equal(expected, result);
        }
        [Fact]
        public void ToFile_ValidPoint3D_ReturnRightString()
        {
            Point3D p = new Point3D(3.0, 6.2, PointColor.Green, 4.6, false, 1234);
            string result = p.ToFile();
            string expected = "Point3D: X = 3, Y = 6,2, Z = 4,6, color = Green, isSelected = False, id = 1234";
            Assert.Equal(expected, result);
        }
    }
}
