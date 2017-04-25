namespace WarpShift
{
    public class StringMapShifter : IMapShifter
    {
        public void Shift(ShiftCommand cmd, StringMap m)
        {
            var movePlayerHor = cmd.Horizontal && cmd.Line == m.y;
            var movePlayerVer = !cmd.Horizontal && cmd.Line == m.x;

            var moveGoalHor = cmd.Horizontal && cmd.Line == m.gy;
            var moveGoalVer = !cmd.Horizontal && cmd.Line == m.gx;

            var moveChipHor = cmd.Horizontal && cmd.Line == m.chip.y;
            var moveChipVer = !cmd.Horizontal && cmd.Line == m.chip.x;


            var x = cmd.Horizontal ? cmd.Line : 0;
            var y = !cmd.Horizontal ? cmd.Line : 0;
            var p = cmd.Positive;
            var l = cmd.Line;

            var pm = cmd.Positive ? 1 : -1;

            int mod(int xx, int mm)
            {
                int r = xx % mm;
                return r < 0 ? r + mm : r;
            }

            if (cmd.Horizontal)
            {
                if (movePlayerHor)
                    m.x = mod(m.x + pm, m.size.width);// (m.x + pm) % (m.length);
                if (moveGoalHor)
                    m.gx = mod(m.gx + pm, m.size.width);
                if (moveChipHor)
                    m.chip.x = mod(m.chip.x + pm, m.size.width);
                if (p)
                {

                    var replaceWith = m.Get(m.size.width - 1, l);
                    for (int i = 0; i < m.size.width; i++)
                    {
                        var v = m.Get(i, l);
                        m.Set(i, l, replaceWith);
                        replaceWith = v;
                    }
                }
                else
                {
                    var replaceWith = m.Get(0, l);
                    for (int i = m.size.width - 1; i >= 0; i--)
                    {
                        var v = m.Get(i, l);
                        m.Set(i, l, replaceWith);
                        replaceWith = v;
                    }
                }
            }
            else
            {
                if (movePlayerVer)
                    m.y = mod(m.y + pm, m.size.height);
                if (moveGoalVer)
                    m.gy = mod(m.gy + pm, m.size.height);
                if (moveChipVer)
                    m.chip.y = mod(m.chip.y + pm, m.size.height);

                if (p)
                {
                    var replaceWith = m.Get(l, m.size.height - 1);
                    for (int i = 0; i < m.size.height; i++)
                    {
                        var v = m.Get(l, i);
                        m.Set(l, i, replaceWith);
                        replaceWith = v;
                    }
                }
                else
                {
                    var replaceWith = m.Get(l, 0);
                    for (int i = m.size.height - 1; i >= 0; i--)
                    {
                        var v = m.Get(l, i);
                        m.Set(l, i, replaceWith);
                        replaceWith = v;
                    }
                }
            }
        }
    }
}
