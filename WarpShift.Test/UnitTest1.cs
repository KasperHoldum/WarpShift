using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WarpShift.Test
{
    [TestClass]
    public class Scenario1Test
    {
        [TestMethod]
        public void MapTest()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            //map.Execute(new ShiftCommand() { Horizontal = true });

            Assert.AreEqual(map.map[0][0], Field.Closed);
            Assert.AreEqual(map.map[1][0], Field.Bottom);
        }

        [TestMethod]
        public void HorizontalShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            map.Execute(new ShiftCommand() { Horizontal = true, Positive = true });

            Assert.AreEqual(map.map[0][0], Field.Bottom);
            Assert.AreEqual(map.map[1][0], Field.Closed);
        }
    }
}
