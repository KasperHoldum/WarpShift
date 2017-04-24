using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WarpShift
{
    [Flags]
    public enum Open
    {
        None = 0,
        Top = 1,
        Bottom = 2,
        Right = 4,
        Left = 8
    }
    public struct Field
    {
        public const string e = "-";
        public const string x = "x";
        public Open OpenWalls;



        public bool IsOpen(Open o) => (o & OpenWalls) == o;

        // none
        public static Field Closed = new Field() { OpenWalls = Open.None };

        // single
        public static Field Top = new Field() { OpenWalls = Open.Top };
        public static Field Bottom = new Field() { OpenWalls = Open.Bottom };
        public static Field Left = new Field() { OpenWalls = Open.Left };
        public static Field Right = new Field() { OpenWalls = Open.Right };

        // right
        public static Field RightLeft = new Field() { OpenWalls = Open.Right | Open.Left };
        public static Field RightBottom = new Field() { OpenWalls = Open.Right | Open.Bottom };
        public static Field RightTop = new Field() { OpenWalls = Open.Right | Open.Top };

        public static Field RightLeftBottom = new Field() { OpenWalls = Open.Right | Open.Left | Open.Bottom };
        public static Field RightLeftTop = new Field() { OpenWalls = Open.Right | Open.Left | Open.Top };

        public static Field RightTopBottom = new Field() { OpenWalls = Open.Right | Open.Bottom | Open.Top };

        // top
        public static Field TopBottom = new Field() { OpenWalls = Open.Top | Open.Bottom };
        public static Field TopLeft = new Field() { OpenWalls = Open.Top | Open.Left };
        public static Field TopBottomLeft = new Field() { OpenWalls = Open.Top | Open.Bottom | Open.Left };

        // bottom
        public static Field BottomLeft = new Field() { OpenWalls = Open.Bottom | Open.Left };

        // all
        public static Field All = new Field() { OpenWalls = Open.Right | Open.Bottom | Open.Top | Open.Left };

        private static Dictionary<string, Field> lookup = new Dictionary<string, Field>()
        {
            {$"{e}{e}{e}{e}", Closed},
            {$"{x}{e}{e}{e}", Top},
            {$"{e}{x}{e}{e}", Right},
            {$"{e}{e}{x}{e}", Bottom},
            {$"{e}{e}{e}{x}", Left},
            {$"{e}{x}{e}{x}", RightLeft},
            {$"{e}{x}{x}{e}", RightBottom},
            {$"{x}{x}{e}{e}", RightTop},
            {$"{e}{x}{x}{x}", RightLeftBottom},
            {$"{x}{x}{e}{x}", RightLeftTop},
            {$"{x}{x}{x}{e}", RightTopBottom},
            {$"{x}{e}{x}{e}", TopBottom},
            {$"{x}{e}{e}{x}", TopLeft},
            {$"{x}{e}{x}{x}", TopBottomLeft},
            {$"{e}{e}{x}{x}", BottomLeft},
            {$"{x}{x}{x}{x}", All},
        };

        public override string ToString()
        {
            return
                ((this.OpenWalls & Open.Top) != 0 ? x : e)
                + ((this.OpenWalls & Open.Right) != 0 ? x : e)
                + ((this.OpenWalls & Open.Bottom) != 0 ? x : e)
                + ((this.OpenWalls & Open.Left) != 0 ? x : e);
        }
        public static Field FromString(string s)
        {
            return lookup[s];
        }
    }

    public class StringMap
    {
        private const int _f = 4;

        public string Serialize()
        {
            return $"{map} {x} {y}";
        }

        public StringMap(IArrayShifter shifter, int length)
        {
            this.shifter = shifter;
            this.length = length;
            this.map = new string(Field.e[0], length * length * _f);
        }

        private StringMap(IArrayShifter shifter, int length, string map, int x, int y, int gx, int gy) : this(shifter, length)
        {
            this.map = map;
            this.x = x;
            this.y = y;
            this.gx = gx;
            this.gy = gy;
        }

        private string map;

        public int x, y;
        public int gx, gy;

        public readonly int length;
        private IArrayShifter shifter;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetIndex(int x, int y) => x * _f + y * _f * this.length;

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
            return new StringMap(this.shifter, this.length, this.map, this.x, this.y, this.gx, this.gy);
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




    public interface IArrayShifter
    {
        void Shift(ShiftCommand cmd, StringMap map);
    }

    public class ArrayCopyShifter : IArrayShifter
    {
        public void Shift(ShiftCommand cmd, StringMap m)
        {
            var movePlayerHor = cmd.Horizontal && cmd.Line == m.y;
            var movePlayerVer = !cmd.Horizontal && cmd.Line == m.x;

            var moveGoalHor = cmd.Horizontal && cmd.Line == m.gy;
            var moveGoalVer = !cmd.Horizontal && cmd.Line == m.gx;

            var x = cmd.Horizontal ? cmd.Line : 0;
            var y = !cmd.Horizontal ? cmd.Line : 0;
            var p = cmd.Positive;
            var l = cmd.Line;

            var pm = cmd.Positive ? 1 : -1;

            int mod(int xx, int mm)
            {
                int r = xx % mm;
                return r < 0 ? r + mm : r;
            }

            if (cmd.Horizontal)
            {
                if (movePlayerHor)
                    m.x = mod(m.x + pm, m.length);// (m.x + pm) % (m.length);
                if (moveGoalHor)
                    m.gx = mod(m.gx + pm, m.length);
                if (p)
                {

                    var replaceWith = m.Get(m.length - 1, l);
                    for (int i = 0; i < m.length; i++)
                    {
                        var v = m.Get(i, l);
                        m.Set(i, l, replaceWith);
                        replaceWith = v;
                    }
                }
                else
                {
                    var replaceWith = m.Get(0, l);
                    for (int i = m.length - 1; i >= 0; i--)
                    {
                        var v = m.Get(i, l);
                        m.Set(i, l, replaceWith);
                        replaceWith = v;
                    }
                }
            }
            else
            {
                if (movePlayerVer)
                    m.y = mod(m.y + pm, m.length);
                if (moveGoalVer)
                    m.gy = mod(m.gy + pm, m.length);

                if (p)
                {
                    var replaceWith = m.Get(l, m.length - 1);
                    for (int i = 0; i < m.length; i++)
                    {
                        var v = m.Get(l, i);
                        m.Set(l, i, replaceWith);
                        replaceWith = v;
                    }
                }
                else
                {
                    var replaceWith = m.Get(l, 0);
                    for (int i = m.length - 1; i >= 0; i--)
                    {
                        var v = m.Get(l, i);
                        m.Set(l, i, replaceWith);
                        replaceWith = v;
                    }
                }
            }
        }
    }

    public enum Axis
    {
        X,
        Y
    }

    public enum Move
    {
        MoveCharacter,
        ShiftWorld
    }

    public class MoveCommand
    {
        public int toX;
        public int toY;
    }

    public class ShiftCommand
    {
        public int Line;
        public bool Horizontal;

        /// <summary>
        /// Positive = Right | Down
        /// </summary>
        public bool Positive;

        public override string ToString()
        {
            if (Horizontal && Positive)
                return $"→{Line}";
            if (Horizontal && !Positive)
                return $"←{Line}";
            if (!Horizontal && Positive)
                return $"↓{Line}";
            if (!Horizontal && !Positive)
                return $"↑{Line}";
            throw new InvalidOperationException("ABE");
        }
    }

    public static class ArrayHelper
    {
        public static Field[][] InitializeArray(int mapLength)
        {
            var f = new Field[mapLength][];

            for (int i = 0; i < mapLength; i++)
            {
                f[i] = new Field[mapLength];
            }

            return f;
        }
    }
}
