using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TruckRouter.Models;

namespace TruckRouter.Controllers {
	[Route( "[controller]" )]
	public class SolveMazeController:Controller {

		private readonly IMazeSolver _mazeSolution;

		public SolveMazeController( IMazeSolver mazeSolution ) {
			_mazeSolution = mazeSolution;
		}

		[HttpPost]
		public async Task<IActionResult> Post() {

			byte[] mazeBytes;

			using ( var ms = new MemoryStream() ) {
				await Request.Body.CopyToAsync( ms );
				mazeBytes = ms.ToArray();
			}

			_mazeSolution.Solve( Encoding.UTF8.GetString( mazeBytes ) );

			return Ok( _mazeSolution );

		}
	}
}
