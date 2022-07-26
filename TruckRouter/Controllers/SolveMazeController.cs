using System.Text;
using Microsoft.AspNetCore.Mvc;
using TruckRouter.Models;

namespace TruckRouter.Controllers
{
    [Route("[controller]")]
    public class SolveMazeController : Controller
    {
        private readonly IMazeSolver _mazeSolver;

        public SolveMazeController(IMazeSolver mazeSolver)
        {
            _mazeSolver = mazeSolver;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            byte[] mazeBytes;
            string mazeString;

            using (MemoryStream ms = new())
            {
                await Request.Body.CopyToAsync(ms);

                if (ms.Length == 0)
                {
                    return BadRequest();
                }

                mazeBytes = ms.ToArray();
            }

            mazeString = Encoding.UTF8.GetString(mazeBytes);

            if (!_mazeSolver.IsValidMaze(mazeString))
            {
                return BadRequest();
            }

            _mazeSolver.Solve(Encoding.UTF8.GetString(mazeBytes));

            return Ok(_mazeSolver);
        }
    }
}
