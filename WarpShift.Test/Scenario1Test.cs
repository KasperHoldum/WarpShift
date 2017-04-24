using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WarpShift.Test
{
    [TestClass]
    public class MapTests
    {
        [TestMethod]
        public void MapTest()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            //map.Execute(new ShiftCommand() { Horizontal = true });

            Assert.AreEqual(map.map[0][0], Field.Closed);
            Assert.AreEqual(map.map[1][0], Field.Bottom);
        }
    }

    [TestClass]
    public class PlayerPositionShiftTests
    {
        [TestMethod]
        public void PlayerHorizontalPositiveShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            map.Execute(new ShiftCommand() { Horizontal = true, Positive = true, Line = 1 });

            Assert.AreEqual(1, map.x);
            Assert.AreEqual(1, map.y);

        }
        [TestMethod]
        public void PlayerHorizontalNegativeShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            map.Execute(new ShiftCommand() { Horizontal = true, Positive = false, Line = 1 });

            Assert.AreEqual(1, map.x);
            Assert.AreEqual(1, map.y);

        }
        [TestMethod]
        public void PlayerVerticalPositiveShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            map.Execute(new ShiftCommand() { Horizontal = false, Positive = true, Line = 1 });

            Assert.AreEqual(0, map.x);
            Assert.AreEqual(0, map.y);

        }
        [TestMethod]
        public void PlayerVerticalNegativeShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            map.Execute(new ShiftCommand() { Horizontal = false, Positive = false, Line = 1 });

            Assert.AreEqual(0, map.x);
            Assert.AreEqual(0, map.y);

        }
    }


    [TestClass]
    public class BasicShiftingTests
    {
        [TestMethod]
        public void HorizontalPositiveShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            map.Execute(new ShiftCommand() { Horizontal = true, Positive = true, Line = 0 });

            Assert.AreEqual(map.map[0][0], Field.Bottom);
            Assert.AreEqual(map.map[1][0], Field.Closed);
        }

        [TestMethod]
        public void HorizontalNegativeShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            map.Execute(new ShiftCommand() { Horizontal = true, Positive = false, Line = 0 });

            Assert.AreEqual(map.map[0][0], Field.Bottom);
            Assert.AreEqual(map.map[1][0], Field.Closed);
        }

        [TestMethod]
        public void VerticalPositiveShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            map.Execute(new ShiftCommand() { Horizontal = false, Positive = true, Line = 0 });

            Assert.AreEqual(map.map[0][0], Field.Right);
            Assert.AreEqual(map.map[0][1], Field.Closed);
        }

        [TestMethod]
        public void VerticalNegativeShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            map.Execute(new ShiftCommand() { Horizontal = false, Positive = false, Line = 0 });

            Assert.AreEqual(map.map[0][0], Field.Right);
            Assert.AreEqual(map.map[0][1], Field.Closed);
        }

        [TestMethod]
        public void HorizontalPositiveLineShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            map.Execute(new ShiftCommand() { Horizontal = true, Positive = true, Line = 1 });

            Assert.AreEqual(map.map[0][1], Field.TopLeft);
            Assert.AreEqual(map.map[1][1], Field.Right);
        }

        [TestMethod]
        public void HorizontalNegativeLineShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            map.Execute(new ShiftCommand() { Horizontal = true, Positive = false, Line = 1 });

            Assert.AreEqual(map.map[0][1], Field.TopLeft);
            Assert.AreEqual(map.map[1][1], Field.Right);
        }

        [TestMethod]
        public void VerticalPositiveLineShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            map.Execute(new ShiftCommand() { Horizontal = false, Positive = true, Line = 1 });

            Assert.AreEqual(map.map[1][0], Field.TopLeft);
            Assert.AreEqual(map.map[1][1], Field.Bottom);
        }

        [TestMethod]
        public void VerticalNegativeLineShift()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            map.Execute(new ShiftCommand() { Horizontal = false, Positive = false, Line = 1 });

            Assert.AreEqual(map.map[1][0], Field.TopLeft);
            Assert.AreEqual(map.map[1][1], Field.Bottom);
        }
    }
}
