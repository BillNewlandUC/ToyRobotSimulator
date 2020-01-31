using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ToyRobotSimulator
{
    public class CommandParser
    {
        public readonly Robot _robot;
        public CommandParser(Robot robot)
        {
            _robot = robot;
        }

        /// <summary>
        /// Takes an arbitary string of commands seperated by line breaks
        /// and issues them to the robot
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public string Run(string commandText)
        {
            var command = "";
            var output = new StringBuilder();
            var lines = commandText.Split(Environment.NewLine);
            foreach(var line in lines)
            {
                var parts = Regex.Match(line, @"(?<cmd>\w+)( (?<x>\d+ ?),(?<y> ?\d+ ?),(?<direction> ?\w+))?");
                command = parts.Groups["cmd"].Value.ToUpper();
                switch (command)
                {
                    case "MOVE":
                        _robot.Move();
                        break;
                    case "PLACE":
                        var x = -1;
                        var y = -1;
                        object direction = Direction.North;
                        if (int.TryParse(parts.Groups["x"].Value, out x) &&
                                int.TryParse(parts.Groups["y"].Value, out y) &&
                                Enum.TryParse(typeof(Direction), parts.Groups["direction"].Value, true, out direction))
                        {
                            _robot.Place(x, y, (Direction)direction);
                        }
                        break;
                    case "LEFT":
                        _robot.Left();
                        break;
                    case "RIGHT":
                        _robot.Right();
                        break;
                    case "REPORT":
                        var report = _robot.Report();
                        if (report != null)
                        {
                            output.Append($"{report.X},{report.Y},{report.Direction}").Append(Environment.NewLine);
                        }
                        break;

                }
            }
            return output.ToString();
        }

    }
}
