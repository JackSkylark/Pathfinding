using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pathfinding.Design;
using Pathfinding.Design.Enums;
using Pathfinding.Finders;
using Pathfinding.Grids;

namespace PathfindingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new SquareGrid(500, 500);
            var dijkstraFinder = new Dijkstra(grid);
            var aStarFinder = new AStar(grid);

            var startLocation = new Location(25, 25);
            var endLocation = new Location(400, 400);

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var dijkstraPath = dijkstraFinder.FindPath(startLocation, endLocation);
            stopWatch.Stop();

            Console.WriteLine($"dijkstra: Elapsed Time: {stopWatch.Elapsed}");
            stopWatch.Restart();
            var manhattanPath = aStarFinder.FindPath(startLocation, endLocation, HeuristicType.Manhattan);
            stopWatch.Stop();
            Console.WriteLine($"manhattan: Elapsed Time: {stopWatch.Elapsed}");
            stopWatch.Restart();
            var euclideanPath = aStarFinder.FindPath(startLocation, endLocation, HeuristicType.Euclidean);
            stopWatch.Stop();
            Console.WriteLine($"euclidean: Elapsed Time: {stopWatch.Elapsed}");
            stopWatch.Restart();
            var octilePath = aStarFinder.FindPath(startLocation, endLocation, HeuristicType.Octile);
            stopWatch.Stop();
            Console.WriteLine($"octile: Elapsed Time: {stopWatch.Elapsed}");
            stopWatch.Restart();
            var chebyshevPath = aStarFinder.FindPath(startLocation, endLocation, HeuristicType.Chebyshev);
            stopWatch.Stop();
            Console.WriteLine($"chebyshev: Elapsed Time: {stopWatch.Elapsed}");

            Console.Read();
        }
    }
}
