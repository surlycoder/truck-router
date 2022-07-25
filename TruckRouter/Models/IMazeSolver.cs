namespace TruckRouter.Models
{
    /// <summary>
    /// Interface representing a maze solver
    /// </summary>
    public interface IMazeSolver
    {
        /// <summary>
        /// The number of steps in the solution path
        /// </summary>
        int Steps
        {
            get;
        }

        /// <summary>
        /// The maze solution
        /// </summary>
        string Solution
        {
            get;
        }

        /// <summary>
        /// Determines if maze is valid
        /// </summary>
        /// <param name="mazeString"></param>
        /// <returns>Boolean indicating if maze is valid</returns>
        bool IsValidMaze(string mazeString);

        /// <summary>
        /// Solve the maze
        /// </summary>
        /// <param name="mazeString"></param>
        void Solve(string mazeString);
    }
}