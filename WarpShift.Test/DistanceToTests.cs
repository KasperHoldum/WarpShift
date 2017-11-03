using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarpShift.Test
{
    [TestClass]
    public class DistanceToTests
    {
        [TestMethod]
        public void BasicTest()
        {
            var m = new StringMap(new StringMapShifter(), (3, 3), (0, 2), (2, 2),
                  Field.RightBottom, Field.BottomLeft, Field.Top,
                  Field.TopBottom, Field.TopBottom, new Field((O.Bottom, C.L)),
                  Field.Top, Field.RightTop, Field.Left);

            var abe2 = m.DistanceToGoal();

            Assert.IsTrue(abe2 <= 10);
        }
    }
}
