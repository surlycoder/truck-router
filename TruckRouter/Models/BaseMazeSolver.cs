using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TruckRouter.Models {
	public abstract class BaseMazeSolver:IMazeSolver {
		protected bool[,] wasHere;
		protected string[,] correctPath;

		public int Steps {
			get; protected set;
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

		public virtual void Solve( string mazeString ) {}

		protected string[,] GenerateMaze( string mazeString ) {
			//TODO: Fix split to eliminate last column ('')
			var res = mazeString.Split( Environment.NewLine )
				.Select( p => Regex.Split( p, "(?<=\\G.{1})" ) )
				.ToArray();

			int width = res.Length;
			int height = res[0].Length - 1;

			string[,] maze = new string[width, height];
			for ( int i = 0; i != width; i++ )
				for ( int j = 0; j != height; j++ )
					maze[i, j] = res[i][j];

			return maze;
		}

	}
}
