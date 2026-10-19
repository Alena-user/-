using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using практика_ис1;

namespace ProjectTests
{
    public class TestExceptionsFactory
    {
        private readonly Factory _factory = new Factory();
        [Fact]
        public void CreateObject_NullLine_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _factory.CreateObject(null));
        }

        [Fact]
        public void CreateObject_EmptyOrWhitespaceLine_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => _factory.CreateObject(""));
        }

        [Theory]
        [InlineData("Point")]
        [InlineData("Point 2.4")]
        [InlineData("Point 1.5 2.7")]
        public void CreateObject_FewFields_ThrowsFormatException(string line)
        {
            Assert.Throws<FormatException>(() => _factory.CreateObject(line));
        }

        [Theory]
        [InlineData("WrongType 1 2 red")]
        [InlineData("point 1 2 red")]
        public void CreateObject_UnknownType_ThrowsFormatException(string line)
        {
            Assert.Throws<FormatException>(() => _factory.CreateObject(line));
        }

        [Theory]
        [InlineData("Point abc 2 red")]          
        [InlineData("Point 1 abc red")]          
        public void CreateObject_InvalidXY_ThrowsFormatException(string line)
        {
            Assert.Throws<FormatException>(() => _factory.CreateObject(line));
        }

        [Fact]
        public void CreateObject_InvalidColor_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _factory.CreateObject("Point 4.6 2.6 Purple"));
        }

        [Fact]
        public void CreateObject_NamedPointWithoutName_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => _factory.CreateObject("NamedPoint 1.4 5.8 red"));
        }


        [Fact]
        public void CreateObject_DatedPointWithBadDate_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => _factory.CreateObject("DatedPoint 5.2 2 Green 2026-05-17"));
        }


        [Fact]
        public void CreateObject_Point3DFewFields_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => _factory.CreateObject("Point3D 5.8 3.2 Blue 3.5 true"));
        }

        [Fact]
        public void CreateObject_Point3DBadZ_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => _factory.CreateObject("Point3D 6.1 5.2 Blue abc true 1242"));
        }

        [Fact]
        public void CreateObject_Point3DInvalidBool_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => _factory.CreateObject("Point3D 9.8 4.2 Green 3.5 bool 1342"));
        }

        [Fact]
        public void CreateObject_Point3DNonNumericId_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => _factory.CreateObject("Point3D 7.7 2.8 Red 3.5 true abc"));
        }
    }
}
