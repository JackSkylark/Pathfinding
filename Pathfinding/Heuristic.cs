using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pathfinding.Design.Enums;

namespace Pathfinding
{
    public static class Heuristic
    {
        public static double CalculateHeuristic(HeuristicType heuristic, int xDiff, int yDiff)
        {
            switch (heuristic)
            {
                case HeuristicType.Manhattan:
                    return Manhattan(xDiff, yDiff);
                case HeuristicType.Euclidean:
                    return Euclidean(xDiff, yDiff);
                case HeuristicType.Octile:
                    return Octile(xDiff, yDiff);
                case HeuristicType.Chebyshev:
                    return Chebyshev(xDiff, yDiff);
                case HeuristicType.None:
                    return 0;
                default:
                    return 0;
            }
        }

        private static double Manhattan(float xDiff, float yDiff)
        {
            return xDiff + yDiff;
        }

        private static double Euclidean(float xDiff, float yDiff)
        {
            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }

        private static double Octile(float xDiff, float yDiff)
        {
            var sqrt2 = Math.Sqrt(2);
            return (xDiff < yDiff) ? sqrt2 * xDiff + yDiff : sqrt2 * yDiff + xDiff;
        }

        private static double Chebyshev(float xDiff, float yDiff)
        {
            return Math.Max(xDiff, yDiff);
        }
    }
}
