using System;
using System.Text;
namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new Map(5, 5);
            var robot = new Robot(map);
            var controller = new Controller(robot);
            if (args.Length == 0)
            {
                controller.UseConsole();
            }
            else
            {
                controller.UseFile(args[0]);
            }
        }
    }
}
