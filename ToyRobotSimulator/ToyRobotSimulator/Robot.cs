using System;
namespace ToyRobotSimulator
{
    public class Robot
    {
        private readonly IMap _map;
        private bool _placed = false;

        private Location _location;

        public Robot(IMap map)
        {
            _map = map;
            _location = null;
        }

        /// <summary>
        /// Places the robot on the map at the given co-ordinates, if the
        /// co-ordinates are invalid the function will return False
        /// </summary>
        /// <param name="x">The location of the robot on the X-axis</param>
        /// <param name="y">The location of the robot on the Y-axis</param>
        /// <returns>True if the robot has been successfully placed</returns>
        public bool Place(int x, int y, Direction direction)
        {
            if (!_map.IsValidCoordinates(x, y))
                return false;
            _placed = true;
            _location = new Location { Direction = direction, X = x, Y = y };
            return true;
        }

        /// <summary>
        /// Returns the current location and direction of the reblt
        /// </summary>
        /// <returns></returns>
        public Location Report()
        {            
            return _location;
        }



    }
}
