namespace TruckRouter.Models
{
    /// <summary>
    /// Represents a 2-dimensional point
    /// </summary>
    public class Point
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="prevPoint"></param>
        public Point(int x, int y, Point prevPoint)
        {
            X = x;
            Y = y;
            PreviousPoint = prevPoint;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// X coordinate
        /// </summary>
        public int X
        {
            get;
        }

        /// <summary>
        /// Y coordinate
        /// </summary>
        public int Y
        {
            get;
        }

        /// <summary>
        /// Reference to previous point
        /// </summary>
        public Point? PreviousPoint
        {
            get;
        }

        /// <summary>
        /// Equality overide
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Boolean indicating of the comparison object is equal</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not Point comp)
            {
                return false;
            }

            return X == comp.X && Y == comp.Y;
        }

        /// <summary>
        /// Calculates a hash
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => X ^ Y;
    }
}
