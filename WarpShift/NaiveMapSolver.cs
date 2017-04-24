using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarpShift
{
    public class FieldSerializer
    {
        public string Serialize(Field f)
        {
            return f.IsOpen(Open.Top) ? "x" : " " +
                (f.IsOpen(Open.Right) ? "x" : " ") +
                (f.IsOpen(Open.Bottom) ? "x" : " ") +
                (f.IsOpen(Open.Left) ? "x" : " ");
        }
    }

    public class NaiveMapSolver
    {
        public NaiveMapSolver(int counterLimit)
        {
            this.limit = counterLimit;
        }

        private Dictionary<string, int> seenMaps = new Dictionary<string, int>();
        private int limit;

        public StringMap Solve(StringMap map, int counter = 0)
        {
            if (limit < counter)
                return null;

            var serialized = map.Serialize();

            if (seenMaps.ContainsKey(serialized))
                if (seenMaps[serialized] < counter)
                    return null;
                else
                    seenMaps[serialized] = counter;
            else
                seenMaps[serialized] = counter;
            var currentMap = map;
            while (currentMap.x != map.gx || currentMap.y != map.gy)
            {
                foreach(var cmd in GetAvailableMoveCommands(currentMap))
                {
                    var m = map.Execute(cmd);
                    var m2 = Solve(m, counter + 1);

                    if (m2 == null)
                        // no solution
                        continue;
                    else
                        return m2;

                }

                foreach (var cmd in GetAvailableShiftCommands(currentMap))
                {
                    var m = map.Execute(cmd);
                    Solve(m);

                    var m2 = Solve(m);

                    if (m2 == null)
                        // no solution
                        continue;
                    else
                        return m2;
                }
            }
            
            return map;
        }

        public IEnumerable<MoveCommand> GetAvailableMoveCommands(StringMap m)
        {
            var pos = m.Get(m.x,m.y);

            if (m.y > 0 && pos.IsOpen(Open.Top) && m.Get(m.x,m.y - 1).IsOpen(Open.Bottom))
                yield return new MoveCommand() { toX = m.x, toY = m.y - 1 };

            if (m.y < m.length - 1 && pos.IsOpen(Open.Bottom) && m.Get(m.x,m.y + 1).IsOpen(Open.Top))
                yield return new MoveCommand() { toX = m.x, toY = m.y + 1 };

            if (m.x > 0 && pos.IsOpen(Open.Left) && m.Get(m.x - 1,m.y).IsOpen(Open.Right))
                yield return new MoveCommand() { toX = m.x - 1, toY = m.y };

            if (m.x < m.length - 1 && pos.IsOpen(Open.Right) && m.Get(m.x + 1,m.y).IsOpen(Open.Left))
                yield return new MoveCommand() { toX = m.x + 1, toY = m.y };
        }

        public IEnumerable<ShiftCommand> GetAvailableShiftCommands(StringMap m)
        {
            for (int i = 0; i < m.length; i++)
            {
                yield return new ShiftCommand() { Horizontal = true, Positive = true, Line = i };
                yield return new ShiftCommand() { Horizontal = true, Positive = false, Line = i };
                yield return new ShiftCommand() { Horizontal = false, Positive = true, Line = i };
                yield return new ShiftCommand() { Horizontal = false, Positive = false, Line = i };
            }
        }
    }

    public class AStar
    {
        private Func<(int, int), (int, int), int> h;

        public AStar(Func<(int,int), (int,int),int> heuristic)
        {
            this.h = heuristic;
        }

        StringMap m;
        public void Solve(StringMap map)
        {
            this.m = map;

            Work((m.x, m.y), (m.gx, m.gy));
        }

        private void Work((int x, int y) start, (int x, int y) goal)
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
