using System;

namespace WarpShift
{
    [Flags]
    public enum Open
    {
        None = 0,
        Top = 1,
        Bottom = 2,
        Right = 4,
        Left = 8
    }
}
