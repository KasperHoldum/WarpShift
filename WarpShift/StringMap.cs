using System;
using System.Runtime.CompilerServices;

namespace WarpShift
{
    public class StringMap
    {
        private const int _f = 4;

        public string Serialize()
        {
            return $"{map}{x}{y}{(chipPickedUp ? 0 : 1)}{chip.x}{chip.y}";
        }

        public StringMap(IMapShifter shifter, int size, (int, int) start, (int, int) goal, params Field[] fields):
            this(shifter, (size, size), start, goal, fields){}

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

        private StringMap(IMapShifter shifter, (int, int) size, string map, int x, int y, int gx, int gy) : this(shifter, size, (x,y), (gx, gy))
        {
            this.map = map;
        }

        private string map;

        public int x, y;
        public int gx, gy;
        public (int x, int y) chip;

        private IMapShifter shifter;
        public (int width, int height) size;

        public bool IsSolved => x == gx && y == gy && chipPickedUp;
        private bool chipPickedUp = true;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetIndex(int x, int y) => x * _f + (y * _f * this.size.width);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Field Get(int x, int y)
        {
            var startIndex = GetIndex(x, y);

            return Field.FromString(map.Substring(startIndex, _f));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            return clone;
        }

        public StringMap Clone()
        {
            return new StringMap(this.shifter, this.size, this.map, this.x, this.y, this.gx, this.gy);
        }


        public StringMap Execute(ShiftCommand cmd)
        {
            var clone = this.Clone();
            // move player
            var movePlayer = cmd.Line == x || cmd.Line == y;

            // move map
            shifter.Shift(cmd, clone);

            return clone;
        }
    }
}
