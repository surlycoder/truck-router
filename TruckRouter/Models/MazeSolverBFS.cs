using System;
using System.Collections.Generic;

namespace TruckRouter.Models {
	public class MazeSolverBFS:BaseMazeSolver {

		public override void Solve( string mazeString ) {

			int startX, startY; // Starting X and Y values of maze
			int endX, endY;     // Ending X and Y values of maze

			string[,] maze = GenerateMaze( mazeString );

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

			Point p = GetShortestPathByBFS( maze, startX, startY, endX, endY );

			while ( p.PreviousPoint != null ) {
				if ( !p.Equals( end ) ) {
					correctPath[p.X, p.Y] = "@";
				}
				Steps++;
				p = p.PreviousPoint;
			}
		}

		public Point GetShortestPathByBFS( string[,] srcMaze, int xStPos, int yStPos, int x1, int y1 ) {
			Queue<Point> pointQueue = new Queue<Point>();
			pointQueue.Enqueue( new Point( xStPos, yStPos, null ) );

			while ( pointQueue.Count > 0 ) {
				Point currPoint = pointQueue.Dequeue();

				if ( currPoint.X == x1 && currPoint.Y == y1 )
					return currPoint;

				ProcessPoint( srcMaze, currPoint, pointQueue, currPoint.X + 1, currPoint.Y );
				ProcessPoint( srcMaze, currPoint, pointQueue, currPoint.X - 1, currPoint.Y );
				ProcessPoint( srcMaze, currPoint, pointQueue, currPoint.X, currPoint.Y + 1 );
				ProcessPoint( srcMaze, currPoint, pointQueue, currPoint.X, currPoint.Y - 1 );
			}
			return null;
		}

		private void ProcessPoint( string[,] srcMaze, Point currPoint, Queue<Point> pointQueue, int x, int y ) {
			if ( IsSafePoint( srcMaze, x, y ) ) {
				wasHere[currPoint.X, currPoint.Y] = true;
				Point nextP = new Point( x, y, currPoint );
				pointQueue.Enqueue( nextP );
			}
		}

		public bool IsSafePoint( string[,] srcMaze, int x, int y ) {
			if ( x >= 0 && x < srcMaze.GetLength( 0 ) &&
				y >= 0 && x < srcMaze.GetLength( 1 ) ) {

				if ( (srcMaze[x, y] == "A" || srcMaze[x, y] == "B" || srcMaze[x, y] == ".") &&
				!wasHere[x, y] ) {
					return true;
				}

			}
			return false;
		}
	}
}
