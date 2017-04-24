using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarpShift.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //var scenario = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());
            var s = OfficialMaps.Chapter1.S2(new MapShifter());
            NaiveMapSolver nms = new NaiveMapSolver(s.limit);

            var solution = nms.Solve(s.Item1, 0);
        }
    }
}
