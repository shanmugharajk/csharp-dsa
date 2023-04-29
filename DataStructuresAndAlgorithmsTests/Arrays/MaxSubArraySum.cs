using DataStructuresAndAlgorithms.Arrays;
using NUnit.Framework;

namespace DataStructuresAndAlgorithmsTests.Arrays
{
    public class MaxSubArraySumTests
    {
        [Test]
        [TestCase(new[] {-2, 1, -3, 4, -1, 2, 1, -5, 4}, 6)]
        public void Sum(int[] nums, int expectedSum)
        {
            var sum = MaxSubArraySum.Sum(nums);
            Assert.That(sum, Is.EqualTo(expectedSum));
        }
    }
}