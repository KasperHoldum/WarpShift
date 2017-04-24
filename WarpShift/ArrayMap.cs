using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarpShift
{
    //public class ArrayMap
    //{
    //    private Field[][] map;
    //    public int startX, startY;
    //    public int x, y;
    //    public int gx, gy;

    //    public readonly int length;
    //    private IArrayShifter shifter;

    //    public Field Get(int x, int y)
    //    {
    //        var startIndex = x * 4 
    //                        + y * 4 * this.length;
    //        throw new NotImplementedException();
    //    }
    //    public void Set(int x, int y, Field value)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public ArrayMap(IArrayShifter shifter, int length)
    //    {
    //        this.shifter = shifter;

    //        map = ArrayHelper.InitializeArray(length);
    //        this.length = length;
    //    }


    //    public void Execute(MoveCommand cmd)
    //    {
    //        // ignore check for performance
    //        //if (cmd.toX - x + cmd.toY - y == 1)
    //        {
    //            x = cmd.toX;
    //            y = cmd.toY;
    //        }
    //    }

    //    public void Execute(ShiftCommand cmd)
    //    {
    //        // move player
    //        var movePlayer = cmd.Line == x || cmd.Line == y;

    //        // move map
    //        shifter.Shift(cmd, this);
    //    }
    //}
}
