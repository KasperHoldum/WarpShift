using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarpShift
{
    public class Timer
    {
        public class DisposeObject : IDisposable
        {
            private Action action;

            public DisposeObject(Action action)
            {
                this.action = action;
            }

            public void Dispose()
            {
                action();
            }
        }
        public static Dictionary<string, (double ms, int count)> stats = new Dictionary<string, (double, int)>();
        public static DisposeObject T(string name)
        {
            var before = DateTime.UtcNow;

            return new DisposeObject(() =>
            {
                var ts = DateTime.UtcNow - before;
                var ms = ts.TotalMilliseconds;

                if (stats.ContainsKey(name))
                {
                    stats[name] = (stats[name].ms + ms, stats[name].count + 1);
                }
                else
                {
                    stats[name] = (ms, 1);
                }
            });
        }

        public static void Print()
        {
            foreach (var item in stats)
            {
                Console.WriteLine($"{item.Key}, {Math.Round(item.Value.ms,0)}ms in {item.Value.count}");
            }
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
        public int solved = 0;
        public List<(StringMap, string)> Solve(StringMap map, int counter = 0)
        {
            using (Timer.T("IsSolved"))
            {
                if (map.IsSolved)
                {
                    //return new List<(StringMap, string)>() { };
                    solved++;
                    return null;
                }
            }

            int movesLeft = limit - counter;

            var dg = map.DistanceToGoal();
            if (dg > movesLeft)
                return null;

            if (limit <= counter)
                return null;

            using (Timer.T("Map.Serialize"))
            {
                var serialized = map.Serialize();

                if (seenMaps.ContainsKey(serialized))
                    if (seenMaps[serialized] < counter)
                        return null;
                    else
                        seenMaps[serialized] = counter;
                else
                    seenMaps[serialized] = counter;
            }
            using (Timer.T($"Move{counter}"))
            {
                foreach (var cmd in GetAvailableMoveCommands(map))
                {
                    using (Timer.T("MoveExecute"))
                    {
                        var m = map.Execute(cmd);
                        var m2 = Solve(m, counter + 1);

                        if (m2 != null)
                        {
                            m2.Insert(0, (m, cmd.ToString()));
                            return m2;
                        }
                    }

                }
            }

            using (Timer.T($"Shift{counter}"))
            {
                foreach (var cmd in GetAvailableShiftCommands(map))
                {
                    StringMap m;
                    using (Timer.T("ShiftExecute"))
                    {
                        m = map.Execute(cmd);
                    }
                    var m2 = Solve(m, counter + 1);

                    if (m2 != null)
                    {
                        m2.Insert(0, (m, cmd.ToString()));
                        return m2;
                    }

                }
            }

            // No solution :(
            return null;
        }

        public IEnumerable<MoveCommand> GetAvailableMoveCommands(StringMap m)
        {
            // player position
            var pp = m.Get(m.x, m.y);


            if (m.y > 0)
            {
                var up = m.Get(m.x, m.y - 1);
                if (Field.IsOpen(pp, O.Top, up, O.Bottom,m.locked))
                {
                    yield return new MoveCommand(m.x, m.y) { toX = m.x, toY = m.y - 1 };
                }
            }
            if (m.y < m.size.height - 1)
            {
                if (Field.IsOpen(pp, O.Bottom, m.Get(m.x, m.y + 1), O.Top, m.locked))
                {
                    yield return new MoveCommand(m.x, m.y) { toX = m.x, toY = m.y + 1 };
                }
            }

            if (m.x > 0)
            {
                if (Field.IsOpen(pp, O.Left, m.Get(m.x - 1, m.y), O.Right, m.locked))
                {
                    yield return new MoveCommand(m.x, m.y) { toX = m.x - 1, toY = m.y };
                }
            }

            if (m.x < m.size.width - 1)
            {
                if (Field.IsOpen(pp, O.Right, m.Get(m.x + 1, m.y), O.Left, m.locked))
                {
                    yield return new MoveCommand(m.x, m.y) { toX = m.x + 1, toY = m.y };
                }
            }
        }

        public IEnumerable<ShiftCommand> GetAvailableShiftCommands(StringMap m)
        {
            for (int i = 0; i < m.size.height; i++)
            {
                yield return new ShiftCommand() { Horizontal = true, Positive = true, Line = i };
                yield return new ShiftCommand() { Horizontal = true, Positive = false, Line = i };
            }
            for (int i = 0; i < m.size.width; i++)
            {
                yield return new ShiftCommand() { Horizontal = false, Positive = true, Line = i };
                yield return new ShiftCommand() { Horizontal = false, Positive = false, Line = i };
            }
        }
    }

    public class AStar
    {
        private Func<(int, int), (int, int), int> h;

        public AStar(Func<(int, int), (int, int), int> heuristic)
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
            var closed = new HashSet<(int, int)>() { };
            var open = new HashSet<(int, int)>() { start };
            var cameFrom = new Dictionary<(int, int), (int, int)>();

            var gScore = new Dictionary<(int, int), int>() { { start, 0 } };
            var fScore = new Dictionary<(int, int), int>();

            fScore[start] = h(start, goal);

            (int x, int y) getNextOpen()
            {
                // find lowest fscore
                return default((int, int));
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

                foreach (var neighbor in getNeighbors(current))
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
