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
            var s = OfficialMaps.Scenario_1_1_2x2(new ArrayCopyShifter());
            NaiveMapSolver nms = new NaiveMapSolver(2);

            var solution = nms.Solve(s, 0);
        }
    }
}
