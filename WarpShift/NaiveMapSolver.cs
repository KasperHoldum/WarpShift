using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarpShift
{
    public class NaiveMapSolver
    {
        public Map Solve(Map map)
        {
            map.x = 1;
            map.y = 0;
            return map;
        }
    }

    public class AStar
    {
        private Func<(int, int), (int, int), int> h;

        public AStar(Func<(int,int), (int,int),int> heuristic)
        {
            this.h = heuristic;
        }

        public void Work((int x, int y) start, (int x, int y) goal)
        {
            var closed = new HashSet<(int, int)>(){ };
            var open = new HashSet<(int, int)>() { start };
            var cameFrom = new Dictionary<(int, int), (int, int)>();

            var gScore = new Dictionary<(int, int), int>() { { start, 0} };
            var fScore = new Dictionary<(int, int), int>();

            fScore[start] = h(start, goal);

            (int x,int y) getNextOpen()
            {
                // find lowest fscore
                return default((int,int));
            }
            (int x, int y)[] getNeighbors((int x, int y) v)
            {
                throw new NotImplementedException();
            }

            while (open.Any())
            {
                var current = getNextOpen();
                if (current.Equals(goal))
                    return; // WIN

                open.Remove(current);
                closed.Add(current);

                foreach(var neighbor in getNeighbors(current))
                {
                    if (closed.Contains(neighbor))
                        continue; // Ignore the neighbor which is already evaluated.
                    // The distance from start to a neighbor
                    var tentative_gScore = gScore[current] + 1; // exchange 1 with distance for weighted edges

                    if (!open.Contains(neighbor))
                        open.Add(neighbor); // discovered new node
                    else if (tentative_gScore >= gScore[neighbor])
                        continue;// trash path

                    // This path is the best until now. Record it!
                    cameFrom[neighbor] = current;
                    gScore[neighbor] = tentative_gScore;
                    fScore[neighbor] = h(neighbor, goal);
                }
                return; // FAILURE
            }
        }
    }
}
