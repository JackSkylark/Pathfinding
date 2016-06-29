using Pathfinding.Design;

namespace Pathfinding
{
    public class Node : INode
    {
        public Location Location { get; set; }
        public int MovementCost { get; set; }
        public bool IsTraversable { get; set; }

        public Node(Location location)
        {
            Location = location;
            MovementCost = 1;
            IsTraversable = true;
        }

        public Node(Location location, bool isTraversable, int movementCost)
            : this(location)
        {
            IsTraversable = isTraversable;
            MovementCost = movementCost;
        }
    }
}