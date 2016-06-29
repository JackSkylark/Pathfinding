using System.Collections.Generic;

namespace Pathfinding.Design
{
    public interface IWeightedGraph<L>
    {
        int GetCost(L currentLocation, L newLocation);
        IEnumerable<L> GetNeighbors(L currentLocation);
    }
}