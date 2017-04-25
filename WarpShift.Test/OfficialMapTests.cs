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
        protected void Test(Func<IMapShifter, (StringMap, int limit)> abe)
        {
            var s = abe(new MapShifter());
            NaiveMapSolver nms = new NaiveMapSolver(s.limit);

            var solution = nms.Solve(s.Item1);
            Assert.AreEqual(s.limit, solution.Count);
        }

        [TestClass]
        public class Chapter1 : OfficialMapTests
        {
            [TestMethod]
            public void TestScenario_1_1()
            {
                var s = OfficialMaps.Chapter1.S1(new MapShifter());
                NaiveMapSolver nms = new NaiveMapSolver(s.limit);

                var solution = nms.Solve(s.Item1, 0);
                Assert.AreEqual(s.limit, solution.Count);
            }

            [TestMethod]
            public void TestScenario_1_2()
            {
                var s = OfficialMaps.Chapter1.S2(new MapShifter());
                NaiveMapSolver nms = new NaiveMapSolver(s.limit);

                var solution = nms.Solve(s.Item1, 0);
                Assert.AreEqual(s.limit, solution.Count);
            }

            [TestMethod]
            public void TestScenario_1_3()
            {
                var s = OfficialMaps.Chapter1.S3(new MapShifter());
                NaiveMapSolver nms = new NaiveMapSolver(s.limit);

                var solution = nms.Solve(s.Item1, 0);
                Assert.AreEqual(s.limit, solution.Count);
            }

            [TestMethod]
            public void TestScenario_1_4()
            {
                var s = OfficialMaps.Chapter1.S4(new MapShifter());
                NaiveMapSolver nms = new NaiveMapSolver(s.limit);

                var solution = nms.Solve(s.Item1, 0);
                Assert.AreEqual(s.limit, solution.Count);
            }

            [TestMethod]
            public void TestScenario_1_5()
            {
                var s = OfficialMaps.Chapter1.S5(new MapShifter());
                NaiveMapSolver nms = new NaiveMapSolver(s.limit);

                var solution = nms.Solve(s.Item1, 0);
                Assert.AreEqual(s.limit, solution.Count);
            }

            [TestMethod]
            public void TestScenario_1_6()
            {
                var s = OfficialMaps.Chapter1.S6(new MapShifter());
                NaiveMapSolver nms = new NaiveMapSolver(s.limit);

                var solution = nms.Solve(s.Item1, 0);
                Assert.AreEqual(s.limit, solution.Count);
            }

            [TestMethod]
            public void TestScenario_1_7()
            {
                var s = OfficialMaps.Chapter1.S7(new MapShifter());
                NaiveMapSolver nms = new NaiveMapSolver(s.limit);

                var solution = nms.Solve(s.Item1, 0);
                Assert.AreEqual(s.limit, solution.Count);
            }

            [TestMethod]
            public void TestScenario_1_8()
            {
                var s = OfficialMaps.Chapter1.S8(new MapShifter());
                NaiveMapSolver nms = new NaiveMapSolver(s.limit);

                var solution = nms.Solve(s.Item1, 0);
                Assert.AreEqual(s.limit, solution.Count);
            }

            [TestMethod]
            public void TestScenario_1_9()
            {
                var s = OfficialMaps.Chapter1.S9(new MapShifter());
                NaiveMapSolver nms = new NaiveMapSolver(s.limit);

                var solution = nms.Solve(s.Item1, 0);
                Assert.AreEqual(s.limit, solution.Count);
            }

            [TestMethod]
            public void TestScenario_1_10()
            {
                var s = OfficialMaps.Chapter1.S10(new MapShifter());
                NaiveMapSolver nms = new NaiveMapSolver(s.limit);

                var solution = nms.Solve(s.Item1, 0);
                Assert.AreEqual(s.limit, solution.Count);
            }


            [TestMethod]
            public void TestScenario_1_11()
            {
                var s = OfficialMaps.Chapter1.S11(new MapShifter());
                NaiveMapSolver nms = new NaiveMapSolver(s.limit);

                var solution = nms.Solve(s.Item1, 0);
                Assert.AreEqual(s.limit, solution.Count);
            }


            [TestMethod]
            public void TestScenario_1_12()
            {
                var s = OfficialMaps.Chapter1.S12(new MapShifter());
                NaiveMapSolver nms = new NaiveMapSolver(s.limit);

                var solution = nms.Solve(s.Item1, 0);
                Assert.AreEqual(s.limit, solution.Count);
            }

            [TestMethod]
            public void TestScenario_1_13()
            {
                var s = OfficialMaps.Chapter1.S13(new MapShifter());
                NaiveMapSolver nms = new NaiveMapSolver(s.limit);

                var solution = nms.Solve(s.Item1, 0);
                Assert.AreEqual(s.limit, solution.Count);
            }

            [TestMethod]
            public void TestScenario_1_14()
            {
                var s = OfficialMaps.Chapter1.S14(new MapShifter());
                NaiveMapSolver nms = new NaiveMapSolver(s.limit);

                var solution = nms.Solve(s.Item1, 0);
                Assert.AreEqual(s.limit, solution.Count);
            }

            [TestMethod]
            public void TestScenario_1_15()
            {
                var s = OfficialMaps.Chapter1.S15(new MapShifter());
                NaiveMapSolver nms = new NaiveMapSolver(s.limit);

                var solution = nms.Solve(s.Item1, 0);
                Assert.AreEqual(s.limit, solution.Count);
            }
        }
        [TestClass]
        public class Chapter2 : OfficialMapTests
        {
            [TestMethod]
            public void S1()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S1;
                this.Test(abe);
            }

            [TestMethod]
            public void S2()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S2;
                this.Test(abe);
            }

            [TestMethod]
            public void S3()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S3;
                this.Test(abe);
            }

            [TestMethod]
            public void S4()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S4;
                this.Test(abe);
            }
            [TestMethod]
            public void S5()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S5;
                this.Test(abe);
            }

            [TestMethod]
            public void S6()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S6;
                this.Test(abe);
            }

            [TestMethod]
            public void S7()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S7;
                this.Test(abe);
            }

            [TestMethod]
            public void S8()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S8;
                this.Test(abe);
            }
            [TestMethod]
            public void S9()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S9;
                this.Test(abe);
            }
        }
    }
    
}
