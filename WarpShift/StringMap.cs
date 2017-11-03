using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WarpShift
{
    public class StringMap
    {
        private const int _f = 4;

        public string Serialize()
        {
            return $"{map}{x}{y}{(chipPickedUp ? 0 : 1)}{chip.x}{chip.y}{lockLoc.x}{lockLoc.y}{(locked ? 0 : 1)}";
        }

        public StringMap(IMapShifter shifter, int size, (int, int) start, (int, int) goal, params Field[] fields) :
            this(shifter, (size, size), start, goal, fields)
        { }

        public StringMap(IMapShifter shifter, (int width, int height) size, (int, int) start, (int, int) goal, params Field[] fields)
        {
            this.shifter = shifter;
            this.size = size;
            this.map = new string(Field.e[0], size.width * size.height * _f);

            this.x = start.Item1;
            this.y = start.Item2;

            this.gx = goal.Item1;
            this.gy = goal.Item2;

            if (fields != null)
            {
                var counter = 0;
                foreach (var i in fields)
                {
                    this.Set(counter % this.size.width, (int)Math.Floor((counter * 1.0) / this.size.width * 1.0), i);
                    counter++;
                }
            }
        }

        private StringMap(IMapShifter shifter, (int, int) size, string map, int x, int y, int gx, int gy) : this(shifter, size, (x, y), (gx, gy))
        {
            this.map = map;
        }

        private string map;

        public int x, y;
        public int gx, gy;
        public (int x, int y) chip;
        public bool hasChip = false;
        private IMapShifter shifter;
        public (int width, int height) size;

        public void AddChip((int, int) c)
        {
            hasChip = true;
            chipPickedUp = false;
            chip = c;
        }

        public bool IsSolved => x == gx && y == gy && chipPickedUp;
        private bool chipPickedUp = true;
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetIndex(int x, int y) => x * _f + (y * _f * this.size.width);
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]

        private int PlayerDistance((int x, int y) to)
        {
            return Distance((x, y), to, true);
        }

        private int Distance((int x, int y) from, (int x, int y) to, bool isPlayer = false)
        {
            var candidates = new List<int>();

            var dx = Math.Abs(from.x - to.x);
            var dy = Math.Abs(from.y - to.y);

            var cheatX = this.size.width - dx;
            var cheatY = this.size.height - dy;

            var cheatedX = cheatX < dx;
            var cheatedY = cheatY < dy;

            var xDistance = Math.Min(cheatX, dx);
            var yDistance = Math.Min(cheatY, dy);

            if (xDistance == 0)
            {
                var canVert = CanConnectVertical(from, to) || !isPlayer; // if its not player but chip to goal then map coulda changed
                if (cheatedY)
                {
                    // distance + rotation + 
                    candidates.Add(yDistance + 1 + (canVert ? 0 : 1));
                }

                candidates.Add(yDistance + (canVert ? 0 : 2));

                return candidates.Min();
            }

            if (yDistance == 0)
            {
                var canHor = CanConnectHorizontal(from, to) || !isPlayer; // if its not player but chip to goal then map coulda changed
                if (cheatedX)
                    return xDistance + 1 + (canHor ? 0 : 1);

                return xDistance + (canHor ? 0 : 2);
            }

            //if (xDistance == 0 &&)

            return xDistance + yDistance;
        }

        private bool CanConnectHorizontal((int x, int y) from, (int x, int y) to)
        {
            var f = Get(from.x, from.y);
            var t = Get(to.x, to.y);

            var fIsLeft = from.x < to.x;
            // TODO: either try entire path
            //var canRight = Field.IsOpen(f, Open.Right, t, Open.Left);
            //var canLeft = Field.IsOpen(f, Open.Left, t, Open.Right);
            var canRight = f.IsOpen(O.Right) && t.IsOpen(O.Left);
            var canLeft = f.IsOpen(O.Left) && t.IsOpen(O.Right);
            //return fIsLeft ? canRight : canLeft; // not sure this is admissable 
            return canRight || canLeft;
        }

        private bool CanConnectVertical((int x, int y) from, (int x, int y) to)
        {
            var f = Get(from.x, from.y);
            var t = Get(to.x, to.y);

            var fIsAbove = from.y < to.y;
            // TODO: either try entire path
            //var canDown = Field.IsOpen(f, Open.Bottom, t, Open.Top);
            //var canUp = Field.IsOpen(f, Open.Top, t, Open.Bottom);
            var canDown = f.IsOpen(O.Bottom) && t.IsOpen(O.Top);
            var canUp = f.IsOpen(O.Top) && t.IsOpen(O.Bottom);

            //return fIsAbove ? canDown : canUp; // not sure this is admissable 
            return canDown || canUp;
        }

        public int DistanceToGoal()
        {
            var distance = 0;

            if (chipLocked && locked)
            {
                return PlayerDistance(lockLoc) + 2; // +1 for at least one step to goal, 1+ at least one step to unlock
            }
            else // chip is freely available
            {
                if (chipPickedUp)
                {
                    distance = PlayerDistance((gx, gy));
                }
                else
                {
                    distance = PlayerDistance(chip) + Distance(chip, (gx, gy));
                }
            }
            return distance;
        }


        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Field Get(int x, int y)
        {
            var startIndex = GetIndex(x, y);

            return Field.FromString(map.Substring(startIndex, _f));
        }

        public Field Get((int x, int y) loc)
        {
            return Get(loc.x, loc.y);
        }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Set(int x, int y, Field value)
        {
            var index = GetIndex(x, y);
            map = map.Remove(index, _f);
            map = map.Insert(index, value.ToString());
        }
        public StringMap Execute(MoveCommand cmd)
        {
            var clone = this.Clone();
            // ignore check for performance
            //if (cmd.toX - x + cmd.toY - y == 1)
            clone.x = cmd.toX;
            clone.y = cmd.toY;

            if (cmd.toX == clone.chip.x && cmd.toY == clone.chip.y)
                clone.chipPickedUp = true;

            if (cmd.toX == lockLoc.x && cmd.toY == lockLoc.y)
                clone.locked = false;

            return clone;
        }

        public StringMap Clone()
        {
            var clone = new StringMap(this.shifter, this.size, this.map, this.x, this.y, this.gx, this.gy);

            clone.chip = this.chip;
            clone.chipPickedUp = this.chipPickedUp;
            clone.hasChip = this.hasChip;
            clone.hasLocks = this.hasLocks;
            clone.locked = this.locked;
            clone.lockLoc = this.lockLoc;
            return clone;
        }


        public StringMap Execute(ShiftCommand cmd)
        {
            StringMap clone;
            using (Timer.T("Clone"))
            {
                clone = this.Clone();
            }
            // move player
            var movePlayer = cmd.Line == x || cmd.Line == y;

            using (Timer.T("Shifter.Shift"))
            {
                // move map
                shifter.Shift(cmd, clone);
            }
            return clone;
        }

        public bool hasLocks = false;
        public (int x, int y) lockLoc;
        public bool locked = true;

        internal void AddLockHandle((int, int) p)
        {
            this.hasLocks = true;
            lockLoc = p;
            locked = true;
        }

        private bool chipLocked = false;
        internal void FinalizeMap()
        {
            if (hasChip && hasLocks)
            {
                var f = Get(chip);
                chipLocked = f.IsBehindLock();
            }
        }
    }
}
