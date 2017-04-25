using System;
using System.Linq;
using System.Collections.Generic;

namespace WarpShift
{
    [Flags]
    public enum Color
    {
        N = 1,
        P = 2
    }

    public struct Field
    {
        public Field(Open open)
        {
            OpenWalls = open;
            doorColors = new Dictionary<Open, Color>();
        }
        public Field(params (Open, Color)[] color)
        {
            OpenWalls = Open.None;
            doorColors = new Dictionary<Open, Color>();
            foreach (var c in color)
            {
                doorColors[c.Item1] = c.Item2;
                OpenWalls = OpenWalls | c.Item1;
            }
        }

        public const string e = "-";
        public const string x = "x";
        public static Dictionary<Color, string> colorToString = new Dictionary<Color, string>()
        {
            {WarpShift.Color.P, "p" },
            {WarpShift.Color.N, "x" }
        };
        public Open OpenWalls;

        public Dictionary<Open, Color> doorColors;

        public bool IsOpen(Open o) => (o & OpenWalls) == o;

        // none
        public static Field Closed = new Field() { OpenWalls = Open.None };

        // single
        public static Field PinkTop = new Field((Open.Top, WarpShift.Color.P));
        public static Field PinkBottom = new Field((Open.Bottom, WarpShift.Color.P));
        public static Field PinkLeft = new Field((Open.Left, WarpShift.Color.P));
        public static Field PinkRight = new Field((Open.Right, WarpShift.Color.P));

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

        internal static bool IsOpen(Field f1, Open o1, Field f2, Open o2)
        {

            return f1.IsOpen(o1) && f2.IsOpen(o2)
                && f1.Color(o1) == f2.Color(o2);
        }

        private Color Color(Open direction)
        {
            if (doorColors == null || doorColors.Count == 0 || !doorColors.ContainsKey(direction))
                return WarpShift.Color.N;

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
            return SerializeDoor(Open.Top) + SerializeDoor(Open.Right) + SerializeDoor(Open.Bottom) + SerializeDoor(Open.Left);
        }

        public string SerializeDoor(Open o)
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
            Open value = Open.None;

            var list = new[] { Open.Top, Open.Right, Open.Bottom, Open.Left };
            foreach (var c in s.Zip(list, (s1,s2) => (s1, s2)))
            {
                if (c.Item1 == 'p')
                {
                    value |= c.Item2;
                    if (f.doorColors == null)
                        f.doorColors = new Dictionary<Open, Color>();

                    f.doorColors[c.Item2] = WarpShift.Color.P;
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
