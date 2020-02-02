using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using ToyRobotSimulator;
namespace ToyRobotSimulator.Tests
{
    [TestFixture]
    public class MapTests
    {
        [Test]
        public void IsValidCoordinates_ValidCordinates()
        {
            var map = new Map(10,10);
            var result = map.IsValidCoordinates(0, 0);
            Assert.True(result);
        }

        [Test, Sequential]
        public void IsValidCoordinates_InValidCordinates(
            [Values(0, -1, 0, 10, 10)] int x,
            [Values(-1, 0, 10, 0, 10)] int y)
        {
            var map = new Map(10, 10);
              var result = map.IsValidCoordinates(x,y);
            Assert.False(result);
        }


    }
}
