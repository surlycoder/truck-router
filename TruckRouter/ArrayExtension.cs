﻿using System;
using System.Collections.Generic;

namespace TruckRouter {
	public static class ArrayExtensions {

		public static IEnumerable<T> GetRow<T>( this T[,] array, int rowIndex ) {
			int columnsCount = array.GetLength( 1 );
			for ( int colIndex = 0; colIndex < columnsCount; colIndex++ )
				yield return array[rowIndex, colIndex];
		}

		public static Tuple<int, int> CoordinatesOf<T>( this T[,] matrix, T value ) {
			int w = matrix.GetLength( 0 ); // width
			int h = matrix.GetLength( 1 ); // height

			for ( int x = 0; x < w; ++x ) {
				for ( int y = 0; y < h; ++y ) {
					if ( matrix[x, y].Equals( value ) )
						return Tuple.Create( x, y );
				}
			}

			return Tuple.Create( -1, -1 );
		}

	}
}
