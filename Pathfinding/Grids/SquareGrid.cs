using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pathfinding.Design;

namespace Pathfinding.Grids
{
    public class SquareGrid : IWeightedGraph<Location>
    {
        private readonly List<Location> _dirs = new List<Location>
        {
            new Location(0, 1), // UP
            new Location(1, 0), // RIGHT
            new Location(0, -1), // DOWN 
            new Location(-1, 0), // LEFT
            new Location(-1, 1), // TOP-LEFT
            new Location(1, 1), // TOP-RIGHT
            new Location(-1, -1), // BOTTOM-LEFT
            new Location(1, -1) // BOTTOM-RIGHT
        };

        private int GridSizeX { get; set; }
        private int GridSizeY { get; set; }
        public INode[,] Nodes { get; set; }

        public SquareGrid(int gridSizeX, int gridSizeY)
        {
            GridSizeX = gridSizeX;
            GridSizeY = gridSizeY;
            Nodes = BuildNodes();
        }

        private INode[,] BuildNodes()
        {
            var nodes = new INode[GridSizeX, GridSizeY];

            for (var x = 0; x < GridSizeX; x++)
            {
                for (var y = 0; y < GridSizeY; y++)
                {
                    nodes[x, y] = new Node(new Location(x, y));
                }
            }

            return nodes;
        }

        public INode GetNodeAtIndex(int x, int y)
        {
            return Nodes[x, y];
        }

        public bool IsIndexInsideGrid(int x, int y)
        {
            return (x >= 0 && x < this.GridSizeX) && (y >= 0 && y < this.GridSizeY);
        }

        public int GetCost(Location currentLocation, Location newLocation)
        {
            // ToDo: Check to make sure that the current step and the test step are neighbors
            return GetNodeAtIndex(newLocation.X, newLocation.Y).MovementCost;
        }

        public IEnumerable<Location> GetNeighbors(Location currentLocation)
        {
            var directions = _dirs;

            return directions.Where(dir => IsIndexInsideGrid(currentLocation.X + dir.X, currentLocation.Y + dir.Y)
                                           && GetNodeAtIndex(currentLocation.X + dir.X, currentLocation.Y + dir.Y).IsTraversable)
                                           .Select(dir => new Location(currentLocation.X + dir.X, currentLocation.Y + dir.Y)).ToList();
        }
    }
}
