using System;
using System.Linq;
using System.Collections.Generic;

namespace WarpShift
{
    [Flags]
    public enum C
    {
        N = 1,
        P = 2
    }

    public struct Field
    {
        public Field(O open)
        {
            OpenWalls = open;
            doorColors = new Dictionary<O, C>();
        }
        public Field(params (O, C)[] color)
        {
            OpenWalls = O.None;
            doorColors = new Dictionary<O, C>();
            foreach (var c in color)
            {
                doorColors[c.Item1] = c.Item2;
                OpenWalls = OpenWalls | c.Item1;
            }
        }

        public const string e = "-";
        public const string x = "x";
        public static Dictionary<C, string> colorToString = new Dictionary<C, string>()
        {
            {WarpShift.C.P, "p" },
            {WarpShift.C.N, "x" }
        };
        public O OpenWalls;

        public Dictionary<O, C> doorColors;

        public bool IsOpen(O o) => (o & OpenWalls) == o;

        // none
        public static Field Closed = new Field() { OpenWalls = O.None };

        // single
        public static Field PinkTop = new Field((O.Top, WarpShift.C.P));
        public static Field PinkBottom = new Field((O.Bottom, WarpShift.C.P));
        public static Field PinkLeft = new Field((O.Left, WarpShift.C.P));
        public static Field PinkRight = new Field((O.Right, WarpShift.C.P));

        public static Field Top = new Field() { OpenWalls = O.Top };
        public static Field Bottom = new Field() { OpenWalls = O.Bottom };
        public static Field Left = new Field() { OpenWalls = O.Left };
        public static Field Right = new Field() { OpenWalls = O.Right };

        // right
        public static Field RightLeft = new Field() { OpenWalls = O.Right | O.Left };
        public static Field RightBottom = new Field() { OpenWalls = O.Right | O.Bottom };
        public static Field RightTop = new Field() { OpenWalls = O.Right | O.Top };

        public static Field RightLeftBottom = new Field() { OpenWalls = O.Right | O.Left | O.Bottom };
        public static Field RightLeftTop = new Field() { OpenWalls = O.Right | O.Left | O.Top };

        public static Field RightTopBottom = new Field() { OpenWalls = O.Right | O.Bottom | O.Top };

        // top
        public static Field TopBottom = new Field() { OpenWalls = O.Top | O.Bottom };
        public static Field TopLeft = new Field() { OpenWalls = O.Top | O.Left };
        public static Field TopBottomLeft = new Field() { OpenWalls = O.Top | O.Bottom | O.Left };

        // bottom
        public static Field BottomLeft = new Field() { OpenWalls = O.Bottom | O.Left };

        // all
        public static Field All = new Field() { OpenWalls = O.Right | O.Bottom | O.Top | O.Left };

        internal static bool IsOpen(Field f1, O o1, Field f2, O o2)
        {

            return f1.IsOpen(o1) && f2.IsOpen(o2)
                && f1.Color(o1) == f2.Color(o2);
        }

        private C Color(O direction)
        {
            if (doorColors == null || doorColors.Count == 0 || !doorColors.ContainsKey(direction))
                return WarpShift.C.N;

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
            var a = (this.OpenWalls & o) != 0;

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
                if (c.Item1 == 'p')
                {
                    value |= c.Item2;
                    if (f.doorColors == null)
                        f.doorColors = new Dictionary<O, C>();

                    f.doorColors[c.Item2] = WarpShift.C.P;
                }
                else if (c.Item1 == 'x')
                {
                    value |= c.Item2;
                }
            }
            f.OpenWalls = value;
            return f;

            //return lookup[s];
        }
    }
}
