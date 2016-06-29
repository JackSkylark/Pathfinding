using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pathfinding.Design;
using Pathfinding.Design.Enums;

namespace Pathfinding.Finders
{
    public class Dijkstra : IPathfinder
    {
        private AStar _finder { get; set; }

        public Dijkstra(IWeightedGraph<Location> graph)
        {
            _finder = new AStar(graph);
        }


        public IEnumerable<Location> FindPath(Location start, Location end)
        {
            return _finder.FindPath(start, end, HeuristicType.None);
        }
    }
}
