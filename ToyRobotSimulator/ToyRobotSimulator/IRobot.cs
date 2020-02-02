namespace ToyRobotSimulator
{
    public interface IRobot
    {

        /// <summary>
        /// Places the robot on the map at the given co-ordinates, if the
        /// co-ordinates are invalid the function will return False
        /// </summary>
        /// <param name="x">The location of the robot on the X-axis</param>
        /// <param name="y">The location of the robot on the Y-axis</param>
        /// <returns>True if the robot has been successfully placed</returns>
        bool Place(int x, int y, Direction direction);

        /// <summary>
        /// Removes the robot from the map, if the robot has not been placed
        /// this has no effect
        /// </summary>
        void Unplace();

        /// <summary>
        /// Returns the current location and direction of the reblt
        /// </summary>
        /// <returns></returns>
        Location Report();

        /// <summary>
        /// Totates the robot 90 degress to the left / anticlockwise without
        /// changing the position of the robot
        /// </summary>
        void Left();

        /// <summary>
        /// Totates the robot 90 degress to the right / clockwise without
        /// changing the position of the robot
        /// </summary>
        void Right();


        /// <summary>
        /// Moves the robot one unit forward in the direction it is currently facing
        /// </summary>
        void Move();      

    }
}
