using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TruckRouter.Models {
	public class MazeSolution {
		int width, height;
		string[,] maze; // The maze
		bool[,] wasHere;
		string[,] correctPath; // The solution to the maze
		int startX, startY; // Starting X and Y values of maze
		int endX, endY;     // Ending X and Y values of maze

		public MazeSolution( string mazeString ) {

			//TODO: Fix split to eliminate last column ('')
			var res = mazeString.Split( Environment.NewLine )
				.Select( p => Regex.Split( p, "(?<=\\G.{1})" ) )
				.ToArray();

			width = res.Length;
			height = res[0].Length - 1;

			maze = new string[width, height];
			for ( int i = 0; i != width; i++ )
				for ( int j = 0; j != height; j++ )
					maze[i, j] = res[i][j];

			wasHere = new bool[width, height];
			correctPath = new string[width, height];

			(startX, startY) = maze.CoordinatesOf( "A" );
			(endX, endY) = maze.CoordinatesOf( "B" );
		}

		public int Steps {
			get; private set;
		}

		public string Solution {
			get {
				StringBuilder sb = new StringBuilder();

				for ( int i = 0; i < correctPath.GetLength( 0 ); i++ ) {
					sb.Append( string.Join( "", correctPath.GetRow( i ) ) + "\n" );
				}

				return sb.ToString();
			}
		}

		private int[][] GenerateMaze( string[][] m ) {
			//TODO: Move constructor logic here
			throw new NotImplementedException();
		}

		public void SolveMaze() {

			for ( int row = 0; row < maze.GetLength( 0 ); row++ )
				// Sets boolean Arrays to default values
				for ( int col = 0; col < maze.GetLength( 1 ); col++ ) {
					wasHere[row, col] = false;
					correctPath[row, col] = maze[row, col];
				}
			bool b = RecursiveSolve( startX, startY );
			// Will leave you with a boolean array (correctPath) 
			// with the path indicated by true values.
			// If b is false, there is no solution to the maze
		}

		public bool RecursiveSolve( int x, int y ) {
			//TODO: Avoid overwriting "A"
			if ( x == endX && y == endY )
				return true; // If you reached the end
			if ( maze[x, y] == "#" || wasHere[x, y] )
				return false;
			// If you are on a wall or already were here
			wasHere[x, y] = true;
			if ( x != 0 ) // Checks if not on left edge
				if ( RecursiveSolve( x - 1, y ) ) { // Recalls method one to the left
					correctPath[x, y] = "@"; // Sets that path value to true;
					Steps++;
					return true;
				}
			if ( x != width - 1 ) // Checks if not on right edge
				if ( RecursiveSolve( x + 1, y ) ) { // Recalls method one to the right
					correctPath[x, y] = "@";
					Steps++;
					return true;
				}
			if ( y != 0 )  // Checks if not on top edge
				if ( RecursiveSolve( x, y - 1 ) ) { // Recalls method one up
					correctPath[x, y] = "@";
					Steps++;
					return true;
				}
			if ( y != height - 1 ) // Checks if not on bottom edge
				if ( RecursiveSolve( x, y + 1 ) ) { // Recalls method one down
					correctPath[x, y] = "@";
					Steps++;
					return true;
				}
			return false;
		}
	}
}
