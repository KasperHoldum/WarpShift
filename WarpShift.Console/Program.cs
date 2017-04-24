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
            var scenario = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());

            NaiveMapSolver nms = new NaiveMapSolver(2);

            var map = nms.Solve(scenario, 0);

            string s = new string('a', 4 * 4 * 4 + 2);
            var a = new int[4 * 4];

            var before = DateTime.UtcNow;
            Random r = new Random();
            for (int i = 0; i < 10000000; i++)
            {
                var next = r.Next(0, s.Length);
                var rr = s[next];
            }
            var ts = DateTime.UtcNow - before;


            before = DateTime.UtcNow;
            r = new Random();
            for (int i = 0; i < 10000000; i++)
            {
                var next = r.Next(0, a.Length);
                var rr = a[next];
            }
            var ts2 = DateTime.UtcNow - before;


        }
    }
}
