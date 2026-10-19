using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using практика_ис1;

namespace ProjectTests
{
    public class Class1
    {
        [Fact]
        public void Test1()
        {
            List<int> nums = new List<int>{1, 2, 3, 4, 5, 6};
            
            int result = Menu.GetSum(nums);

            Assert.Equal(0, result);
        }

        [Fact]
        public void Test2()
        {
            List<int> nums = new List<int> { -1, -2, -3, -4, -5, -6};
            
            int result = Menu.GetSum(nums);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test3()
        {
            List<int> nums = null;

            int result = Menu.GetSum(nums);
            Assert.Throws<ArgumentNullException>(() => Menu.GetSum(nums));
        }

        [Fact]
        public void Test4()
        {
            List<int> nums = new List<int> {1, -2, 3};

            int result = Menu.GetSum(nums);
            Assert.Equal(0, result);
        }
        [Fact]
        public void Test5()
        {
            List<int> nums = new List<int> {1, 2, 3, 4, 5, -6};

            int result = Menu.GetSum(nums);

            Assert.Equal(14, result);
        }

        [Fact]
        public void Test6()
        {
            List<int> nums = new List<int> {-1, 0, 0, 4};

            int result = Menu.GetSum(nums);

            Assert.Equal(0, result);
        }

        [Fact]
        public void Test7()
        {
            List<int> nums = new List<int> { 0, 0, 0, 0, 0}; ;

            int result = Menu.GetSum(nums);
            Assert.Throws<ArgumentException>(() => Menu.GetSum(nums));
        }

        [Fact]
        public void Test8()
        {
            List<int> nums = new List<int> { 3, 0, 0, -4 };

            int result = Menu.GetSum(nums);

            Assert.Equal(0, result);
        }

    }
}
