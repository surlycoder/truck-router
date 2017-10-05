﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
			
			string mazeString = System.Text.Encoding.UTF8.GetString( mazeBytes );

			result = new MazeSolution( mazeString ) {
				Steps = 0,
			};

			result.SolveMaze();

			return Ok( result );

		}
	}
}
