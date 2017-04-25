using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WarpShift.Console
{
    class Program
    {
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();

        [DllImport("kernel32.dll")]
        public static extern int GetCurrentProcessorNumber();
        private static ProcessThread CurrentThread
        {
            get
            {
                int id = GetCurrentThreadId();
                return Process.GetCurrentProcess().Threads.Cast<ProcessThread>().Single(x => x.Id == id);
            }
        }

        static void Main(string[] args)
        {
            Thread.BeginThreadAffinity();
            CurrentThread.ProcessorAffinity = new IntPtr(1);

            //var scenario = MapTestScenarios.Scenario1_2x2(new ArrayCopyShifter());
            //var s = OfficialMaps.Chapter2.S11(new StringMapShifter());
            var s = OfficialMaps.Chapter2.S15(new StringMapShifter());
            NaiveMapSolver nms = new NaiveMapSolver(s.limit);

          

            var before= DateTime.UtcNow;
            var solution = nms.Solve(s.Item1);
            var after = DateTime.UtcNow;
            var ts = after - before;
            System.Console.WriteLine($"Solutions found: {nms.solved}, time taken: {Math.Round(ts.TotalMilliseconds,0)}ms");
            Timer.Print();

            System.Console.ReadLine();
        }
    }
}
