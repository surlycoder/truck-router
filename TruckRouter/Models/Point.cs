namespace TruckRouter.Models {
	public class Point {
		public Point( int x, int y, Point prevPoint ) {
			X = x;
			Y = y;
			PreviousPoint = prevPoint;
		}

		public Point( int x, int y) {
			X = x;
			Y = y;
		}

		public int X {
			get;
		}
		public int Y {
			get;
		}
		public Point PreviousPoint {
			get;
		}

		public override bool Equals( object obj ) {
			Point comp = obj as Point;

			if ( comp == null ) {
				return false;
			}

			return this.X == comp.X && this.Y == comp.Y;
		}
	}
}
