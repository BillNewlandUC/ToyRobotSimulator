using NUnit.Framework;
using System.Text.Json;

namespace ToyRobotSimulator.Tests
{
    [TestFixture]
    public class RobotTests
    {
        private IMap _map;

        [SetUp]
        public void Setup()
        {
            _map = new Map(5, 5);
        }

        [Test]
        public void Place_ValidCoordinates()
        {
            var robot = new Robot(_map);
            Assert.True(robot.Place(0, 0, Direction.North));
        }

        [Test, Sequential]
        public void Place_InValidCoordinates(
            [Values(0, -1, 0, 5, 5)] int x,
            [Values(-1, 0, 5, 0, 5)] int y)
        {
            
            var robot = new Robot(_map);
            Assert.False(robot.Place(x, y, Direction.North));
        }

        [Test]
        public void PlaceReport_Match()
        {
            var robot = new Robot(_map);
            robot.Place(2, 2, Direction.South);
            var expected = JsonSerializer.Serialize(new Location { Direction = Direction.South, X = 2, Y = 2 });
            var actual = JsonSerializer.Serialize(robot.Report());
            Assert.AreEqual(expected, actual);
        }

        [Test, Sequential]
        public void PlaceReport_InvalidCoordinates(
            [Values(0, -1, 0, 5, 5)] int x,
            [Values(-1, 0, 5, 0, 5)] int y)
        {
            var robot = new Robot(_map);
            robot.Place(x,y, Direction.South);
            var result = robot.Report();
            Assert.IsNull(result);
        }

        
    }
}
