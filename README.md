# Truck Router

### Table of Contents

- [Purpose](#purpose)
- [Implementation](#implementation)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [API](#api)
- [Notes](#notes)

### Purpose

The goal of this project is to solve a truck routing problem. Well, it's actually a maze solving problem but I developed this project as a coding challenge given to me by a former employer, a transportation company, hence the name. Given a text maze with starting point "A" and ending point "B", find the shortest path from "A" to "B".

### Implementation

This project is a web service developed using ASP.NET Core Web API in Microsoft Visual Studio.

### Prerequisites

- [Visual Studio](https://www.visualstudio.com/downloads/)
- [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

### Installation

1. Clone or download the truck-router repo
1. Open the solution file "TruckRouter.sln" in Visual Studio
1. Change the build configuration to "Release"
1. Build the solution by selecting Build | Build Solution from the Visual Studio menu

### Usage

From Windows PowerShell or command line, navigate to the build output folder and execute the following command:

```
dotnet .\TruckRouter.dll --urls "http://localhost:8080"
```

This will launch the Truck Router web service via the Kestrel web server listening on port 8080.

Once the Trucker Router web service is up and running, you can send it requests from an HTTP client such as [Insomnia](https://insomnia.rest/), [Fiddler](http://www.telerik.com/fiddler), or [Postman](https://www.getpostman.com/). See the [API](#api) section below for the endpoint and request/response format. 

### API

The Truck Router API exposes a single endpoint:

#### POST /solveMaze

The `solveMaze` endpoint accepts raw text in the request body in the following format:

```
##########
#A...#...#
#.#.##.#.#
#.#.##.#.#
#.#....#B#
#.#.##.#.#
#....#...#
##########
```

where:

- . represents an open road
- \# represents a blocked road
- A represents the starting point
- B represents the destination point

The corresponding response is a JSON object:

```
{
    "steps": 14,
    "solution": "##########
                 #A@@.#...#
                 #.#@##.#.#
                 #.#@##.#.#
                 #.#@@@@#B#
                 #.#.##@#@#
                 #....#@@@#
                 ##########"
}
```

where @ represents the chosen path.

### Notes

- The coding challenge instructions that were given to me specified the input format to be the text maze only, not the text maze wrapped in JSON. Not wanting to make assumptions, I followed the directions to the letter. That's why the endpoint accepts the maze as raw text.
- I initially implemented the [depth-first search](https://en.wikipedia.org/wiki/Depth-first_search). Noticing that it did not give the optimal (i.e. shortest) solution, I implemented the [breadth-first search](https://en.wikipedia.org/wiki/Breadth-first_search). The algorthm is injected at startup in [`Program.cs`](TruckRouter/Program.cs).
- 3 sample mazes are located in the root folder ([`maze1.txt`](maze1.txt), [`maze2.txt`](maze2.txt), [`maze3.txt`](maze3.txt)), as well as the solutions to those mazes for each algorithm ([`soln1.txt`](soln1.txt), [`soln2.txt`](soln2.txt), [`soln3.txt`](soln3.txt)).
