namespace ToyRobotSimulator
{
    public class Robot : IRobot
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
        /// Removes the robot from the map, if the robot has not been placed
        /// this has no effect
        /// </summary>
        public void Unplace()
        {
            _location = null;
        }

        /// <summary>
        /// Returns the current location and direction of the reblt
        /// </summary>
        /// <returns></returns>
        public Location Report()
        {            
            return _location;
        }

        /// <summary>
        /// Totates the robot 90 degress to the left / anticlockwise without
        /// changing the position of the robot
        /// </summary>
        public void Left()
        {
            if (_location != null)
            {
                _location.Direction -= 1;
                if (_location.Direction < 0)
                    _location.Direction = Direction.West;
            }
        }

        /// <summary>
        /// Totates the robot 90 degress to the right / clockwise without
        /// changing the position of the robot
        /// </summary>
        public void Right()
        {
            if (_location != null)
            {
                _location.Direction += 1;
                if (_location.Direction > Direction.West)
                    _location.Direction = Direction.North;
            }
        }

        /// <summary>
        /// Moves the robot one unit forward in the direction it is currently facing
        /// </summary>
        public void Move()
        {
            if (_location != null)
            {
                var moveX = 0;
                var moveY = 0;
                switch (_location.Direction)
                {
                    case Direction.North:
                        moveY = 1;
                        break;
                    case Direction.East:
                        moveX = 1;
                        break;
                    case Direction.South:
                        moveY = -1;
                        break;
                    case Direction.West:
                        moveX = -1;
                        break;

                }
                if (_map.IsValidCoordinates(_location.X + moveX, _location.Y + moveY))
                {
                    _location.X += moveX;
                    _location.Y += moveY;
                }
            }
        }

    }
}
