namespace WarpShift
{

    public static class MapTestScenarios
    {
        public static StringMap Scenario1_2x2(IArrayShifter shifter)
        {
            var m = new StringMap(shifter, 2, (0, 1), (1, 0));
            m.Set(0, 0, Field.Closed);
            m.Set(1, 0, Field.Bottom);
            m.Set(0, 1, Field.Right);
            m.Set(1, 1, Field.TopLeft);

            return m;
        }
    }
}
