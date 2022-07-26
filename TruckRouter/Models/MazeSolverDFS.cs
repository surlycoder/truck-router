namespace TruckRouter.Models
{
    /// <summary>
    /// Maze solver using recursive depth-first search (DFS) algorithm
    /// </summary>
    public class MazeSolverDFS : BaseMazeSolver
    {
        /// <summary>
        /// Solve the maze
        /// </summary>
        /// <param name="mazeString"></param>
        public override void Solve(string mazeString)
        {
            int startX, startY;
            int endX, endY;

            string[,] maze = CreateMaze(mazeString);

            int rowCount = maze.GetLength(0);
            int colCount = maze.GetLength(1);

            Visited = new bool[rowCount, colCount];
            MazePath = new string[rowCount, colCount];

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    Visited[row, col] = false;
                    MazePath[row, col] = maze[row, col];
                }
            }

            (startX, startY) = maze.CoordinatesOf(StartToken);
            (endX, endY) = maze.CoordinatesOf(EndToken);

            Point start = new(startX, startY);
            Point end = new(endX, endY);

            _ = RecursiveSolve(maze, startX, startY, start, end);
        }

        /// <summary>
        /// Recursively solve the maze
        /// </summary>
        /// <param name="maze"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>Boolean indicating if there is a solution to the maze</returns>
        private bool RecursiveSolve(string[,] maze, int x, int y, Point start, Point end)
        {
            if (x == end.X && y == end.Y)
            {
                return true;
            }

            if (maze[x, y] == WallToken || Visited[x, y])
            {
                return false;
            }
            // If you are on a wall or already were here
            Visited[x, y] = true;
            if (x != 0) // Checks if not on left edge
                if (RecursiveSolve(maze, x - 1, y, start, end))
                { // Recalls method one to the left
                    return ProcessPoint(x, y, start);
                }
            if (x != maze.GetLength(0) - 1) // Checks if not on right edge
                if (RecursiveSolve(maze, x + 1, y, start, end))
                { // Recalls method one to the right
                    return ProcessPoint(x, y, start);
                }
            if (y != 0)  // Checks if not on top edge
                if (RecursiveSolve(maze, x, y - 1, start, end))
                { // Recalls method one up
                    return ProcessPoint(x, y, start);
                }
            if (y != maze.GetLength(1) - 1) // Checks if not on bottom edge
                if (RecursiveSolve(maze, x, y + 1, start, end))
                { // Recalls method one down
                    return ProcessPoint(x, y, start);
                }
            return false;
        }

        /// <summary>
        /// Processes a point by adding it to the path and incrementing steps
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        private bool ProcessPoint(int x, int y, Point start)
        {
            if (!(x == start.X && y == start.Y))
            {
                MazePath[x, y] = PathToken;
            }
            Steps++;
            return true;
        }
    }
}
