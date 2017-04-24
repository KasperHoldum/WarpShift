using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WarpShift.Test
{
    [TestClass]
    public class BasicShiftingTests
    {
        [TestMethod]
        public void HorizontalPositiveShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            var newMap = map.Execute(new ShiftCommand() { Horizontal = true, Positive = true, Line = 0 });

            Assert.AreEqual(newMap.Get(0,0), Field.Bottom);
            Assert.AreEqual(newMap.Get(1,0), Field.Closed);
        }

        [TestMethod]
        public void HorizontalNegativeShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            var newMap = map.Execute(new ShiftCommand() { Horizontal = true, Positive = false, Line = 0 });

            Assert.AreEqual(newMap.Get(0,0), Field.Bottom);
            Assert.AreEqual(newMap.Get(1,0), Field.Closed);
        }

        [TestMethod]
        public void VerticalPositiveShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

           var newMap =  map.Execute(new ShiftCommand() { Horizontal = false, Positive = true, Line = 0 });

            Assert.AreEqual(newMap.Get(0,0), Field.Right);
            Assert.AreEqual(newMap.Get(0,1), Field.Closed);
        }

        [TestMethod]
        public void VerticalNegativeShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            var newMap = map.Execute(new ShiftCommand() { Horizontal = false, Positive = false, Line = 0 });

            Assert.AreEqual(newMap.Get(0,0), Field.Right);
            Assert.AreEqual(newMap.Get(0,1), Field.Closed);
        }

        [TestMethod]
        public void HorizontalPositiveLineShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            var newMap = map.Execute(new ShiftCommand() { Horizontal = true, Positive = true, Line = 1 });

            Assert.AreEqual(newMap.Get(0,1), Field.TopLeft);
            Assert.AreEqual(newMap.Get(1,1), Field.Right);
        }

        [TestMethod]
        public void HorizontalNegativeLineShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            var newMap = map.Execute(new ShiftCommand() { Horizontal = true, Positive = false, Line = 1 });

            Assert.AreEqual(newMap.Get(0,1), Field.TopLeft);
            Assert.AreEqual(newMap.Get(1,1), Field.Right);
        }

        [TestMethod]
        public void VerticalPositiveLineShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            var nm = map.Execute(new ShiftCommand() { Horizontal = false, Positive = true, Line = 1 });

            Assert.AreEqual(nm.Get(1,0), Field.TopLeft);
            Assert.AreEqual(nm.Get(1,1), Field.Bottom);
        }

        [TestMethod]
        public void VerticalNegativeLineShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            var nm = map.Execute(new ShiftCommand() { Horizontal = false, Positive = false, Line = 1 });

            Assert.AreEqual(nm.Get(1,0), Field.TopLeft);
            Assert.AreEqual(nm.Get(1,1), Field.Bottom);
        }
    }
}
