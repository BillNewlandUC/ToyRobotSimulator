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

        [Test]
        public void Left_Valid()
        {
            var robot = new Robot(_map);
            robot.Place(0,0, Direction.North);
            robot.Left();
            var actual = robot.Report();
            Assert.AreEqual(Direction.West, actual.Direction);
        }

        [Test]
        public void Left_NotPlaced()
        {
            var robot = new Robot(_map);           
            robot.Left();
            var actual = robot.Report();
            Assert.IsNull(actual);
        }

        [Test]
        public void Right_Valid()
        {
            var robot = new Robot(_map);
            robot.Place(0, 0, Direction.West);
            robot.Right();
            var actual = robot.Report();
            Assert.AreEqual(Direction.North, actual.Direction);
        }

        [Test]
        public void Right_NotPlaced()
        {
            var robot = new Robot(_map);
            robot.Right();
            var actual = robot.Report();
            Assert.IsNull(actual);
        }

        [Test]
        public void Move_Valid()
        {
            var robot = new Robot(_map);
            robot.Place(2, 2, Direction.North);
            robot.Move();
            var expected = JsonSerializer.Serialize(new Location { Direction = Direction.North, X = 2, Y = 3 });
            var actual = JsonSerializer.Serialize(robot.Report());
            Assert.AreEqual(expected, actual);

        }


        [Test,Sequential]
        public void Move_Invalid(
            [Values(Direction.North,Direction.East,Direction.South,Direction.West)] Direction direction,
            [Values(0,4,0,0)] int x,
            [Values(4,0,0,0)] int y
            )
        {
            var robot = new Robot(_map);
            robot.Place(x,y,direction);
            robot.Move();
            var expected = JsonSerializer.Serialize(new Location { Direction = direction, X = x, Y = y });
            var actual = JsonSerializer.Serialize(robot.Report());
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Move_NotPlaced()
        {
            var robot = new Robot(_map);           
            robot.Move();
            var result = robot.Report();
            Assert.IsNull(result);
        }

    }
}
