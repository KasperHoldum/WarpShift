namespace WarpShift
{
    public static class OfficialMaps
    {
        public static (StringMap, int limit) Scenario_1_1_2x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, 2)
            {
                x = 0,
                y = 1,
                gx = 1,
                gy = 0
            };

            m.Set(0, 0, Field.Closed);
            m.Set(1, 0, Field.Left);
            m.Set(0, 1, Field.Right);
            m.Set(1, 1, Field.Closed);

            return (m,2);
        }

        public static (StringMap, int limit) Scenario_1_2_2x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, 2)
            {
                x = 0,
                y = 1,
                gx = 1,
                gy = 0
            };

            m.Set(0, 0, Field.Closed);
            m.Set(1, 0, Field.Right);
            m.Set(0, 1, Field.Left);
            m.Set(1, 1, Field.Closed);

            return (m, 3);
        }

    }
}
