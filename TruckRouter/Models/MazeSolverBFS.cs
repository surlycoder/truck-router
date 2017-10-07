using System;
using System.Collections.Generic;

namespace TruckRouter.Models {

	/// <summary>
	/// Maze solver using breadth-first search (BFS) algorithm
	/// </summary>
	public class MazeSolverBFS:BaseMazeSolver {

		/// <summary>
		/// Solves the maze
		/// </summary>
		/// <param name="mazeString"></param>
		public override void Solve( string mazeString ) {
			int startX, startY;
			int endX, endY;

			string[,] maze = CreateMaze( mazeString );

			int rowCount = maze.GetLength( 0 );
			int colCount = maze.GetLength( 1 );

			_visited = new bool[rowCount, colCount];
			_mazePath = new string[rowCount, colCount];

			for ( int row = 0; row < rowCount; row++ ) {
				for ( int col = 0; col < colCount; col++ ) {
					_visited[row, col] = false;
					_mazePath[row, col] = maze[row, col];
				}
			}

			(startX, startY) = maze.CoordinatesOf( StartToken );
			(endX, endY) = maze.CoordinatesOf( EndToken );

			Point start = new Point( startX, startY, null );
			Point end = new Point( endX, endY, null );

			Point p = GetShortestPathByBFS( maze, start, end );

			if ( p != null ) {
				while ( p.PreviousPoint != null ) {
					if ( !p.Equals( end ) ) {
						_mazePath[p.X, p.Y] = PathToken;
					}
					Steps++;
					p = p.PreviousPoint;
				}
			}
		}

		/// <summary>
		/// Solve a given maze using BFS algorithm
		/// </summary>
		/// <param name="maze"></param>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <returns>Point representing the completed solution</returns>
		public Point GetShortestPathByBFS( string[,] maze, Point start, Point end ) {
			Queue<Point> pointQueue = new Queue<Point>();
			pointQueue.Enqueue( start );

			while ( pointQueue.Count > 0 ) {
				Point currPoint = pointQueue.Dequeue();

				if ( currPoint.Equals( end ) ) {
					return currPoint;
				}

				ProcessPoint( maze, currPoint, pointQueue, currPoint.X + 1, currPoint.Y );
				ProcessPoint( maze, currPoint, pointQueue, currPoint.X - 1, currPoint.Y );
				ProcessPoint( maze, currPoint, pointQueue, currPoint.X, currPoint.Y + 1 );
				ProcessPoint( maze, currPoint, pointQueue, currPoint.X, currPoint.Y - 1 );
			}
			return null;
		}

		/// <summary>
		/// Processes a point by adding to queue and marking as visited if safe for traversal
		/// </summary>
		/// <param name="maze"></param>
		/// <param name="currPoint"></param>
		/// <param name="pointQueue"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		private void ProcessPoint( string[,] maze, Point currPoint, Queue<Point> pointQueue, int x, int y ) {
			if ( IsSafePoint( maze, x, y ) ) {
				_visited[x, y] = true;
				Point nextPoint = new Point( x, y, currPoint );
				pointQueue.Enqueue( nextPoint );
			}
		}

		/// <summary>
		/// Determine if a given set of point coordinates is safe for path traversal
		/// </summary>
		/// <param name="maze"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>Boolean value indicating if the point is a path candidate</returns>
		public bool IsSafePoint( string[,] maze, int x, int y ) {
			if ( x >= 0 && x < maze.GetLength( 0 ) &&
				y >= 0 && x < maze.GetLength( 1 ) ) {

				if ( !_visited[x, y] &&
					( SafePathTokens.IndexOf( maze[x, y] ) > -1 ) ) {
					return true;
				}

			}
			return false;
		}
	}
}
