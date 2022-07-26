# Truck Router

The goal of this project is to solve a truck routing problem. Given a text maze with starting point "A" and ending point "B", find the shortest path from "A" to "B".

### Implementation

This project is a web service developed using ASP.NET Core Web API in Microsoft Visual Studio.

### Prerequisites

- [Visual Studio](https://www.visualstudio.com/downloads/)
- [.NET 6.0 SDK or Runtime](https://www.microsoft.com/net/download/core)

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

Once the Trucker Router web service is up and running, you can send it requests from an HTTP client such as [Fiddler](http://www.telerik.com/fiddler) or [Postman](https://www.getpostman.com/). See the [API](#api) section below for the endpoint and request/response format. 

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
