using System;
using System.Text;

namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Toy Robot Simulator!");
            Console.WriteLine("===================================");
            Console.WriteLine("Commands:");
            Console.WriteLine("PLACE x,y,f - will put the toy robot on the table in position X, Y and facing NORTH, SOUTH, EAST or WEST.");
            Console.WriteLine("MOVE - will move the toy robot one unit forward in the direction it is currentl");
            Console.WriteLine("LEFT - will rotate the robot 90 degrees anti-clockwise");
            Console.WriteLine("RIGHT - will rotate the robot 90 degrees clockwise");
            Console.WriteLine("REPORT - will announce the X, Y and F of the robot");
            Console.WriteLine();
            Console.WriteLine("GO - will execute all the proceeding commands");
            Console.WriteLine("QUIT - will exit the program");
            Console.WriteLine();
            Console.WriteLine("The map origin (0, 0) can be considered to be the SOUTH WEST most corner.");
            Console.WriteLine();

            var map = new Map(5, 5);
            var cmd = new StringBuilder();
            do
            {
                var commandLine = Console.ReadLine();
                if (commandLine.Equals("QUIT", StringComparison.CurrentCultureIgnoreCase))
                    break;
                if (commandLine.Equals("GO", StringComparison.CurrentCultureIgnoreCase))
                {
                    var robot = new Robot(map);
                    var parser = new CommandParser(robot);
                    var output = parser.Run(cmd.ToString());
                    Console.WriteLine("Output: " + output);
                    cmd.Clear();
                } else
                {
                    cmd.Append(commandLine).Append(Environment.NewLine);
                }
            } while (true);
            Console.WriteLine();
            Console.WriteLine("Goodbye!");
            Console.WriteLine();

        }
    }
}
