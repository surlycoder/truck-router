﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckRouter
{
    public static class MatrixExtension
    {
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
