using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace ToyRobotSimulator
{
    public class Controller : IController
    {
        public readonly IRobot _robot;
        

        public Controller(IRobot robot)
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

        /// <summary>
        /// Allows the users to enter commands via the console
        /// </summary>
        public void UseConsole()
        {
            Console.WriteLine("Welcome to the Toy Robot Simulator!");
            Console.WriteLine("===================================");
            Console.WriteLine("Commands:");
            Console.WriteLine("PLACE x,y,f - will put the toy robot on the table in position X, Y and facing NORTH, SOUTH, EAST or WEST.");
            Console.WriteLine("MOVE - will move the toy robot one unit forward in the direction it is currently facing");
            Console.WriteLine("LEFT - will rotate the robot 90 degrees anti-clockwise");
            Console.WriteLine("RIGHT - will rotate the robot 90 degrees clockwise");
            Console.WriteLine("REPORT - will announce the X, Y and F of the robot");
            Console.WriteLine();
            Console.WriteLine("GO - will execute all the proceeding commands");
            Console.WriteLine("QUIT - will exit the program");
            Console.WriteLine();
            Console.WriteLine("The map origin (0, 0) can be considered to be the SOUTH WEST most corner.");
            Console.WriteLine();

            var cmd = new StringBuilder();
            do
            {
                var commandLine = Console.ReadLine();
                if (commandLine.Equals("QUIT", StringComparison.CurrentCultureIgnoreCase))
                    break;
                if (commandLine.Equals("GO", StringComparison.CurrentCultureIgnoreCase))
                {                    
                    var output = Run(cmd.ToString());
                    _robot.Unplace();
                    Console.WriteLine("Output: " + output);
                    cmd.Clear();
                }
                else
                {
                    cmd.Append(commandLine).Append(Environment.NewLine);
                }
            } while (true);
            Console.WriteLine();
            Console.WriteLine("Goodbye!");
            Console.WriteLine();
        }


        /// <summary>
        /// Reads the contents of the file and runs the commands contained therein
        /// </summary>
        /// <param name="path"></param>
        public void UseFile(string path)
        {
            var file = new StreamReader(path);
            var cmd = file.ReadToEnd();
            file.Close();
            var output = Run(cmd);
            Console.WriteLine("Welcome to the Toy Robot Simulator!");
            Console.WriteLine("===================================");
            Console.WriteLine("Output: " + output);
        }

    }
}
