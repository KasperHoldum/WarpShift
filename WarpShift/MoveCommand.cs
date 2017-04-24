using System;

namespace WarpShift
{
    public class MoveCommand
    {

        public MoveCommand(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int toX;
        public int toY;
        private int y;
        private int x;

        public override string ToString()
        {
            if (toX> x)
                return $"→";
            if (toX < x)
                return $"←";
            if (toY > y)
                return $"↓";
            if (toY < y)
                return $"↑";
            throw new InvalidOperationException("ABE");
        }
    }
}
