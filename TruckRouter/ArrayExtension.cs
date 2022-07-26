namespace TruckRouter
{
    /// <summary>
    /// Extensions for array
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Get a row in an array by a given row index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetRow<T>(this T[,] array, int rowIndex)
        {
            int columnsCount = array.GetLength(1);
            for (int colIndex = 0; colIndex < columnsCount; colIndex++)
                yield return array[rowIndex, colIndex];
        }

        /// <summary>
        /// Get coordinates of a given value in an array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Tuple<int, int> CoordinatesOf<T>(this T[,] matrix, T value) where T : notnull
        {
            int w = matrix.GetLength(0); // width
            int h = matrix.GetLength(1); // height

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    if (!matrix[x, y].Equals(value))
                    {
                        continue;
                    }
                    return Tuple.Create(x, y);
                }
            }

            return Tuple.Create(-1, -1);
        }
    }
}
