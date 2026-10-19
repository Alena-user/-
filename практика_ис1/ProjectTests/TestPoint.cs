using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using практика_ис1;
using Xunit;

namespace ProjectTests
{
    public class TestPoint
    {
        [Fact]
        public void ToString_ValidPoint_ReturnRightString()
        {
            Point p = new Point(2.3, 3.6, PointColor.Red);
            string result = p.ToString();
            string expected = "X = 2,3, Y = 3,6, color = Red";
            Assert.Equal(expected, result);
        }
        [Fact]
        public void ToFile_ValidPoint_ReturnRightString()
        {
            Point p = new Point(7.3, -2.6, PointColor.Blue);
            string result = p.ToFile();
            string expected = "Point: X = 7,3, Y = -2,6, color = Blue";
            Assert.Equal(expected, result);
        }
    }
}
