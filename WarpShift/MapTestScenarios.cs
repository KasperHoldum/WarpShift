namespace WarpShift
{
    //public class MapTracker
    //{
    //    public int curX;
    //    public int curY;
    //    public List<object> commands = new List<object>();
    //    //public (Axis, int)[] ShiftHistory;
    //    private StringMap map;

    //    public MapTracker(StringMap map)
    //    {
    //        this.map = map;
    //    }

    //    public void Execute(MoveCommand move)
    //    {

    //    }
    //}

    public static class OfficialMaps
    {
        public static StringMap Scenario_1_1_2x2(IArrayShifter shifter)
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

            return m;
        }

    }

    public static class MapTestScenarios
    {
        public static StringMap Scenario1_2x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, 2)
            {
                x = 0,
                y = 1,
                gx = 1,
                gy = 0
            };

            m.Set(0, 0, Field.Closed);
            m.Set(1, 0, Field.Bottom);
            m.Set(0, 1, Field.Right);
            m.Set(1, 1, Field.TopLeft);

            return m;
        }
    }
}
