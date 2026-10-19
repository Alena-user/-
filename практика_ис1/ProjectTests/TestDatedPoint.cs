using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using практика_ис1;

namespace ProjectTests
{
    public class TestDatedPoint
    {
        [Fact]
        public void ToString_ValidDatedPoint_ReturnRightString()
        {
            DateTime date = new DateTime(2026, 10, 10);
            DatedPoint p = new DatedPoint(-5.3, -9.6, PointColor.Green, date);
            string result = p.ToString();
            string expected = "X = -5,3, Y = -9,6, color = Green, date =  2026.10.10";
            Assert.Equal(expected, result);
        }
        [Fact]
        public void ToFile_ValidDatedPoint_ReturnRightString()
        {
            DateTime date = new DateTime(2026, 10, 12);
            DatedPoint p = new DatedPoint(7.3, 2.6, PointColor.Blue, date);
            string result = p.ToFile();
            string expected = "DatedPoint: X = 7,3, Y = 2,6, color = Blue, date =  2026.10.12";
            Assert.Equal(expected, result);
        }
    }
}
