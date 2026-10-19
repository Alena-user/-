using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using практика_ис1;

namespace ProjectTests
{
    public class TestFactory
    {
        public readonly Factory _factory = new Factory();

        [Fact]
        public void CreateObject_ValidPoint_ReturnPoint()
        {
            string line = "Point 1.7 5.9 Red";
            Point p = _factory.CreateObject(line);

            Assert.Equal(1.7, p.X);
            Assert.Equal(5.9, p.Y);
            Assert.Equal(PointColor.Red, p.Color);
        }

        [Fact]
        public void CreateObject_ValidNamedPoint_ReturnNamedPoint()
        {
            string line = "NamedPoint 1.7 5.9 Red A";
            Point p = _factory.CreateObject(line);

            var named = Assert.IsType<NamedPoint>(p);
            Assert.Equal("A", named.Name);
        }

        [Fact]
        public void CreateObject_ValidDatedPoint_ReturnDatedPoint()
        {
            string line = "DatedPoint 1.9 2.9 Blue 2026.10.13";
            Point p = _factory.CreateObject(line);

            var dated = Assert.IsType<DatedPoint>(p);
            Assert.Equal(new DateTime(2026,10,13), dated.Date);
        }

        [Fact]
        public void CreateObject_ValidPoint3D_ReturnPoint3D()
        {
            string line = "Point3D 1 2 Green 3.5 42 true";
            Point p = _factory.CreateObject(line);

            var p3d = Assert.IsType<Point3D>(p);
            Assert.Equal(3.5, p3d.Z);
            Assert.True(p3d.IsSelected);
            Assert.Equal(42, p3d.Id);
        }
        [Fact]
        public void CreateObject_PointWithSpaces_ReturnPoint()
        {
            string line = "   Point      4.8  5.9  Blue";
            Point p = _factory.CreateObject(line);

            Assert.Equal(4.8, p.X);
            Assert.Equal(5.9, p.Y);
            Assert.Equal(PointColor.Blue, p.Color);
        }

        [Fact]
        public void AddObject_ValidPoint_AddsToList()
        {
            Point p = new Point(1, 2, PointColor.Red);

            _factory.AddObject(p);

            Assert.Single(_factory.points);
            Assert.Same(p, _factory.points[0]);
        }
    }
}
