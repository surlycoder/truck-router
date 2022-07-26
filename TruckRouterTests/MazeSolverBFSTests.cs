using TruckRouter.Models;

namespace TruckRouterTests
{
    [TestClass]
    public class MazeSolverBFSTests
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
                                     "#A@@.#...#\n" + 
                                     "#.#@##.#.#\n" + 
                                     "#.#@##.#.#\n" + 
                                     "#.#@@@@#B#\n" + 
                                     "#.#.##@#@#\n" + 
                                     "#....#@@@#\n" + 
                                     "##########";

        const string malformedMaze = "##########\n#A...#...#\n#.#.#";
        const string invalidCharMaze = "904jf0ajs09r00j";

        [TestMethod]
        public void MazeSolverBFSSolveForSmallMazeReturnsExpectedSolution()
        {
            MazeSolverBFS mazeSolver = new();
            mazeSolver.Solve(smallMaze);

            Assert.AreEqual(14, mazeSolver.Steps);
            Assert.AreEqual(smaleMazeSoln, mazeSolver.Solution);
        }

        [TestMethod]
        public void MazeSolverBFSIsValidForSmallMazeReturnsTrue()
        {
            MazeSolverBFS mazeSolver = new();
            bool isValid = mazeSolver.IsValidMaze(smallMaze);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void MazeSolverBFSIsValidForMalformedMazeReturnsFalse()
        {
            MazeSolverBFS mazeSolver = new();
            bool isValid = mazeSolver.IsValidMaze(malformedMaze);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void MazeSolverBFSIsValidForInvalidCharMazeReturnsFalse()
        {
            MazeSolverBFS mazeSolver = new();
            bool isValid = mazeSolver.IsValidMaze(invalidCharMaze);

            Assert.IsFalse(isValid);
        }
    }
}