using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarpShift.Test
{
    [TestClass]
    public class NaiveMapSolverTests
    {
        //[TestMethod]
        public void BasicSolve()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());
            var solver = new NaiveMapSolver(3);

            var solved = solver.Solve(map);

            Assert.AreEqual(map.x, map.gx);
            Assert.AreEqual(map.y, map.gy);

        }

        [TestMethod]
        public void BasicShiftCommandsAvailableTest()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());
            var solver = new NaiveMapSolver(3);

            var solved = solver.GetAvailableShiftCommands(map);

            Assert.AreEqual(8, solved.Count());
        }

        [TestMethod]
        public void BasicMoveCommandsAvailableTest()
        {
            var map = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());
            var solver = new NaiveMapSolver(3);

            var solved = solver.GetAvailableMoveCommands(map);

            Assert.AreEqual(1, solved.Count());
        }
    }
}
