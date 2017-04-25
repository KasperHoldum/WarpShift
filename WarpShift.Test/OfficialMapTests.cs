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
            var s = abe(new StringMapShifter());
            NaiveMapSolver nms = new NaiveMapSolver(s.limit);

            var solution = nms.Solve(s.Item1);
            var solutionCounter = nms.solved;
            //Assert.AreEqual(s.limit, solution.Count);
            Assert.IsTrue(solutionCounter > 0);
        }

        [TestClass]
        public class Chapter1 : OfficialMapTests
        {
            [TestMethod]
            public void S01()
            {
                Func<IMapShifter, (StringMap, int)> s = OfficialMaps.Chapter1.S1;
                this.Test(s);
            }

            [TestMethod]
            public void S02()
            {
                Func<IMapShifter, (StringMap, int)> s = OfficialMaps.Chapter1.S2;
                this.Test(s);
            }

            [TestMethod]
            public void S03()
            {
                Func<IMapShifter, (StringMap, int)> s = OfficialMaps.Chapter1.S3;
                this.Test(s);
            }

            [TestMethod]
            public void S04()
            {
                Func<IMapShifter, (StringMap, int)> s = OfficialMaps.Chapter1.S4;
                this.Test(s);
            }

            [TestMethod]
            public void S05()
            {
                Func<IMapShifter, (StringMap, int)> s = OfficialMaps.Chapter1.S5;
                this.Test(s);
            }

            [TestMethod]
            public void S06()
            {
                Func<IMapShifter, (StringMap, int)> s = OfficialMaps.Chapter1.S6;
                this.Test(s);
            }

            [TestMethod]
            public void S07()
            {
                Func<IMapShifter, (StringMap, int)> s = OfficialMaps.Chapter1.S7;
                this.Test(s);
            }

            [TestMethod]
            public void S08()
            {
                Func<IMapShifter, (StringMap, int)> s = OfficialMaps.Chapter1.S8;
                this.Test(s);
            }

            [TestMethod]
            public void S09()
            {
                Func<IMapShifter, (StringMap, int)> s = OfficialMaps.Chapter1.S9;
                this.Test(s);
            }

            [TestMethod]
            public void S10()
            {
                Func<IMapShifter, (StringMap, int)> s = OfficialMaps.Chapter1.S10;
                this.Test(s);
            }


            [TestMethod]
            public void S11()
            {
                Func<IMapShifter, (StringMap, int)> s = OfficialMaps.Chapter1.S11;
                this.Test(s);
            }


            [TestMethod]
            public void S12()
            {
                Func<IMapShifter, (StringMap, int)> s = OfficialMaps.Chapter1.S12;
                this.Test(s);
            }

            [TestMethod]
            public void S13()
            {
                Func<IMapShifter, (StringMap, int)> s = OfficialMaps.Chapter1.S13;
                this.Test(s);
            }

            [TestMethod]
            public void S14()
            {
                Func<IMapShifter, (StringMap, int)> s = OfficialMaps.Chapter1.S14;
                this.Test(s);
            }

            [TestMethod]
            public void S15()
            {
                Func<IMapShifter, (StringMap, int)> s = OfficialMaps.Chapter1.S15;
                this.Test(s);
            }
        }
        [TestClass]
        public class Chapter2 : OfficialMapTests
        {
            [TestMethod]
            public void S01()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S1;
                this.Test(abe);
            }

            [TestMethod]
            public void S02()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S2;
                this.Test(abe);
            }

            [TestMethod]
            public void S03()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S3;
                this.Test(abe);
            }

            [TestMethod]
            public void S04()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S4;
                this.Test(abe);
            }
            [TestMethod]
            public void S05()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S5;
                this.Test(abe);
            }

            [TestMethod]
            public void S06()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S6;
                this.Test(abe);
            }

            [TestMethod]
            public void S07()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S7;
                this.Test(abe);
            }

            [TestMethod]
            public void S08()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S8;
                this.Test(abe);
            }
            [TestMethod]
            public void S09()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S9;
                this.Test(abe);
            }

            [TestMethod]
            public void S10()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S10;
                this.Test(abe);
            }


            [TestMethod]
            public void S11()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S11;
                this.Test(abe);
            }

            [TestMethod]
            public void S12()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S12;
                this.Test(abe);
            }
            [TestMethod]
            public void S13()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S13;
                this.Test(abe);
            }
            [TestMethod]
            public void S14()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S14;
                this.Test(abe);
            }

            [TestMethod]
            public void S15()
            {
                Func<IMapShifter, (StringMap, int)> abe = OfficialMaps.Chapter2.S15;
                this.Test(abe);
            }
        }
    }
    
}
