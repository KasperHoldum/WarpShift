using System;

namespace WarpShift
{
    public class ShiftCommand
    {
        public int Line;
        public bool Horizontal;

        /// <summary>
        /// Positive = Right | Down
        /// </summary>
        public bool Positive;

        public override string ToString()
        {
            if (Horizontal && Positive)
                return $"→{Line}";
            if (Horizontal && !Positive)
                return $"←{Line}";
            if (!Horizontal && Positive)
                return $"↓{Line}";
            if (!Horizontal && !Positive)
                return $"↑{Line}";
            throw new InvalidOperationException("ABE");
        }
    }
}
