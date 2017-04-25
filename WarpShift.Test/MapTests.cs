using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WarpShift.Test
{
    [TestClass]
    public class MapTests
    {
        [TestMethod]
        public void MapTest()
        {
            var map = MapTestScenarios.Scenario1_2x2(new StringMapShifter());

            //map.Execute(new ShiftCommand() { Horizontal = true });

            Assert.AreEqual(map.Get(0,0), Field.Closed);
            Assert.AreEqual(map.Get(1,0), Field.Bottom);
        }
    }
}
