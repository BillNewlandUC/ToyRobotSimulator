using System.Collections;
using NUnit.Framework;

namespace ToyRobotSimulator.Tests
{

    [TestFixture]
    public class ControllerTests
    {
        private IMap _map;
        private Robot _robot;

        [SetUp]
        public void Setup()
        {
            _map = new Map(5, 5);
            _robot = new Robot(_map);
        }

        [TearDown]
        public void TearDown()
        {
            _robot = null;
        }


        [Test]
        public void Run_Place_Invalid(
            [Values("PLACE 1\nREPORT","PLACE 1,3\nREPORT","PLACE 1,3,FOO\nREPORT")] string cmd
            )
        {
            var command = new Controller(_robot);            
            var actual = command.Run(cmd);
            Assert.IsEmpty(actual);
        }

        [TestCaseSource(typeof(MoveTestData), nameof(MoveTestData.TestCases))]
        public string Run_TestCases(string cmd)
        {
            var command = new Controller(_robot);
            return command.Run(cmd).ToUpper();
        }

    }


    public class MoveTestData
    {
        public static IEnumerable TestCases
        {

            get
            {
                yield return new TestCaseData("PLACE 0,0,NORTH\nMOVE\nREPORT").Returns($"0,1,NORTH\n").SetName("Simple move");
                yield return new TestCaseData($"PLACE 0,0,NORTH\nLEFT\nREPORT").Returns($"0,0,WEST\n").SetName("Simple turn");
                yield return new TestCaseData($"PLACE 1,2,EAST\nMOVE\nMOVE\nLEFT\nMOVE\nREPORT").Returns($"3,3,NORTH\n").SetName("Move and turn and move");
                yield return new TestCaseData($"PLACE 2,2,NORTH\nMOVE\nMOVE\nMOVE\nMOVE\nREPORT").Returns($"2,4,NORTH\n").SetName("Prevent falling off table");
                yield return new TestCaseData($"PLACE 2,2,NORTH\nFOO\nMOVE\nREPORT").Returns($"2,3,NORTH\n").SetName("Ignore bad command");
                yield return new TestCaseData($"PLACE 6,2,EAST\nMOVE\nMOVE\nLEFT\nMOVE\nREPORT").Returns(string.Empty).SetName("Bad placement of toy at 6,2");
                yield return new TestCaseData($"PLACE 2,2,NORTH\nMOVE\nMOVE\nMOVE\nPLACE 2,2,EAST\nMOVE\nREPORT").Returns($"3,2,EAST\n").SetName("Multiple place commands");
                yield return new TestCaseData($"PLACE 6,2,NORTH\nMOVE\nMOVE\nMOVE\nPLACE 2,2,EAST\nMOVE\nREPORT").Returns($"3,2,EAST\n").SetName("Multiple place commands with invalid first");
                yield return new TestCaseData($"PLACE 2,2,NORTH\nMOVE\nMOVE\nMOVE\nPLACE 6,2,EAST\nMOVE\nREPORT").Returns($"2,4,NORTH\n").SetName("Multiple place commands with invlaid second");
                yield return new TestCaseData($"PLACE 2,2,NORTH\nMOVE\nREPORT\nMOVE\nREPORT").Returns($"2,3,NORTH\n2,4,NORTH\n").SetName("Multiple report commands");
                yield return new TestCaseData("MOVE\nREPORT").Returns(string.Empty).SetName("No place command so ignore all following commands");
                yield return new TestCaseData("MOVE\nPLACE 2,2,NORTH\nMOVE\nREPORT").Returns("2,3,NORTH\n").SetName("Ignore commands before place command");
                yield return new TestCaseData($"PLACE 0,0,NORTH\nMOVE\nRIGHT\nMOVE\nRIGHT\nMOVE\nRIGHT\nMOVE\nREPORT").Returns($"0,0,WEST\n").SetName("Move in a clockwise cirle");
                yield return new TestCaseData($"PLACE 0,4,SOUTH\nMOVE\nLEFT\nMOVE\nLEFT\nMOVE\nLEFT\nMOVE\nREPORT").Returns($"0,4,WEST\n").SetName("Move in a anticlockwise cirle");

            }
        }
    }
}
