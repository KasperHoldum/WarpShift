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
            Assert.AreEqual(s.limit + 1, solution.Count);
        }

        [TestMethod]
        public void TestScenario_1_2()
        {
            var s = OfficialMaps.Scenario_1_2_2x2(new ArrayCopyShifter());
            NaiveMapSolver nms = new NaiveMapSolver(s.limit);

            var solution = nms.Solve(s.Item1, 0);
            Assert.AreEqual(s.limit +1, solution.Count);
        }
    }
}
