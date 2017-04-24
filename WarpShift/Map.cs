using System;
using System.Collections.Generic;
using System.Linq;
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
        public Open OpenWalls;

        public bool IsOpen(Open o) => (o & OpenWalls) == o;

        // none
        public static Field Closed = new Field() { OpenWalls = Open.None};

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

        public override string ToString()
        {
            return this.OpenWalls.ToString();
        }

    }

    //public static class MapSerializer
    //{
    //    public static string Serialize(Map m)
    //    {
    //        return $"{m.x} {m.y} {SerializeFields(m.map, m.length)}";
    //    }

    //    private static object SerializeFields(Field[][] map, int length)
    //    {
    //        for (int i = 0; i < length; i++)
    //        {

    //        }
    //    }
    //}


    public class Map
    {
        public Field[][] map;
        public int startX, startY;
        public int x, y;
        public int gx, gy;

        public int length;
        private IArrayShifter shifter;

        public Map(IArrayShifter shifter)
        {
            this.shifter = shifter;
        }


        public void Execute(MoveCommand cmd)
        {
            // ignore check for performance
            //if (cmd.toX - x + cmd.toY - y == 1)
            {
                x = cmd.toX;
                y = cmd.toY;
            }
        }

        public void Execute(ShiftCommand cmd)
        {
            // move player
            var movePlayer = cmd.Line == x || cmd.Line == y;

            // move map
            shifter.Shift(cmd, this);
        }
    }

    public interface IArrayShifter
    {
        void Shift(ShiftCommand cmd, Map map);
    }

    public class ArrayCopyShifter : IArrayShifter
    {
        public void Shift(ShiftCommand cmd, Map m)
        {
            var movePlayerHor = cmd.Horizontal && cmd.Line == m.y;
            var movePlayerVer = !cmd.Horizontal && cmd.Line == m.x;

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
                m.x = mod(m.x + pm, m.length);// (m.x + pm) % (m.length);

                if (p)
                {
                    
                    var replaceWith = m.map[m.length - 1][l];
                    for (int i = 0; i < m.length; i++)
                    {
                        var v = m.map[i][l];
                        m.map[i][l] = replaceWith;
                        replaceWith = v;
                    }
                }
                else
                {
                    var replaceWith = m.map[0][l];
                    for (int i = m.length - 1; i >= 0; i--)
                    {
                        var v = m.map[i][l];
                        m.map[i][l] = replaceWith;
                        replaceWith = v;
                    }
                }
            }
            else
            {
                m.y = mod(m.y + pm, m.length);

                if (p)
                {
                    var replaceWith = m.map[l][m.length - 1];
                    for (int i = 0; i < m.length; i++)
                    {
                        var v = m.map[l][i];
                        m.map[l][i] = replaceWith;
                        replaceWith = v;
                    }
                }
                else
                {
                    var replaceWith = m.map[l][0];
                    for (int i = m.length - 1; i >= 0; i--)
                    {
                        var v = m.map[l][i];
                        m.map[l][i] = replaceWith;
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
    }

    public class MapTracker
    {
        public int curX;
        public int curY;
        public List<object> commands = new List<object>();
        //public (Axis, int)[] ShiftHistory;
        private Map map;

        public MapTracker(Map map)
        {
            this.map = map;
        }

        public void Execute(MoveCommand move)
        {

        }
    }

    public static class MapTestScenarios
    {
        public static Map Scenario1_2x2(IArrayShifter shifter)
        {
            var m = new Map(shifter)
            {
                map = ArrayHelper.InitializeArray(2),
                length = 2,
                startX = 0,
                startY = 1,
                x = 0,
                y = 1,
                gx = 1,
                gy = 0
            };

            m.map[0][0] = Field.Closed;
            m.map[1][0] = Field.Bottom;
            m.map[0][1] = Field.Right;
            m.map[1][1] = Field.TopLeft;

            return m;
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
