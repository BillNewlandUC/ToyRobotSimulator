namespace ToyRobotSimulator
{
    public interface IMap
    {
        /// <summary>
        /// Indicates whether the coordinates given are valid on the current map
        /// </summary>
        /// <param name="x">The X co-ordinate</param>
        /// <param name="y">The Y co-oridnate</param>
        /// <returns>True if the co-ordinates exist on the current map</returns>
        bool IsValidCoordinates(int x, int y);

    }
}