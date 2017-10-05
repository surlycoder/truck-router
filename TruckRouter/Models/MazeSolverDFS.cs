using System;

namespace TruckRouter.Models {
	public class MazeSolverDFS:BaseMazeSolver {
		string[,] maze;

		public override void Solve( string mazeString ) {

			int startX, startY; // Starting X and Y values of maze
			int endX, endY;     // Ending X and Y values of maze

			maze = GenerateMaze( mazeString );

			wasHere = new bool[maze.GetLength( 0 ), maze.GetLength( 1 )];
			correctPath = new string[maze.GetLength( 0 ), maze.GetLength( 1 )];

			(startX, startY) = maze.CoordinatesOf( "A" );
			(endX, endY) = maze.CoordinatesOf( "B" );

			Point start = new Point( startX, startY, null );
			Point end = new Point( endX, endY, null );

			for ( int row = 0; row < maze.GetLength( 0 ); row++ )
				for ( int col = 0; col < maze.GetLength( 1 ); col++ ) {
					wasHere[row, col] = false;
					correctPath[row, col] = maze[row, col];
				}
			bool b = RecursiveSolve( startX, startY, start, end );
			// Will leave you with a boolean array (correctPath) 
			// with the path indicated by true values.
			// If b is false, there is no solution to the maze
		}

		private bool RecursiveSolve( int x, int y, Point start, Point end ) {
			//TODO: Avoid overwriting "A"
			if ( x == end.X && y == end.Y )
				return true; // If you reached the end
			if ( maze[x, y] == "#" || wasHere[x, y] )
				return false;
			// If you are on a wall or already were here
			wasHere[x, y] = true;
			if ( x != 0 ) // Checks if not on left edge
				if ( RecursiveSolve( x - 1, y, start, end ) ) { // Recalls method one to the left
					return ProcessPoint( x, y, start );
				}
			if ( x != maze.GetLength( 0 ) - 1 ) // Checks if not on right edge
				if ( RecursiveSolve( x + 1, y, start, end ) ) { // Recalls method one to the right
					return ProcessPoint( x, y, start );
				}
			if ( y != 0 )  // Checks if not on top edge
				if ( RecursiveSolve( x, y - 1, start, end ) ) { // Recalls method one up
					return ProcessPoint( x, y, start );
				}
			if ( y != maze.GetLength( 1 ) - 1 ) // Checks if not on bottom edge
				if ( RecursiveSolve( x, y + 1, start, end ) ) { // Recalls method one down
					return ProcessPoint( x, y, start );
				}
			return false;
		}

		private bool ProcessPoint( int x, int y, Point start ) {
			if ( !( x == start.X && y == start.Y ) ) {
				correctPath[x, y] = "@";
			}
			Steps++;
			return true;
		}
	}
}
