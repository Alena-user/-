using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using практика_ис1;

namespace ProjectTests
{
    public class TestNamedPoint
    {
        [Fact]
        public void ToString_ValidNamedPoint_ReturnRightString()
        {
            NamedPoint p = new NamedPoint(-5.3, 9.6, PointColor.Red, "A");
            string result = p.ToString();
            string expected = "X = -5,3, Y = 9,6, color = Red, name = A";
            Assert.Equal(expected, result);
        }
        [Fact]
        public void ToFile_ValidNamedPoint_ReturnRightString()
        {
            NamedPoint p = new NamedPoint(7.3, 9.1, PointColor.Green, "B");
            string result = p.ToFile();
            string expected = "NamedPoint: X = 7,3, Y = 9,1, color = Green, name = B";
            Assert.Equal(expected, result);
        }
    }
}
