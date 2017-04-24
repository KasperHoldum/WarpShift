using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarpShift.Test
{
    [TestClass]
    public class OfficialMapTests
    {
        [TestMethod]
        public void TestScenario_1_1()
        {
            var s = OfficialMaps.Scenario_1_1_2x2(new ArrayCopyShifter());
            NaiveMapSolver nms = new NaiveMapSolver(s.limit);

            var solution = nms.Solve(s.Item1, 0);
            Assert.AreEqual(s.limit, solution.Count);
        }

        [TestMethod]
        public void TestScenario_1_2()
        {
            var s = OfficialMaps.Scenario_1_2_2x2(new ArrayCopyShifter());
            NaiveMapSolver nms = new NaiveMapSolver(s.limit);

            var solution = nms.Solve(s.Item1, 0);
            Assert.AreEqual(s.limit, solution.Count);
        }

        [TestMethod]
        public void TestScenario_1_3()
        {
            var s = OfficialMaps.Scenario_1_3_2x2(new ArrayCopyShifter());
            NaiveMapSolver nms = new NaiveMapSolver(s.limit);

            var solution = nms.Solve(s.Item1, 0);
            Assert.AreEqual(s.limit, solution.Count);
        }

        [TestMethod]
        public void TestScenario_1_4()
        {
            var s = OfficialMaps.Scenario_1_4_2x2(new ArrayCopyShifter());
            NaiveMapSolver nms = new NaiveMapSolver(s.limit);

            var solution = nms.Solve(s.Item1, 0);
            Assert.AreEqual(s.limit, solution.Count);
        }

        [TestMethod]
        public void TestScenario_1_5()
        {
            var s = OfficialMaps.Scenario_1_5_2x2(new ArrayCopyShifter());
            NaiveMapSolver nms = new NaiveMapSolver(s.limit);

            var solution = nms.Solve(s.Item1, 0);
            Assert.AreEqual(s.limit, solution.Count);
        }

        [TestMethod]
        public void TestScenario_1_6()
        {
            var s = OfficialMaps.Scenario_1_6_2x2(new ArrayCopyShifter());
            NaiveMapSolver nms = new NaiveMapSolver(s.limit);

            var solution = nms.Solve(s.Item1, 0);
            Assert.AreEqual(s.limit, solution.Count);
        }

        [TestMethod]
        public void TestScenario_1_7()
        {
            var s = OfficialMaps.Scenario_1_7_3x2(new ArrayCopyShifter());
            NaiveMapSolver nms = new NaiveMapSolver(s.limit);

            var solution = nms.Solve(s.Item1, 0);
            Assert.AreEqual(s.limit, solution.Count);
        }

        [TestMethod]
        public void TestScenario_1_8()
        {
            var s = OfficialMaps.Scenario_1_8_3x2(new ArrayCopyShifter());
            NaiveMapSolver nms = new NaiveMapSolver(s.limit);

            var solution = nms.Solve(s.Item1, 0);
            Assert.AreEqual(s.limit, solution.Count);
        }

        [TestMethod]
        public void TestScenario_1_9()
        {
            var s = OfficialMaps.Scenario_1_9_3x2(new ArrayCopyShifter());
            NaiveMapSolver nms = new NaiveMapSolver(s.limit);

            var solution = nms.Solve(s.Item1, 0);
            Assert.AreEqual(s.limit, solution.Count);
        }

        [TestMethod]
        public void TestScenario_1_10()
        {
            var s = OfficialMaps.Scenario_1_10_3x2(new ArrayCopyShifter());
            NaiveMapSolver nms = new NaiveMapSolver(s.limit);

            var solution = nms.Solve(s.Item1, 0);
            Assert.AreEqual(s.limit, solution.Count);
        }
    }
}
