namespace TruckRouter.Models {
	public interface IMazeSolver {
		string Solution {
			get;
		}
		int Steps {
			get;
		}

		void Solve( string mazeString);
	}
}