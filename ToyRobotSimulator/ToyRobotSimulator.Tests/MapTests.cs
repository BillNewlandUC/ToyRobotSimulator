using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using ToyRobotSimulator;

namespace ToyRobotSimulator.Tests
{
    [TestFixture]
    public class MapTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsValidCoordinates_ValidCordinates()
        {
            var map = new Map(10,10);
            var result = map.IsValidCoordinates(0, 0);
            Assert.True(result);
        }

        [Test]
        public void IsValidCoordinates_InValidXCordinates()
        {
            var map = new Map(10, 10);
            // The map is zero-indexed so 10 is off the map
            var result = map.IsValidCoordinates(10, 0);
            Assert.False(result);
        }


        [Test]
        public void IsValidCoordinates_InValidYCordinates()
        {
            var map = new Map(10, 10);
            var result = map.IsValidCoordinates(0, 10);
            Assert.False(result);
        }

        [Test]
        public void IsValidCoordinates_InValidXYCordinates()
        {
            var map = new Map(10, 10);
            var result = map.IsValidCoordinates(10, 10);
            Assert.False(result);
        }

        [Test]
        public void IsValidCoordinates_NegativeXCordinate()
        {
            var map = new Map(10, 10);
            var result = map.IsValidCoordinates(-1, 0);
            Assert.False(result);
        }

        [Test]
        public void IsValidCoordinates_NegativeYCordinate()
        {
            var map = new Map(10, 10);
            var result = map.IsValidCoordinates(0,-1);
            Assert.False(result);
        }

    }
}
