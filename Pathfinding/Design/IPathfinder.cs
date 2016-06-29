using System.Collections.Generic;
using Pathfinding.Design.Enums;

namespace Pathfinding.Design
{
    public interface IPathfinder
    {
        IEnumerable<Location> FindPath(Location start, Location end);
    }
}