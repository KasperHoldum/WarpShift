namespace WarpShift
{
    public static class OfficialMaps
    {
        public static (StringMap, int limit) Scenario_1_1_2x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, 2, (0, 1), (1, 0),
            Field.Closed,Field.Left,
            Field.Right,Field.Closed);

            return (m,2);
        }

        public static (StringMap, int limit) Scenario_1_2_2x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, 2, (0, 1), (1, 0),
            Field.Closed,Field.Right,
            Field.Left, Field.Closed);

            return (m, 3);
        }

        public static (StringMap, int limit) Scenario_1_3_2x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, 2, (1, 0), (0, 1),
             Field.Closed,Field.Top,
             Field.Bottom,Field.Closed);

            return (m, 3);
        }

        public static (StringMap, int limit) Scenario_1_4_2x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, 2, (0, 1), (1, 1),
                Field.RightBottom, Field.Left,
                Field.TopLeft, Field.RightTop);

            return (m, 2);
        }

        public static (StringMap, int limit) Scenario_1_5_2x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, 2, (0, 0), (1, 1),
                Field.Bottom, Field.Closed,
                Field.Top, Field.Bottom);

            return (m, 4);
        }

        public static (StringMap, int limit) Scenario_1_6_2x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, 2, (1, 0), (1, 1),
                Field.Right, Field.Left,
                Field.RightTop, Field.Right);

            return (m, 3);
        }

        public static (StringMap, int limit) Scenario_1_7_3x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, (3,2), (0, 1), (2, 1),
                Field.Closed, Field.Bottom, Field.Closed,
                Field.Top, Field.Closed, Field.Top);

            return (m, 4);
        }

        public static (StringMap, int limit) Scenario_1_8_3x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, (3, 2), (0, 0), (1, 0),
                Field.Right, Field.Bottom, Field.Closed,
                Field.Closed, Field.Closed, Field.TopLeft);

            return (m, 4);
        }

        public static (StringMap, int limit) Scenario_1_9_3x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, (3, 2), (0, 0), (1, 1),
                Field.RightTop, Field.RightLeft, Field.BottomLeft,
                Field.Closed, Field.RightBottom, Field.TopLeft);

            return (m, 3);
        }

        public static (StringMap, int limit) Scenario_1_10_3x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, (3, 2), (0, 0), (1, 1),
                Field.Right, Field.Closed, Field.BottomLeft,
                Field.RightLeft, Field.Top, Field.RightLeft);

            return (m, 5);
        }
    }
}
