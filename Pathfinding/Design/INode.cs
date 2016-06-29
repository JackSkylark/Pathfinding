namespace Pathfinding.Design
{
    public interface INode
    {
        Location Location { get; set; }
        int MovementCost { get; set; }
        bool IsTraversable { get; }
    }
}