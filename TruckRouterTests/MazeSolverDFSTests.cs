using TruckRouter.Models;

namespace TruckRouterTests
{
    [TestClass]
    public class MazeSolverDFSTests
    {
        const string smallMaze = "##########\n" +
                                 "#A...#...#\n" +
                                 "#.#.##.#.#\n" +
                                 "#.#.##.#.#\n" +
                                 "#.#....#B#\n" +
                                 "#.#.##.#.#\n" +
                                 "#....#...#\n" +
                                 "##########";

        const string smaleMazeSoln = "##########\n" +
                                     "#A...#@@@#\n" +
                                     "#@#.##@#@#\n" +
                                     "#@#.##@#@#\n" +
                                     "#@#@@@@#B#\n" +
                                     "#@#@##.#.#\n" +
                                     "#@@@.#...#\n" +
                                     "##########";

        [TestMethod]
        public void MazeSolverDFSSolveForSmallMazeReturnsExpectedSolution()
        {
            MazeSolverDFS mazeSolver = new();
            mazeSolver.Solve(smallMaze);

            Assert.AreEqual(20, mazeSolver.Steps);
            Assert.AreEqual(smaleMazeSoln, mazeSolver.Solution);
        }
    }
}