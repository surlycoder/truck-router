using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TruckRouter.Models {

	/// <summary>
	/// Contains base functionality to solve mazes
	/// </summary>
	public abstract class BaseMazeSolver:IMazeSolver {
		protected const string StartToken = "A";
		protected const string EndToken = "B";
		protected const string WallToken = "#";
		protected const string OpenToken = ".";
		protected const string PathToken = "@";

		protected const string SafePathTokens = OpenToken + StartToken + EndToken;

		protected bool[,] _visited;
		protected string[,] _mazePath;

		/// <summary>
		/// The number of steps in the solution path
		/// </summary>
		public int Steps {
			get; protected set;
		}

		/// <summary>
		/// The maze solution
		/// </summary>
		public string Solution {
			get {
				if ( _mazePath == null ) {
					return string.Empty;
				}

				StringBuilder sb = new StringBuilder();
				int rowCount = _mazePath.GetLength( 0 );

				for ( int i = 0; i < rowCount; i++ ) {
					sb.Append( string.Join( "", _mazePath.GetRow( i ) ) );
					sb.Append( '\n' );
				}

				sb.Remove( sb.Length - 1, 1 );

				return sb.ToString();
			}
		}

		public bool IsValidMaze( string mazeString ) {
			char[] validChars = { 'A', 'B', '.', '#', '\r', '\n' };

			// Check for invalid characters
			foreach ( char ch in mazeString ) {
				if ( !validChars.Contains( ch ) ) {
					return false;
				}
			}

			// Check for non-rectangular maze
			string[][] jaggedMaze = CreateJaggedArray( mazeString );
			int colCount = jaggedMaze[0].Length;

			for ( int i = 0; i < jaggedMaze.Length; i++ ) {
				if ( jaggedMaze[i].Length != colCount ) {
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Solve the maze
		/// </summary>
		/// <param name="mazeString"></param>
		public virtual void Solve( string mazeString ) {
		}

		/// <summary>
		/// Creates the maze matrix
		/// </summary>
		/// <param name="mazeString"></param>
		/// <returns>The maze matrix</returns>
		protected string[,] CreateMaze( string mazeString ) {
			string[][] jaggedMaze = CreateJaggedArray( mazeString );

			int rowCount = jaggedMaze.Length;
			int colCount = jaggedMaze[0].Length - 1;

			string[,] maze = new string[rowCount, colCount];
			for ( int i = 0; i < rowCount; i++ ) {
				for ( int j = 0; j < colCount; j++ ) {
					maze[i, j] = jaggedMaze[i][j];
				}
			}

			return maze;
		}

		/// <summary>
		/// Creates a jagged array
		/// </summary>
		/// <param name="input">String delimited by CRLFs</param>
		/// <returns>Jagged array</returns>
		private string[][] CreateJaggedArray( string input ) {
			string[][] result = input.Split( new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None )
				.Select( p => Regex.Split( p, "(?<=\\G.{1})" ) )
				.ToArray();

			return result;
		}
	}
}
