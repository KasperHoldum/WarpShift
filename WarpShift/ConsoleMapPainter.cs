using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarpShift
{
    public class ConsoleMapPainter
    {
        public static void Paint(StringMap map)
        {
            for (int j = 0; j < map.size.height; j++)
            {
                var topStr = "";
                var middleStr = "";
                var bottomString = "";
                foreach (var o in new[] { O.Top, O.Left })
                {
                    for (int i = 0; i < map.size.width; i++)
                    {
                        var f = map.Get((i, j));
                        var top = GetFieldString(f, o);
                        //var mid = GetFieldString(f, O.Left);
                        //var bot = GetFieldString(f, O.Bottom);

                        //topStr += top;
                        //middleStr += mid;
                        //bottomString += bot;


                    }
                    Console.WriteLine();
                }
                Console.WriteLine(topStr);
                Console.WriteLine(middleStr);
                Console.WriteLine(bottomString);
            }

        }

        private static object GetFieldString(Field f, O o)
        {
            var c = Console.ForegroundColor;

            var fieldC = f.GetColor(o);
            Console.ForegroundColor = fieldC == C.N ? ConsoleColor.White : (fieldC == C.L ? ConsoleColor.Red : ConsoleColor.Green);

            var isOpen = f.IsOpen(o);
            switch (o)
            {
                case O.Top:
                    if (isOpen)
                        Console.Write(" _ ");
                    else
                        Console.Write("   ");
                    return " _ ";
                case O.Left:
                    return "|_|";
            }
            Console.ForegroundColor = c;

            return "ERROR";
        }
    }
}
