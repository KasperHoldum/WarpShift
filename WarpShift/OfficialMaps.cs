namespace WarpShift
{
    public static class OfficialMaps
    {
        public class Chapter1 { 
        public static (StringMap, int limit) S1_2x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, 2, (0, 1), (1, 0),
            Field.Closed,Field.Left,
            Field.Right,Field.Closed);

            return (m,2);
        }

        public static (StringMap, int limit) S2_2x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, 2, (0, 1), (1, 0),
            Field.Closed,Field.Right,
            Field.Left, Field.Closed);

            return (m, 3);
        }

        public static (StringMap, int limit) S3_2x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, 2, (1, 0), (0, 1),
             Field.Closed,Field.Top,
             Field.Bottom,Field.Closed);

            return (m, 3);
        }

        public static (StringMap, int limit) S4_2x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, 2, (0, 1), (1, 1),
                Field.RightBottom, Field.Left,
                Field.TopLeft, Field.RightTop);

            return (m, 2);
        }

        public static (StringMap, int limit) S5_2x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, 2, (0, 0), (1, 1),
                Field.Bottom, Field.Closed,
                Field.Top, Field.Bottom);

            return (m, 4);
        }

        public static (StringMap, int limit) S6_2x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, 2, (1, 0), (1, 1),
                Field.Right, Field.Left,
                Field.RightTop, Field.Right);

            return (m, 3);
        }

        public static (StringMap, int limit) S7_3x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, (3,2), (0, 1), (2, 1),
                Field.Closed, Field.Bottom, Field.Closed,
                Field.Top, Field.Closed, Field.Top);

            return (m, 4);
        }

        public static (StringMap, int limit) S8_3x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, (3, 2), (0, 0), (1, 0),
                Field.Right, Field.Bottom, Field.Closed,
                Field.Closed, Field.Closed, Field.TopLeft);

            return (m, 4);
        }

        public static (StringMap, int limit) S9_3x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, (3, 2), (0, 0), (1, 1),
                Field.RightTop, Field.RightLeft, Field.BottomLeft,
                Field.Closed, Field.RightBottom, Field.TopLeft);

            return (m, 3);
        }

        public static (StringMap, int limit) S10_3x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, (3, 2), (0, 0), (1, 1),
                Field.Right, Field.Closed, Field.BottomLeft,
                Field.RightLeft, Field.Top, Field.RightLeft);

            return (m, 5);
        }

        public static (StringMap, int limit) S11_3x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, (3, 2), (2, 0), (0, 0),
                Field.Bottom, Field.TopLeft, Field.Bottom,
                Field.Top, Field.Top, Field.Bottom);

            return (m, 4);
        }

        public static (StringMap, int limit) S12_3x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, (3, 2), (2, 0), (0, 1),
                Field.Closed, Field.Right, Field.Left,
                Field.Top, Field.RightBottom, Field.Top);

            return (m, 4);
        }

        public static (StringMap, int limit) S13_3x3(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, (3, 3), (2, 0), (0, 2),
                Field.Closed, Field.TopBottomLeft, Field.Left,
                Field.RightBottom, Field.TopLeft, Field.Closed,
                Field.RightTop, Field.Closed, Field.Closed);

            return (m, 3);
        }


        public static (StringMap, int limit) S14_3x3(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, (3, 3), (0, 1), (1, 1),
                Field.RightBottom, Field.RightLeft, Field.BottomLeft,
                Field.TopBottom, Field.Right, Field.TopBottom,
                Field.RightTop, Field.RightLeft, Field.TopLeft);

            return (m, 4);
        }

        public static (StringMap, int limit) S15_3x3(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, (3, 3), (0, 0), (2, 1),
                Field.Left, Field.Closed, Field.RightBottom,
                Field.TopBottom, Field.Closed, Field.Bottom,
                Field.RightTop, Field.Top, Field.Closed);

            return (m, 5);
        }
        }
        public class Chapter2
        {
            public static (StringMap, int limit) S1_3x3(IArrayShifter shifter)
            {
                var m = new StringMap(shifter, (3, 3), (0, 0), (2, 1),
                    Field.Left, Field.Closed, Field.RightBottom,
                    Field.TopBottom, Field.Closed, Field.Bottom,
                    Field.RightTop, Field.Top, Field.Closed);

                return (m, 5);
            }
        }
    }
}
