using System;
using System.Linq;
using System.Collections.Generic;

namespace WarpShift
{
    [Flags]
    public enum C
    {
        N = 1,
        P = 2,
        L = 4
    }

    public struct Field
    {
        public Field(O open)
        {
            Value = open;
            doorColors = new Dictionary<O, C>();
        }
        public Field(params (O, C)[] color)
        {
            Value = O.None;
            doorColors = new Dictionary<O, C>();
            foreach (var c in color)
            {
                doorColors[c.Item1] = c.Item2;
                Value = Value | c.Item1;
            }
        }

        public const string e = "-";
        public const string x = "x";
        public static Dictionary<C, string> colorToString = new Dictionary<C, string>()
        {
            {WarpShift.C.P, "p" },
            {WarpShift.C.N, "x" },
            {WarpShift.C.L, "l" }

        };
        public O Value;

        public Dictionary<O, C> doorColors;

        public bool IsOpen(O o) => (o & Value) == o;

        // none
        public static Field Closed = new Field() { Value = O.None };

        // single
        public static Field PinkTop = new Field((O.Top, WarpShift.C.P));
        public static Field PinkBottom = new Field((O.Bottom, WarpShift.C.P));
        public static Field PinkLeft = new Field((O.Left, WarpShift.C.P));

  

        public static Field PinkRight = new Field((O.Right, WarpShift.C.P));

        public static Field Top = new Field() { Value = O.Top };
        public static Field Bottom = new Field() { Value = O.Bottom };
        public static Field Left = new Field() { Value = O.Left };
        public static Field Right = new Field() { Value = O.Right };

        // right
        public static Field RightLeft = new Field() { Value = O.Right | O.Left };
        public static Field RightBottom = new Field() { Value = O.Right | O.Bottom };
        public static Field RightTop = new Field() { Value = O.Right | O.Top };

        public static Field RightLeftBottom = new Field() { Value = O.Right | O.Left | O.Bottom };
        public static Field RightLeftTop = new Field() { Value = O.Right | O.Left | O.Top };

        public static Field RightTopBottom = new Field() { Value = O.Right | O.Bottom | O.Top };

        // top
        public static Field TopBottom = new Field() { Value = O.Top | O.Bottom };
        public static Field TopLeft = new Field() { Value = O.Top | O.Left };
        public static Field TopBottomLeft = new Field() { Value = O.Top | O.Bottom | O.Left };

        // bottom
        public static Field BottomLeft = new Field() { Value = O.Bottom | O.Left };

        // all
        public static Field All = new Field() { Value = O.Right | O.Bottom | O.Top | O.Left };

        internal C GetColor(O o)
        {
            if (this.doorColors == null)
                return C.N;

            if (doorColors.ContainsKey(o))
                return doorColors[o];

            return C.N;
        }

        internal static bool IsOpen(Field f1, O o1, Field f2, O o2, bool locked = true)
        {
            var c1 = f1.Color(o1);
            var c2 = f2.Color(o2);
            var hasLock = c1 == C.L || c2 == C.L;

            var hasDoors = f1.IsOpen(o1) && f2.IsOpen(o2);

            if (hasDoors)
            {
                // if one of the doors has a lock, then true if unlocked
                if (hasLock)
                {
                    return !locked;
                }
                else
                {
                    // if no locks, then color must match
                    return c1 == c2;
                }
            }

            // no doors towards each other == failure
            return false;
        }

        private C Color(O direction)
        {
            if (doorColors == null || doorColors.Count == 0 || !doorColors.ContainsKey(direction))
                return C.N;

            return doorColors[direction];
        }

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
            return SerializeDoor(O.Top) + SerializeDoor(O.Right) + SerializeDoor(O.Bottom) + SerializeDoor(O.Left);
        }

        public string SerializeDoor(O o)
        {
            var a = (this.Value & o) != 0;

            if (!a)
                return e;
            else
            {
                if (doorColors != null && doorColors.ContainsKey(o))
                {
                    return colorToString[doorColors[o]];
                }
                return x;
            }
        }
        public static Field FromString(string s)
        {
            Field f = new Field();
            O value = O.None;

            var list = new[] { O.Top, O.Right, O.Bottom, O.Left };
            foreach (var c in s.Zip(list, (s1,s2) => (s1, s2)))
            {
                if (c.Item1 == 'p' || c.Item1 == 'l')
                {
                    value |= c.Item2;
                    if (f.doorColors == null)
                        f.doorColors = new Dictionary<O, C>();

                    f.doorColors[c.Item2] = c.Item1 == 'p' ? C.P : C.L;
                }
                else if (c.Item1 == 'x')
                {
                    value |= c.Item2;
                }
            }
            f.Value = value;
            return f;
            //return lookup[s];
        }

        internal bool IsBehindLock()
        {
            if (doorColors == null)
                return false;

            return this.doorColors.ContainsValue(C.L) && this.doorColors.Any();
        }
    }
}
