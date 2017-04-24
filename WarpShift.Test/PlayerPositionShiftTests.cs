using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WarpShift.Test
{

    [TestClass]
    public class PlayerPositionShiftTests
    {
        [TestMethod]
        public void PlayerHorizontalPositiveShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            var nm = map.Execute(new ShiftCommand() { Horizontal = true, Positive = true, Line = 1 });

            Assert.AreEqual(1, nm.x);
            Assert.AreEqual(1, nm.y);

        }
        [TestMethod]
        public void PlayerHorizontalNegativeShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            var nm = map.Execute(new ShiftCommand() { Horizontal = true, Positive = false, Line = 1 });

            Assert.AreEqual(1, nm.x);
            Assert.AreEqual(1, nm.y);

        }
        [TestMethod]
        public void PlayerVerticalPositiveShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            var nm = map.Execute(new ShiftCommand() { Horizontal = false, Positive = true, Line = 1 });

            Assert.AreEqual(0, nm.x);
            Assert.AreEqual(0, nm.y);

        }
        [TestMethod]
        public void PlayerVerticalNegativeShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            var nm = map.Execute(new ShiftCommand() { Horizontal = false, Positive = false, Line = 1 });

            Assert.AreEqual(0, nm.x);
            Assert.AreEqual(0, nm.y);

        }
    }
}
