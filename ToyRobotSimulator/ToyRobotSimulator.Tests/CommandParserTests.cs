using System;
using System.Collections;
using NUnit.Framework;

namespace ToyRobotSimulator.Tests
{

    [TestFixture]
    public class CommandParserTests
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
            var command = new CommandParser(_robot);            
            var actual = command.Run(cmd);
            Assert.IsEmpty(actual);
        }

        [TestCaseSource(typeof(RobotDataClass), "TestCases")]
        public string Run_TestCases(string cmd)
        {
            var command = new CommandParser(_robot);
            return command.Run(cmd).ToUpper();
        }

    }


    public class RobotDataClass
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData("PLACE 0,0,NORTH\nMOVE\nREPORT").Returns($"0,1,NORTH\n");
                yield return new TestCaseData($"PLACE 0,0,NORTH\nLEFT\nREPORT").Returns($"0,0,WEST\n");
                yield return new TestCaseData($"PLACE 1,2,EAST\nMOVE\nMOVE\nLEFT\nMOVE\nREPORT").Returns($"3,3,NORTH\n");

            }
        }
    }
}
