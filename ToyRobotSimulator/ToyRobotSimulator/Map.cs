using System;
namespace ToyRobotSimulator
{
    /// <summary>
    /// The map represents the terrain which the robot(s) inhabit, it is
    /// built as a separate class so the map can easily be modified
    /// </summary>
    public class Map : IMap
    {

        private readonly int _width = 0;
        private readonly int _height = 0;

        /// <summary>
        /// Constructor for the map object, defining the height and width
        /// of the map
        /// </summary>
        /// <param name="width">The number of squares on the X-axis</param>
        /// <param name="height">The number of squares on the Y-axis</param>
        public Map(int width, int height)
        {
            _height = height;
            _width = width;
        }
        
        public bool IsValidCoordinates(int x, int y)
        {
            return x < _width && y < _height && x >= 0 && y >= 0;
        }
    }
}
