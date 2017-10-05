using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TruckRouter.Models;

namespace TruckRouter.Controllers {
	[Route( "[controller]" )]
	public class SolveMazeController:Controller {

		[HttpPost]
		public async Task<IActionResult> Post() {

			MazeSolution result;

			byte[] mazeBytes;

			using ( var ms = new MemoryStream() ) {
				await Request.Body.CopyToAsync( ms );
				mazeBytes = ms.ToArray();
			}
			
			string mazeString = Encoding.UTF8.GetString( mazeBytes );

			result = new MazeSolution( mazeString );
			result.SolveMaze();

			return Ok( result );

		}
	}
}
