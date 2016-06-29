using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pathfinding.Design;
using Pathfinding.Design.Enums;
using Utilities.Generics.Heap;

namespace Pathfinding.Finders
{
    public class AStar : IPathfinder
    {
        private IWeightedGraph<Location> Graph { get; set; }

        public AStar(IWeightedGraph<Location> graph)
        {
            Graph = graph;
        }

        public IEnumerable<Location> FindPath(Location start, Location end)
        {
            return FindPath(start, end, HeuristicType.None);
        } 

        public IEnumerable<Location> FindPath(Location start, Location end, HeuristicType heuristic)
        {
            var cameFrom = new Dictionary<Location, Location>
            {
                {start, start}
            };

            var costSoFar = new Dictionary<Location, int>
            {
                {start, 0}
            };

            var frontier = new BinaryHeap<Location>();
            frontier.Insert(start, 0);

            while (!frontier.IsEmpty())
            {
                var current = frontier.ExtractBest();

                if (current.Equals(end))
                {
                    // Trace Back over
                    var backtraceLocation = current;
                    var path = new List<Location>
                    {
                        backtraceLocation
                    };

                    while (!start.Equals(backtraceLocation))
                    {
                        backtraceLocation = cameFrom[backtraceLocation];
                        path.Add(backtraceLocation);
                    }

                    path.Reverse();
                    return path;
                }

                foreach (var next in Graph.GetNeighbors(current))
                {
                    var newCost = costSoFar[current] + Graph.GetCost(current, next);
                    if (!costSoFar.ContainsKey(next) || newCost < costSoFar[next])
                    {
                        costSoFar[next] = newCost;
                        var priority = newCost + Heuristic.CalculateHeuristic(heuristic, end.X - next.X, end.Y - next.Y);
                        frontier.Insert(next, priority);
                        cameFrom[next] = current;
                    }
                }
            }

            // Find Path Failed
            return new List<Location>();
        }
    }
}
