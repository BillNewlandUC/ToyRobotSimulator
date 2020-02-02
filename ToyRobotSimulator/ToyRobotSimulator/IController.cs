namespace ToyRobotSimulator
{
    public interface IController
    {

        /// <summary>
        /// Takes an arbitary string of commands seperated by line breaks
        /// and issues them to the robot
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        string Run(string commandText);

        /// <summary>
        /// Imports the file at the given path and runs it
        /// </summary>
        /// <param name="path"></param>
        void UseFile(string path);

        /// <summary>
        /// Allows the user to enter commands via the console
        /// </summary>
        void UseConsole();

    }
}
